using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Student_Grading_System
{
    public partial class Add: Form
    {
        private string connectionString;
        private int studentID; // Nullable int to allow for no ID being passed

        public Add(string connString)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            connectionString = connString;         
        }




      
      

        internal void SetEditData(string studentID, string name, string email, string score)
        {
            this.studentID = int.Parse(studentID);
            txt_name.Text = name;
            txt_email.Text = email;
            txt_score.Text = score;
           
        }

        private void btn_submit_Click_1(object sender, EventArgs e)
        {
            string name = txt_name.Text.Trim();
            string email = txt_email.Text.Trim();
            string score = txt_score.Text.Trim();
            string courseID = txt_courseid.Text.Trim();
            string usernameadd = txt_usernameadd.Text.Trim();
            string passwordadd = txt_passwordadd.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(score) || string.IsNullOrWhiteSpace(courseID)
                       || string.IsNullOrWhiteSpace(usernameadd) || string.IsNullOrWhiteSpace(passwordadd))
            {
                MessageBox.Show("Please enter all required fields.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlTransaction transaction = null;
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();




                    string addUserQuery = @"
                    INSERT INTO Useres (Username, Password, Role)
                    VALUES (@Username, @Password, 'Student');
                    SELECT SCOPE_IDENTITY();"; // Lấy UserID vừa được tạo

                    SqlCommand addUserCommand = new SqlCommand(addUserQuery, connection, transaction);
                    addUserCommand.Parameters.AddWithValue("@Username", usernameadd);
                    addUserCommand.Parameters.AddWithValue("@Password", passwordadd);

                    int newUserID = Convert.ToInt32(addUserCommand.ExecuteScalar());

                    // Thêm sinh viên vào bảng Students
                    string addStudentQuery = @"
                    INSERT INTO Students (Name, Email, UserID)
                    VALUES (@Name, @Email, (SELECT TOP 1 UserID FROM Useres WHERE Role = 'Student'));
                    SELECT SCOPE_IDENTITY();"; // Lấy StudentID vừa được tạo

                    SqlCommand addStudentCommand = new SqlCommand(addStudentQuery, connection, transaction);
                    addStudentCommand.Parameters.AddWithValue("@Name", name);
                    addStudentCommand.Parameters.AddWithValue("@Email", email);

                    int newStudentID = Convert.ToInt32(addStudentCommand.ExecuteScalar());

                    // Thêm điểm vào bảng Grades
                    string addGradeQuery = @"
                    INSERT INTO Gradess (Score, CourseID, StudentID)
                    VALUES (@Score, @CourseID, @StudentID);";

                    SqlCommand addGradeCommand = new SqlCommand(addGradeQuery, connection, transaction);
                    addGradeCommand.Parameters.AddWithValue("@Score", score);
                    addGradeCommand.Parameters.AddWithValue("@CourseID", courseID);
                    addGradeCommand.Parameters.AddWithValue("@StudentID", newStudentID);

                    addGradeCommand.ExecuteNonQuery();

                    // Commit transaction nếu tất cả các bước đều thành công
                    transaction.Commit();
                    MessageBox.Show("Student and score added successfully.");

                    this.Close();
                }
                catch (Exception ex)
                {
                    if (transaction != null)
                        transaction.Rollback();
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlTransaction transaction = null;
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    // Existing user and student adding code...

                    if (studentID > 0) // If editing
                    {
                        string updateStudentQuery = @"
                UPDATE Students 
                SET Name = @Name, Email = @Email 
                WHERE StudentID = @StudentID";

                        SqlCommand updateStudentCommand = new SqlCommand(updateStudentQuery, connection, transaction);
                        updateStudentCommand.Parameters.AddWithValue("@Name", name);
                        updateStudentCommand.Parameters.AddWithValue("@Email", email);
                        updateStudentCommand.Parameters.AddWithValue("@StudentID", studentID);

                        updateStudentCommand.ExecuteNonQuery();

                        string updateGradeQuery = @"
                UPDATE Gradess 
                SET Score = @Score, CourseID = @CourseID 
                WHERE StudentID = @StudentID";

                        SqlCommand updateGradeCommand = new SqlCommand(updateGradeQuery, connection, transaction);
                        updateGradeCommand.Parameters.AddWithValue("@Score", score);
                        updateGradeCommand.Parameters.AddWithValue("@CourseID", courseID);
                        updateGradeCommand.Parameters.AddWithValue("@StudentID", studentID);

                        updateGradeCommand.ExecuteNonQuery();
                    }
                    else // Existing code for adding new records
                    {
                        // Code for adding new student...
                    }

                    transaction.Commit();
                    MessageBox.Show("Student and score updated successfully.");

                    this.Close();
                }
                catch (Exception ex)
                {
                    if (transaction != null)
                        transaction.Rollback();
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}

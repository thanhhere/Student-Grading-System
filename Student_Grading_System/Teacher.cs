using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Grading_System
{
    public partial class Teacher : Form
    {
        public Teacher(string username)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Login form = new Login();
            form.Show();
            this.Hide();
        }


        private string connectionString = "Data Source=THANHPT09\\SQLEXPRESS03;Initial Catalog=Student_Score_System;Integrated Security=True;";


       
        

        private void btn_search_Click_1(object sender, EventArgs e)
        {
            string courseID = txt_courseid.Text;
            string teacherID = txt_teacherid.Text;
            string email = txt_email.Text;

            if (string.IsNullOrWhiteSpace(teacherID) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(courseID))
            {
                MessageBox.Show("Please enter both Teacher ID and Email.");
                return;
            }

            string query = @"

        SELECT
            s.StudentID,
            s.Name,
            s.Email,
            c.CourseName,
            g.Score,
            t.Name AS TeacherName
        FROM
            Students s
        JOIN
            Gradess g ON s.StudentID = g.StudentID
        JOIN
            Courses c ON g.CourseID = c.CourseID
        JOIN
            Teachers t ON c.TeacherID = t.TeacherID";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CourseID", courseID);
                    command.Parameters.AddWithValue("@StudentID", teacherID);
                    command.Parameters.AddWithValue("@Email", email);
                   

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();

                    try
                    {
                        // Mở kết nối và thực hiện truy vấn
                        connection.Open();
                        adapter.Fill(dataTable);

                        // Kiểm tra nếu không có dữ liệu trả về
                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("No data found for the provided Teacher ID, Email, and Course ID.");
                        }
                        else
                        {
                            datagridview_teacher.DataSource = dataTable;
                            datagridview_teacher.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Hiển thị thông báo lỗi nếu có vấn đề
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }

                }
            }
        }

        private void btn_delete_Click_1(object sender, EventArgs e)
        {
            if (datagridview_teacher.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a student to delete.");
                return;
            }

            DataGridViewRow selectedRow = datagridview_teacher.SelectedRows[0];
            string studentID = selectedRow.Cells["StudentID"].Value.ToString();

            DialogResult result = MessageBox.Show("Are you sure you want to delete this student ?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string deleteQuery = @"
            DELETE FROM Gradess WHERE StudentID = @StudentID;
            DELETE FROM Students WHERE StudentID = @StudentID;";

                    SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                    deleteCommand.Parameters.AddWithValue("@StudentID", studentID);

                    try
                    {
                        connection.Open();
                        deleteCommand.ExecuteNonQuery();
                        MessageBox.Show("Student deleted successfully.");

                        // Reload the teacher form data after deletion
                        btn_load_Click(sender, e);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
             string query = @"
        SELECT 
            s.StudentID,
            s.Name,
            s.Email,
            g.Score,
            c.CourseName,
            t.Name AS TeacherName
        FROM 
            Students s
        JOIN 
            Gradess g ON s.StudentID = g.StudentID
        JOIN 
            Courses c ON g.CourseID = c.CourseID
        JOIN 
            Teachers t ON c.TeacherID = t.TeacherID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();

                    try
                    {
                        connection.Open();
                        adapter.Fill(dataTable);
                        datagridview_teacher.DataSource = dataTable;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
        }

        private void btn_add_Click_1(object sender, EventArgs e)
        {
            // Mở form AddStudentForm để thêm dữ liệu
            Add addStudentForm = new Add(connectionString);
            addStudentForm.ShowDialog(); // Sử dụng ShowDialog để mở form ở chế độ modal
        }

        private void btn_load_Click_1(object sender, EventArgs e)
        {
            string query = @"
        SELECT 
            s.StudentID,
            s.Name,
            s.Email,
            g.Score,
            c.CourseName,
            t.Name AS TeacherName
        FROM 
            Students s
        JOIN 
            Gradess g ON s.StudentID = g.StudentID
        JOIN 
            Courses c ON g.CourseID = c.CourseID
        JOIN 
            Teachers t ON c.TeacherID = t.TeacherID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();

                    try
                    {
                        connection.Open();
                        adapter.Fill(dataTable);
                        datagridview_teacher.DataSource = dataTable;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
        }

        private void btn_edit_Click_1(object sender, EventArgs e)
        {
            if (datagridview_teacher.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a student to edit.");
                return;
            }

            DataGridViewRow selectedRow = datagridview_teacher.SelectedRows[0];
            string studentID = selectedRow.Cells["StudentID"].Value.ToString();
            string name = selectedRow.Cells["Name"].Value.ToString();
            string email = selectedRow.Cells["Email"].Value.ToString();
            string score = selectedRow.Cells["Score"].Value.ToString();


            // Open the Add form with the selected student's data
            Add addForm = new Add(connectionString);
            addForm.SetEditData(studentID, name, email, score);
            addForm.ShowDialog();

            // Reload the teacher form data after editing
            btn_load_Click(sender, e);
        }
    }
}

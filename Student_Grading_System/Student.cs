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
    public partial class Student : Form
    {
        public Student(string username)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }


        private string connectionString = "Data Source=THANHPT09\\SQLEXPRESS03;Initial Catalog=Student_Score_System;Integrated Security=True;"; // Cập nhật chuỗi kết nối

        

        private void Student_Load(object sender, EventArgs e)
        {

        }

        private void btn_search_Click_1(object sender, EventArgs e)
        {
            string courseID = txt_courseid.Text;
            string studentID = txt_studentid.Text;
            string email = txt_email.Text;

            if (string.IsNullOrWhiteSpace(studentID) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(courseID))
            {
                MessageBox.Show("Please enter both Student ID and Email.");
                return;
            }

            string query = @"
    SELECT 
        g.Score,
        c.CourseName,
        t.Name AS TeacherName
    FROM 
        Gradess g
    JOIN 
        Students s ON g.StudentID = s.StudentID
    JOIN 
        Courses c ON g.CourseID = c.CourseID
    JOIN 
        Teachers t ON c.TeacherID = t.TeacherID
    WHERE 
        s.StudentID = @StudentID AND s.Email = @Email AND c.CourseID = @CourseID";



            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CourseID", courseID);
                    command.Parameters.AddWithValue("@StudentID", studentID);
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
                            MessageBox.Show("No data found for the provided Student ID, Email, and Course ID.");
                        }
                        else
                        {
                            datagridview_student.DataSource = dataTable;
                            datagridview_student.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

        private void btn_exit_Click_1(object sender, EventArgs e)
        {

            Login form = new Login();
            form.Show();
            this.Hide();
        }
    }
}


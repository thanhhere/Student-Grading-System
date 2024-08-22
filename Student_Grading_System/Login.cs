using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Grading_System
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }


        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string username = txt_username.Text;
            string password = txt_password.Text;
            bool isStudent = ckb_student.Checked;
            bool isTeacher = ckb_teacher.Checked;
           

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username and Password are required.");
                return;
            }

            if (!isStudent && !isTeacher )
            {
                MessageBox.Show("Please select a role.");
                return;
            }


            string role = isStudent ? "student" : (isTeacher ? "teacher" : null);

            // Check if a valid role is selected
            if (role == null)
            {
                MessageBox.Show("Please select a role.");
                return;
            }

            // Authenticate the user with the specified role
            if (AuthenticateUser(username, password, role, out int userId))
            {
                // Inform the user of a successful login
                MessageBox.Show("Login successful!");

                // Show the appropriate form based on the user's role
                if (isStudent)
                {
                    new Student(username).Show();
                }
                else if (isTeacher)
                {
                    new Teacher(username).Show();
                }
                

                // Hide the current login form
                this.Hide();
            }
            else
            {
                // Inform the user of failed authentication
                MessageBox.Show("Invalid username or password.");
            }

        }

        private bool AuthenticateUser(string username, string password, string role, out int userId)
        {
            userId = -1;
            bool isAuthenticated = false;


            using (SqlConnection conn = new SqlConnection("Data Source=THANHPT09\\SQLEXPRESS03;Initial Catalog=Student_Score_System;Integrated Security=True;"))
            {
                conn.Open();
                string query = "SELECT UserID FROM [Useres] WHERE Username = @username AND Password = @password AND Role = @role";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@role", role);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        userId = Convert.ToInt32(result);
                        isAuthenticated = true;
                    }
                }
            }

            return isAuthenticated;
        }

       

        private void ckb_teacher_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_teacher.Checked)
            {
                
                ckb_student.Checked = false;
            }

        }

        private void ckb_student_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_student.Checked)
            {
                ckb_teacher.Checked = false;
                
            }
        }

        private void txt_username_TextChanged(object sender, EventArgs e)
        {
            // Example validation: Check if username length is at least 3 characters
            if (txt_username.Text.Length < 10)
            {
                // Provide feedback, e.g., change border color
                txt_username.BackColor = Color.LightCoral;
            }
            else
            {
                txt_username.BackColor = Color.White;
            }
        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {
            // Example validation: Check if password length is at least 6 characters
            if (txt_password.Text.Length < 10)
            {
                // Provide feedback, e.g., change border color
                txt_password.BackColor = Color.LightCoral;
            }
            else
            {
                txt_password.BackColor = Color.White;
            }
        }

      

    }

}

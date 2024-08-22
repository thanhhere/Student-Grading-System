namespace Student_Grading_System
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.lb_username = new System.Windows.Forms.Label();
            this.lb_password = new System.Windows.Forms.Label();
            this.btn_login = new System.Windows.Forms.Button();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ckb_teacher = new System.Windows.Forms.CheckBox();
            this.ckb_student = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_username
            // 
            this.lb_username.AutoSize = true;
            this.lb_username.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_username.Location = new System.Drawing.Point(140, 129);
            this.lb_username.Name = "lb_username";
            this.lb_username.Size = new System.Drawing.Size(83, 20);
            this.lb_username.TabIndex = 0;
            this.lb_username.Text = "User Name";
            // 
            // lb_password
            // 
            this.lb_password.AutoSize = true;
            this.lb_password.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_password.Location = new System.Drawing.Point(140, 205);
            this.lb_password.Name = "lb_password";
            this.lb_password.Size = new System.Drawing.Size(72, 20);
            this.lb_password.TabIndex = 1;
            this.lb_password.Text = "Password";
            // 
            // btn_login
            // 
            this.btn_login.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btn_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_login.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_login.Location = new System.Drawing.Point(203, 352);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(128, 44);
            this.btn_login.TabIndex = 2;
            this.btn_login.Text = "Login";
            this.btn_login.UseVisualStyleBackColor = false;
            this.btn_login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // txt_username
            // 
            this.txt_username.Location = new System.Drawing.Point(144, 152);
            this.txt_username.Multiline = true;
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(266, 41);
            this.txt_username.TabIndex = 4;
            this.txt_username.TextChanged += new System.EventHandler(this.txt_username_TextChanged);
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(144, 229);
            this.txt_password.Multiline = true;
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(266, 40);
            this.txt_password.TabIndex = 5;
            this.txt_password.TextChanged += new System.EventHandler(this.txt_password_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Stencil", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(207, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 51);
            this.label3.TabIndex = 6;
            this.label3.Text = "Login";
            // 
            // ckb_teacher
            // 
            this.ckb_teacher.AutoSize = true;
            this.ckb_teacher.Font = new System.Drawing.Font("Perpetua Titling MT", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckb_teacher.Location = new System.Drawing.Point(158, 293);
            this.ckb_teacher.Name = "ckb_teacher";
            this.ckb_teacher.Size = new System.Drawing.Size(94, 20);
            this.ckb_teacher.TabIndex = 8;
            this.ckb_teacher.Text = "Teacher";
            this.ckb_teacher.UseVisualStyleBackColor = true;
            this.ckb_teacher.CheckedChanged += new System.EventHandler(this.ckb_teacher_CheckedChanged);
            // 
            // ckb_student
            // 
            this.ckb_student.AutoSize = true;
            this.ckb_student.Font = new System.Drawing.Font("Perpetua Titling MT", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckb_student.Location = new System.Drawing.Point(290, 293);
            this.ckb_student.Name = "ckb_student";
            this.ckb_student.Size = new System.Drawing.Size(95, 20);
            this.ckb_student.TabIndex = 9;
            this.ckb_student.Text = "Student";
            this.ckb_student.UseVisualStyleBackColor = true;
            this.ckb_student.CheckedChanged += new System.EventHandler(this.ckb_student_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(363, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(173, 99);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(548, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ckb_student);
            this.Controls.Add(this.ckb_teacher);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.txt_username);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.lb_password);
            this.Controls.Add(this.lb_username);
            this.Name = "Login";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_username;
        private System.Windows.Forms.Label lb_password;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ckb_teacher;
        private System.Windows.Forms.CheckBox ckb_student;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}


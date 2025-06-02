namespace lab6_op.Forms
{
    partial class Registerform
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
            lblUserName = new Label();
            txtUserName = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnRegister = new Button();
            lblConfirm = new Label();
            txtConfirm = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtFirstName = new TextBox();
            txtLast = new TextBox();
            txtEmail = new TextBox();
            txtPhone = new TextBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Location = new Point(161, 14);
            lblUserName.Margin = new Padding(2, 0, 2, 0);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(100, 15);
            lblUserName.TabIndex = 0;
            lblUserName.Text = "Ім'я користувача";
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(161, 31);
            txtUserName.Margin = new Padding(2);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(134, 23);
            txtUserName.TabIndex = 1;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(161, 64);
            lblPassword.Margin = new Padding(2, 0, 2, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(49, 15);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Пароль";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(161, 81);
            txtPassword.Margin = new Padding(2);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(134, 23);
            txtPassword.TabIndex = 3;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(161, 180);
            btnRegister.Margin = new Padding(2);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(134, 23);
            btnRegister.TabIndex = 4;
            btnRegister.Text = "Зареєструватися";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // lblConfirm
            // 
            lblConfirm.AutoSize = true;
            lblConfirm.Location = new Point(161, 113);
            lblConfirm.Margin = new Padding(2, 0, 2, 0);
            lblConfirm.Name = "lblConfirm";
            lblConfirm.Size = new Size(74, 15);
            lblConfirm.TabIndex = 5;
            lblConfirm.Text = "Підтвердити";
            // 
            // txtConfirm
            // 
            txtConfirm.Location = new Point(161, 130);
            txtConfirm.Margin = new Padding(2);
            txtConfirm.Name = "txtConfirm";
            txtConfirm.Size = new Size(134, 23);
            txtConfirm.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 14);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(28, 15);
            label1.TabIndex = 7;
            label1.Text = "Ім'я";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 62);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 8;
            label2.Text = "Прізвище";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 113);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(110, 15);
            label3.TabIndex = 9;
            label3.Text = "Електронна пошта";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(26, 31);
            txtFirstName.Margin = new Padding(2);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(104, 23);
            txtFirstName.TabIndex = 11;
            // 
            // txtLast
            // 
            txtLast.Location = new Point(26, 81);
            txtLast.Margin = new Padding(2);
            txtLast.Name = "txtLast";
            txtLast.Size = new Size(104, 23);
            txtLast.TabIndex = 12;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(26, 130);
            txtEmail.Margin = new Padding(2);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(104, 23);
            txtEmail.TabIndex = 13;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(26, 180);
            txtPhone.Margin = new Padding(2);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(104, 23);
            txtPhone.TabIndex = 14;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 163);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(101, 15);
            label4.TabIndex = 15;
            label4.Text = "Номер телефону";
            // 
            // Registerform
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(324, 225);
            Controls.Add(label4);
            Controls.Add(txtPhone);
            Controls.Add(txtEmail);
            Controls.Add(txtLast);
            Controls.Add(txtFirstName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtConfirm);
            Controls.Add(lblConfirm);
            Controls.Add(btnRegister);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUserName);
            Controls.Add(lblUserName);
            Margin = new Padding(2);
            Name = "Registerform";
            Text = "Registerform";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUserName;
        private TextBox txtUserName;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnRegister;
        private Label lblConfirm;
        private TextBox txtConfirm;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtFirstName;
        private TextBox txtLast;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private Label label4;
    }
}
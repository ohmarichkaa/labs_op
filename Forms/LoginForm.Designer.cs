namespace lab6_op.Forms
{
    partial class LoginForm
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
            btnLogin = new Button();
            txtLoginUsername = new TextBox();
            txtLoginPassword = new TextBox();
            label1 = new Label();
            lblPassword = new Label();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(62, 122);
            btnLogin.Margin = new Padding(2);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(104, 25);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Увійти";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtLoginUsername
            // 
            txtLoginUsername.Location = new Point(62, 32);
            txtLoginUsername.Margin = new Padding(2);
            txtLoginUsername.Name = "txtLoginUsername";
            txtLoginUsername.Size = new Size(104, 23);
            txtLoginUsername.TabIndex = 1;
            // 
            // txtLoginPassword
            // 
            txtLoginPassword.Location = new Point(62, 83);
            txtLoginPassword.Margin = new Padding(2);
            txtLoginPassword.Name = "txtLoginPassword";
            txtLoginPassword.Size = new Size(104, 23);
            txtLoginPassword.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(62, 16);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 15);
            label1.TabIndex = 3;
            label1.Text = "Ім'я користувача";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(62, 66);
            lblPassword.Margin = new Padding(2, 0, 2, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(49, 15);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Пароль";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(232, 168);
            Controls.Add(lblPassword);
            Controls.Add(label1);
            Controls.Add(txtLoginPassword);
            Controls.Add(txtLoginUsername);
            Controls.Add(btnLogin);
            Margin = new Padding(2);
            Name = "LoginForm";
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private TextBox txtLoginUsername;
        private TextBox txtLoginPassword;
        private Label label1;
        private Label lblPassword;
    }
}
namespace lab6_op.Forms
{
    partial class UserForm
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
            dataGridViewUsers = new DataGridView();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            brnRefresh = new Button();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            txtEmail = new TextBox();
            txtPhone = new TextBox();
            txt1name = new Label();
            txt2Name = new Label();
            txt1Email = new Label();
            txt1Phone = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewUsers
            // 
            dataGridViewUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUsers.Location = new Point(253, 22);
            dataGridViewUsers.Margin = new Padding(2, 2, 2, 2);
            dataGridViewUsers.Name = "dataGridViewUsers";
            dataGridViewUsers.RowHeadersWidth = 72;
            dataGridViewUsers.Size = new Size(294, 138);
            dataGridViewUsers.TabIndex = 0;
            dataGridViewUsers.CellContentClick += dataGridViewUsers_CellContentClick;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(36, 178);
            btnAdd.Margin = new Padding(2, 2, 2, 2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(76, 36);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Додати";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(318, 178);
            btnEdit.Margin = new Padding(2, 2, 2, 2);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(76, 36);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Редагувати";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(156, 178);
            btnDelete.Margin = new Padding(2, 2, 2, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(76, 36);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Видалити";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // brnRefresh
            // 
            brnRefresh.Location = new Point(442, 178);
            brnRefresh.Margin = new Padding(2, 2, 2, 2);
            brnRefresh.Name = "brnRefresh";
            brnRefresh.Size = new Size(76, 36);
            brnRefresh.TabIndex = 4;
            brnRefresh.Text = "Оновити";
            brnRefresh.UseVisualStyleBackColor = true;
            brnRefresh.Click += brnRefresh_Click;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(128, 22);
            txtFirstName.Margin = new Padding(2, 2, 2, 2);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(104, 23);
            txtFirstName.TabIndex = 5;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(128, 60);
            txtLastName.Margin = new Padding(2, 2, 2, 2);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(104, 23);
            txtLastName.TabIndex = 6;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(128, 98);
            txtEmail.Margin = new Padding(2, 2, 2, 2);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(104, 23);
            txtEmail.TabIndex = 7;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(128, 137);
            txtPhone.Margin = new Padding(2, 2, 2, 2);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(104, 23);
            txtPhone.TabIndex = 8;
            // 
            // txt1name
            // 
            txt1name.AutoSize = true;
            txt1name.Location = new Point(84, 25);
            txt1name.Margin = new Padding(2, 0, 2, 0);
            txt1name.Name = "txt1name";
            txt1name.Size = new Size(28, 15);
            txt1name.TabIndex = 9;
            txt1name.Text = "Ім'я";
            // 
            // txt2Name
            // 
            txt2Name.AutoSize = true;
            txt2Name.Location = new Point(51, 63);
            txt2Name.Margin = new Padding(2, 0, 2, 0);
            txt2Name.Name = "txt2Name";
            txt2Name.Size = new Size(61, 15);
            txt2Name.TabIndex = 10;
            txt2Name.Text = "Прізвище";
            // 
            // txt1Email
            // 
            txt1Email.AutoSize = true;
            txt1Email.Location = new Point(50, 101);
            txt1Email.Margin = new Padding(2, 0, 2, 0);
            txt1Email.Name = "txt1Email";
            txt1Email.Size = new Size(62, 15);
            txt1Email.TabIndex = 11;
            txt1Email.Text = "Ел. пошта";
            // 
            // txt1Phone
            // 
            txt1Phone.AutoSize = true;
            txt1Phone.Location = new Point(11, 140);
            txt1Phone.Margin = new Padding(2, 0, 2, 0);
            txt1Phone.Name = "txt1Phone";
            txt1Phone.Size = new Size(101, 15);
            txt1Phone.TabIndex = 12;
            txt1Phone.Text = "Номер телефону";
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(558, 232);
            Controls.Add(txt1Phone);
            Controls.Add(txt1Email);
            Controls.Add(txt2Name);
            Controls.Add(txt1name);
            Controls.Add(txtPhone);
            Controls.Add(txtEmail);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Controls.Add(brnRefresh);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(dataGridViewUsers);
            Margin = new Padding(2, 2, 2, 2);
            Name = "UserForm";
            Text = "UserForm";
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewUsers;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button brnRefresh;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private Label txt1name;
        private Label txt2Name;
        private Label txt1Email;
        private Label txt1Phone;
    }
}
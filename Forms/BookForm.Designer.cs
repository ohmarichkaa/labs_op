namespace lab6_op.Forms
{
    partial class BookForm
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
            Button btnAdd;
            dataGridViewBooks = new DataGridView();
            txtTitle = new TextBox();
            txtAuthor = new TextBox();
            txtYear = new TextBox();
            txtPages = new TextBox();
            btnEdit = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();
            lblTitle = new Label();
            lblAuthor = new Label();
            lblyear = new Label();
            lblPages = new Label();
            chkAvailable = new CheckBox();
            btnAdd = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBooks).BeginInit();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(118, 160);
            btnAdd.Margin = new Padding(2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(76, 26);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Додати";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // dataGridViewBooks
            // 
            dataGridViewBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBooks.Location = new Point(221, 14);
            dataGridViewBooks.Margin = new Padding(2);
            dataGridViewBooks.Name = "dataGridViewBooks";
            dataGridViewBooks.RowHeadersWidth = 72;
            dataGridViewBooks.Size = new Size(241, 138);
            dataGridViewBooks.TabIndex = 0;
            dataGridViewBooks.CellClick += dataGridViewBooks_CellContentClick;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(100, 17);
            txtTitle.Margin = new Padding(2);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(104, 23);
            txtTitle.TabIndex = 1;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(100, 55);
            txtAuthor.Margin = new Padding(2);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(104, 23);
            txtAuthor.TabIndex = 2;
            // 
            // txtYear
            // 
            txtYear.Location = new Point(100, 93);
            txtYear.Margin = new Padding(2);
            txtYear.Name = "txtYear";
            txtYear.Size = new Size(104, 23);
            txtYear.TabIndex = 3;
            // 
            // txtPages
            // 
            txtPages.Location = new Point(133, 129);
            txtPages.Margin = new Padding(2);
            txtPages.Name = "txtPages";
            txtPages.Size = new Size(71, 23);
            txtPages.TabIndex = 4;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(297, 162);
            btnEdit.Margin = new Padding(2);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(76, 26);
            btnEdit.TabIndex = 6;
            btnEdit.Text = "Редагувати";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(208, 162);
            btnDelete.Margin = new Padding(2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(76, 26);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Видалити";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(386, 162);
            btnRefresh.Margin = new Padding(2);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(76, 26);
            btnRefresh.TabIndex = 8;
            btnRefresh.Text = "Оновити";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(22, 20);
            lblTitle.Margin = new Padding(2, 0, 2, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(74, 15);
            lblTitle.TabIndex = 9;
            lblTitle.Text = "Назва книги";
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Location = new Point(22, 58);
            lblAuthor.Margin = new Padding(2, 0, 2, 0);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(40, 15);
            lblAuthor.TabIndex = 10;
            lblAuthor.Text = "Автор";
            // 
            // lblyear
            // 
            lblyear.AutoSize = true;
            lblyear.Location = new Point(22, 96);
            lblyear.Margin = new Padding(2, 0, 2, 0);
            lblyear.Name = "lblyear";
            lblyear.Size = new Size(71, 15);
            lblyear.TabIndex = 11;
            lblyear.Text = "Рік видання";
            // 
            // lblPages
            // 
            lblPages.AutoSize = true;
            lblPages.Location = new Point(22, 132);
            lblPages.Margin = new Padding(2, 0, 2, 0);
            lblPages.Name = "lblPages";
            lblPages.Size = new Size(107, 15);
            lblPages.TabIndex = 12;
            lblPages.Text = "Кількість сторінок";
            // 
            // chkAvailable
            // 
            chkAvailable.AutoSize = true;
            chkAvailable.Location = new Point(22, 162);
            chkAvailable.Margin = new Padding(2);
            chkAvailable.Name = "chkAvailable";
            chkAvailable.Size = new Size(78, 19);
            chkAvailable.TabIndex = 13;
            chkAvailable.Text = "Доступна";
            chkAvailable.UseVisualStyleBackColor = true;
            // 
            // BookForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(487, 206);
            Controls.Add(chkAvailable);
            Controls.Add(lblPages);
            Controls.Add(lblyear);
            Controls.Add(lblAuthor);
            Controls.Add(lblTitle);
            Controls.Add(btnRefresh);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(txtPages);
            Controls.Add(txtYear);
            Controls.Add(txtAuthor);
            Controls.Add(txtTitle);
            Controls.Add(dataGridViewBooks);
            Margin = new Padding(2);
            Name = "BookForm";
            Text = "BookForm";
            ((System.ComponentModel.ISupportInitialize)dataGridViewBooks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewBooks;
        private TextBox txtTitle;
        private TextBox txtAuthor;
        private TextBox txtYear;
        private TextBox txtPages;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnRefresh;
        private Label lblTitle;
        private Label lblAuthor;
        private Label lblyear;
        private Label lblPages;
        private CheckBox chkAvailable;
    }
}
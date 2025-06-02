namespace lab6_op.Forms
{
    partial class MainForm
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
            btnUsers = new Button();
            btnBooks = new Button();
            btnReservation = new Button();
            SuspendLayout();
            // 
            // btnUsers
            // 
            btnUsers.Location = new Point(62, 27);
            btnUsers.Margin = new Padding(2);
            btnUsers.Name = "btnUsers";
            btnUsers.Size = new Size(138, 36);
            btnUsers.TabIndex = 0;
            btnUsers.Text = "Користувачі";
            btnUsers.UseVisualStyleBackColor = true;
            btnUsers.Click += btnUsers_Click;
            // 
            // btnBooks
            // 
            btnBooks.Location = new Point(62, 78);
            btnBooks.Margin = new Padding(2);
            btnBooks.Name = "btnBooks";
            btnBooks.Size = new Size(138, 36);
            btnBooks.TabIndex = 1;
            btnBooks.Text = "Книги";
            btnBooks.UseVisualStyleBackColor = true;
            btnBooks.Click += btnBooks_Click;
            // 
            // btnReservation
            // 
            btnReservation.Location = new Point(62, 130);
            btnReservation.Margin = new Padding(2);
            btnReservation.Name = "btnReservation";
            btnReservation.Size = new Size(138, 36);
            btnReservation.TabIndex = 2;
            btnReservation.Text = "Бронювання";
            btnReservation.UseVisualStyleBackColor = true;
            btnReservation.Click += btnReservation_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(263, 217);
            Controls.Add(btnReservation);
            Controls.Add(btnBooks);
            Controls.Add(btnUsers);
            Margin = new Padding(2);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnUsers;
        private Button btnBooks;
        private Button btnReservation;
    }
}
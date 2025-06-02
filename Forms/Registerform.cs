using lab6_op.Models;
using lab6_op.Repositories;
using lab6_op.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace lab6_op.Forms
{
    public partial class Registerform : Form
    {




        private readonly AuthService _authService;

        public Registerform(AuthService authService)
        {
            InitializeComponent();
            _authService = authService;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var username = txtUserName.Text.Trim();
            var password = txtPassword.Text;
            var confirm = txtConfirm.Text;

            var firstName = txtFirstName.Text.Trim();
            var lastName = txtLast.Text.Trim();
            var email = txtEmail.Text.Trim();
            var phone = txtPhone.Text.Trim();

            if (password != confirm)
            {
                MessageBox.Show("Паролі не співпадають!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var success = _authService.Register(username, password, "User", firstName, lastName, email, phone);

            if (success)
            {
                MessageBox.Show("Реєстрація успішна!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var user = _authService.GetUserByUsername(username);
                var bookRepository = new Repository<Book>(new JsonStorage<Book>("books.json"));
                var bookService = new BookService(bookRepository);

                var userForm = new UUSerForm(user, bookService);
                userForm.Show();
                userForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Користувач з таким іменем вже існує.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }        
    }
}

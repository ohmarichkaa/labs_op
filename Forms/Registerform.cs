using lab6_op.Models;
using lab6_op.Repositories;
using lab6_op.Services;
using System;
using System.Windows.Forms;

namespace lab6_op.Forms
{
    public partial class Registerform : Form
    {
        private readonly AuthService _authService;
        private readonly ValidationService _validationService;

        public Registerform(AuthService authService)
        {
            InitializeComponent();
            _authService = authService;
            _validationService = new ValidationService();
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

            var tempUser = new User(0, firstName, lastName, email, phone);

            if (!_validationService.ValidateUser(tempUser, out string error))
            {
                MessageBox.Show(error, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                this.Hide();
            }
            else
            {
                MessageBox.Show("Користувач з таким іменем вже існує.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

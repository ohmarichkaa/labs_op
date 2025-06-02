using lab6_op.Models;
using lab6_op.Repositories;
using lab6_op.Services;
using System;
using System.Windows.Forms;

namespace lab6_op.Forms
{
    public partial class LoginForm : Form
    {
        private readonly AuthService _authService;

        public LoginForm(AuthService authService)
        {
            InitializeComponent();
            _authService = authService;

            // Створюємо адміна, якщо ще не створено
            if (_authService.GetUserByUsername("admin") == null)
            {
                _authService.Register("admin", "admin", "admin", "Admin", "Адмін", "admin@library.com", "0000000000");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var username = txtLoginUsername.Text.Trim();
            var password = txtLoginPassword.Text;

            var user = _authService.Login(username, password);

            if (user != null)
            {
                MessageBox.Show($"Ласкаво просимо, {user.Username}!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (user.Role.ToLower() == "admin")
                {
                    var mainForm = new MainForm(user);
                    mainForm.Show();
                }
                else
                {
                    var bookRepository = new Repository<Book>(new JsonStorage<Book>("books.json"));
                    var bookService = new BookService(bookRepository);

                    var userForm = new UUSerForm(user, bookService);
                    userForm.Show();
                }

                this.Hide();
            }
            else
            {
                MessageBox.Show("Невірний логін або пароль.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

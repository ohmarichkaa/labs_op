using lab6_op.Models;
using lab6_op.Services;
using System;
using System.Windows.Forms;

namespace lab6_op.Forms
{
    public partial class LoginForm : Form
    {
        private readonly AuthService _authService;
        private readonly BookService _bookService;
        private readonly UserService _userService;
        private readonly ReservationService _reservationService;

        public LoginForm(AuthService authService, BookService bookService, UserService userService, ReservationService reservationService)
        {
            InitializeComponent();
            _authService = authService;
            _bookService = bookService;
            _userService = userService;
            _reservationService = reservationService;

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
                    var mainForm = new MainForm(user, _userService, _bookService, _reservationService);
                    mainForm.Show();
                }
                else
                {
                    var userForm = new UUSerForm(user, _bookService);
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

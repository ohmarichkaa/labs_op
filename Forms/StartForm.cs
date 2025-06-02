using lab6_op.Data;
using lab6_op.Models;
using lab6_op.Services;
using System;
using System.Windows.Forms;

namespace lab6_op.Forms
{
    public partial class StartForm : Form
    {
        private readonly AuthService _authService;
        private readonly UserService _userService;
        private readonly BookService _bookService;
        private readonly ReservationService _reservationService;

        public StartForm()
        {
            InitializeComponent();

            var context = new LibraryContext(); // EF Core контекст

            _userService = new UserService(context);
            _bookService = new BookService(context);
            _reservationService = new ReservationService(context);
            _authService = new AuthService(context);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var loginForm = new LoginForm(_authService, _bookService, _userService, _reservationService);
            loginForm.Show();
            this.Hide();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var registerForm = new Registerform(_authService, _bookService);
            registerForm.Show();
            this.Hide();
        }
    }
}

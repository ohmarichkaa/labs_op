using System;
using System.Windows.Forms;
using lab6_op.Models;
using lab6_op.Services;

namespace lab6_op.Forms
{
    public partial class MainForm : Form
    {
        private readonly UserService _userService;
        private readonly BookService _bookService;
        private readonly ReservationService _reservationService;
        private readonly UserReg _currentUser;

        public MainForm(UserReg user, UserService userService, BookService bookService, ReservationService reservationService)
        {
            InitializeComponent();

            _currentUser = user;
            _userService = userService;
            _bookService = bookService;
            _reservationService = reservationService;
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            var userForm = new UserForm(_userService);
            userForm.ShowDialog();
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            var bookForm = new BookForm(_bookService);
            bookForm.ShowDialog();
        }

        private void btnReservation_Click(object sender, EventArgs e)
        {
            var reservationForm = new ReservationForm(_reservationService, _userService, _bookService);
            reservationForm.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}

using System;
using System.Windows.Forms;
using lab6_op.Forms;
using lab6_op.Models;
using lab6_op.Repositories;
using lab6_op.Services;

namespace lab6_op.Forms
{
    public partial class MainForm : Form
    {
        private readonly UserService _userService;
        private readonly BookService _bookService;
        private readonly ReservationService _reservationService;

        private UserReg _currentUser;

        public MainForm()
        {
            InitializeComponent();

            // Ініціалізуємо сервіси з відповідними репозиторіями
            var userRepo = new Repository<User>(new JsonStorage<User>("users.json"));
            var bookRepo = new Repository<Book>(new JsonStorage<Book>("books.json"));
            var reservationRepo = new Repository<Reservation>(new JsonStorage<Reservation>("reservations.json"));

            _userService = new UserService(userRepo);
            _bookService = new BookService(bookRepo);
            _reservationService = new ReservationService(reservationRepo, userRepo, bookRepo);

        }

        public MainForm(UserReg user) : this()
        {
            _currentUser = user;
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

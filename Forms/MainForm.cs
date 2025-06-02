using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lab6_op.Forms;
using lab6_op.Models;
using lab6_op.Repositories;

namespace lab6_op.Forms
{
    public partial class MainForm : Form
    {
        private readonly Repository<User> _userRepository;
        private readonly Repository<Book> _bookRepository;
        private readonly Repository<Reservation> _reservationRepository;

        private UserReg _currentUser;

        public MainForm()
        {
            InitializeComponent();

            _userRepository = new Repository<User>(
                new JsonStorage<User>("users.json"));

            _bookRepository = new Repository<Book>(
                new JsonStorage<Book>("books.json"));

            _reservationRepository = new Repository<Reservation>(
                new JsonStorage<Reservation>("reservations.json"));
        }

        public MainForm(UserReg user) : this()
        {
            _currentUser = user;
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            UserForm userForm = new UserForm(_userRepository);
            userForm.ShowDialog();
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            BookForm bookForm = new BookForm(_bookRepository);
            bookForm.ShowDialog();
        }

        private void btnReservation_Click(object sender, EventArgs e)
        {
            ReservationForm reservationForm = new ReservationForm(
                _reservationRepository,
                _userRepository,
                _bookRepository);
            reservationForm.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }
    }
}

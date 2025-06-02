using System;
using System.Linq;
using System.Windows.Forms;
using lab6_op.Models;
using lab6_op.Services;

namespace lab6_op.Forms
{
    public partial class ReservationForm : Form
    {
        private readonly ReservationService _reservationService;
        private readonly UserService _userService;
        private readonly BookService _bookService;

        public ReservationForm(
            ReservationService reservationService,
            UserService userService,
            BookService bookService)
        {
            InitializeComponent();
            _reservationService = reservationService;
            _userService = userService;
            _bookService = bookService;
            LoadUsers();
            LoadBooks();
            LoadReservations();
        }

        private void LoadUsers()
        {
            comboBoxUsers.DataSource = _userService.GetAllUsers();
            comboBoxUsers.DisplayMember = "FirstName";
            comboBoxUsers.ValueMember = "ID";
        }

        private void LoadBooks()
        {
            comboBoxBooks.DataSource = _bookService.GetAllBooks();
            comboBoxBooks.DisplayMember = "Title";
            comboBoxBooks.ValueMember = "ID";
        }

        private void LoadReservations()
        {
            var reservations = _reservationService.GetAllReservations();
            dataGridViewReservations.DataSource = reservations.Select(r => new
            {
                r.ID,
                UserName = _userService.GetUserById(r.UserId)?.FirstName,
                BookTitle = _bookService.GetBookById(r.BookId)?.Title,
                StartDate = r.StartDate.ToShortDateString(),
                EndDate = r.EndDate.ToShortDateString(),
                Status = r.IsReserved ? "Активне" : "Скасоване"
            }).ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var userId = (int)comboBoxUsers.SelectedValue;
            var bookId = (int)comboBoxBooks.SelectedValue;
            var startDate = dateTimePickerStart.Value;
            var endDate = dateTimePickerEnd.Value;

            var (success, message) = _reservationService.AddReservation(userId, bookId, startDate, endDate);

            if (success)
            {
                LoadReservations();
                MessageBox.Show("Бронювання додано успішно.");
            }
            else
            {
                MessageBox.Show(message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewReservations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Будь ласка, виберіть бронювання для редагування.");
                return;
            }

            int reservationId = (int)dataGridViewReservations.SelectedRows[0].Cells["ID"].Value;
            int userId = (int)comboBoxUsers.SelectedValue;
            int bookId = (int)comboBoxBooks.SelectedValue;
            DateTime startDate = dateTimePickerStart.Value;
            DateTime endDate = dateTimePickerEnd.Value;

            var (success, message) = _reservationService.UpdateReservation(reservationId, userId, bookId, startDate, endDate);

            if (success)
            {
                LoadReservations();
                MessageBox.Show("Бронювання оновлено.");
            }
            else
            {
                MessageBox.Show(message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewReservations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Будь ласка, виберіть бронювання для видалення.");
                return;
            }

            int reservationId = (int)dataGridViewReservations.SelectedRows[0].Cells["ID"].Value;

            _reservationService.RemoveReservation(reservationId);
            LoadReservations();
            MessageBox.Show("Бронювання видалено.");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadReservations();
        }


        private void dataGridViewReservations_SelectionChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewReservations.SelectedRows.Count == 0) return;

            var selectedRow = dataGridViewReservations.SelectedRows[0];
            int selectedId = (int)selectedRow.Cells["ID"].Value;
            var reservation = _reservationService.GetReservationById(selectedId);

            if (reservation != null)
            {
                comboBoxUsers.SelectedValue = reservation.UserId;
                comboBoxBooks.SelectedValue = reservation.BookId;
                dateTimePickerStart.Value = reservation.StartDate;
                dateTimePickerEnd.Value = reservation.EndDate;
            }
        }
    }
}

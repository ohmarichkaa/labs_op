using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using lab6_op.Models;
using lab6_op.Repositories;

namespace lab6_op.Forms
{
    public partial class ReservationForm : Form
    {
        private readonly Repository<Reservation> _reservationRepository;
        private readonly Repository<User> _userRepository;
        private readonly Repository<Book> _bookRepository;

        public ReservationForm(
            Repository<Reservation> reservationRepository,
            Repository<User> userRepository,
            Repository<Book> bookRepository)
        {
            InitializeComponent();
            _reservationRepository = reservationRepository;
            _userRepository = userRepository;
            _bookRepository = bookRepository;
        }

        private void ReservationForm_Load(object sender, EventArgs e)
        {
            LoadUsers();
            LoadBooks();
            LoadReservations();
        }

        private void LoadUsers()
        {
            comboBoxUsers.DataSource = _userRepository.GetAll();
            comboBoxUsers.DisplayMember = "FirstName";
            comboBoxUsers.ValueMember = "ID";
        }

        private void LoadBooks()
        {
            comboBoxBooks.DataSource = _bookRepository.GetAll();
            comboBoxBooks.DisplayMember = "Title";
            comboBoxBooks.ValueMember = "ID";
        }

        private void LoadReservations()
        {
            var reservations = _reservationRepository.GetAll();
            dataGridViewReservations.DataSource = reservations.Select(r => new
            {
                r.ID,
                UserName = _userRepository.GetById(r.UserId)?.FirstName,
                BookTitle = _bookRepository.GetById(r.BookId)?.Title,
                StartDate = r.StartDate.ToShortDateString(),
                EndDate = r.EndDate.ToShortDateString(),
                Status = r.IsReserved ? "Активне" : "Скасоване"
            }).ToList();
        }

        private int GetNextReservationId()
        {
            var reservations = _reservationRepository.GetAll();
            return reservations.Count == 0 ? 1 : reservations.Max(r => r.ID) + 1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var userId = (int)comboBoxUsers.SelectedValue;
                var bookId = (int)comboBoxBooks.SelectedValue;
                var startDate = dateTimePickerStart.Value;
                var endDate = dateTimePickerEnd.Value;

                if (startDate > endDate)
                {
                    MessageBox.Show("Дата початку не може бути пізнішою за дату кінця.");
                    return;
                }

                var book = _bookRepository.GetById(bookId);
                if (!book.Available)
                {
                    MessageBox.Show("Ця книга вже заброньована.");
                    return;
                }

                var newReservation = new Reservation(GetNextReservationId(), userId, bookId);
                newReservation.Reserve(startDate, endDate);
                _reservationRepository.Add(newReservation);

                book.Available = false;
                _bookRepository.Update(book);

                LoadReservations();
                MessageBox.Show("Бронювання додано успішно.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewReservations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Будь ласка, виберіть бронювання для редагування.");
                return;
            }

            try
            {
                int selectedId = (int)dataGridViewReservations.SelectedRows[0].Cells["ID"].Value;
                var reservation = _reservationRepository.GetById(selectedId);
                if (reservation == null) return;

                int userId = (int)comboBoxUsers.SelectedValue;
                int bookId = (int)comboBoxBooks.SelectedValue;
                DateTime startDate = dateTimePickerStart.Value.Date;
                DateTime endDate = dateTimePickerEnd.Value.Date;

                if (startDate > endDate)
                {
                    MessageBox.Show("Дата початку не може бути пізнішою за дату кінця.");
                    return;
                }

                if (reservation.BookId != bookId)
                {
                    var oldBook = _bookRepository.GetById(reservation.BookId);
                    var newBook = _bookRepository.GetById(bookId);

                    if (!newBook.Available)
                    {
                        MessageBox.Show("Нова книга вже заброньована.");
                        return;
                    }

                    oldBook.Available = true;
                    _bookRepository.Update(oldBook);

                    newBook.Available = false;
                    _bookRepository.Update(newBook);

                    reservation.BookId = bookId;
                }

                reservation.UserId = userId;
                reservation.Reserve(startDate, endDate);
                _reservationRepository.Update(reservation);

                LoadReservations();
                MessageBox.Show("Бронювання оновлено.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewReservations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Будь ласка, виберіть бронювання для видалення.");
                return;
            }

            try
            {
                int selectedId = (int)dataGridViewReservations.SelectedRows[0].Cells["ID"].Value;
                var reservation = _reservationRepository.GetById(selectedId);
                if (reservation == null) return;

                var book = _bookRepository.GetById(reservation.BookId);
                if (book != null)
                {
                    book.Available = true;
                    _bookRepository.Update(book);
                }

                _reservationRepository.Remove(reservation);
                LoadReservations();
                MessageBox.Show("Бронювання видалено.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadReservations();
        }

        private void dataGridViewReservations_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewReservations.SelectedRows.Count == 0) return;

            var selectedRow = dataGridViewReservations.SelectedRows[0];
            int selectedId = (int)selectedRow.Cells["ID"].Value;
            var reservation = _reservationRepository.GetById(selectedId);

            if (reservation != null)
            {
                comboBoxUsers.SelectedValue = reservation.UserId;
                comboBoxBooks.SelectedValue = reservation.BookId;
                dateTimePickerStart.Value = reservation.StartDate == DateTime.MinValue ? DateTime.Today : reservation.StartDate;
                dateTimePickerEnd.Value = reservation.EndDate == DateTime.MinValue ? DateTime.Today : reservation.EndDate;
            }
        }
    }
}

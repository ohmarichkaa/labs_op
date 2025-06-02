using System;
using System.Collections.Generic;
using System.Linq;
using lab6_op.Models;
using lab6_op.Repositories;

namespace lab6_op.Services
{
    public class ReservationService
    {
        private readonly IRepository<Reservation> _reservationRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Book> _bookRepository;

        public ReservationService(
            IRepository<Reservation> reservationRepository,
            IRepository<User> userRepository,
            IRepository<Book> bookRepository)
        {
            _reservationRepository = reservationRepository;
            _userRepository = userRepository;
            _bookRepository = bookRepository;
        }

        public List<Reservation> GetAllReservations() => _reservationRepository.GetAll();

        public Reservation GetReservationById(int id) => _reservationRepository.GetById(id);

        public (bool, string) AddReservation(int userId, int bookId, DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
                return (false, "Дата початку не може бути пізнішою за дату кінця.");

            var book = _bookRepository.GetById(bookId);
            if (book == null || !book.Available)
                return (false, "Ця книга вже заброньована або не знайдена.");

            var nextId = _reservationRepository.GetAll().Count == 0
                ? 1
                : _reservationRepository.GetAll().Max(r => r.ID) + 1;

            var newReservation = new Reservation(nextId, userId, bookId);
            newReservation.Reserve(startDate, endDate);

            _reservationRepository.Add(newReservation);
            book.Available = false;
            _bookRepository.Update(book);

            return (true, "Успішно заброньовано.");
        }

        public (bool, string) UpdateReservation(int id, int userId, int bookId, DateTime startDate, DateTime endDate)
        {
            var reservation = _reservationRepository.GetById(id);
            if (reservation == null)
                return (false, "Бронювання не знайдено.");

            if (startDate > endDate)
                return (false, "Дата початку не може бути пізнішою за дату кінця.");

            if (reservation.BookId != bookId)
            {
                var oldBook = _bookRepository.GetById(reservation.BookId);
                var newBook = _bookRepository.GetById(bookId);

                if (newBook == null || !newBook.Available)
                    return (false, "Нова книга недоступна для бронювання.");

                oldBook.Available = true;
                newBook.Available = false;

                _bookRepository.Update(oldBook);
                _bookRepository.Update(newBook);

                reservation.BookId = bookId;
            }

            reservation.UserId = userId;
            reservation.Reserve(startDate, endDate);
            _reservationRepository.Update(reservation);

            return (true, "Бронювання оновлено.");
        }

        public void RemoveReservation(int id)
        {
            var reservation = _reservationRepository.GetById(id);
            if (reservation == null) return;

            var book = _bookRepository.GetById(reservation.BookId);
            if (book != null)
            {
                book.Available = true;
                _bookRepository.Update(book);
            }

            _reservationRepository.Remove(reservation);
        }
    }
}

using lab6_op.Data;
using lab6_op.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace lab6_op.Services
{
    public class ReservationService
    {
        private readonly LibraryContext _context;

        public ReservationService(LibraryContext context)
        {
            _context = context;
        }

        public List<Reservation> GetAllReservations() => _context.Reservations.ToList();

        public Reservation GetReservationById(int id) => _context.Reservations.Find(id);

        public (bool, string) AddReservation(int userId, int bookId, DateTime start, DateTime end)
        {
            var book = _context.Books.Find(bookId);
            if (book == null || !book.Available)
                return (false, "Книга недоступна");

            var reservation = new Reservation(0, userId, bookId);
            reservation.Reserve(start, end);
            book.Available = false;

            _context.Reservations.Add(reservation);
            _context.SaveChanges();
            return (true, null);
        }

        public (bool, string) UpdateReservation(int id, int userId, int bookId, DateTime start, DateTime end)
        {
            var reservation = _context.Reservations.Find(id);
            if (reservation == null) return (false, "Не знайдено");

            reservation.UserId = userId;
            reservation.BookId = bookId;
            reservation.Reserve(start, end);

            _context.SaveChanges();
            return (true, null);
        }

        public void RemoveReservation(int id)
        {
            var reservation = _context.Reservations.Find(id);
            if (reservation != null)
            {
                var book = _context.Books.Find(reservation.BookId);
                if (book != null) book.Available = true;

                _context.Reservations.Remove(reservation);
                _context.SaveChanges();
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6_op.Models
{
    class BookReservation : Reservation, IReservation
    {
        private Book Book { get; set; }
        private User User { get; set; }

        public override bool IsReserved { get; set; }

        public BookReservation(int id, int userId, int bookId, Book book, User user) : base(id, userId, bookId)
        {
            Book = book;
            User = user;
            IsReserved = false;
        }

        public override void Reserve(DateTime startDate, DateTime endDate)
        {
            if (Book.Available && !IsReserved)
            {
                base.Reserve(startDate, endDate);
                Book.Available = false;
                Console.WriteLine($"Книга '{Book.Title}' заброньована користувачем {User.FirstName} з {StartDate.ToShortDateString()} до {EndDate.ToShortDateString()}.");
            }
            else
            {
                Console.WriteLine("Неможливо забронювати книгу. Вона вже заброньована.");
            }
        }
    }

}


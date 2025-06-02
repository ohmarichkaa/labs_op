using System;

namespace lab6_op.Models
{
    class BookReservation : Reservation, IReservation
    {
        public Book Book { get; private set; }
        public User User { get; private set; }

        public override bool IsReserved { get; set; }

        public BookReservation(int id, int userId, int bookId, Book book, User user)
            : base(id, userId, bookId)
        {
            Book = book ?? throw new ArgumentNullException(nameof(book));
            User = user ?? throw new ArgumentNullException(nameof(user));
            IsReserved = false;
        }

        public override void Reserve(DateTime startDate, DateTime endDate)
        {
            if (Book.Available && !IsReserved)
            {
                base.Reserve(startDate, endDate);
                Book.Available = false;

                Console.WriteLine(
                    $"Книга '{Book.Title}' заброньована користувачем {User.FirstName} з {StartDate:dd.MM.yyyy} до {EndDate:dd.MM.yyyy}.");
            }
            else
            {
                Console.WriteLine($"Неможливо забронювати книгу '{Book.Title}'. Вона вже заброньована.");
            }
        }

        public override void CancelReservation()
        {
            base.CancelReservation();
            Book.Available = true;

            Console.WriteLine($"Бронювання книги '{Book.Title}' скасовано.");
        }
    }
}

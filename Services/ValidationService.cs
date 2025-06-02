using System;
using System.Text.RegularExpressions;
using lab6_op.Models;

namespace lab6_op.Services
{
    public class ValidationService
    {
        public bool ValidateUser(User user, out string error)
        {
            if (string.IsNullOrWhiteSpace(user.FirstName) || string.IsNullOrWhiteSpace(user.LastName))
            {
                error = "Ім'я та прізвище не можуть бути порожніми.";
                return false;
            }

            if (!Regex.IsMatch(user.Email ?? "", @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                error = "Невірний формат email.";
                return false;
            }

            if (!Regex.IsMatch(user.Phone ?? "", @"^\d{10}$"))
            {
                error = "Телефон має містити 10 цифр.";
                return false;
            }

            error = null;
            return true;
        }

        public bool ValidateBook(Book book, out string error)
        {
            if (string.IsNullOrWhiteSpace(book.Title) || string.IsNullOrWhiteSpace(book.Author))
            {
                error = "Назва книги та автор є обов'язковими.";
                return false;
            }

            if (book.Year < 1500 || book.Year > DateTime.Now.Year)
            {
                error = "Рік видання вказано некоректно.";
                return false;
            }

            if (book.Pages <= 0)
            {
                error = "Кількість сторінок має бути додатною.";
                return false;
            }

            error = null;
            return true;
        }

        public bool ValidateReservationDates(DateTime startDate, DateTime endDate, out string error)
        {
            if (startDate > endDate)
            {
                error = "Дата початку не може бути пізнішою за дату завершення.";
                return false;
            }

            if (startDate.Date < DateTime.Today)
            {
                error = "Дата початку не може бути в минулому.";
                return false;
            }

            error = null;
            return true;
        }
    }
}

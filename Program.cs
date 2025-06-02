using lab6_op.Data;
using lab6_op.Forms;
using lab6_op.Models;
using lab6_op.Services;

namespace lab6_op
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            using var context = new LibraryContext();

            var bookService = new BookService(context);
            var userService = new UserService(context);
            var reservationService = new ReservationService(context);
            var authService = new AuthService(context);

            Application.Run(new StartForm());
        }
    }
}
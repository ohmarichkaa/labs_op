using lab6_op.Data;
using lab6_op.Models;
using System.Collections.Generic;

namespace lab6_op.Services
{
    public class BookService
    {
        private readonly LibraryContext _context;

        public BookService(LibraryContext context)
        {
            _context = context;
        }

        public List<Book> GetAllBooks() => _context.Books.ToList();

        public Book GetBookById(int id) => _context.Books.FirstOrDefault(b => b.ID == id);

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }

        public void RemoveBook(Book book)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}

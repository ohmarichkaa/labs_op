using lab6_op.Data;
using lab6_op.Models;
using System.Collections.Generic;
using System.Linq;

namespace lab6_op.Services
{
    public class UserService
    {
        private readonly LibraryContext _context;

        public UserService(LibraryContext context)
        {
            _context = context;
        }

        public List<User> GetAllUsers() => _context.Users.ToList();

        public User GetUserById(int id) => _context.Users.FirstOrDefault(u => u.ID == id);

        public void AddUser(string firstName, string lastName, string email, string phone)
        {
            var user = new User(0, firstName, lastName, email, phone);
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(int id, string firstName, string lastName, string email, string phone)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                user.FirstName = firstName;
                user.LastName = lastName;
                user.Email = email;
                user.Phone = phone;
                _context.SaveChanges();
            }
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public int GetNextUserId()
        {
            return _context.Users.Any() ? _context.Users.Max(u => u.ID) + 1 : 1;
        }
    }
}

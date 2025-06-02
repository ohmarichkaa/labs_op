using lab6_op.Data;
using lab6_op.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace lab6_op.Services
{
    public class AuthService
    {
        private readonly LibraryContext _context;

        private readonly UserService _userService;
        public AuthService(LibraryContext context)
        {
            _context = context;
            _userService= new UserService(context);
        }

        public UserReg Login(string username, string password)
        {
            var user = _context.UserRegs.FirstOrDefault(u => u.Username == username);
            if (user == null) return null;

            bool verified = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
            return verified ? user : null;
        }

        public UserReg GetUserByUsername(string username)
        {
            return _context.UserRegs.FirstOrDefault(u => u.Username == username);
        }

        public bool Register(string username, string password, string role, string firstName, string lastName, string email, string phone)
        {
            if (_context.UserRegs.Any(u => u.Username == username))
                return false;

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            var userReg = new UserReg(0, username, passwordHash, role);
            var user = new User(0, firstName, lastName, email, phone);

            _context.UserRegs.Add(userReg);
            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }
    }
}

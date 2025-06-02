using System;
using System.Collections.Generic;
using System.Linq;
using lab6_op.Repositories;
using lab6_op.Models;

namespace lab6_op.Models
{
    public class AuthService
    {
        private readonly IRepository<UserReg> _userRegRepository;
        private readonly IRepository<User> _userRepository;

        public AuthService(IRepository<UserReg> userRegRepository, IRepository<User> userRepository)
        {
            _userRepository = userRepository;
            _userRegRepository = userRegRepository;
        }

        public UserReg Login(string username, string password)
        {
            var user = _userRegRepository.GetAll().FirstOrDefault(u => u.Username == username);
            if (user == null) return null;

            bool verified = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
            return verified ? user : null;
        }

        public UserReg GetUserByUsername(string username)
        {
            return _userRegRepository.GetAll().FirstOrDefault(u => u.Username == username);
        }

        public bool Register(string username, string password, string role, string firstName, string lastName, string email, string phone)
        {
            if (_userRegRepository.GetAll().Any(u => u.Username == username))
                return false;

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

            var userReg = new UserReg(0, username, passwordHash, role);
            _userRegRepository.Add(userReg);

            var user = new User(0, firstName, lastName, email, phone);
            _userRepository.Add(user);

            return true;
        }
    }
}

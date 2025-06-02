using System.Collections.Generic;
using System.Linq;
using lab6_op.Models;
using lab6_op.Repositories;

namespace lab6_op.Services
{
    public class UserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public User? GetUserById(int id)
        {
            return _userRepository.GetById(id);
        }

        public void AddUser(string firstName, string lastName, string email, string phone)
        {
            int nextId = GetNextUserId();
            var user = new User(nextId, firstName, lastName, email, phone);
            _userRepository.Add(user);
        }

        public void UpdateUser(int id, string firstName, string lastName, string email, string phone)
        {
            var user = _userRepository.GetById(id);
            if (user != null)
            {
                user.FirstName = firstName;
                user.LastName = lastName;
                user.Email = email;
                user.Phone = phone;
                _userRepository.Update(user);
            }
        }

        public void DeleteUser(int id)
        {
            var user = _userRepository.GetById(id);
            if (user != null)
            {
                _userRepository.Remove(user);
            }
        }

        private int GetNextUserId()
        {
            var users = _userRepository.GetAll();
            return users.Count == 0 ? 1 : users.Max(u => u.ID) + 1;
        }
    }
}

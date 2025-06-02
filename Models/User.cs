using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6_op.Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        private string phone;

        public string Phone
        {
            get => phone;
            set => phone = value;
        }

        public User(int id, string firstName, string lastName, string email, string phone) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"User: {FirstName} {LastName}, Email: {Email}");
        }
    }
}


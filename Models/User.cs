using System;
using System.ComponentModel.DataAnnotations;

namespace lab6_op.Models
{
    public class User : BaseEntity
    {
        [Required(ErrorMessage = "Ім'я обов'язкове")]
        [StringLength(50, ErrorMessage = "Ім'я не може бути довшим за 50 символів")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Прізвище обов'язкове")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email обов'язковий")]
        [EmailAddress(ErrorMessage = "Невірний формат email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Телефон обов'язковий")]
        [Phone(ErrorMessage = "Невірний формат телефону")]
        public string Phone { get; set; }

        public User(int id, string firstName, string lastName, string email, string phone)
            : base(id)
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

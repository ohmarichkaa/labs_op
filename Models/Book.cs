using System;
using System.ComponentModel.DataAnnotations;

namespace lab6_op.Models
{
    public class Book : BaseEntity
    {
        [Required(ErrorMessage = "Назва книги є обов’язковою")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Назва повинна містити від 1 до 100 символів")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Автор книги є обов’язковим")]
        [StringLength(100)]
        public string Author { get; set; }

        [Range(1000, 2100, ErrorMessage = "Рік повинен бути у діапазоні 1000-2100")]
        public int Year { get; set; }

        [Range(1, 5000, ErrorMessage = "Кількість сторінок повинна бути більше 0")]
        public int Pages { get; set; }

        public bool Available { get; set; } = true;

        public Book(int id, string title, string author, int year, int pages) : base(id)
        {
            Title = title;
            Author = author;
            Year = year;
            Pages = pages;
        }

        public string GetStatus() => Available ? "Доступна" : "Заброньована";

        public override void PrintInfo()
        {
            Console.WriteLine($"Книга: {Title} ({Author}, {Year}) - {GetStatus()}");
        }
    }
}

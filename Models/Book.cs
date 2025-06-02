using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6_op.Models
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public int Pages { get; set; }
        public bool Available { get; set; } = true;

        public Book(int id, string title, string author, int year, int pages) : base(id)
        {
            Title = title;
            Author = author;
            Year = year;
            Pages = pages;
        }

        public string GetStatus()
        {
            return Available ? "Доступна" : "Заброньована";
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Книга: {Title} ({Author}, {Year}) - {GetStatus()}");
        }
    }

}

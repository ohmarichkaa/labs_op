using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lab6_op.Models;
using lab6_op.Repositories;
using lab6_op.Services;

namespace lab6_op.Forms
{
    public partial class UUSerForm : Form
    {
        private readonly UserReg _currentUser;
        private readonly BookService _bookService;

        public UUSerForm(UserReg user, BookService bookService)
        {
            InitializeComponent();
            _currentUser = user;
            _bookService = bookService;

            LoadBooks();
        }

        private void LoadBooks()
        {
            var books = _bookService.GetAllBooks();
            dataGridView1.DataSource = books.Select(b => new
            {
                b.ID,
                b.Title,
                b.Author,
                b.Year,
                b.Pages,
                Available = b.Available ? "Так" : "Ні"
            }).ToList();
        }

        private void UUSerForm_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int selectedId = (int)dataGridView1.CurrentRow.Cells["ID"].Value;
                var book = _bookService.GetBookById(selectedId);

                if (book != null && book.Available)
                {
                    book.Available = false;
                    _bookService.UpdateBook(book);
                    MessageBox.Show($"Книгу \"{book.Title}\" заброньовано!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadBooks();
                }
                else
                {
                    MessageBox.Show("Книга недоступна для бронювання.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}

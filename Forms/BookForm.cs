using System;
using System.Linq;
using System.Windows.Forms;
using lab6_op.Models;
using lab6_op.Services;

namespace lab6_op.Forms
{
    public partial class BookForm : Form
    {
        private readonly BookService _bookService;

        public BookForm(BookService bookService)
        {
            InitializeComponent();
            _bookService = bookService;

            if (_bookService.GetAllBooks().Count == 0)
            {
                _bookService.AddBook(new Book(1, "Кобзар", "Тарас Шевченко", 1840, 200) { Available = true });
                _bookService.AddBook(new Book(2, "Фауст", "Й.В. Ґете", 1808, 350) { Available = true });
                _bookService.AddBook(new Book(3, "Майстер і Маргарита", "Булгаков", 1967, 400) { Available = true });
            }

            LoadBooks();
        }

        private void LoadBooks()
        {
            var books = _bookService.GetAllBooks();
            dataGridViewBooks.DataSource = null;
            dataGridViewBooks.AutoGenerateColumns = true;

            dataGridViewBooks.DataSource = books.Select(b => new
            {
                b.ID,
                b.Title,
                b.Author,
                b.Year,
                b.Pages,
                Available = b.Available ? "Доступна" : "Заброньована"
            }).ToList();
        }

        private int GetNextBookId()
        {
            var books = _bookService.GetAllBooks();
            return books.Count == 0 ? 1 : books.Max(b => b.ID) + 1;
        }

        private void ClearInputFields()
        {
            txtTitle.Text = "";
            txtAuthor.Text = "";
            txtYear.Text = "";
            txtPages.Text = "";
            chkAvailable.Checked = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var newBook = new Book(
                    GetNextBookId(),
                    txtTitle.Text,
                    txtAuthor.Text,
                    int.Parse(txtYear.Text),
                    int.Parse(txtPages.Text)
                )
                {
                    Available = chkAvailable.Checked
                };

                _bookService.AddBook(newBook);
                LoadBooks();
                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при додаванні книги: {ex.Message}");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.SelectedRows.Count > 0)
            {
                int selectedId = (int)dataGridViewBooks.SelectedRows[0].Cells["ID"].Value;
                var book = _bookService.GetBookById(selectedId);
                if (book != null)
                {
                    book.Title = txtTitle.Text;
                    book.Author = txtAuthor.Text;
                    book.Year = int.Parse(txtYear.Text);
                    book.Pages = int.Parse(txtPages.Text);
                    book.Available = chkAvailable.Checked;

                    _bookService.UpdateBook(book);
                    LoadBooks();
                    ClearInputFields();
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть книгу для редагування.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.SelectedRows.Count > 0)
            {
                int selectedId = (int)dataGridViewBooks.SelectedRows[0].Cells["ID"].Value;
                var book = _bookService.GetBookById(selectedId);
                if (book != null)
                {
                    _bookService.RemoveBook(book);
                    LoadBooks();
                    ClearInputFields();
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть книгу для видалення.");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadBooks();
        }

        private void dataGridViewBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewBooks.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewBooks.SelectedRows[0];
                txtTitle.Text = selectedRow.Cells["Title"].Value.ToString();
                txtAuthor.Text = selectedRow.Cells["Author"].Value.ToString();
                txtYear.Text = selectedRow.Cells["Year"].Value.ToString();
                txtPages.Text = selectedRow.Cells["Pages"].Value.ToString();
                chkAvailable.Checked = selectedRow.Cells["Available"].Value.ToString() == "Доступна";
            }
        }
    }
}

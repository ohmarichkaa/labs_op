using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lab6_op.Models;
using lab6_op.Repositories;

namespace lab6_op.Forms
{
    public partial class BookForm : Form
    {
        private readonly Repository<Book> _bookRepository;


        public BookForm(Repository<Book> bookRepository)
        {
            InitializeComponent();

            _bookRepository = bookRepository;

            if (_bookRepository.GetAll().Count == 0)
            {
                _bookRepository.Add(new Book(1, "Кобзар", "Тарас Шевченко", 1840, 200) { Available = true });
                _bookRepository.Add(new Book(2, "Фауст", "Й.В. Ґете", 1808, 350) { Available = true });
                _bookRepository.Add(new Book(3, "Майстер і Маргарита", "Булгаков", 1967, 400) { Available = true });
            }

            LoadBooks();
        }



        private void LoadBooks()
        {
            var books = _bookRepository.GetAll();
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
            var books = _bookRepository.GetAll();
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
        private void BookForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

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

                _bookRepository.Add(newBook);
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
                var book = _bookRepository.GetById(selectedId);
                if (book != null)
                {
                    book.Title = txtTitle.Text;
                    book.Author = txtAuthor.Text;
                    book.Year = int.Parse(txtYear.Text);
                    book.Pages = int.Parse(txtPages.Text);
                    book.Available = chkAvailable.Checked;

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
                var book = _bookRepository.GetById(selectedId);
                if (book != null)
                {
                    _bookRepository.Remove(book);
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

        private void txtPages_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkAvailable_CheckedChanged(object sender, EventArgs e)
        {

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

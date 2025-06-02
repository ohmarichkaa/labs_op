using System;
using System.Linq;
using System.Windows.Forms;
using lab6_op.Models;
using lab6_op.Services;

namespace lab6_op.Forms
{
    public partial class UserForm : Form
    {
        private readonly UserService _userService;
        private readonly ValidationService _validationService = new ValidationService();

        public UserForm(UserService userService)
        {
            InitializeComponent();
            _userService = userService;
            LoadUsers();
        }

        private void LoadUsers()
        {
            var users = _userService.GetAllUsers();
            dataGridViewUsers.DataSource = users.Select(u => new
            {
                u.ID,
                u.FirstName,
                u.LastName,
                u.Email,
                u.Phone
            }).ToList();
        }

        private int GetNextUserId()
        {
            var users = _userService.GetAllUsers();
            return users.Count == 0 ? 1 : users.Max(u => u.ID) + 1;
        }

        private void ClearInputFields()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var newUser = new User(GetNextUserId(), txtFirstName.Text, txtLastName.Text, txtEmail.Text, txtPhone.Text);

                if (!_validationService.ValidateUser(newUser, out string error))
                {
                    MessageBox.Show(error, "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _userService.AddUser(newUser.FirstName, newUser.LastName, newUser.Email, newUser.Phone);

                LoadUsers();
                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при додаванні користувача: {ex.Message}");
            }
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count > 0)
            {
                int selectedId = (int)dataGridViewUsers.SelectedRows[0].Cells["ID"].Value;

                var updatedUser = new User(selectedId, txtFirstName.Text, txtLastName.Text, txtEmail.Text, txtPhone.Text);

                if (!_validationService.ValidateUser(updatedUser, out string error))
                {
                    MessageBox.Show(error, "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _userService.UpdateUser(updatedUser.ID, updatedUser.FirstName, updatedUser.LastName, updatedUser.Email, updatedUser.Phone);
                LoadUsers();
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть користувача для редагування.");
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count > 0)
            {
                int selectedId = (int)dataGridViewUsers.SelectedRows[0].Cells["ID"].Value;
                var user = _userService.GetUserById(selectedId);
                if (user != null)
                {
                    _userService.DeleteUser(selectedId);
                    LoadUsers();
                    ClearInputFields();
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть користувача для видалення.");
            }
        }

        private void brnRefresh_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void dataGridViewUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewUsers.SelectedRows[0];
                txtFirstName.Text = selectedRow.Cells["FirstName"].Value.ToString();
                txtLastName.Text = selectedRow.Cells["LastName"].Value.ToString();
                txtEmail.Text = selectedRow.Cells["Email"].Value.ToString();
                txtPhone.Text = selectedRow.Cells["Phone"].Value.ToString();
            }
        }
    }
}

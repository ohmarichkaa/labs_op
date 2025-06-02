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
    public partial class LoginForm : Form
    {
        private readonly AuthService _authService;

        public LoginForm()
        {
            InitializeComponent();

            // Репозиторій книг (через Holder)
            if (Holder.BookRepository.GetAll().Count == 0)
            {
                Holder.BookRepository.Add(new Book(1, "Кобзар", "Тарас Шевченко", 1840, 200) { Available = true });
                Holder.BookRepository.Add(new Book(2, "Фауст", "Й.В. Ґете", 1808, 350) { Available = true });
                Holder.BookRepository.Add(new Book(3, "Майстер і Маргарита", "Булгаков", 1967, 400) { Available = true });
            }

            // Репозиторії користувачів (оновлені)
            var userRegRepository = new Repository<UserReg>(
                new JsonStorage<UserReg>("userregs.json"));

            var userRepository = new Repository<User>(
                new JsonStorage<User>("users.json"));

            // Ініціалізація AuthService
            _authService = new AuthService(userRegRepository, userRepository);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var username = txtLoginUsername.Text.Trim();
            var password = txtLoginPassword.Text;

            var user = _authService.Login(username, password);

            if (user != null)
            {
                MessageBox.Show($"Ласкаво просимо, {user.Username}!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (user.Role == "Admin")
                {
                    MainForm adminForm = new MainForm(user);
                    adminForm.Show();
                }
                else
                {
                    var userForm = new UUSerForm(user);
                    userForm.Show();
                }

                this.Hide();
            }
            else
            {
                MessageBox.Show("Невірний логін або пароль.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

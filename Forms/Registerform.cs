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
    public partial class Registerform : Form
    {



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblConfirm_Click(object sender, EventArgs e)
        {

        }

        private void txtConfirm_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }
        private readonly AuthService _authService;

        public Registerform()
        {
            InitializeComponent();

            var userRegRepo = new Repository<UserReg>(
                new JsonStorage<UserReg>("userregs.json"));

            var userRepo = new Repository<User>(
                new JsonStorage<User>("users.json"));

            _authService = new AuthService(userRegRepo, userRepo);
        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            var username = txtUserName.Text.Trim();
            var password = txtPassword.Text;
            var confirm = txtConfirm.Text;

            var firstName = txtFirstName.Text.Trim();
            var lastName = txtLast.Text.Trim();
            var email = txtEmail.Text.Trim();
            var phone = txtPhone.Text.Trim();

            if (password != confirm)
            {
                MessageBox.Show("Паролі не співпадають!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var success = _authService.Register(username, password, firstName, lastName, email, phone, "User");

            if (success)
            {
                MessageBox.Show("Реєстрація успішна!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Отримати створеного користувача з репозиторію
                var user = _authService.GetUserByUsername(username); // Тебе треба додати цей метод в AuthService

                var userForm = new UUSerForm(user);
                userForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Користувач з таким іменем вже існує.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Registerform_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLast_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

   

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }
    }
}

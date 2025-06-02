using lab6_op.Models;
using lab6_op.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab6_op.Forms
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private readonly AuthService _authService = new AuthService(
            new Repository<UserReg>(new JsonStorage<UserReg>("userregs.json")),
            new Repository<User>(new JsonStorage<User>("users.json"))
        );

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var loginForm = new LoginForm(_authService);
            loginForm.Show();
            this.Hide();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var registerForm = new Registerform(_authService);
            registerForm.Show();
            this.Hide();
        }
    }
}

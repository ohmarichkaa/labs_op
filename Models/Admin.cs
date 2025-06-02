using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6_op.Models
{
    class Admin : BaseEntity
    {
        public string Login { get; set; }
        private string password;

        public string Password
        {
            get => password;
            set => password = value;
        }

        public Admin(int id, string login, string password) : base(id)
        {
            Login = login;
            Password = password;
        }
    }

}

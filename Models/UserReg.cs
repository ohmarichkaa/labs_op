using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6_op.Models
{

    public class UserReg : BaseEntity
    {

        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }

        public UserReg(int id, string username, string passwordHash,string role)
            : base(id)
        {
            Username = username;
            PasswordHash = passwordHash;
            Role = role;
        }
    }

}

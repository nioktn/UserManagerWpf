using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManager.Domain
{
    public class User
    {
        public User(string lastName, string name, string login, string password, int active)
        {
            this.LastName = lastName;
            this.Name = name;
            this.Login = login;
            this.Password = password;
            this.Active = active;
        }


        public User()
        { }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Active { get; set; } = 0;
    }
}
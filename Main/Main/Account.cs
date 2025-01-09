using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    internal class Account
    {


        private string Username { get; set; }
        public string Password { get; set; }

      
        public Account()
        {
        }

        public Account(string username, string password)
        {
            // Gán giá trị cho thuộc tính
            Username = username;
            Password = password;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedClasses
{
    public class User
    {
        private string username;
        private string password;
        private int id;

        public User(string username, int id, string password)
        {
            this.username = username;
            this.id = id;
            this.password = password;
        }


        public int getId()
        {
            return id;
        }

        public string getPassword()
        {
            return password;
        }

        public void setPassword(string pass)
        {
            password = pass;
        }
    }
}

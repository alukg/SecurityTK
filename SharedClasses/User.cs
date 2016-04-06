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
        private int line;

        public User(string username, int line, string password)
        {
            this.username = username;
            this.line = line;
            this.password = password;
        }


        public int getLine()
        {
            return line;
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

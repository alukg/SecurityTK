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
          //  private int line;

            public User(string username)
            {

                this.username = username;
            }


            public User(string username, string password)
            {
                this.username = username;
                this.password = password;
            }

        /*    public int getLine()
            {
                  return line;
            }*/

            public string getUsername()
            {
                return username;
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

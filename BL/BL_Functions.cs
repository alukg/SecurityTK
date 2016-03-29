using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedClasses;

namespace BL
{
    public class BL_Function : IBL
    {
        public bool verifyCardentials(string username, string password)
        {
            return true;
        }

        public void setPassword(User user, string pass)
        {
            user.setPassword(pass);
        }

        public void setPassword(User user)
        {
            string pass = "";
            bool ans = false;
            Random rnd = new Random();
            for (int i = 0; i < 8; i++) { 
                if (i == 7 && !ans)
                {
                    pass = pass + ((char)rnd.Next(48,58));
                }
                else
                {
                    pass=pass+ ((char)rnd.Next(33, 127));
                }
            }

            setPassword(user, pass);
        }

        public bool checkPassword(String password)
        {
            bool ans = false;
            if (password.Length == 8)
            {
                for (int i = 0; i < password.Length && !ans; i++)
                {
                    if (password[i] >= 48 || password[i] <= 57)
                        ans = true;
                }
            }
            return ans;
        }
    }
}


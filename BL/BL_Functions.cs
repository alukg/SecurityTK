using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedClasses;
using DAL;

namespace BL
{
    public class BL_Functions: IBL
    {
        private IDAL itsDAL;
        public BL_Functions(IDAL itsDAL)
        {
            this.itsDAL = itsDAL;
        }

      /*  // checks if the username is in the database.
        public int findUsername(String username)
        {
            return itsDAL.getLine(username);
           
        }*/

        public bool verifyCardentials(string username, string enteredPassword)
        {
            if (username == null)
                throw new Exception("The username is null");
            if (enteredPassword == null)
                throw new Exception("The password is null");
            String currentPassword = itsDAL.getPassword(username);
            if (currentPassword.Equals(enteredPassword))
               return true;
            else
               return false;
         }
        //set user's password 
        public void setPassword(User user, string pass)
        {
            itsDAL.setPassword(user.getUsername(), pass);
        }

        //create a random password 
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
        
        //check if thr password is legal
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



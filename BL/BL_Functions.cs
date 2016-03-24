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

        // checks if the username is in the database.
        public int findUsername(String username)
        {
            return itsDAL.getLine(username);
           
        }

        public bool verifyCardentials(string username, string enteredPassword)
        {
            if (username == null)
                throw new Exception("The username is null");
            if (enteredPassword == null)
                throw new Exception("The password is null");
            int line = findUsername(username);
            String currentPassword = itsDAL.getPassword(line);
            if (currentPassword.Equals(enteredPassword))
               return true;
            else
               return false;
            }
        }

        public void setPassword(User user)
        {
            throw new NotImplementedException();
        }

        public void setPassword(User user, string pass)
        {
            throw new NotImplementedException();
        }


    }
}

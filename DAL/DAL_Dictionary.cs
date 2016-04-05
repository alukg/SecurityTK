using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedClasses;


namespace DAL
{
    public class DAL_Dictionary : IDAL
    {
        public string getPassword(string userName)
        {
            if (userName == null) //checks if the input is legal.
            {
                throw new Exception("input is null");
            }
            Dictionary<string, string> UsersDB = Serializer.getFromBinaryFile();
            User currUser = new User((UsersDB[userName]));
            if(UsersDB[userName]==null)
                throw new KeyNotFoundException("There is no such user in the DataBase");
            else
                return currUser.getPassword();
        }
        
        public void setPassword(string userName, string newPassword)
        {
            if (userName == null | newPassword == null) //checks if the input is legal.
            {
                throw new Exception("input is null");
            }
            Dictionary<string,string> UsersDB = Serializer.getFromBinaryFile();
            User currUser = new User((UsersDB[userName]));
            if (UsersDB[userName] == null)
                throw new KeyNotFoundException("There is no such user in the DataBase");
            else
            {
                currUser.setPassword(newPassword);
                Serializer.saveToBinaryFile(UsersDB);
            }
        }

    }
}

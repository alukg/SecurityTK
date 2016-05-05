using DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BL_Tests
{
    public class UserFunctions
    {
        public IDAL itsDAL;

        public UserFunctions()
        {
            itsDAL = new DAL_SQL();
        }

        public string addUser(string myName, string userName, string pass, string role)
        {
            if (userNameExists(userName)) return "That Username already taken";
            if (checkPassword(pass))
            {
                itsDAL.setNewUser(userName, pass, role);
                itsDAL.writeToLog("Adding a new user", myName, userName);
                return "User added successfully";
            }
            else
            {
                return "Password is not good";
            }
        }

        public string addUser(string myName, string userName, string role)
        {
            if (userNameExists(userName)) return "That Username already taken";
            string randomPass = getRandomPass();
            itsDAL.setNewUser(userName, randomPass, role);
            itsDAL.writeToLog("Adding a new user", myName, userName);
            return "User added successfully. The password is: " + randomPass;
        }

        public string changePass(string myName, string userName)
        {
            string randomPass = getRandomPass();
            itsDAL.setPassword(userName, randomPass);
            itsDAL.writeToLog("Changing password", myName, userName);
            return "Password changed successfully. The new password is: " + randomPass;
        }

        public string changePass(string myName, string userName, string pass)
        {
            if (checkPassword(pass))
            {
                itsDAL.setPassword(userName, pass);
                itsDAL.writeToLog("Changing password", myName, userName);
                return "Password changed successfully";
            }
            else
            {
                return "Password is not good";
            }
        }


        //Help functions
        private string getRandomPass()
        {
            string pass = "";
            bool thereIsNumber = false;
            Random rnd = new Random();
            for (int i = 0; i < 8; i++)
            {
                if (i == 7 && !thereIsNumber)
                {
                    pass = pass + ((char)rnd.Next(48, 58));
                }
                else
                {
                    int charType = rnd.Next(3); //decide whice group of numbers will be chosen for the next char
                    int nextChar;

                    if (charType == 0) { nextChar = rnd.Next(48, 58); }
                    else if (charType == 1) { nextChar = rnd.Next(65, 91); }
                    else { nextChar = rnd.Next(97, 123); }

                    if (nextChar >= 48 && nextChar <= 57) thereIsNumber = true; //if there is a number in the password
                    pass = pass + (char)nextChar;
                }
            }
            return pass;
        }

        private bool checkPassword(string pass)
        {
            if (pass == null) throw new Exception("the pass is null");
            if (pass.Length != 8) return false;
            bool ans = false;
            byte[] ASCIIValues = Encoding.ASCII.GetBytes(pass);
            for (int i = 0; i < pass.Length; i++)
            {
                if (ASCIIValues[i] >= 48 || ASCIIValues[i] <= 57) ans = true;
                else if (ASCIIValues[i] >= 65 || ASCIIValues[i] <= 90) continue;
                else if (ASCIIValues[i] >= 97 || ASCIIValues[i] <= 122) continue;
                else
                {
                    throw new Exception("there is illegal char in the password");
                }
            }
            return ans;
        }

        public bool userNameExists(string userName)
        {
            if (itsDAL.checkUserName(userName) == 0) return false;
            else return true;
        }
    }
}



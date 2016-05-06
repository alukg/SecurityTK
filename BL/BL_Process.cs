﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using SharedClasses;

namespace BL
{
    public class BL_Process : IBL
    {
        private IDAL itsDAL;
        internal User currUser;

        public BL_Process(IDAL itsDAL)
        {
            this.itsDAL = itsDAL;
            currUser = null;
        }

        public bool userVarification(string userName, string enteredPassword)
        {
            if (userName == null)
                throw new ArgumentNullException("The username is null");
            if (enteredPassword == null)
                throw new ArgumentNullException("The password is null");
            userName = userName.ToLower();
            if (!itsDAL.userNameExists(userName)) return false; //There is no such user
            string currentPassword = itsDAL.getPassword(userName);
            if (currentPassword.Equals(enteredPassword))
            {
                string userRole = itsDAL.getRole(userName);
                currUser = new User(userName, currentPassword, userRole);
                return true;
            }
            else
                return false;
        }

        public string changeRole(string userName, string newRole)
        {
            if (currUser.role.Equals("Administrator")){
                if (userName == null)
                    throw new ArgumentNullException("The username is null");
                if (newRole == null)
                    throw new ArgumentNullException("The role is null");
                userName = userName.ToLower();
                if (!(newRole == "Administrator" || newRole == "Manager" || newRole == "Employee")) return "There is no such role";
                if (!itsDAL.userNameExists(userName)) return "Username don't exits";
                newRole = newRole.First().ToString().ToUpper() + newRole.Substring(1).ToString().ToLower();
                if (itsDAL.getRole(userName) == newRole) return "This user already in that role";
                itsDAL.setRole(userName, newRole);
                itsDAL.writeToLog("Changing role", currUser.userName, userName);
                if (currUser.userName.Equals(userName)) currUser = new User(currUser.userName,currUser.password,newRole);
                return "Role changed successfully";
            }
            else
            {
                return "No permission to perform the operation";
            }
        }

        public string removeUser(string userName) //need to check what happen with the admin when he erase himself, what to do with the current user???????
        {
            if (currUser.role.Equals("Administrator") || currUser.role.Equals("Manager"))
            {
                if (userName == null) throw new ArgumentNullException("Username input is null");
                userName = userName.ToLower();
                if (!itsDAL.userNameExists(userName)) return "Username does not exist";
                if (currUser.role.Equals("Manager") && !(itsDAL.getRole(userName).Equals("Employee")))
                    return "There is no permissions to remove this user";
                else
                {
                    itsDAL.removeUser(userName);
                    itsDAL.writeToLog("Removing user", currUser.userName, userName);
                    return "The user was removed successfully";
                }
            }
            else
            {
                return "No permission to perform the operation";
            }
        }

        public string addUser(string userName, string role)
        {
            if (currUser.role.Equals("Employee"))
            {
                return "No permission to perform the operation";
            }
            else
            {
                return addUser(userName, getRandomPass(), role);
            }
        }

        public string addUser(string userName, string pass, string role)
        {
            if (currUser.role.Equals("Employee"))
            {
                return "No permission to perform the operation";
            }
            else
            {
                if (userName == null) throw new ArgumentNullException("Username input is null");
                if (pass == null) throw new ArgumentNullException("Password input is null");
                if (role == null) throw new ArgumentNullException("Role input is null");
                userName = userName.ToLower();
                if (itsDAL.userNameExists(userName)) return "That Username already taken";
                if (!checkPassword(pass)) return "Password is not good";
                role = role.First().ToString().ToUpper() + role.Substring(1).ToString().ToLower();

                if (role == "Employee" || role == "Manager")
                {
                    itsDAL.setNewUser(userName, pass, role);
                    itsDAL.writeToLog("Adding a new user", currUser.userName, userName);
                    return "User added successfully. The password is: " + pass;
                }
                else if(role == "Administrator")
                {
                    if(currUser.role == "Administrator")
                    {
                        itsDAL.setNewUser(userName, pass, role);
                        itsDAL.writeToLog("Adding a new user", currUser.userName, userName);
                        return "User added successfully. The password is: " + pass;
                    }
                    else
                        return "There is no permission to add user with that role";
                }
                else
                {
                    return "There is no such role";
                }
            }
        }

        public string changePass(string userName)
        {
            if (userName == null) return "Username input is null";
            return changePass(userName, getRandomPass());
        }

        public string changePass(string userName, string pass)
        {
            if (userName == null) throw new ArgumentNullException("Username input is null");
            if (pass == null) throw new ArgumentNullException("Password input is null");
            userName = userName.ToLower();
            if (!itsDAL.userNameExists(userName)) return "Username does not exist";
            if (!checkPassword(pass)) return "Password is not good";
            if (pass.Equals(itsDAL.getPassword(userName))) return "The new password identical to the current one";
            if (currUser.userName == userName)
            {
                itsDAL.setPassword(userName, pass);
                itsDAL.writeToLog("Changing password", currUser.userName, userName);
                currUser = new User(currUser.userName, pass, currUser.role);
                return "Password changed successfully. The new password is: " + pass;
            }
            else
            {
                if(currUser.role == "Employee") return "There is no permissions";
                else if(currUser.role == "Manager" && !(itsDAL.getRole(userName) == "Employee"))
                {
                    return "There is no permissions";
                }
                else
                {
                    itsDAL.setPassword(userName, pass);
                    itsDAL.writeToLog("Changing password", currUser.userName, userName);
                    return "Password changed successfully. The new password is: " + pass;
                }
            }
        }

        public List<string> readLog()
        {
            if(currUser.role == "Administrator")
            {
                return itsDAL.getLog();
            }
            else
            {
                throw new Exception("No permission to perform the operation");
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
                if (ASCIIValues[i] >= 48 && ASCIIValues[i] <= 57) ans = true;
                else if (ASCIIValues[i] >= 65 && ASCIIValues[i] <= 90) continue;
                else if (ASCIIValues[i] >= 97 && ASCIIValues[i] <= 122) continue;
                else
                {
                    return false;
                }
            }
            return ans;
        }

    }
}
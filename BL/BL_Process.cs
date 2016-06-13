using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using SharedClasses;
using BL.UserTools;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Collections;

namespace BL
{
    /// <summary>
    /// That class contains all the functions for user managment.
    /// </summary>
    public class BL_Process : IBL
    {
        private IDAL itsDAL;
        internal User currUser;
        private DataLeakageTool dataLeakageTool;
        private FileCryptoTool fileCryptoTool;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="itsDAL"> The instance of the DAL layer for accessing the DB functions. </param>
        public BL_Process(IDAL itsDAL)
        {
            this.itsDAL = itsDAL;
            currUser = null;
            dataLeakageTool = new DataLeakageTool();
            fileCryptoTool = new FileCryptoTool();
        }

        /// <summary>
        /// returns object of the current user.
        /// </summary>
        /// <returns> current connected user </returns>
        public User getUser()
        {
            return currUser;
        }

        /// <summary>
        /// User log off from the system.
        /// </summary>
        public void logOff()
        {
            itsDAL.writeToLog("User log off", currUser.userName, null);
            currUser = null;
        }

        /// <summary>
        /// convert role from string to Role enum
        /// </summary>
        /// <param name="role"></param>
        /// <returns> Role object with the suitable role </returns>
        public Role convertRole(string role)
        {
            if (role == "Administrator") return Role.Administrator;
            else if (role == "Employee") return Role.Employee;
            else return Role.Manager;
        }

        /// <summary>
        /// varify the login of the user.
        /// </summary>
        /// <param name="userName"> username for enter </param>
        /// <param name="enteredPassword"> password for enter </param>
        /// <returns></returns>
        public bool userVarification(string userName, string enteredPassword)
        {
            //checks if the input is null.
            if (userName == null)
                throw new ArgumentNullException("The username is null");
            if (enteredPassword == null)
                throw new ArgumentNullException("The password is null");
            userName = userName.ToLower(); //low the username chars for prevanting issues.
            if (!itsDAL.userNameExists(userName)) return false; //if there is no such user
            string currentPassword = itsDAL.getPassword(userName);
            if (currentPassword.Equals(enteredPassword)) //if the password is right.
            {
                Role userRole = itsDAL.getRole(userName);
                currUser = new User(userName, currentPassword, userRole); //set this user to be the cuurent user.
                itsDAL.writeToLog("User log on", currUser.userName, null);
                return true;
            }
            else //if the password isn't good.
                return false;
        }

        /// <summary>
        /// changes the role of the requested person.
        /// </summary>
        /// <param name="userName"> username to change </param>
        /// <param name="newRole"> the new Role </param>
        /// <returns></returns>
        public string changeRole(string userName, Role newRole)
        {
            if (currUser.role.Equals(Role.Administrator)) //if the cuurent user is admin, so he can change role of other user.
            {
                if (userName == null)
                    throw new ArgumentNullException("The username is null");
                userName = userName.ToLower();
                if (!itsDAL.userNameExists(userName)) return "Username don't exits";
                if (itsDAL.getRole(userName).Equals(newRole)) return "This user already in that role"; //if the user is already in the requested role.
                itsDAL.setRole(userName, newRole);
                itsDAL.writeToLog("User changed role", currUser.userName, userName);
                if (currUser.userName.Equals(userName)) currUser = new User(currUser.userName,currUser.password,newRole); //if the user changed is role, update the curr user.
                return "Role changed successfully";
            }
            else
            {
                return "No permission to perform the operation";
            }
        }

        /// <summary>
        /// remove requested user from the database.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public string removeUser(string userName) //need to check what happen with the admin when he erase himself, what to do with the current user???????
        {
            if (currUser.role.Equals(Role.Administrator) || currUser.role.Equals(Role.Manager)) //checks that the curr user is admin or manager
            {
                if (userName == null) throw new ArgumentNullException("Username input is null");
                userName = userName.ToLower();
                if (currUser.userName.Equals(userName)) return "No permission to perform the operation"; //checks that user nor remove himself.
                if (!itsDAL.userNameExists(userName)) return "Username does not exist";
                if (currUser.role.Equals(Role.Manager) && !(itsDAL.getRole(userName).Equals(Role.Employee))) //if the curr user is manager, varify that can't remove someone isn't an employee.
                    return "There is no permissions to remove this user";
                else
                {
                    itsDAL.removeUser(userName);
                    itsDAL.writeToLog("Removed user", currUser.userName, userName);
                    return "The user was removed successfully";
                }
            }
            else //if the curr user is employee.
            {
                return "No permission to perform the operation";
            }
        }

        /// <summary>
        /// add new user with random password.
        /// </summary>
        /// <param name="userName"> username for the new user </param>
        /// <param name="role"> role for the new user </param>
        /// <returns></returns>
        public string addUser(string userName, Role role)
        {
            if (currUser.role.Equals(Role.Employee)) //employee can't add new user.
            {
                return "No permission to perform the operation";
            }
            else if (userName.Equals(""))
                return "Please enter a Username";
            else
            {
                return addUser(userName, getRandomPass(), role); //choose random password, and send for addUser function with that pass.
            }
        }

        /// <summary>
        /// function for adding a new user.
        /// </summary>
        /// <param name="userName"> username for the new user. </param>
        /// <param name="pass"> password for the new user. </param>
        /// <param name="role"> role for the new user. </param>
        /// <returns></returns>
        public string addUser(string userName, string pass, Role role)
        {
            if (currUser.role.Equals(Role.Employee)) //varify that employee can't add a new user.
            {
                return "No permission to perform the operation";
            }
            else
            {
                if (userName == null) throw new ArgumentNullException("Username input is null");
                if (pass == null) throw new ArgumentNullException("Password input is null");
                userName = userName.ToLower();
                if (itsDAL.userNameExists(userName)) return "That Username already taken"; //if that username is exists.
                if (!checkPassword(pass)) return "Password is not good"; //checks if the password is legal.

                if(role.Equals(Role.Administrator))
                {
                    if(currUser.role.Equals(Role.Administrator)) //if the new user is admin, only admin can add him.
                    {
                        itsDAL.setNewUser(userName, pass, role);
                        itsDAL.writeToLog("New user added", currUser.userName, userName);
                        return "User added successfully. The password is: " + pass;
                    }
                    else //if the curr role is manager.
                        return "There is no permission to add user with that role";
                }
                else //if the requested role is manager or employee, either manager or admin can add it.
                {
                    itsDAL.setNewUser(userName, pass, role);
                    itsDAL.writeToLog("New user added", currUser.userName, userName);
                    return "User added successfully. The password is: " + pass;
                }
            }
        }

        /// <summary>
        /// change password for existing user to random password.
        /// </summary>
        /// <param name="userName"> requested user. </param>
        /// <returns></returns>
        public string changePass(string userName)
        {
            if (userName == null) return "Username input is null";
            return changePass(userName, getRandomPass()); //choose random password and send it to the change pass function.
        }

        /// <summary>
        /// change password function.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pass"> requested password. </param>
        /// <returns></returns>
        public string changePass(string userName, string pass)
        {
            if (userName == null) throw new ArgumentNullException("Username input is null");
            if (pass == null) throw new ArgumentNullException("Password input is null");
            userName = userName.ToLower();
            if (!itsDAL.userNameExists(userName)) return "Username does not exist";
            if (!checkPassword(pass)) return "Password is not good";
            if (pass.Equals(itsDAL.getPassword(userName))) return "The new password identical to the current one";
            if (currUser.userName == userName) //every user can change his password.
            {
                itsDAL.setPassword(userName, pass);
                itsDAL.writeToLog("Changed password", currUser.userName, userName);
                currUser = new User(currUser.userName, pass, currUser.role);
                return "Password changed successfully. The new password is: " + pass;
            }
            else //if he wan't to change other user password.
            {
                if(currUser.role.Equals(Role.Employee)) return "There is no permissions";
                else if(currUser.role.Equals(Role.Manager) && !(itsDAL.getRole(userName).Equals(Role.Employee))) //Manager can change only his, and employee password.
                {
                    return "There is no permissions";
                }
                else
                {
                    itsDAL.setPassword(userName, pass);
                    itsDAL.writeToLog("Changed password", currUser.userName, userName);
                    return "Password changed successfully. The new password is: " + pass;
                }
            }
        }

        /// <summary>
        /// return the software log
        /// </summary>
        /// <returns> list of log strings </returns>
        public List<string> readLog()
        {
            if(currUser.role.Equals(Role.Administrator))
            {
                return itsDAL.getLog();
            }
            else
            {
                throw new Exception("No permission to perform the operation");
            }
        }

        /// <summary>
        /// For each file in the path checks it's sesitivity score.
        /// </summary>
        /// <param name="path"> Folder path </param>
        /// <returns></returns>
        public SortedDictionary<double, FileInfo> checkSensitivity(string path)
        {
            itsDAL.writeToLog("User accessed Data Leakage Tool", currUser.userName, null);
            return dataLeakageTool.checkSensitivity(path);
        }

        /// <summary>
        /// Encrypt file by password.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="destinationPath"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public string encrypt(string filePath, string destinationPath, string password)
        {
            itsDAL.writeToLog("User accessed Encryption Tool", currUser.userName, null);
            return fileCryptoTool.encrypt(filePath, destinationPath, password);
        }

        /// <summary>
        /// Decrypt file by password.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="destinationPath"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public string decrypt(string filePath, string destinationPath, string password)
        {
            itsDAL.writeToLog("User accessed Encryption Tool", currUser.userName, null);
            return fileCryptoTool.decrypt(filePath, destinationPath, password);
        }

        //Help functions
        /// <summary>
        /// create legal random password.
        /// </summary>
        /// <returns></returns>
        private string getRandomPass()
        {
            string pass = "";
            bool thereIsNumber = false;
            Random rnd = new Random();
            for (int i = 0; i < 8; i++)
            {
                if (i == 7 && !thereIsNumber) //if there is olready 7 chars and no numbers, set one number.
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

        /// <summary>
        /// checks if the password is legal.
        /// </summary>
        /// <param name="pass"></param>
        /// <returns></returns>
        private bool checkPassword(string pass)
        {
            if (pass == null) throw new ArgumentNullException("the pass input is null");
            if (pass.Length != 8) return false; //if the size of the password isn't 8 chars.
            bool ans = false;
            byte[] ASCIIValues = Encoding.ASCII.GetBytes(pass);
            for (int i = 0; i < pass.Length; i++)
            {
                if (ASCIIValues[i] >= 48 && ASCIIValues[i] <= 57) ans = true; //there is one number.
                else if (ASCIIValues[i] >= 65 && ASCIIValues[i] <= 90) continue;
                else if (ASCIIValues[i] >= 97 && ASCIIValues[i] <= 122) continue;
                else
                {
                    return false;
                }
            }
            return ans;
        }

        public Hashtable getLineForUsername(string username){
            return itsDAL.getLineForUsername(username);
        }
        public void updateEmailLine(Hashtable h)
        {
            itsDAL.updateEmailLine(h);
        }
    }
}

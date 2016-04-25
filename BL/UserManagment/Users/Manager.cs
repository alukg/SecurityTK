using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.UserManagment.Users
{
    public class Manager : User
    {
        public Manager(string userName, string password) : base(userName, password)
        {
        }

        public override string addUser(string userName, string role)
        {
            if (userName == null) throw new Exception("Username input is null");
            if (role == null) throw new Exception("Role input is null");
            role = role.First().ToString().ToUpper() + role.Substring(1).ToString().ToLower();
            if (role == "Employee" || role == "Manager")
            {
                return userM.addUser(this.userName,userName, role);
            }
            else if (role == "Administrator") return "There is no permission for that role";
            else
            {
                return "There is no such role";
            }
        }

        public override string addUser(string userName, string pass, string role)
        {
            if (userName == null) throw new Exception("Username input is null");
            if (pass == null) throw new Exception("Password input is null");
            if (role == null) throw new Exception("Role input is null");
            role = role.First().ToString().ToUpper() + role.Substring(1).ToString().ToLower();
            if (role == "Employee" || role == "Manager")
            {
                return userM.addUser(this.userName,userName, pass, role);
            }
            else if (role == "Administrator") return "There is no permission for that role";
            else
            {
                return "There is no such role";
            }
        }

        public override string changePass(string userName)
        {
            if (userName == null) return "Username input is null";
            if (!userM.userNameExists(userName)) return "Username does not exist";
            if (this.userName == userName)
            {
                return userM.changePass(this.userName,userName);
            }
            else if (userM.itsDAL.getRole(userName) == "Employee")
            {
                return userM.changePass(this.userName,userName);
            }
            else
            {
                return "There is no permissions";
            }
        }

        public override string changePass(string userName, string pass)
        {
            if (userName == null) return "Username input is null";
            if (pass == null) return "Username input is null";
            if (!userM.userNameExists(userName)) return "Username does not exist";
            if (this.userName == userName)
            {
                return userM.changePass(this.userName,userName, pass);
            }
            else if (userM.itsDAL.getRole(userName) == "Employee")
            {
                return userM.changePass(this.userName,userName, pass);
            }
            else
            {
                return "There is no permissions";
            }
        }

        public override string changeRole(string userName, string newRole)
        {
            return "No permission to perform the operation";
        }

        public override List<string> readLog()
        {
            throw new Exception("No permission to perform the operation");
        }

        public override string removeUser(string userName)
        {
            if (userName == null) throw new Exception("Username input is null");
            if (!userM.userNameExists(userName)) return "Username does not exist";
            if (userM.itsDAL.getRole(userName) == "Employee")
            {
                userM.itsDAL.removeUser(userName);
                userM.itsDAL.writeToLog("Removing user", this.userName, userName);
                return "The user was removed successfully";
            }
            else
            {
                return "There is no permissions to remove this user";
            }
        }
    }
}

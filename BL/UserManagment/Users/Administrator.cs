using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.UserManagment.Users
{
    public class Administrator : User
    {
        public Administrator(string userName, string password) : base(userName, password) { }

        public override string addUser(string userName, string role)
        {
            if (userName == null) throw new Exception("Username input is null");
            if (role == null) throw new Exception("Role input is null");
            role = role.First().ToString().ToUpper() + role.Substring(1).ToString().ToLower();
            if (role == "Employee" || role == "Manager" || role == "Administrator")
            {
                return userM.addUser(this.userName,userName, role);
            }
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
            if (role == "Employee" || role == "Manager" || role =="Administrator")
            {
                return userM.addUser(this.userName,userName, pass, role);
            }
            else
            {
                return "There is no such role";
            }
        }

        public override string changePass(string userName)
        {
            if (userName == null) return "Username input is null";
            if (!userM.userNameExists(userName)) return "Username does not exist";
            return userM.changePass(this.userName,userName);
        }

        public override string changePass(string userName, string pass)
        {
            if (userName == null) return "Username input is null";
            if (pass == null) return "Username input is null";
            if (!userM.userNameExists(userName)) return "Username does not exist";
            return userM.changePass(this.userName,userName, pass);
        }

        public override string changeRole(string userName, string newRole)
        {
            if (userName == null)
                throw new Exception("The username is null");
            if (newRole == null)
                throw new Exception("The role is null");
            if (!userM.userNameExists(userName)) return "Username don't exits";
            newRole = newRole.First().ToString().ToUpper() + newRole.Substring(1).ToString().ToLower();
            if (userM.itsDAL.getRole(userName) == newRole) return "This user already in this role";
            userM.itsDAL.setRole(userName, newRole);
            userM.itsDAL.writeToLog("Changing role", this.userName, userName);
            return "Role changed successfully";
        }

        public override List<string> readLog()
        {
            return userM.itsDAL.getLog();
        }

        public override string removeUser(string userName)
        {
            if (userName == null) throw new Exception("Username input is null");
            if (!userM.userNameExists(userName)) return "Username does not exist";
            userM.itsDAL.removeUser(userName);
            userM.itsDAL.writeToLog("Removing user", this.userName, userName);
            return "The user was removed successfully";
        }
    }
}

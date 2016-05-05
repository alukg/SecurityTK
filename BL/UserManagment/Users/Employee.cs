using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BL_Tests.Users
{
    public class Employee : User
    {
        public Employee(string userName, string password) : base(userName, password)
        {
        }

        public override string addUser(string userName, string role)
        {
            return "No permission to perform the operation";
        }

        public override string addUser(string userName, string pass, string role)
        {
            return "No permission to perform the operation";
        }

        public override string changePass(string userName)
        {
            if (userName == null) return "Username input is null";
            if (!userM.userNameExists(userName)) return "Username does not exist";
            if (this.userName == userName)
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
                return userM.changePass(this.userName,userName,pass);
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
            return "No permission to perform the operation";
        }
    }
}

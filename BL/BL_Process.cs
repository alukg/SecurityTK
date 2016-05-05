using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BL.BL_Tests;
using BL.BL_Tests.Users;

namespace BL
{
    public class BL_Process : IBL
    {
        private IDAL itsDAL;

        public BL_Process(IDAL itsDAL)
        {
            this.itsDAL = itsDAL;
        }

        public User userEntrance(string userName, string enteredPassword)
        {
            if (userName == null)
                throw new Exception("The username is null");
            if (enteredPassword == null)
                throw new Exception("The password is null");
            if (itsDAL.checkUserName(userName)==0) throw new Exception("There is no such user");
            string currentPassword = itsDAL.getPassword(userName);
            if (currentPassword == enteredPassword)
            {
                string userRole = itsDAL.getRole(userName);
                if (userRole == "Employee") return new Employee(userName, currentPassword);
                else if (userRole == "Manager") return new Manager(userName, currentPassword);
                else { return new Administrator(userName, currentPassword); }
            }
            else
                throw new Exception("Incorrect password");
        }
    }
}

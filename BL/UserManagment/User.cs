using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BL_Tests
{
    public abstract class User
    {
        protected string userName;
        protected string password;
        protected UserFunctions userM;

        //Constractor
        public User(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
            userM = new UserFunctions();
        }

        //Getters
        public string getUserName()
        {
            return userName;
        }
        public string getPassword()
        {
            return password;
        }

        //Functions
        public abstract List<string> readLog();
        public abstract string changeRole(string userName, string newRole);
        public abstract string addUser(string userName, string pass, string role);
        public abstract string addUser(string userName, string role);
        public abstract string removeUser(string userName);
        public abstract string changePass(string userName);
        public abstract string changePass(string userName, string pass);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// interface for the Database layer.
    /// </summary>
    public interface IDAL
    {
        int checkUserName(string userName);
        string getRole(string userName);
        string getPassword(string userName);
        void setPassword(string userName, string value);
        void setRole(string userName, string value);
        void setNewUser(string userName, string password, string role);
        void removeUser(string userName);
        void writeToLog(string action, string performed, string affected);
        List<string> getLog();
    }
}

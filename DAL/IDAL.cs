using System.Collections.Generic;
using SharedClasses;
using System.Collections;

namespace DAL
{
    /// <summary>
    /// interface for the Database layer.
    /// </summary>
    public interface IDAL
    {
        bool userNameExists(string userName);
        Role getRole(string userName);
        string getPassword(string userName);
        void setPassword(string userName, string value);
        void setRole(string userName, Role value);
        void setNewUser(string userName, string password, Role role);
        void removeUser(string userName);
        void writeLogToDB(string dateTime, string action, string performed, string affected);
        List<string> getLog();
        Dictionary<string, object> getLineForUsername(string username);
        void updateEmailLine(Dictionary<string, object> h, string username);
        List<string> getLiveAlertsMailsForAction(string action);
    }
}

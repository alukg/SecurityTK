using System.Collections.Generic;
using SharedClasses;

namespace BL
{
    /// <summary>
    /// interface for the logic layer. user managment.
    /// </summary>
    public interface IBL
    {
        User getUser();
        Role convertRole(string role);
        bool userVarification(string userName, string enteredPassword);
        string changeRole(string userName, Role newRole);
        string removeUser(string userName);
        string addUser(string userName, Role role);
        string addUser(string userName, string pass, Role role);
        string changePass(string userName);
        string changePass(string userName, string pass);
        List<string> readLog();
        
        // data-leakage tool function
    }

}

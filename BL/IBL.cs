using System.Collections.Generic;
using SharedClasses;
using System.IO;

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
        SortedDictionary<double, FileInfo> checkSensitivity(string path);
        string encrypt(string filePath, string destinationPath, string password);
        string decrypt(string filePath, string destinationPath, string password);
        List<string> readLog();
    }

}

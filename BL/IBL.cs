using System.Collections.Generic;
using SharedClasses;
using System.IO;
using System.Collections;
using System.Collections.ObjectModel;

namespace BL
{
    /// <summary>
    /// interface for the logic layer. user managment.
    /// </summary>
    public interface IBL
    {
        User getUser();
        void logOff();
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
        Dictionary<string, object> getLineForUsername(string username);
        void updateEmailLine(Dictionary<string, object> h);
        void guestEnter();
        string createsPDFFile(string PDFName, string path);
        string createsPDFDataLeakage(string PDFName, string path, ObservableCollection<DataFile> files);
    }

}

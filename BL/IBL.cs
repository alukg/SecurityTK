﻿using System.Collections.Generic;
using SharedClasses;

namespace BL
{
    public interface IBL
    {
        User getUser();
        bool userVarification(string userName, string enteredPassword);
        string changeRole(string userName, string newRole);
        string removeUser(string userName);
        string addUser(string userName, string role);
        string addUser(string userName, string pass, string role);
        string changePass(string userName);
        string changePass(string userName, string pass);
        List<string> readLog();
        
        // data-leakage tool function
    }

}

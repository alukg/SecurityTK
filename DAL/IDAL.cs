using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedClasses;

namespace DAL
{
    public interface IDAL
    {
        //getLine function - Return the line value of the username. If the username doesn't exists return -1 .
        int getLine(string userName);
        string getPassword(int line);
    }
}

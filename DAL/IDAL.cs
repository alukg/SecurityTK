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
        /// <summary>
        /// getLine function - Returns the line value of the username. If the username doesn't exists return the value -1 .
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        int getLine(string userName);
        string getPassword(int line);
        void setPassword(int line, string value);
    }
}

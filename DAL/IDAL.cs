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
        ///
        int getLine(string userName);
        string getPassword(int line);
        void setPassword(int line, string value);
    }
}

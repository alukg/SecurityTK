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
        string getPassword(string userName);
        void setPassword(string userName, string value);
    }
}

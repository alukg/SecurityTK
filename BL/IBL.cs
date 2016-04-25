using BL.UserManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public interface IBL
    {
        User userEntrance(string username, string password);
        // data-leakage tool function
    }

}

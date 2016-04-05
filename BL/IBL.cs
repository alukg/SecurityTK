using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedClasses;

namespace BL
{
   public interface IBL

    {
        bool verifyCardentials(string username, string password);
        //int findUsername(String username);
        void setPassword(User user, string pass);
        void setPassword(User user);
        bool checkPassword(String password);
    }

}

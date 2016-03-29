using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PL;
using BL;
using DAL;


namespace ProgramLauncher
{
    class Program
    {
        static void Main(string[] args)
        {
            IDAL theDAL = new DAL_Excel();
            IBL theBL = new BL_Functions(theDAL);
            IPL thePL = new PL_Run(theBL);
            thePL.Run();
            
        }
    }
}

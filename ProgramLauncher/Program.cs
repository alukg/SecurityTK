using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PL;
using BL;
using DAL;



/*
Rotem Avni 204247852
Guy Aluk 305051260
Barak Hartman 203038534
Keren Herman 204544688
*/

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

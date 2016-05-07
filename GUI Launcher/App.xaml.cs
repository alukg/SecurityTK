using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using PL_GUI;
using BL;
using DAL;

/*
Rotem Avni 204247852
Guy Aluk 305051260
Barak Hartman 203038534
Keren Herman 204544688
*/

namespace GUI_Launcher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
        IDAL theDAL = new DAL_SQL();
        IBL theBL = new BL_Process(theDAL);
        IPL thePL = new MainMenu(theBL);
        thePL.Run();
       }
    }
}

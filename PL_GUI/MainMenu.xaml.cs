using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SharedClasses;
using BL;

namespace PL_GUI
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window , IPL
    {
        IBL theBL;

        public MainMenu(IBL bl)
        {
            theBL = bl;
            InitializeComponent();
        }

        public void Run()
        {
            this.Show();
        }

        private void Data_Leakage_Left_Button_Click(object sender, RoutedEventArgs e)
        {
            DataLeakageWindow dl = new DataLeakageWindow(theBL);
            dl.Run();
            this.Close();
        }

        private void User_Management_Left_Button_Click(object sender, RoutedEventArgs e)
        {
            AdministratorManagment am = new AdministratorManagment(theBL);
            am.Run();
            this.Close();
        }

        private void File_Crypto_Left_Button_Click(object sender, RoutedEventArgs e)
        {
            CryptoWindow cw = new CryptoWindow(theBL);
            cw.Run();
            this.Close();
        }

        private void Log_off_Left_Button_Click(object sender, RoutedEventArgs e)
        {
            theBL.logOff();
            LoginWindow lw = new LoginWindow(theBL);
            lw.Run();
            this.Close();
        }
        private void Process_Monitor_Left_Button_Click(object sender, RoutedEventArgs e)
        {
            ProcessMonitorWindow pmw = new ProcessMonitorWindow(theBL);
            pmw.Run();
            this.Close();
        }
    }
}

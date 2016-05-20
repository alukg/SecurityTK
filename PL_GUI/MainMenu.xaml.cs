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
            dl.Close();
        }

        private void User_Management_Left_Button_Click(object sender, RoutedEventArgs e)
        {
            if (theBL.getUser().role == "Employee")
            {
                EmployManagment em = new EmployManagment(theBL);
                em.Run();
                em.Close();

            }
            else if (theBL.getUser().role == "Manager")
            {
                ManagerManagment mm = new ManagerManagment(theBL);
                mm.Run();
                mm.Close();
            }
            else if (theBL.getUser().role == "Administrator")
            {
                AdministratorManagment am = new AdministratorManagment(theBL);
                am.Run();
                am.Close();
            }
        }

        private void File_Crypto_Left_Button_Click(object sender, RoutedEventArgs e)
        {
            CryptoWindow cw = new CryptoWindow(theBL);
            cw.Run();
            cw.Close();
        }
    }
}

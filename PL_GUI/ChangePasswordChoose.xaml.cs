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
using BL;

namespace PL_GUI
{
    /// <summary>
    /// Interaction logic for ChangePasswordChoose.xaml
    /// </summary>
    public partial class ChangePasswordChoose : Window, IPL
    {
        IBL theBL;

        public ChangePasswordChoose(IBL bl)
        {
            theBL = bl;
            InitializeComponent();
        }

        public void Run()
        {
            this.Show();

        }

        private void YourPassword_Click(object sender, RoutedEventArgs e)
        {
            ChangePasswordWindow cpw = new ChangePasswordWindow(theBL,0);
            cpw.Run();
            this.Close();
        }

        private void AnotherWorker_Click(object sender, RoutedEventArgs e)
        {
            ChangePasswordWindow cpw = new ChangePasswordWindow(theBL, 1);
            cpw.Run();
            this.Close();
        }

        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mm = new MainMenu(theBL);
            mm.Run();
            this.Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AdministratorManagment am = new AdministratorManagment(theBL);
            am.Show();
            this.Close();
        }
    }
}

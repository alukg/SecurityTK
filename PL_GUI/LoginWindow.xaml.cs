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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window, IPL
    {
        IBL theIBL;

        public LoginWindow(IBL bl)
        {
            theIBL = bl;
            InitializeComponent();
        }

        public void Run()
        {
            this.Show();
  
        }

        private void Left_Enter_Button_Click(object sender, RoutedEventArgs e)
        {
            if (theIBL.userVarification(Username.Text, Password.Password))
            {
                MainMenu mm = new MainMenu(theIBL);
                mm.Run();
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong Username/Password");
                Left_Refresh_Button_Click(sender, e);
            }
        }

        private void Left_Refresh_Button_Click(object sender, RoutedEventArgs e)
        {
           Username.Text = "";
           Password.Password = "";
        }
    }
}

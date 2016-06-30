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
using SharedClasses;

namespace PL_GUI
{
    /// <summary>
    /// Interaction logic for ChangeRoleWindow.xaml
    /// </summary>
    public partial class ChangeRoleWindow : Window, IPL
    {
        IBL theBL;

        public ChangeRoleWindow(IBL bl)
        {
            theBL = bl;
            InitializeComponent();
        }

        public void Run()
        {
            try
            {
                this.Show();
                if (theBL.getUser().role == Role.Administrator)
                {
                    Administrator.Visibility = Visibility.Visible;
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Connection to server faild");
            }
        }

        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mm = new MainMenu(theBL);
            mm.Run();
            this.Close();
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Role newRole = theBL.convertRole(RoleBox.SelectedItem.ToString());
                MessageBox.Show(theBL.changeRole(UsernameBox.Text, newRole));
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Connection to server faild");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AdministratorManagment am = new AdministratorManagment(theBL);
            am.Show();
            this.Close();
        }
    }
}

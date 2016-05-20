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
    /// Interaction logic for AdministratorManagment.xaml
    /// </summary>
    public partial class AdministratorManagment : Window, IPL
    {
        IBL theBL;
<<<<<<< HEAD
        public AdministratorManagment(IBL theBL)
        {
            this.theBL = theBL;
=======
        public AdministratorManagment(IBL bl)
        {
            theBL = bl;
>>>>>>> Keren'sGUI
            InitializeComponent();
            if(theBL.getUser().role == "Administrator" || theBL.getUser().role == "Employee")
            {
                AddUser.Visibility = Visibility.Visible;
                RemoveUser.Visibility = Visibility.Visible;
                if(theBL.getUser().role == "Administrator")
                {
                    ChangeRole.Visibility = Visibility.Visible;
                    ReadLog.Visibility = Visibility.Visible;
                }
            } 
        }

        public void Run()
        {
            this.Show();

        }

        private void ChangePassword_Button_Click(object sender, RoutedEventArgs e)
        {
            if(theBL.getUser().role == "Employee")
            {
                ChangePasswordWindow cpw = new ChangePasswordWindow(theBL, 0);
                cpw.Run();
            }
            else
            {
                ChangePasswordChoose cpc = new ChangePasswordChoose(theBL);
                cpc.Run(); 
            }
            this.Close();
        }

        private void AddUser_Button_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow auw = new AddUserWindow(theBL);
            auw.Run();
            this.Close();
        }

        private void RemoveUser_Button_Click(object sender, RoutedEventArgs e)
        {
            RemoveUserWindow ruw = new RemoveUserWindow(theBL);
            ruw.Run();
            this.Close();
        }

        private void ChangeRole_Button_Click(object sender, RoutedEventArgs e)
        {
            ChangeRoleWindow crw = new ChangeRoleWindow(theBL);
            crw.Run();
            this.Close();
        }

        private void ReadLog_Button_Click(object sender, RoutedEventArgs e)
        {
            ReadLogWindow rlw = new ReadLogWindow(theBL);
            rlw.Run();
            this.Close();
        }

        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mm = new MainMenu(theBL);
            mm.Run();
            this.Close();
        }

        public void Run()
        {
            this.Show();
        }
    }
}

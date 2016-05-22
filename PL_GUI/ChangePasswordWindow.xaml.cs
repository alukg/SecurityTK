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
    /// Interaction logic for ChangePasswordWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window, IPL
    {
        IBL theBL;
        int choose;
        //choose=0 - your password, choose=1 -another worker
      
        public ChangePasswordWindow(IBL bl, int choose)
        {
            this.choose = choose;
            theBL = bl;
            InitializeComponent();
        }

        public void Run()
        {
            this.Show();
        }

        private void Random_Button_Click(object sender, RoutedEventArgs e)
        {
            string newPass;
            if(choose == 0)
            {
                newPass = theBL.changePass(theBL.getUser().userName);
                MessageBox.Show(newPass);
                
            }
            else
            {
                UserName.Visibility = Visibility.Visible;
                UserNameBox.Visibility = Visibility.Visible;
                EnterRandom.Visibility = Visibility.Visible;
            }
        }

        private void YourOwn_Button_Click(object sender, RoutedEventArgs e)
        {

            New_Password.Visibility = Visibility.Visible;
            PasswordBox.Visibility = Visibility.Visible;
            EnterYourOwn.Visibility = Visibility.Visible;
            if (choose == 1)
            {
                UserName.Visibility = Visibility.Visible;
                UserNameBox.Visibility = Visibility.Visible;
            }
        }

        private void MainMenu_Button_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mm = new MainMenu(theBL);
            mm.Run();
            this.Close();
        }

        private void Enter_RandomButton_Click(object sender, RoutedEventArgs e)
        {
            String newPass = theBL.changePass(UserNameBox.Text);
            MessageBox.Show(newPass);
            
        }

        private void EnterYourOwn_Click(object sender, RoutedEventArgs e)
        {
            String newPass = "";
            if(choose == 0)
            {
                newPass = theBL.changePass(theBL.getUser().userName, PasswordBox.Password);
            }
            else
            {
                newPass = theBL.changePass(UserNameBox.Text, PasswordBox.Password);
            }
            MessageBox.Show(newPass);
            
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if(theBL.getUser().userName == "Employee")
            {
                AdministratorManagment am = new AdministratorManagment(theBL);
                am.Show();
            }
            else
            {
                ChangePasswordChoose cpc = new ChangePasswordChoose(theBL);
                cpc.Show();
            }
            this.Close();
        }
    }
}

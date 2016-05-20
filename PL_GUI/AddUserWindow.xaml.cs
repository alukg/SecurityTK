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
    /// Interaction logic for AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window, IPL
    {
        IBL theBL;

        public AddUserWindow(IBL bl)
        {
            theBL = bl;
            InitializeComponent();
        }

        public void Run()
        {
            this.Show();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if(theBL.getUser().role == "Administrator")
            {
                Administrator.Visibility = Visibility.Visible;
               
            }
            String role = RoleBox.SelectedItem.ToString();
            String ans = theBL.addUser(UserNameBox.Text, PasswordBox.Password, role);
            MessageBox.Show(ans);
        }

        private void MainMenu_Button_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mm = new MainMenu(theBL);
            mm.Run();
            this.Close();
        }

        private void Random_Click(object sender, RoutedEventArgs e)
        {
            String ans = theBL.addUser(UserNameBox.Text, RoleBox.SelectedItem.ToString());
            MessageBox.Show(ans);
        }

        private void YourOwn_Click(object sender, RoutedEventArgs e)
        {
            PasswordBox.Visibility = Visibility.Visible;
            Add.Visibility = Visibility.Visible;
        }
    }
}

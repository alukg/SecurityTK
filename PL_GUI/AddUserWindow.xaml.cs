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
            if(theBL.getUser().role == Role.Administrator)
            {
                Administrator.Visibility = Visibility.Visible;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Role role = theBL.convertRole(RoleBox.SelectedItem.ToString());
            String ans = theBL.addUser(UserNameBox.Text, PasswordBox.Password, role);
            MessageBox.Show(ans);
            AddUserWindow auw = new AddUserWindow(theBL);
            auw.Run();
            this.Close();

        }

        private void MainMenu_Button_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mm = new MainMenu(theBL);
            mm.Run();
            this.Close();
        }

        private void Random_Click(object sender, RoutedEventArgs e)
        {
            Role role = theBL.convertRole(RoleBox.SelectedItem.ToString());
            String ans = theBL.addUser(UserNameBox.Text, role);
            MessageBox.Show(ans);
        }

        private void YourOwn_Click(object sender, RoutedEventArgs e)
        {
            PasswordBox.Visibility = Visibility.Visible;
            Add.Visibility = Visibility.Visible;
        }
    }
}

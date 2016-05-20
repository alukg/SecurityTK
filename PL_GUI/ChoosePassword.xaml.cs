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
    /// Interaction logic for ChoosePassword.xaml
    /// </summary>
    public partial class ChoosePassword : Window, IPL
    {
        IBL theBL;

        public ChoosePassword(IBL bl)
        {
            theBL = bl;
            InitializeComponent();
        }

        public void Run()
        {
            this.Show();

        }

        private void Random_Button_Click(object sender, RoutedEventArgs e)
        {
            String pass = theBL.changePass(theBL.getUser().userName);
            ChangePasswordWindow cpw = new ChangePasswordWindow(theBL, pass);

        }
        private void YourOwn_Button_Click(object sen
der, RoutedEventArgs e)
        {

        }
    }
}

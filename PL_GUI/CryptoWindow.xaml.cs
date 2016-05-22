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
using BL.UserTools;
using System.Windows.Forms;

namespace PL_GUI
{
    /// <summary>
    /// Interaction logic for CryptoWindow.xaml
    /// </summary>
    public partial class CryptoWindow : Window, IPL
    {
        IBL theBL;
        int choose;
        //0- if choose encrypt, 1- if choose decrypt
        String pathFile;
        String pathFolder;

        public CryptoWindow(IBL theBL)
        {
            this.theBL = theBL;
            InitializeComponent();
        }

        public void Run()
        {
            this.Show();
            Password.Password = "";     
        }

        private void encrypt_Click(object sender, RoutedEventArgs e)
        {
            choose = 0;
            Choose_File.Visibility = Visibility.Visible;
            Choose_Folder.Visibility = Visibility.Visible;
            Password.Visibility = Visibility.Visible;
            PasswordN.Visibility = Visibility.Visible;
            Enter.Visibility = Visibility.Visible;

            /*     if (Password.Password == "")
                 {
                     MessageBox.Show("Please enter a password");
                 }
                 else
                 {

                 }
                 */
        }

        private void decrypt_Click(object sender, RoutedEventArgs e)
        {
            choose = 1;
            Choose_File.Visibility = Visibility.Visible;
            Choose_Folder.Visibility = Visibility.Visible;
            Password.Visibility = Visibility.Visible;
            PasswordN.Visibility = Visibility.Visible;
            Enter.Visibility = Visibility.Visible;
        }

        private void Choose_File_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AdministratorManagment am = new AdministratorManagment(theBL);
            am.Show();
            this.Close();
        }

        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mm = new MainMenu(theBL);
            mm.Run();
            this.Close();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            if (Password.Password == "")
            {
                MessageBox.Show("Please enter a password");
            }
            else if(choose == 0)
            {
                //לשקול לעשות פונקציה סטטית
                FileCryptoTool cryptoTool = new FileCryptoTool();
                cryptoTool.encrypt(pathFile, pathFolder, Password.Password);
                //להחזיר הודעה למשתמש
            }
            else
            {
                FileCryptoTool cryptoTool = new FileCryptoTool();
                cryptoTool.decrypt(pathFile, pathFolder, Password.Password);
            }
        }

        private void Choose_Folder_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = true; //??
            DialogResult result = openFileDialog1.ShowDialog();
            path = openFileDialog1.
        }
    }
}

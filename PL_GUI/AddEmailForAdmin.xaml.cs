using BL;
using System;
using System.Collections;
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

namespace PL_GUI
{
    /// <summary>
    /// Interaction logic for AddEmailForAdmin.xaml
    /// </summary>
    public partial class AddEmailForAdmin : Window ,IPL
    {
        IBL theBL;
        string GetUpdateCheck;
        string logOnCheck;
        string logOffCheck;
        string changePasswordCheck;
        string encryptionCheck;
        string dataLeakageCheck;
        string processMonitorCheck;
        string EmailString;

        public AddEmailForAdmin(IBL bl)
        {
            theBL = bl;
            InitializeComponent();

            try {
                Dictionary<string, object> h = theBL.getLineForUsername(theBL.getUser().userName);
                GetUpdateCheck = (string) h["GetUpdate"];
                logOnCheck = (string) h["logOn"];
                logOffCheck = (string) h["logOff"];
                changePasswordCheck = (string) h["changePassword"];
                encryptionCheck = (string) h["encryption"];
                dataLeakageCheck = (string) h["dataLeakage"];
                processMonitorCheck = (string) h["processMonitor"];
                EmailString = (string) h["Email"];

                wrongEmailText.Visibility = System.Windows.Visibility.Hidden;

                EmailBox.Text = EmailString;
                if (GetUpdateCheck == "1") {
                    getUpdates.SetCurrentValue(CheckBox.IsCheckedProperty, true);
                    ifChecked.Visibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    getUpdates.SetCurrentValue(CheckBox.IsCheckedProperty, false);
                    ifChecked.Visibility = System.Windows.Visibility.Hidden;
                }

                if (logOnCheck == "1") logOn.SetCurrentValue(CheckBox.IsCheckedProperty, true);
                else logOn.SetCurrentValue(CheckBox.IsCheckedProperty, false);

                if (logOffCheck == "1") logOff.SetCurrentValue(CheckBox.IsCheckedProperty, true);
                else logOff.SetCurrentValue(CheckBox.IsCheckedProperty, false);

                if (changePasswordCheck == "1") changePassword.SetCurrentValue(CheckBox.IsCheckedProperty, true);
                else changePassword.SetCurrentValue(CheckBox.IsCheckedProperty, false);

                if (encryptionCheck == "1") encryption.SetCurrentValue(CheckBox.IsCheckedProperty, true);
                else encryption.SetCurrentValue(CheckBox.IsCheckedProperty, false);

                if (dataLeakageCheck == "1") dataLeakage.SetCurrentValue(CheckBox.IsCheckedProperty, true);
                else dataLeakage.SetCurrentValue(CheckBox.IsCheckedProperty, false);

                if (processMonitorCheck == "1") processMonitor.SetCurrentValue(CheckBox.IsCheckedProperty, true);
                else processMonitor.SetCurrentValue(CheckBox.IsCheckedProperty, false);

            }
            catch
            {
                throw new Exception("connection faild");
            }
        }

        public void Run()
        {
            this.Show();

        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            if (IsValidEmail(EmailBox.Text))
            {
                EmailString = EmailBox.Text;

                if (getUpdates.IsChecked.Value == true) GetUpdateCheck = "1";
                else GetUpdateCheck = "0";

                if (logOn.IsChecked.Value == true) logOnCheck = "1";
                else logOnCheck = "0";

                if (logOff.IsChecked.Value == true) logOffCheck = "1";
                else logOffCheck = "0";

                if (changePassword.IsChecked.Value == true) changePasswordCheck = "1";
                else changePasswordCheck = "0";

                if (encryption.IsChecked.Value == true) encryptionCheck = "1";
                else encryptionCheck = "0";

                if (dataLeakage.IsChecked.Value == true) dataLeakageCheck = "1";
                else dataLeakageCheck = "0";

                if (processMonitor.IsChecked.Value == true) processMonitorCheck = "1";
                else processMonitorCheck = "0";

                //
                Dictionary<string, object> h = new Dictionary<string, object>();
                h.Add("GetUpdate", GetUpdateCheck);
                h.Add("logOn", logOnCheck);
                h.Add("logOff", logOffCheck);
                h.Add("changePassword", changePasswordCheck);
                h.Add("encryption", encryptionCheck);
                h.Add("dataLeakage", dataLeakageCheck);
                h.Add("processMonitor", processMonitorCheck);
                h.Add("Email", EmailString);
                theBL.updateEmailLine(h);

                wrongEmailText.Visibility = System.Windows.Visibility.Hidden;
                MessageBox.Show("Setting updated.");
            }
            else {
                wrongEmailText.Visibility = System.Windows.Visibility.Visible;
            }

        }

        public void getUpdatesChecked(object sender, RoutedEventArgs e)
        {
            ifChecked.Visibility = System.Windows.Visibility.Visible;
        }

        public void getUpdatesUnChecked(object sender, RoutedEventArgs e)
        {
            ifChecked.Visibility = System.Windows.Visibility.Hidden;
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public void back_Click(object sender, RoutedEventArgs e)
        {
            AdministratorManagment am = new AdministratorManagment(theBL);
            am.Run();
            this.Close();
        }

        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mm = new MainMenu(theBL);
            mm.Run();
            this.Close();
        }
        
        private void LogOnChecked(object sender, RoutedEventArgs e)
        {

        }

        private void LogOffChecked(object sender, RoutedEventArgs e)
        {

        }
        private void changedPasswordChecked(object sender, RoutedEventArgs e)
        {

        }

        private void encryptionChecked(object sender, RoutedEventArgs e)
        {

        }
        private void dataLeakageChecked(object sender, RoutedEventArgs e)
        {

        }
        private void processMonitorChecked(object sender, RoutedEventArgs e)
        {

        }



    }
}
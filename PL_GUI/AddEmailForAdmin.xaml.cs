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
        bool GetUpdateCheck;
        bool logOnCheck;
        bool logOffCheck;
        bool changePasswordCheck;
        bool encryptionCheck;
        bool dataLeakageCheck;
        bool processMonitorCheck;
        string EmailString;

        public AddEmailForAdmin(IBL bl)
        {
            theBL = bl;
            InitializeComponent();            

            try {
                Dictionary<string, object> h = theBL.getLineForUsername(theBL.getUser().userName);
                GetUpdateCheck = (bool)h["GetUpdate"];
                logOnCheck = (bool) h["logOn"];
                logOffCheck = (bool) h["logOff"];
                changePasswordCheck = (bool) h["changePassword"];
                encryptionCheck = (bool) h["encryption"];
                dataLeakageCheck = (bool) h["dataLeakage"];
                processMonitorCheck = (bool) h["processMonitor"];
                EmailString = (string) h["Email"];

                wrongEmailText.Visibility = System.Windows.Visibility.Hidden;

                EmailBox.Text = EmailString;
                if (GetUpdateCheck) {
                    getUpdates.SetCurrentValue(CheckBox.IsCheckedProperty, true);
                    ifChecked.Visibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    getUpdates.SetCurrentValue(CheckBox.IsCheckedProperty, false);
                    ifChecked.Visibility = System.Windows.Visibility.Hidden;
                }

                if (logOnCheck) logOn.SetCurrentValue(CheckBox.IsCheckedProperty, true);
                else logOn.SetCurrentValue(CheckBox.IsCheckedProperty, false);

                if (logOffCheck) logOff.SetCurrentValue(CheckBox.IsCheckedProperty, true);
                else logOff.SetCurrentValue(CheckBox.IsCheckedProperty, false);

                if (changePasswordCheck == true) changePassword.SetCurrentValue(CheckBox.IsCheckedProperty, true);
                else changePassword.SetCurrentValue(CheckBox.IsCheckedProperty, false);

                if (encryptionCheck == true) encryption.SetCurrentValue(CheckBox.IsCheckedProperty, true);
                else encryption.SetCurrentValue(CheckBox.IsCheckedProperty, false);

                if (dataLeakageCheck == true) dataLeakage.SetCurrentValue(CheckBox.IsCheckedProperty, true);
                else dataLeakage.SetCurrentValue(CheckBox.IsCheckedProperty, false);

                if (processMonitorCheck == true) processMonitor.SetCurrentValue(CheckBox.IsCheckedProperty, true);
                else processMonitor.SetCurrentValue(CheckBox.IsCheckedProperty, false);

            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Connection to server faild");
            }
        }

        public void Run()
        {
            this.Show();

        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (IsValidEmail(EmailBox.Text) | EmailBox.Text.Equals(""))
                {
                    EmailString = EmailBox.Text;

                    if (getUpdates.IsChecked.Value == true)
                    {
                        GetUpdateCheck = true;

                        if (logOn.IsChecked.Value == true) logOnCheck = true;
                        else logOnCheck = false;

                        if (logOff.IsChecked.Value == true) logOffCheck = true;
                        else logOffCheck = false;

                        if (changePassword.IsChecked.Value == true) changePasswordCheck = true;
                        else changePasswordCheck = false;

                        if (encryption.IsChecked.Value == true) encryptionCheck = true;
                        else encryptionCheck = false;

                        if (dataLeakage.IsChecked.Value == true) dataLeakageCheck = true;
                        else dataLeakageCheck = false;

                        if (processMonitor.IsChecked.Value == true) processMonitorCheck = true;
                        else processMonitorCheck = false;
                    }
                    else
                    {
                        GetUpdateCheck = false;
                        logOnCheck = false;
                        logOffCheck = false;
                        changePasswordCheck = false;
                        encryptionCheck = false;
                        dataLeakageCheck = false;
                        processMonitorCheck = false;
                    }

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
                else
                {
                    wrongEmailText.Visibility = System.Windows.Visibility.Visible;
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Connection to server faild");
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
﻿using System;
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
using System.Windows.Forms;



namespace PL_GUI
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window, IPL
    {
        IBL theBL;

        public LoginWindow(IBL bl)
        {
            theBL = bl;
            InitializeComponent();
        }

        public void Run()
        {
            this.Show();
  
        }

        private void Left_Enter_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (theBL.userVarification(Username.Text, Password.Password))
                {
                    System.Windows.Forms.MessageBox.Show("Welcome " + theBL.getUser().userName + "!");
                    MainMenu mm = new MainMenu(theBL);
                    mm.Run();
                    this.Close();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Wrong Username/Password. Please try again.");
                    Left_Refresh_Button_Click(sender, e);
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Connection to server faild");
            }
        }

        private void Left_Refresh_Button_Click(object sender, RoutedEventArgs e)
        {
           Username.Text = "";
           Password.Password = "";
        }


        private void GuestEnter_Click(object sender, RoutedEventArgs e)
        {
            theBL.guestEnter();
            System.Windows.MessageBox.Show("Welcome Guset");
            MainMenu mm = new MainMenu(theBL);
            mm.Run();
            this.Close();
        }
        
    }
}

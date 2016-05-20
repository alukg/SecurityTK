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

namespace PL_GUI
{
    /// <summary>
    /// Interaction logic for ReadLogWindow.xaml
    /// </summary>
    public partial class ReadLogWindow : Window, IPL
    {
        IBL theBL;

        public ReadLogWindow(IBL bl)
        {
            theBL = bl;
            InitializeComponent();
        }

        public void Run()
        {
            this.Show();
            log.DataContext = theBL.readLog();
        }

        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mm = new MainMenu(theBL);
            mm.Run();
            this.Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AdministratorManagment am = new AdministratorManagment(theBL);
            am.Show();
            this.Close();
        }
    }
}

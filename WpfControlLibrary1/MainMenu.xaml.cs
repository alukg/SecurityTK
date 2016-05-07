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


namespace PL_GUI
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window, IPL
    {
       private IBL theBL;
        public MainMenu(IBL bl)
        {
            theBL = bl;
            InitializeComponent();
        }

        public void Run()
        {
            this.Show();
        }
    }
}

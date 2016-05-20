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
    /// Interaction logic for CryptoWindow.xaml
    /// </summary>
    public partial class CryptoWindow : Window, IPL
    {
        IBL theBL;
        public CryptoWindow(IBL theBL)
        {
            this.theBL = theBL;
            InitializeComponent();
        }

        public void Run()
        {
            this.Show();
        }
    }
}

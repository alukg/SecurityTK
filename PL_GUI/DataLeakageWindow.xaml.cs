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
using Microsoft.Win32;
using System.IO;
using BL;

namespace PL_GUI
{
    /// <summary>
    /// Interaction logic for DataLeakageWindow.xaml
    /// </summary>
    public partial class DataLeakageWindow : Window, IPL
    {
        IBL theBL;
        string urlAdress;

        public DataLeakageWindow(IBL theBL)
        {
            this.theBL = theBL;
            InitializeComponent();
        }

        public void Run()
        {
            this.Show();
        }

        private void Open_File_Left_Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                urlAdress = File.ReadAllText(openFileDialog.FileName);
            else urlAdress = null;
            DataLeakageTool dlt = new DataLeakageTool();
            SortedDictionary < double, FileInfo > dictionary = dlt.checkSensitivity(urlAdress);
            foreach(var item in dictionary.Reverse())
            {
                Sensitivity_Text.Text = Sensitivity_Text.Text + item.Value.Name + "," + item.Key;
            }
            
        }

        private void Back_To_Main_Menu_Left_Button_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mm = new MainMenu(theBL);
            mm.Run();
            mm.Close();
        }
    }
}

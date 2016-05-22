using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Microsoft.Win32;
using System.IO;
using BL;
using BL.UserTools;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Controls;
using System.Windows.Input;

namespace PL_GUI
{
    /// <summary>
    /// Interaction logic for DataLeakageWindow.xaml
    /// </summary>
    public partial class DataLeakageWindow : Window, IPL
    {
        IBL theBL;
        string urlAdress;
        ObservableCollection<DataFile> files;

        public DataLeakageWindow(IBL theBL)
        {
            this.theBL = theBL;
            InitializeComponent();
            files = new ObservableCollection<DataFile>();
        }

        public void Run()
        {
            this.Show();
        }

        private void Open_File_Left_Button_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            urlAdress = fbd.SelectedPath;
            DataLeakageTool dlt = new DataLeakageTool();
            SortedDictionary<double, FileInfo> dictionary = dlt.checkSensitivity(urlAdress);
            foreach (var item in dictionary.Reverse())
            {
                double temp;
                if (item.Key <= 0) temp = 0;
                else temp = item.Key;
                DataFile currVar = new DataFile()
                {
                    fi = item.Value,
                    name = item.Value.Name,
                    score = temp,
                    text = "",
                    url = urlAdress

                };
                files.Add(currVar); 
            };
            dlt = null;
            this.Files_List.ItemsSource = files;
        }

        private void Back_To_Main_Menu_Left_Button_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mm = new MainMenu(theBL);
            mm.Run();
            mm.Close();
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            String theFile;
            DataFile currDF = (DataFile)Files_List.SelectedItem;
            theFile = System.IO.File.ReadAllText(@currDF.url + "\\" + currDF.name);
            Text_TextBlock.Text = theFile;
        }
    }

    public class DataFile
    {
        public FileInfo fi { get; set; }
        public String name { get; set; }
        public double score { get; set; }
        public String text { get; set; }
        public String url { get; set; }
    }
}
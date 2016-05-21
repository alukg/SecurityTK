using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Microsoft.Win32;
using System.IO;
using BL;
using BL.DataLeakageTool;

namespace PL_GUI
{
    /// <summary>
    /// Interaction logic for DataLeakageWindow.xaml
    /// </summary>
    public partial class DataLeakageWindow : Window, IPL
    {
        IBL theBL;
        string urlAdress;
        List<DataFile> files;

        public DataLeakageWindow(IBL theBL)
        {
            this.theBL = theBL;
            InitializeComponent();
            files = new List<DataFile>();
            sensitivityBox.ItemsSource = files;
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
            SortedDictionary<double, FileInfo> dictionary = dlt.checkSensitivity(urlAdress);
            foreach (var item in dictionary.Reverse())
            {
                DataFile currVar = new DataFile()
                {
                    name = item.Value.Name,
                    score = item.Key,
                    text = ""
                };
                files.Add(currVar);
                //Sensitivity_Text.Text = Sensitivity_Text.Text + item.Value.Name + "," + item.Key;
            }

        }

        private void Back_To_Main_Menu_Left_Button_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mm = new MainMenu(theBL);
            mm.Run();
            mm.Close();
        }
    }

    public class DataFile
    {
        public String name { get; set; }
        public double score { get; set; }
        public String text { get; set; }
    }
}
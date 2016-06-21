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

        //after clicking the "open file" vutton
        private void Open_File_Left_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                DialogResult result = fbd.ShowDialog();
                urlAdress = fbd.SelectedPath;
                DataLeakageTool dlt = new DataLeakageTool();
                SortedDictionary<double, FileInfo> dictionary = null;
                try
                {
                    dictionary = dlt.checkSensitivity(urlAdress);
                }
                catch (Exception exc)
                {
                    System.Windows.MessageBox.Show(exc.Message);
                    Open_File_Left_Button_Click(sender, e);

                }
                foreach (var item in dictionary.Reverse())
                {
                    double temp;
                    if (item.Key <= 0) temp = 0;
                    else temp = item.Key;
                    DataFile currVar = new DataFile()
                    {
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
            catch (Exception exc)
            {
                System.Windows.MessageBox.Show("Error, please start-over");
                string s = exc.Message;
                this.Run();
            }
        }

        private void Back_To_Main_Menu_Left_Button_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mm = new MainMenu(theBL);
            mm.Run();
            this.Close();
        }

        //after clicking twice on a txt file from the list
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                String theFile;
                DataFile currDF = (DataFile)Files_List.SelectedItem;
                theFile = System.IO.File.ReadAllText(@currDF.url + "\\" + currDF.name);
                Text_TextBlock.Text = theFile;
            }
            catch (Exception exc)
            {
                System.Windows.MessageBox.Show("Error, please start-over");
                string s = exc.Message;
                this.Run();
            }
        }

        private void SavePDF_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            String pathFolder = fbd.SelectedPath;
            string dateTime = DateTime.Now.ToString("ddMMyyHHmm");

            System.Windows.MessageBox.Show(theBL.createsPDFDataLeakage("DataLeakage" + dateTime, pathFolder, files));
        }
    }

    //a data stracture to save information about each .txt file
  /*  public class DataFile
    {
        public String name { get; set; }
        public double score { get; set; }
        public String text { get; set; }
        public String url { get; set; }
    }*/
}

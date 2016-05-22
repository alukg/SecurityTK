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
        //    List<DataFile> files;
        ObservableCollection<DataFile> files;
        public DataLeakageWindow(IBL theBL)
        {
            this.theBL = theBL;
            InitializeComponent();
            files = new ObservableCollection<DataFile>();

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(files);

        }

        public void Run()
        {
            this.Show();
        }

        private void Open_File_Left_Button_Click(object sender, RoutedEventArgs e)
        {
            //Files_List.ItemsSource = files;
            //OpenFileDialog openFileDialog = new OpenFileDialog()
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            //fbd.SelectedPath = sourceFol
            urlAdress = fbd.SelectedPath;
            //urlAdress = File.ReadAllText(fbd.SelectedPath);

            // if (fbd.ShowDialog() == DialogResult.ok)
            // else urlAdress = null;
           /* if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                urlAdress = File.ReadAllText(fbd.SelectedPath);
                string[] files1 = Directory.GetFiles(fbd.SelectedPath);

                //System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");

            }*/
            DataLeakageTool dlt = new DataLeakageTool();
            SortedDictionary<double, FileInfo> dictionary = dlt.checkSensitivity(urlAdress);
            foreach (var item in dictionary.Reverse())
            {
                DataFile currVar = new DataFile()
                {
                    fi = item.Value,
                    name = item.Value.Name,
                    score = item.Key,
                    text = "",
                    url = urlAdress

                };
                files.Add(currVar);
                //Sensitivity_Text.Text = Sensitivity_Text.Text + item.Value.Name + "," + item.Key;
            };
            dlt = null;
               this.Files_List.ItemsSource = files;
           // LogBox.ItemsSource = files;



        }

        private void Back_To_Main_Menu_Left_Button_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mm = new MainMenu(theBL);
            mm.Run();
            mm.Close();
        }

        private void LoadText_Left_Click_Button(object sender, RoutedEventArgs e)
        {
            String theFile;
            //DataGridRow row = sender as DataGridRow;
            // List<String> theList = new List<String>();
            // DataFile currDF = (DataFile)LogBox.SelectedItem;
            DataFile currDF =  (DataFile)Files_List.SelectedItem;
            //DataFile currDF = (DataFile)row.DataContext;
            // System.Windows.MessageBox.Show(currDF.url);
            //String theFile = System.IO.File.ReadAllText(@currDF.url + "\\" + currDF.name);
            //FileInfo fl = new FileInfo(currDF.url + "\\" + currDF.name);
            //StreamReader reader = new StreamReader(@currDF.url + "\\" + currDF.name);
            //if (currDF.url + "\\" + currDF.name
            StreamReader reader = currDF.fi.OpenText();
             using (reader)
             {
                theFile = reader.ReadToEnd();
                //theList.Add(reader.ReadLine());
            }
            // Text_Block.ItemsSource = theList; //לפתוח URL של קובץ נתון
            //DataContext? מקבל ליסט
            Text_TextBlock.Text = theFile;
        }

        private void Files_List_Click(object sender, MouseButtonEventArgs e)
        {
                //< EventSetter Event = "PreviewMouseLeftButtonDown"  Handler = "Files_List_Click" ></ EventSetter >
            var item = sender as System.Windows.Controls.ListViewItem;
            if(item != null && item.IsSelected)
            {
                String theFile;
                DataFile currDF = (DataFile)Files_List.SelectedItem;
                StreamReader reader = currDF.fi.OpenText();
                using (reader)
                {
                    theFile = reader.ReadToEnd();
                    //theList.Add(reader.ReadLine());
                }
                Text_TextBlock.Text = theFile;
            }
        }

                private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
                {
                    String theFile;
                    //DataGridRow row = sender as DataGridRow;
                    DataFile currDF = (DataFile)Files_List.SelectedItem;
                    //String s = System.IO.File.ReadAllText(@currDF.url + "\\" + currDF.name);
                    StreamReader reader = currDF.fi.OpenText();
                    using (reader)
                    {
                        theFile = reader.ReadToEnd();
                        //theList.Add(reader.ReadLine());
                    }
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
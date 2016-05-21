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
        List<DataFile> files;

        public DataLeakageWindow(IBL theBL)
        {
            this.theBL = theBL;
            InitializeComponent();
            files = new List<DataFile>();
            Files_List.ItemsSource = files;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(files);

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
                    text = "",
                    url = urlAdress

                };
                files.Add(currVar);
                //Sensitivity_Text.Text = Sensitivity_Text.Text + item.Value.Name + "," + item.Key;
            };

        }

        private void Back_To_Main_Menu_Left_Button_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mm = new MainMenu(theBL);
            mm.Run();
            mm.Close();
        }

        private void LoadText_Left_Click_Button(object sender, RoutedEventArgs e)
        {
            List<String> theList = new List<String>();
            DataFile currDF =  (DataFile)Files_List.SelectedItem; 
            using (StreamReader reader = new StreamReader(currDF.url))
            {

                theList.Add(reader.ReadLine());
            }
            Text_Block.ItemsSource = theList; //לפתוח URL של קובץ נתון
                                        //DataContext? מקבל ליסט
        }

/*        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;
            DataFile selected = (DataFile)row.DataContext;
            String s = System.IO.File.ReadAllText(@	File + "\\" + selected.file);
            fileshow.Text = s;
        }
        
        לבדוק גם לגבי הפונקציה במסך עצמו
        */
    }

    public class DataFile
    {
        public String name { get; set; }
        public double score { get; set; }
        public String text { get; set; }
        public String url { get; set; }
    }
}
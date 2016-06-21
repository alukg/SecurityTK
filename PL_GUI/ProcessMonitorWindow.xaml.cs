using BL;
using BL.UserTools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Diagnostics;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Data;
using System.Threading;

namespace PL_GUI
{
    public partial class ProcessMonitorWindow : Window, IPL
    {
        ObservableCollection<Proc> pro;
        IBL theBL;
        private GridViewColumnHeader lastHeaderClicked = null;
        private ListSortDirection lastDirection = ListSortDirection.Ascending;
        private List<Proc> toKill;
        private ProcessMonitor pm;
        public string totalCPU;
        public string totalMemory;

        //constructor
        public ProcessMonitorWindow(IBL theBL)
        {
            
            this.theBL = theBL;
            InitializeComponent();
            pro = new ObservableCollection<Proc>();
            pm = new ProcessMonitor();
            initialize();
        }

        //The function initializes the content of the list

        private void initialize()
        {
            List<ProcessObj> processes = pm.getProcessList();
            double totalc = 0;
            double totalm = 0;
            
            foreach (var p in processes)
            {
                Proc proc = new Proc()
                {
                    process = p.getProcess(),
                    pName = p.getProcess().ProcessName,
                    cpu = Convert.ToDouble(p.getCPU()),
                    memory = Convert.ToDouble(p.getMemory())

                };
                pro.Add(proc);
                totalc += p.getCPU();
                totalm += p.getMemory();
            }
            this.Process_List.ItemsSource = pro;
            this.toKill = new List<Proc>();
            if (totalc > 100)
            {
                pm = new ProcessMonitor();
                initialize();
            }
            else
            {
                totalCPU = "Total CPU Usage " + String.Format("{0:0.00}", totalc) + "%";
                totalMemory = "Total Memory Usage: " + String.Format("{0:0.00}", totalm) + " MB";
                lable1.Content = totalCPU;
                lable2.Content = totalMemory;
            }

        }

        public void Run()
        {
            this.Show();
        }

        //return to main menu
        private void Back_To_Main_Menu_Left_Button_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mm = new MainMenu(theBL);
            mm.Run();
            this.Close();
        }

        //the list is being sorted when clicking on a header
        private void Sort_By_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader clickedHeader = e.OriginalSource as GridViewColumnHeader;
            ListSortDirection direction = ListSortDirection.Descending;

            if (clickedHeader != null)
            {
                 if (lastDirection == ListSortDirection.Ascending)
                        direction = ListSortDirection.Descending;
                else
                     direction = ListSortDirection.Ascending;
            }

            string sortString = ((Binding)clickedHeader.Column.DisplayMemberBinding).Path.Path;
            Sort(sortString, direction);
            lastHeaderClicked = clickedHeader;
            lastDirection = direction;

        }

        //the function performs the list sorting by the desired direction
        private void Sort(string sortBy, ListSortDirection direction)
        {
            ICollectionView dataView = CollectionViewSource.GetDefaultView(this.Process_List.ItemsSource != null ? this.Process_List.ItemsSource : this.Process_List.Items);

            dataView.SortDescriptions.Clear();
            SortDescription sD = new SortDescription(sortBy, direction);
            dataView.SortDescriptions.Add(sD);
            dataView.Refresh();
        }

        /*The function kills all the processes that were marked by the user
         */
        private void Kill_Process(object sender, RoutedEventArgs e)
        {
            foreach (var item in toKill)
            {
                string confirmation;
                confirmation=pm.killProcess(item.process);
                if(confirmation.Equals(""))
                    pro.Remove(item); // removing the processes from the list
                else
                    MessageBox.Show(confirmation);
            }
            toKill.Clear(); // updating the marked processes list

        }

        // The function recieves a checkbox checked event and adds the process to a list
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var temp1=e.Source as CheckBox;
            toKill.Add(temp1.DataContext as Proc);
        }

        //The function recieves a checkbox unchecked event and removes the process from a list
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            var temp1 = e.Source as CheckBox;
            toKill.Remove(temp1.DataContext as Proc);

        }

        private void Refresh_Processes(object sender, RoutedEventArgs e)
        {
            pro.Clear();
            pm = new ProcessMonitor();
            Thread.Sleep(500);    
            initialize();
        }

    }

    // an objeck to aid us with displaying the process list

        public class Proc
    {
        public Process process { get; set; }
        public string pName { get; set; }
        public double cpu { get; set; }
        public double memory { get; set; }
    }


}

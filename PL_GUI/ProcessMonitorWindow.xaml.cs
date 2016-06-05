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

namespace PL_GUI
{
    public partial class ProcessMonitorWindow : Window, IPL
    {
        ObservableCollection<Proc> pro;
        IBL theBL;
        private GridViewColumnHeader lastHeaderClicked = null;
        private ListSortDirection lastDirection = ListSortDirection.Ascending;
        private List<Process> toKill;
        private ProcessMonitor pm;

        //constructor
        public ProcessMonitorWindow(IBL theBL)
        {
            this.theBL = theBL;
            InitializeComponent();
            pro = new ObservableCollection<Proc>();
            pm = new ProcessMonitor();
            List<ProcessObj> processes = pm.getProcessList();

            // initializing the content of the list
            foreach (var p in processes)
            {
                Proc proc = new Proc()
                {
                    process=p.getProcess(),
                    pName = p.getProcess().ProcessName,
                    cpu = Convert.ToDouble(p.getCPU()),
                    memory = Convert.ToDouble(p.getMemory())

                };
                pro.Add(proc);
            }
            this.Process_List.ItemsSource = pro;
            this.toKill = new List<Process>();

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

        private void Kill_Process(object sender, RoutedEventArgs e)
        {
            pm.killProcess(toKill);

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

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Process[] p = Process.GetProcessesByName(e.Source as string);
            foreach(Process p1 in p)
            {
                toKill.Add(p1);
            }

        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            toKill.Remove(e.Source as Process);

        }

        private void listView_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            toKill.Add(item.process);
        }
    }

        public class Proc
    {
        public Process process { get; set; }
        public string pName { get; set; }
        public double cpu { get; set; }
        public double memory { get; set; }
    }


}

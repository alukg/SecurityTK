
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace BL.UserTools
{
    public class ProcessMonitor
    {
        private List<ProcessObj> processes;

        //constructor
        public ProcessMonitor()
        {
            processes = new List<ProcessObj>();
            Process[] allProcesses = Process.GetProcesses(); // array of current proccesses
            CounterSample[] firstSample = new CounterSample[allProcesses.Length];
            CounterSample[] secondSample = new CounterSample[allProcesses.Length];

           for(int p=0; p<allProcesses.Length; p++)
            {
                var cpu = new PerformanceCounter("Process", "% Processor Time", allProcesses[p].ProcessName);
                try
                {
                    firstSample[p] = cpu.NextSample();
                }
                catch(Exception e)
                {
                    string s = e.Message;
                }
            }

            Thread.Sleep(300);

            for (int p = 0; p < allProcesses.Length; p++)
            {
                var cpu = new PerformanceCounter("Process", "% Processor Time", allProcesses[p].ProcessName);
                try
                {
                    secondSample[p] = cpu.NextSample();
                    var mem = allProcesses[p].WorkingSet64;
                    ProcessObj process = new ProcessObj(allProcesses[p], CounterSample.Calculate(firstSample[p], secondSample[p]), mem);
                    processes.Add(process);
                }
                catch(Exception e) {
                    string s = e.Message;
                }
            }


        }

        //returns the list of current process
        public List<ProcessObj> getProcessList()
        {
            return this.processes;
        }

        //kills several processes
        public string killProcess(Process toKill)
        {
            try
            {
                toKill.Kill();
                return "";
            }
            catch(Exception e)
            {
                string s = e.Message;
                return "Could not kill process";
            }
        }
    }
}

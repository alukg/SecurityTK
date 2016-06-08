
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

            foreach(Process p in allProcesses)
            {
                var cpu = new PerformanceCounter("Process", "% Processor Time", p.ProcessName);
                var mem = p.WorkingSet64;
                if (p.ProcessName != "Idle")
                {
                    ProcessObj process = new ProcessObj(p, cpu, mem);
                    processes.Add(process);
                }
            }


        }

        //returns the list of current process
        public List<ProcessObj> getProcessList()
        {
            return this.processes;
        }

        //kills several processes
        public void killProcess(Process toKill)
        {
            toKill.Kill();
        }
    }
}

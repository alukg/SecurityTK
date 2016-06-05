using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace BL.UserTools
{
    public class ProcessObj
    {
        private Process process;
        private double cpu;
        private double memory;  

        //constructor
        public ProcessObj(Process process, PerformanceCounter cpu, long memory)
        {
            this.process = process;
            try
            {
                CounterSample cs1 = cpu.NextSample();
                Thread.Sleep(300);
                CounterSample cs2 = cpu.NextSample();
                this.cpu = CounterSample.Calculate(cs1, cs2);
            }
            catch(Exception e)
            {
                
            }
            this.memory = memory/ (1024f) / 1024f;
                
        }

        //get process
        public Process getProcess()
        {
            return this.process;
        }

        //get cpu
        public double getCPU()
        {
            return this.cpu;
        }

        //get memory
        public double getMemory()
        {
            return this.memory;
        }
    }
}

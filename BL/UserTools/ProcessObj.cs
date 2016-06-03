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
        private float cpu;
        private float memory;  

        //constructor
        public ProcessObj(Process process, PerformanceCounter cpu, float memory)
        {
            ifqASDES
            this.process = process;
            /* cpu.NextValue();
             Thread.Sleep(1000);
             this.cpu = cpu.NextValue();*/

            CounterSample cs1 = cpu.NextSample();
            //Thread.Sleep(100);
            CounterSample cs2 = cpu.NextSample();
            this.cpu = CounterSample.Calculate(cs1, cs2);
            this.memory = memory;
        }

        //get process
        public Process getProcess()
        {
            return this.process;
        }

        //get cpu
        public float getCPU()
        {
            return this.cpu;
        }

        //get memory
        public float getMemory()
        {
            return this.memory;
        }
    }
}

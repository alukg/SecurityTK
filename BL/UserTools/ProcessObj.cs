
using System;
using System.Diagnostics;


namespace BL.UserTools
{
    public class ProcessObj
    {
        private Process process;
        private double cpu;
        private double memory;

        //constructor
        public ProcessObj(Process process, double cpu, long memory)
        {
            this.process = process;
            if (process.ProcessName != "Idle")
            {
                if (cpu > 100) // if the process takes more than 100%, divide it by the number of cores
                    cpu = cpu / Environment.ProcessorCount;

                //making the doubles show only two digits after the decimical point
                string tempcpu = String.Format("{0:0.00}", cpu);
                cpu = Convert.ToDouble(tempcpu);
                this.cpu = cpu;

                string tempMemory = String.Format("{0:0.00}", memory / (1024f) / 1024f);
                this.memory = Convert.ToDouble(tempMemory);
            }

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

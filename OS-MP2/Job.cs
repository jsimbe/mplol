using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OS_MP2
{
    class Job
    {
        public int JobNumber { get; set; }
        public int ArrivalTime { get; set; }
        public int Cycle { get; set; }
        public string JobType { get; set; }
        public int TimeFinished { get; set; }
        public int WatingTime { get; set; }
        public int ResponseTime { get; set; }
        public int TurnaroundTime { get; set; }
        public int OriginalCycle { get; set; }

        public Job(int jobNumber, int arrivalTime, int cycle, string jobType)
        {
            this.ArrivalTime = arrivalTime;
            this.Cycle = cycle;
            this.JobNumber = jobNumber;
            this.JobType = jobType;
            this.OriginalCycle = cycle;
        }
    }
}

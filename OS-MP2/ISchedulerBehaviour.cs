using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OS_MP2
{
    interface ISchedulerBehaviour
    {
        void Simulate(List<Job> jobList, List<Job> waitingQueue,ref Job currentJob, int time);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace OS_MP2
{
    class Scheduler
    {
        List<Job> waitingQueue = new List<Job>();
        List<Job> jobList = new List<Job>();
        Job currentJob;
        static int time = 0;
        public ISchedulerBehaviour SchedulerBehaviour;

        public void jobInit()
        {
            int[] arrivalTime = { 0, 3, 5, 9, 10, 12, 14, 16, 17, 19 };
            int[] CPUCycle = { 6, 2, 1, 7, 5, 3, 4, 5, 7, 2 };
            string[] jobType = { "N", "NPR", "PR", "PR", "N", "N", "NPR", "PR", "PR", "N"};
            int index = 0;
            foreach (int a in arrivalTime)
            {
                Job j = new Job(index+1,a,CPUCycle[index],jobType[index]);
                Debug.WriteLine(jobType[index]);
                jobList.Add(j);
                Debug.WriteLine("job " + j.JobType + " added!");
                index++;

            }

            //hackish
            currentJob = jobList.First();
            jobList.Remove(currentJob);


        }

        public void Simulate()
        {
            
            while (jobList.Count > 0 || waitingQueue.Count > 0)
            {
                if (currentJob.JobType == "N")
                {
                    this.SchedulerBehaviour = new RR();
                    Debug.WriteLine("now using round robin algorithm!");

                }
                else
                {
                    this.SchedulerBehaviour = new FCFS();
                    Debug.WriteLine("now using first come, first served algorithm!");
                }
                SchedulerBehaviour.Simulate(jobList, waitingQueue, ref currentJob, time);
                time++;

                Debug.WriteLine("current job on scheduler: " + currentJob.JobNumber + " remaining cycle: " + currentJob.Cycle);
                if (waitingQueue.Count > 0)
                {
                    Debug.WriteLine("next in queue: " + waitingQueue.First().JobNumber);
                }
                else
                {
                    Debug.WriteLine("queue empty!");
                }
            }
            
        }

        public List<Job> GetJobList()
        {
            return jobList;
        }
    }
}

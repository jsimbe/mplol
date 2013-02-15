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
        List<Job> jobsFinished = new List<Job>();
        Job currentJob;
        public string timeline = "";
        public string jobTimeLine = "";
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
        }

        public void waitingQueueInit()
        {
            waitingQueue.Clear();
        }

        public void resetTime()
        {
            time = 0;
            timeline = "";
            jobTimeLine = "";
        }
        public void Simulate()
        {
            //hackish
            currentJob = jobList.First();
            jobList.Remove(currentJob);
            
            while ((jobList.Count > 0 || waitingQueue.Count > 0) || currentJob.Cycle > 0)
            {
                
                if (currentJob.JobType == "N")
                {
                    
                    this.SchedulerBehaviour = new SJN();
                    Debug.WriteLine("now using shortest job next algorithm!");

                }
                else if (currentJob.JobType == "NPR")
                {
                    this.SchedulerBehaviour = new FCFS();
                    Debug.WriteLine("now using first come, first served algorithm!");
                }
                else
                {
                    this.SchedulerBehaviour = new RR();
                    Debug.WriteLine("now using round robin algorithm!");

                }
                
               

                SchedulerBehaviour.Simulate(jobList, waitingQueue, ref currentJob, time);
                time++;

                timeline += time.ToString() + " ";
                jobTimeLine += currentJob.JobNumber.ToString() + " ";

                Debug.WriteLine("current job on scheduler: " + currentJob.JobNumber + " remaining cycle: " + currentJob.Cycle);
                if (currentJob.Cycle == 0)
                {
                    currentJob.TimeFinished = time;
                    jobsFinished.Add(currentJob);

                }
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

        public void Compute()
        {
            foreach (Job j in jobsFinished)
            {
                j.TurnaroundTime = j.TimeFinished - j.ArrivalTime;
                j.WatingTime = j.TurnaroundTime - j.OriginalCycle;
            }
        }
        public List<Job> GetJobList()
        {
            return jobList;
        }

        public List<Job> GetFinishedJobs()
        {
            return jobsFinished;
        }
    }
}

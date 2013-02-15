using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace OS_MP2
{
    class RR : ISchedulerBehaviour
    {
        //Like fcfs but preempt job after N cycles.
        static int quantum = 0;

        public void Simulate(List<Job> jobList, List<Job> waitingQueue, ref Job currentJob, int time)
        {
            const int SLICE = 4;
            if (jobList.Count != 0)
            {
                Job readyJob = jobList[0];
                if (time == readyJob.ArrivalTime)
                {
                    if (currentJob == null && waitingQueue.Count == 0)
                    {
                        currentJob = readyJob;
                    }
                    else
                    {
                        waitingQueue.Add(readyJob);
                    }

                    jobList.Remove(readyJob);
                }
            }
            if (currentJob != null)
            {
                
                currentJob.Cycle--;
                
                
                if (currentJob.Cycle < 0 || quantum == SLICE)
                {
                    quantum = 0;
                    if (currentJob.Cycle >= 0)
                    {
                        //hackish
                        currentJob.Cycle++;
                        waitingQueue.Add(currentJob);
                    }
                    if (currentJob.Cycle < 0)
                    {
                       
                        currentJob.TimeFinished = time;
                    }
                    if (waitingQueue.Any(j => j.JobType != "N"))
                    {
                        currentJob = waitingQueue.FirstOrDefault(j => j.JobType != "N");
                        waitingQueue.Remove(currentJob);
                        currentJob.Cycle--;
                    }
                    else
                    {
                        currentJob = waitingQueue.First();
                        waitingQueue.Remove(waitingQueue.First());
                        currentJob.Cycle--;
                    }
                    
                }
                Debug.WriteLine("quantum: " + quantum);
                quantum++; 
            }

            //tests
            if (currentJob == null)
            {
                Debug.WriteLine("current job null");
            }
            else
            {
                Debug.WriteLine("time : " + time + " job: " + currentJob.JobNumber + " remaining cycles: " + currentJob.Cycle);
            }
        }

    }
}

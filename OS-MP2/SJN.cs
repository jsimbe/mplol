using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace OS_MP2
{
    class SJN : ISchedulerBehaviour
    {
        //preempt if waiting job is shorter than current job.
        //process by arrival time.

        public void Simulate(List<Job> jobList, List<Job> waitingQueue, ref Job currentJob, int time)
        {
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
                if (currentJob.Cycle < 0)
                {
                   
                    currentJob.TimeFinished = time;
                    currentJob = waitingQueue.First();
                    waitingQueue.Remove(waitingQueue.First());
                    currentJob.Cycle--;
                }
                if (waitingQueue.Count > 0)
                {
                    if (currentJob.Cycle > waitingQueue.First().Cycle)
                    {
                        waitingQueue.Add(currentJob);
                        currentJob = waitingQueue.First();
                        waitingQueue.Remove(currentJob);
                        currentJob.Cycle--;
                    }
                }

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

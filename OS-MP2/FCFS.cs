using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace OS_MP2
{
    class FCFS : ISchedulerBehaviour
    {
        //basic alg
        //take job from joblist
        //process the job if processor is idle
        //else put job on waiting queue.
        //non-preemptive. process job by arrival time.

        public void Simulate(List<Job> jobList, List<Job> waitingQueue,ref Job currentJob, int time)
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
                    currentJob = waitingQueue.First();
                    waitingQueue.Remove(waitingQueue.First());
                    currentJob.Cycle--;
                }
            }

            //tests
            if (currentJob == null)
            {
                Debug.WriteLine("current job null");
            }
            else
            {
                Debug.WriteLine("time : " + time + " job: " + currentJob.JobNumber);
            }
            
        }


    }
}

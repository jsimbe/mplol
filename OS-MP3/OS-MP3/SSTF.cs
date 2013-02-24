using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace OS_MP3
{
    class SSTF:IOptimizeStrategy
    {
        public List<Request> Simulate(List<Request> requestList,int trackCount)
        {
            int time = 0;
            int currentTrack = 0;
            Request currentRequest;
            List<Request> waitingQueue = new List<Request>();
            List<Request> finishedRequest = new List<Request>();

            while (requestList.Count > 0 || waitingQueue.Count > 0)
            {
                if (requestList.Count > 0 && requestList.First().ArrivalTime == time)
                {
                    waitingQueue.Add(requestList.First());
                    requestList.Remove(requestList.First());
                }
                //find the closest available track to be processed.
                currentRequest = waitingQueue.OrderBy(x => Math.Abs(currentTrack - x.Track)).First();
                Debug.WriteLine("time: " + time + "current track: " + currentTrack + " current request: " + currentRequest.Track);
                if (currentTrack < currentRequest.Track)
                {
                    currentTrack++;
                    time++;
                }
                else if (currentTrack > currentRequest.Track)
                {
                    currentTrack--;
                    time++;
                }
                else
                {
                    Debug.WriteLine("request finished: " + currentRequest.Track);
                    currentRequest.TimeAccessed = time;
                    finishedRequest.Add(currentRequest);
                    waitingQueue.Remove(currentRequest);
                }
            }

            return finishedRequest;
        }
    }
}

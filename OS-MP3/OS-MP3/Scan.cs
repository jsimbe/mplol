using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace OS_MP3
{
    class Scan:IOptimizeStrategy
    {
        public List<Request> Simulate(List<Request> requestList,int trackCount)
        {
            int MAX = trackCount;
            int directionBit = 1;
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
                if (currentTrack < MAX - 1 && directionBit == 1)
                {
                    directionBit = 1;
                    currentRequest = waitingQueue.OrderBy(x => x.Track).FirstOrDefault(x => x.Track >= currentTrack);
                }
                else
                {
                    directionBit = -1;
                    currentRequest = waitingQueue.OrderByDescending(x => x.Track).FirstOrDefault(x => x.Track <= currentTrack);
                }

                
                if (currentRequest != null && currentRequest.Track == currentTrack)
                {
                    Debug.WriteLine("time: " + time + "current track: " + currentTrack + " current request: " + currentRequest.Track);
                    currentRequest.TimeAccessed = time;
                    finishedRequest.Add(currentRequest);
                    waitingQueue.Remove(currentRequest);
                }
                
                time++;
                currentTrack += directionBit;
            }

            return finishedRequest;
        }
    }
}

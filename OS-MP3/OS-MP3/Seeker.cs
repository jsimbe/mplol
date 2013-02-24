using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace OS_MP3
{
    class Seeker
    {
        List<Request> requestList;
        List<Request> waitingQueue;
        List<Request> finishedRequest = new List<Request>();
        public int TrackCount { get; set; }
        public IOptimizeStrategy OptimizeStrategy;

        public void Init()
        {
            TrackCount = 200;

            requestList = new List<Request>();
            int[] arrivalTime = { 0, 23, 25, 29, 35, 45, 57, 83, 88, 95 };
            int[] trackRequested = { 45, 132, 20, 23, 198, 170, 180, 78, 73, 150 };
            int requestNumber = 1;

            foreach (int a in arrivalTime)
            {
                Request r = new Request(requestNumber, a, trackRequested[requestNumber - 1]);
                requestList.Add(r);
                Debug.WriteLine("request " + requestNumber + " added to the list");
                requestNumber++;
            }
        }

        public List<Request> Simulate()
        {
            waitingQueue = new List<Request>();
            finishedRequest = OptimizeStrategy.Simulate(requestList,this.TrackCount);
            return finishedRequest;
        }

        public List<Request> GetRequestList()
        {
            return requestList;
        }
    }
}

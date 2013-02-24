using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OS_MP3
{
    class Request
    {
        public int RequestNumber { get; set; }
        public int ArrivalTime { get; set; }
        public int Track { get; set; }
        public int TimeAccessed { get; set; }

        public Request(int requestNumber, int arrivalTime, int track)
        {
            this.ArrivalTime = arrivalTime;
            this.RequestNumber = requestNumber;
            this.Track = track;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OS_MP3
{
    interface IOptimizeStrategy
    {
        List<Request> Simulate(List<Request> requestList,int trackCount);
    }
}

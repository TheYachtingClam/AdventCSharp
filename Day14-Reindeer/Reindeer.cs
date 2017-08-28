using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14_Reindeer
{
    class Reindeer
    {
        public string Name { get; set; }

        public int Speed { get; set; }
        
        public int GoLength { get; set; }
        
        public int StopLength { get; set; }

        public int TravelledDistance(int timeSpent)
        {
            int cycle = GoLength + StopLength;
            int numCycles = timeSpent / cycle;
            int leftOverTime = timeSpent % cycle;
            if(leftOverTime > GoLength )
            {
                leftOverTime = GoLength;
            }

            return Speed * (numCycles * GoLength + leftOverTime);
        }
    }
}

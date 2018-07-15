using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day24_Balance
{
    class Combo
    {
        public List<int> Passenger { get; set; } = new List<int>();

        public List<int> LeftContainer { get; set; } = new List<int>();

        public List<int> RightContainer { get; set; } = new List<int>();

        public int? QuantumEntanglement
        {
            get
            {
                if(LeftContainer.Count > 0 && Passenger.Count >= LeftContainer.Count ||
                   RightContainer.Count > 0 && Passenger.Count >= RightContainer.Count)
                {
                    return null;
                }
                else
                {
                    var qe = 1;
                    foreach(var pass in Passenger)
                    {
                        qe *= pass;
                    }
                    return qe;
                }
            }
        }
    }
}

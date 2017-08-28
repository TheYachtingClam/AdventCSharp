using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day13_Knights
{
    public class GuestNode
    {
        public string Name { get; set; }

        public GuestNode Right { get; set; }

        public int TotalValue { get; set; }
    }
}

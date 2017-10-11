using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day16_Sue
{
    public class SueData
    {
        public int children { get; set; }

        public int cats { get; set; }

        public int samoyeds { get; set; }

        public int pomeranians { get; set; }

        public int akitas { get; set; }

        public int vizslas { get; set; }

        public int goldfish { get; set; }

        public int trees { get; set; }

        public int cars { get; set; }

        public int perfumes { get; set; }

        public bool compare (SueData comp)
        {
            if(comp.children != 0 && comp.children != children)
            {
                return false;
            }
            
            if (comp.cats != 0 && comp.cats != cats)
            {
                return false;
            }

            if (comp.samoyeds != 0 && comp.samoyeds != samoyeds)
            {
                return false;
            }

            if (comp.pomeranians != 0 && comp.pomeranians != pomeranians)
            {
                return false;
            }

            if (comp.akitas != 0 && comp.akitas != akitas)
            {
                return false;
            }

            if (comp.vizslas != 0 && comp.vizslas != vizslas)
            {
                return false;
            }

            if (comp.goldfish != 0 && comp.goldfish != goldfish)
            {
                return false;
            }

            if (comp.trees != 0 && comp.trees != trees)
            {
                return false;
            }

            if (comp.cars != 0 && comp.cars != cars)
            {
                return false;
            }

            if (comp.perfumes != 0 && comp.perfumes != perfumes)
            {
                return false;
            }
            return true;
        }
    }
}

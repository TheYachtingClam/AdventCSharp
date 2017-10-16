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

        public SueData()
        {
            children = -1;
            cats = -1;
            samoyeds = -1;
            pomeranians = -1;
            akitas = -1;
            vizslas = -1;
            goldfish = -1;
            trees = -1;
            cars = -1;
            perfumes = -1;
        }

        public bool compare (SueData comp)
        {
            if(comp.children != -1 && comp.children != children)
            {
                return false;
            }
            
            if (comp.cats != -1 && comp.cats <= cats)
            {
                return false;
            }

            if (comp.samoyeds != -1 && comp.samoyeds != samoyeds)
            {
                return false;
            }

            if (comp.pomeranians != -1 && comp.pomeranians <= pomeranians)
            {
                return false;
            }

            if (comp.akitas != -1 && comp.akitas != akitas)
            {
                return false;
            }

            if (comp.vizslas != -1 && comp.vizslas != vizslas)
            {
                return false;
            }

            if (comp.goldfish != -1 && comp.goldfish >= goldfish)
            {
                return false;
            }

            if (comp.trees != -1 && comp.trees <= trees)
            {
                return false;
            }

            if (comp.cars != -1 && comp.cars != cars)
            {
                return false;
            }

            if (comp.perfumes != -1 && comp.perfumes != perfumes)
            {
                return false;
            }
            return true;
        }
    }
}

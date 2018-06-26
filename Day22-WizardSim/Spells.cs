using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day22_WizardSim
{
    public class Spells
    {
        public string Name { get; set; }

        public int ManaCost { get; set; }

        public Action<Character, Character> DoSomething;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day22_WizardSim
{
    public class Effect
    {
        public string Name { get; set; }

        public int Time { get; set; }

        public Action<Character> DoEffect;

        public Effect(string name, int time, Action<Character> action)
        {
            Name = name;
            Time = time;
            DoEffect = action;
        }

        public Effect Clone()
        {
            return new Effect(Name, Time, DoEffect);
        }
    }
}

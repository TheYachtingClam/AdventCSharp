using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day22_WizardSim
{
    class Program
    {
        static void Main(string[] args)
        {
            var me = new Character(100, 0, 0);
            var boss = new Character(58, 0, 9);

            var spells = new List<Spells>
            {
                new Spells { Name = "Magic Missle", ManaCost = 53,  Damage = 4},
                new Spells { Name = "Drain",        ManaCost = 73,  Damage = 2, Heal = 2 },
                new Spells { Name = "Shield",       ManaCost = 113,  Armor = 7, Time = 6 },
                new Spells { Name = "Poison",       ManaCost = 173,  DOT = 3,   Time = 6 },
                new Spells { Name = "Recharge",     ManaCost = 229,  Mana = 101, Time = 5 },
            };
        }
    }
}

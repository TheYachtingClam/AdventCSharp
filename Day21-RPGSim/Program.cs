using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day21_RPGSim
{
    class Program
    {
        static void Main(string[] args)
        {
            var me = new Character(100, 0, 0);
            var boss = new Character(104, 1, 8);
            var winningChars = new List<Character>();

            var weapons = new List<Equipment>
            {
                new Equipment { Name = "Dagger",        Cost = 8,  Damage = 4, Armor = 0 },
                new Equipment { Name = "Shortsword",    Cost = 10, Damage = 5, Armor = 0 },
                new Equipment { Name = "Warhammer",     Cost = 25, Damage = 6, Armor = 0 },
                new Equipment { Name = "Longsword",     Cost = 40, Damage = 7, Armor = 0 },
                new Equipment { Name = "Greataxe",      Cost = 74, Damage = 8, Armor = 0 },
            };

            var armors = new List<Equipment>
            {
                new Equipment { Name = "Empty",         Cost = 0,   Damage = 0, Armor = 0 },
                new Equipment { Name = "Leather",       Cost = 13,  Damage = 0, Armor = 1 },
                new Equipment { Name = "Chainmail",     Cost = 31,  Damage = 0, Armor = 2 },
                new Equipment { Name = "Splintmail",    Cost = 53,  Damage = 0, Armor = 3 },
                new Equipment { Name = "Bandedmail",    Cost = 75,  Damage = 0, Armor = 4 },
                new Equipment { Name = "Platemail",     Cost = 102, Damage = 0, Armor = 5 },
            };

            var rings = new List<Equipment>
            {
                new Equipment { Name = "EmptyLeft",     Cost = 0,   Damage = 0, Armor = 0 },
                new Equipment { Name = "EmptyRight",    Cost = 0,   Damage = 0, Armor = 0 },
                new Equipment { Name = "Damage1",       Cost = 25,  Damage = 1, Armor = 0 },
                new Equipment { Name = "Damage2",       Cost = 50,  Damage = 2, Armor = 0 },
                new Equipment { Name = "Damage3",       Cost = 100, Damage = 3, Armor = 0 },
                new Equipment { Name = "Defense1",      Cost = 20,  Damage = 0, Armor = 1 },
                new Equipment { Name = "Defense2",      Cost = 40,  Damage = 0, Armor = 2 },
                new Equipment { Name = "Defense3",      Cost = 80,  Damage = 0, Armor = 3 },
            };

            foreach(var weapon in weapons)
            {
                foreach(var armor in armors)
                {
                    foreach(var ring1 in rings)
                    {
                        foreach(var ring2 in rings)
                        {
                            if(ring1.Name == ring2.Name)
                            {
                                continue;
                            }
                            var fightMe = me.Clone();
                            var fightBoss = boss.Clone();
                            fightMe.equipment.Add(weapon);
                            fightMe.equipment.Add(armor);
                            fightMe.equipment.Add(ring1);
                            fightMe.equipment.Add(ring2);
                            if(!Fight(fightMe, fightBoss))
                            {
                                winningChars.Add(fightMe);
                            }
                        }
                    }
                }
            }

            var cheapestValue = winningChars.Max(ch => ch.Cost);
            var cheapestChar = winningChars.First(ch => ch.Cost == cheapestValue);

            Console.WriteLine($"cheapestVal = {cheapestValue}");
            Console.ReadKey();
        }

        public static bool Fight(Character me, Character boss)
        {
            while(true)
            {
                // you attack
                if(boss.Armor < me.Damage)
                {
                    boss.HitPoints -= (me.Damage - boss.Armor);
                }
                else
                {
                    boss.HitPoints -= 1;
                }
                if(boss.HitPoints <= 0)
                {
                    return true;
                }

                // boss attacks
                if(me.Armor < boss.Damage)
                {
                    me.HitPoints -= (boss.Damage - me.Armor);
                }
                else
                {
                    me.HitPoints -= 1;
                }
                if(me.HitPoints <= 0)
                {
                    return false;
                }
            }
        }
    }
}

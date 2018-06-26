using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day22_WizardSim
{
    class Program
    {
        static int lowestBoss = 500;

        static void Main(string[] args)
        {
            var me = new Character { HitPoints = 50, Mana = 500 };
            var boss = new Character {HitPoints = 58, Damage = 9};

            var spells = new List<Spells>
            {
                new Spells { Name = "Magic Missle", ManaCost = 53,   DoSomething = delegate(Character ch, Character bo) { bo.HitPoints -= 4; } },
                new Spells { Name = "Drain",        ManaCost = 73,   DoSomething = delegate(Character ch, Character bo) { bo.HitPoints -= 2; ch.HitPoints += 2; } },
                new Spells { Name = "Shield",       ManaCost = 113,  DoSomething = delegate(Character ch, Character bo) { ch.ActiveEffects.Add(new Effect("Shield", 6, delegate(Character c) { c.Armor += 7; })); } },
                new Spells { Name = "Poison",       ManaCost = 173,  DoSomething = delegate(Character ch, Character bo) { bo.ActiveEffects.Add(new Effect("Poison", 6, delegate(Character c) { c.HitPoints -= 3; })); } },
                new Spells { Name = "Recharge",     ManaCost = 229,  DoSomething = delegate(Character ch, Character bo) { ch.ActiveEffects.Add(new Effect("Recharge", 5, delegate(Character c) { c.Mana += 101; })); } },
            };

            var winningSpell = new Dictionary<int, List<Spells>>();

            for (int i = 1; i < 20; ++i)
            {
                var spellComb = SpellCombination(i, spells);
                var spellWinning = 0;
                foreach (var comb in spellComb)
                {
                    var spentMana = Fight(me.Clone(), boss.Clone(), comb);

                    if (spentMana > 0)
                    {
                        winningSpell[spentMana] = new List<Spells>(comb);
                        spellWinning++;
                    }
                }
                Console.WriteLine($"Found {spellWinning} winning combos in {i}");
                if (winningSpell.Keys.Any())
                {
                    var bob = winningSpell.Keys.Min();
                    Console.WriteLine($"Minimum = {bob}");
                    Console.WriteLine($"Spells = {string.Join("\n", winningSpell[bob].Select(s => s.Name))}\n");
                }
            }
            Console.ReadKey();

        }

        static int Fight(Character me, Character boss, List<Spells> spells)
        {
            var spentMana = 0;
            var spellsCast = 0;
            foreach(var spell in spells)
            {
                // reset armor to 0.
                me.Armor = 0;
                me.HitPoints--;

                //Console.WriteLine("effects before my turn");
                //PrintDetails(me, "ME");
                //PrintDetails(boss, "BOSS");
                // Check Victory
                if (me.HitPoints <= 0)
                {
                    return -1;  // I died
                }

                if (boss.HitPoints <= 0)
                {
                    if (spellsCast == spells.Count)
                    {
                        return spentMana;  // boss died
                    }
                    else
                    {
                        return -20;
                    }
                }

                // Resolve Effects
                foreach (var eff in me.ActiveEffects)
                {
                    eff.DoEffect(me);
                    eff.Time -= 1;
                }
                me.ActiveEffects.RemoveAll(s => s.Time == 0);
                foreach (var eff in boss.ActiveEffects)
                {
                    eff.DoEffect(boss);
                    eff.Time -= 1;
                }
                boss.ActiveEffects.RemoveAll(s => s.Time == 0);

                //Console.WriteLine("effects before my turn");
                //PrintDetails(me, "ME");
                //PrintDetails(boss, "BOSS");
                // Check Victory
                if (me.HitPoints <= 0)
                {
                    return -1;  // I died
                }
                    
                if (boss.HitPoints <= 0)
                {
                    if(spellsCast == spells.Count)
                    {
                        return spentMana;  // boss died
                    }
                    else
                    {
                        return -20;
                    }
                }

                // Cast Spell
                if (spell.ManaCost > me.Mana)
                {
                    return -10;  // Ran out of Mana.
                }
                else if(me.ActiveEffects.Any(ef => ef.Name == spell.Name) || boss.ActiveEffects.Any(ef => ef.Name == spell.Name))
                {
                    return -20; // Invalid spell order.
                }
                else
                {
                    spellsCast++;
                    spentMana += spell.ManaCost;
                    spell.DoSomething(me, boss);
                    me.Mana -= spell.ManaCost;
                }

                //Console.WriteLine("after my turn");
                //PrintDetails(me, "ME");
                //PrintDetails(boss, "BOSS");
                // Check Victory
                if (me.HitPoints <= 0)
                {
                    if (boss.HitPoints < lowestBoss)
                    {
                        lowestBoss = boss.HitPoints;
                    }
                    return -1;  // I died
                }
                if (boss.HitPoints <= 0)
                {
                    if (spellsCast == spells.Count)
                    {
                        return spentMana;  // boss died
                    }
                    else
                    {
                        return -20;
                    }
                }

                // reset armor to 0.
                me.Armor = 0;

                // Resolve Effects
                foreach (var eff in me.ActiveEffects)
                {
                    eff.DoEffect(me);
                    eff.Time -= 1;
                }
                me.ActiveEffects.RemoveAll(s => s.Time == 0);
                foreach (var eff in boss.ActiveEffects)
                {
                    eff.DoEffect(boss);
                    eff.Time -= 1;
                }
                boss.ActiveEffects.RemoveAll(s => s.Time == 0);

                //Console.WriteLine("effects before bosses turn");
                //PrintDetails(me, "ME");
                //PrintDetails(boss, "BOSS");
                // Check Victory
                if (me.HitPoints <= 0)
                {
                    if (boss.HitPoints < lowestBoss)
                    {
                        lowestBoss = boss.HitPoints;
                    }
                    return -1;  // I died
                }
                if (boss.HitPoints <= 0)
                {
                    if (spellsCast == spells.Count)
                    {
                        return spentMana;  // boss died
                    }
                    else
                    {
                        return -20;
                    }
                }

                // Boss Attacks
                var damage = boss.Damage - me.Armor;
                if(damage < 0)
                {
                    damage = 1;
                }
                me.HitPoints -= damage;

                //Console.WriteLine("after bosses turn");
                //PrintDetails(me, "ME");
                //PrintDetails(boss, "BOSS");
                // Check victory
                if (me.HitPoints <= 0)
                {
                    if (boss.HitPoints < lowestBoss)
                    {
                        lowestBoss = boss.HitPoints;
                    }
                    return -1;  // I died
                }
                if (boss.HitPoints <= 0)
                {
                    if (spellsCast == spells.Count)
                    {
                        return spentMana;  // boss died
                    }
                    else
                    {
                        return -20;
                    }
                }
            }

            return 0;  // No-one won
        }

        static void PrintDetails(Character ch, string nam)
        {
            Console.WriteLine($"************** {nam} *****************");
            Console.WriteLine($"HitPoints: {ch.HitPoints}");
            if(ch.Mana > 0)
            {
                Console.WriteLine($"Mana: {ch.Mana}");
            }
            if (ch.Armor > 0)
            {
                Console.WriteLine($"Armor: {ch.Armor}");
            }
            Console.WriteLine($"\tActive Effects");
            foreach (var ef in ch.ActiveEffects)
            {
                Console.WriteLine($"\t{ef.Name} has {ef.Time} left");
            }
            Console.WriteLine("**************************************\n");
        }

        static List<List<Spells>> SpellCombination(int numberOfTurns, List<Spells> spells)
        {
            var retValue = new List<List<Spells>>();

            for(int i = 0;i < numberOfTurns;++i)
            {
                var newValue = new List<List<Spells>>();
                
                foreach(var spell in spells)
                {
                    if(retValue.Any())
                    {
                        foreach (var comb in retValue)
                        {
                            var newComb = new List<Spells>(comb);
                            newComb.Add(spell);
                            newValue.Add(newComb);
                        }
                    }
                    else
                    {
                        newValue.Add(new List<Spells> { spell });
                    }
                }
                retValue = newValue;
            }
            return retValue;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day22_WizardSim
{
    public class Character
    {
        public int HitPoints { get; set; }

        private int armor;

        public int Armor
        {
            get
            {
                return armor;
            }
            set
            {
                armor = value;
            }
        }

        private int mana;

        public int Mana
        {
            get
            {
                return mana;
            }
            set
            {
                mana = value;
            }
        }

        private int damage;

        public int Damage
        {
            get
            {
                return damage;
            }
            set
            {
                damage = value;
            }
        }
        
        public Character (int hitPoints, int armor, int damage)
        {
            HitPoints = hitPoints;
            Armor = armor;
            Damage = damage;
        }

        public Character Clone()
        {
            return new Character(HitPoints, armor, damage);
        }

        public int Cost
        {
            get
            {
                return equipment.Sum(eq => eq.Cost);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day21_RPGSim
{
    public class Character
    {
        public int HitPoints { get; set; }

        private int armor;

        public int Armor
        {
            get
            {
                return armor + equipment.Sum(eq => eq.Armor);
            }
            set
            {
                armor = value;
            }
        }

        private int damage;

        public int Damage
        {
            get
            {
                return damage + equipment.Sum(eq => eq.Damage);
            }
            set
            {
                damage = value;
            }
        }

        public List<Equipment> equipment { get; set; } = new List<Equipment>();

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

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
        
        public Character Clone()
        {
            return new Character { HitPoints = HitPoints, Mana = Mana, Damage = Damage };
        }

        public List<Effect> ActiveEffects = new List<Effect>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8_Registers
{
    public class Registers
    {
        public readonly Dictionary<string, int> registers = new Dictionary<string, int>();

        public int HighestRegister { get; set; } = 0;

        public int GetRegister(string a)
        {
            if (registers.ContainsKey(a))
            {
                return registers[a];
            }
            else
            {
                registers[a] = 0;
                return 0;
            }
        }

        public void SetRegister(string a, int b)
        {
            if (b > HighestRegister)
            {
                HighestRegister = b;
            }
            registers[a] = b;
        }
    }
}

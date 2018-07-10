using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day23_TuringLock
{
    class TuringState
    {
        public int ProgramCounter { get; set; }

        public Dictionary<string, int> Registers { get; set; } = new Dictionary<string, int> { { "a", 1 }, { "b", 0 } };

        public virtual string ToString()
        {
            return $"PC={ProgramCounter}, Register[a]={Registers["a"]}, Register[b]={Registers["b"]}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day23_TuringLock
{
    class Instruction
    {
        public int Offset { get; private set; }

        public string Register { get; set; }

        public Action<TuringState> DoSomething;

        public string Name { get; set; }

        public Instruction(string inp)
        {
            var leftSide = inp;
            if (inp.Contains(','))
            {
                var stuff = inp.Split(',');
                Offset = getOffset(stuff[1].Trim());
                leftSide = stuff[0].Trim();
            }

            var instruction = leftSide.Split(' ')[0];
            Name = instruction;

            switch (instruction)
            {
                case "hlf":
                    Register = leftSide.Split(' ')[1];
                    DoSomething = (s) => { s.Registers[Register] = s.Registers[Register] / 2; s.ProgramCounter++; };
                    break;
                case "tpl":
                    Register = leftSide.Split(' ')[1];
                    DoSomething = (s) => { s.Registers[Register] = s.Registers[Register] * 3; s.ProgramCounter++; };
                    break;
                case "inc":
                    Register = leftSide.Split(' ')[1];
                    DoSomething = (s) => { s.Registers[Register]++; s.ProgramCounter++; };
                    break;
                case "jmp":
                    Offset = getOffset(leftSide.Split(' ')[1].Trim());
                    DoSomething = (s) => { s.ProgramCounter += Offset; };
                    break;
                case "jie":
                    Register = leftSide.Split(' ')[1];
                    DoSomething = (s) =>
                    {
                        if (s.Registers[Register] % 2 == 0)
                        {
                            s.ProgramCounter += Offset;
                        }
                        else
                        {
                            s.ProgramCounter++;
                        }
                    };
                    break;
                case "jio":
                    Register = leftSide.Split(' ')[1];
                    DoSomething = (s) =>
                    {
                        if (s.Registers[Register] == 1)
                        {
                            s.ProgramCounter += Offset;
                        }
                        else
                        {
                            s.ProgramCounter++;
                        }
                    };
                    break;
                default:
                    Console.WriteLine("AAAAARGH, we should never be here");
                    break;
            }
        }

        private int getOffset(string str)
        {
            if (str[0] == '+')
            {
                return int.Parse(str.Substring(1));
            }
            else
            {
                return -int.Parse(str.Substring(1));
            }
            
        }
    }
}

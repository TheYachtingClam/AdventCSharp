using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8_Registers
{
    class Instruction
    {
        public string RegisterToModify { get; set; }

        public enum ActionType
        {
            inc,
            dec,
        }

        public ActionType Action { get; set; } 

        public int ActionValue { get; set; }

        public Condition Condit { get; set; }

        public Instruction(string val)
        {
            RegisterToModify = val.Split(' ')[0];
            Action = ParseActionType(val.Split(' ')[1]);
            ActionValue = int.Parse(val.Split(' ')[2]);
            Condit = new Condition(val.Substring(val.IndexOf("if")));
        }

        public ActionType ParseActionType(string val)
        {
            if (val == "inc")
            {
                return ActionType.inc;
            }
            else if (val == "dec")
            {
                return ActionType.dec;
            }
            else
            {
                throw new ApplicationException("Action type is unknown.");
            }
        }

        public int HighestValue { get; set; }

        public void ModifyRegisters(Registers inp)
        {
            if (Condit.IsTrue(inp))
            {
                if (Action == ActionType.inc)
                {
                    inp.SetRegister(RegisterToModify, inp.GetRegister(RegisterToModify) + ActionValue);
                }
                else if (Action == ActionType.dec)
                {
                    inp.SetRegister(RegisterToModify, inp.GetRegister(RegisterToModify) - ActionValue);
                }
                else
                {
                    throw new ApplicationException("What the hell are we doing here");
                }
            }
        }
    }
}

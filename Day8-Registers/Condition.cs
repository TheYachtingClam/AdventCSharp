using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8_Registers
{
    using System.CodeDom;

    public class Condition
    {
        public string Register { get; set; }

        public enum ConditionType
        {
            GreaterThan,
            GreaterThanOrEqualTo,
            LessThan,
            LessThanOrEqualTo,
            EqualTo,
            NotEqualTo,
        }

        public ConditionType ConditionAction { get; set; }

        public int ConditionValue { get; set; }

        public bool IsTrue(Registers registers)
        {
            switch (ConditionAction)
            {
                case ConditionType.EqualTo:
                    return registers.GetRegister(Register) == ConditionValue;
                case ConditionType.NotEqualTo:
                    return registers.GetRegister(Register) != ConditionValue;
                case ConditionType.GreaterThan:
                    return registers.GetRegister(Register) > ConditionValue;
                case ConditionType.GreaterThanOrEqualTo:
                    return registers.GetRegister(Register) >= ConditionValue;
                case ConditionType.LessThan:
                    return registers.GetRegister(Register) < ConditionValue;
                case ConditionType.LessThanOrEqualTo:
                    return registers.GetRegister(Register) <= ConditionValue;
                default:
                    throw new ApplicationException("How the hell are we here");
            }
        }

        public Condition(string val)
        {
            Register = val.Split(' ')[1];
            ConditionValue = int.Parse(val.Split(' ')[3]);
            switch (val.Split(' ')[2].Trim())
            {
                case ">":
                    ConditionAction = ConditionType.GreaterThan;
                    break;
                case ">=":
                    ConditionAction = ConditionType.GreaterThanOrEqualTo;
                    break;
                case "<":
                    ConditionAction = ConditionType.LessThan;
                    break;
                case "<=":
                    ConditionAction = ConditionType.LessThanOrEqualTo;
                    break;
                case "==":
                    ConditionAction = ConditionType.EqualTo;
                    break;
                case "!=":
                    ConditionAction = ConditionType.NotEqualTo;
                    break;
                default:
                    throw new ApplicationException($"Aaargh, condition type {val.Split(' ')[1]} is unexpected");
            }
        }
    }
}

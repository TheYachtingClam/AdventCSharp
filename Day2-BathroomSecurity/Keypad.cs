using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2_BathroomSecurity
{
    public class Keypad
    {
        public int CurrentState { get; private set; } = 5;

        public int Move(Directions dir)
        {
            switch (dir)
            {
                case Directions.Up:
                    if (CurrentState == 3)
                    {
                        CurrentState = 1;
                    }
                    else if (CurrentState == 6)
                    {
                        CurrentState = 2;
                    }
                    else if (CurrentState == 7)
                    {
                        CurrentState = 3;
                    }
                    else if (CurrentState == 8)
                    {
                        CurrentState = 4;
                    }
                    else if (CurrentState == 10)
                    {
                        CurrentState = 6;
                    }
                    else if (CurrentState == 11)
                    {
                        CurrentState = 7;
                    }
                    else if (CurrentState == 12)
                    {
                        CurrentState = 8;
                    }
                    else if (CurrentState == 13)
                    {
                        CurrentState = 11;
                    }
                    return CurrentState;
                case Directions.Down:
                    if (CurrentState == 1)
                    {
                        CurrentState = 3;
                    }
                    else if (CurrentState == 2)
                    {
                        CurrentState = 6;
                    }
                    else if (CurrentState == 3)
                    {
                        CurrentState = 7;
                    }
                    else if (CurrentState == 4)
                    {
                        CurrentState = 8;
                    }
                    else if (CurrentState == 6)
                    {
                        CurrentState = 10;
                    }
                    else if (CurrentState == 7)
                    {
                        CurrentState = 11;
                    }
                    else if (CurrentState == 8)
                    {
                        CurrentState = 12;
                    }
                    else if (CurrentState == 11)
                    {
                        CurrentState = 13;
                    }
                    return CurrentState;
                case Directions.Left:
                    if (CurrentState != 1 && CurrentState != 2 && CurrentState != 5 && CurrentState != 10 && CurrentState != 13)
                    {
                        CurrentState--;
                    }
                    return CurrentState;
                case Directions.Right:
                    if (CurrentState != 1 && CurrentState != 4 && CurrentState != 9 && CurrentState != 12 && CurrentState != 13)
                    {
                        CurrentState++;
                    }
                    return CurrentState;
                default:
                    throw new Exception("aaaargh");
            }
        }

        public int Move(List<Directions> dir)
        {
            var retVal = 0;
            foreach (var d in dir)
            {
                retVal = Move(d);
            }
            return retVal;
        }
    }
}

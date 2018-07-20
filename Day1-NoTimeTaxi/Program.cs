using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1_NoTimeTaxi
{
    class Program
    {
        class Movement
        {
            public enum DirectionType
            {
                left,
                right,
            };

            public DirectionType Direction { get; set; }

            public int Distance { get; set; }
        }

        class State
        {
            public enum FacingDirectionType
            {
                north, 
                east,
                south,
                west,
            };

            private List<Tuple<int, int>> VisitedLocations = new List<Tuple<int, int>>();

            public FacingDirectionType FacingDirection { get; set; } = FacingDirectionType.north;

            public int xLocation { get; set; } = 0;

            public int yLocation { get; set; } = 0;

            public int GetDistance()
            {
                return Math.Abs(xLocation) + Math.Abs(yLocation);
            }

            public bool PerformMovement(Movement move)
            {
                if(FacingDirection == FacingDirectionType.north)
                {
                    if(move.Direction == Movement.DirectionType.left)
                    {
                        // face west and move
                        FacingDirection = FacingDirectionType.west;
                        for(int i = 0;i < move.Distance;++i)
                        {
                            xLocation--;
                            var thisLocation = new Tuple<int, int>(xLocation, yLocation);
                            if (VisitedLocations.Contains(thisLocation))
                            {
                                return true;
                            }
                            else
                            {
                                VisitedLocations.Add(thisLocation);
                            }
                        }
                    }
                    else
                    {
                        // face east and move
                        FacingDirection = FacingDirectionType.east;
                        for (int i = 0; i < move.Distance; ++i)
                        {
                            xLocation++;
                            var thisLocation = new Tuple<int, int>(xLocation, yLocation);
                            if (VisitedLocations.Contains(thisLocation))
                            {
                                return true;
                            }
                            else
                            {
                                VisitedLocations.Add(thisLocation);
                            }
                        }
                    }
                }
                else if(FacingDirection == FacingDirectionType.east)
                {
                    if (move.Direction == Movement.DirectionType.left)
                    {
                        // face north and move
                        FacingDirection = FacingDirectionType.north;
                        for (int i = 0; i < move.Distance; ++i)
                        {
                            yLocation++;
                            var thisLocation = new Tuple<int, int>(xLocation, yLocation);
                            if (VisitedLocations.Contains(thisLocation))
                            {
                                return true;
                            }
                            else
                            {
                                VisitedLocations.Add(thisLocation);
                            }
                        }
                    }
                    else
                    {
                        // face south and move
                        FacingDirection = FacingDirectionType.south;
                        for (int i = 0; i < move.Distance; ++i)
                        {
                            yLocation--;
                            var thisLocation = new Tuple<int, int>(xLocation, yLocation);
                            if (VisitedLocations.Contains(thisLocation))
                            {
                                return true;
                            }
                            else
                            {
                                VisitedLocations.Add(thisLocation);
                            }
                        }
                    }
                }
                else if (FacingDirection == FacingDirectionType.south)
                {
                    if (move.Direction == Movement.DirectionType.left)
                    {
                        // face east and move
                        FacingDirection = FacingDirectionType.east;
                        for (int i = 0; i < move.Distance; ++i)
                        {
                            xLocation++;
                            var thisLocation = new Tuple<int, int>(xLocation, yLocation);
                            if (VisitedLocations.Contains(thisLocation))
                            {
                                return true;
                            }
                            else
                            {
                                VisitedLocations.Add(thisLocation);
                            }
                        }
                    }
                    else
                    {
                        // face west and move
                        FacingDirection = FacingDirectionType.west;
                        for (int i = 0; i < move.Distance; ++i)
                        {
                            xLocation--;
                            var thisLocation = new Tuple<int, int>(xLocation, yLocation);
                            if (VisitedLocations.Contains(thisLocation))
                            {
                                return true;
                            }
                            else
                            {
                                VisitedLocations.Add(thisLocation);
                            }
                        }
                    }
                }
                else  // West
                {
                    if (move.Direction == Movement.DirectionType.left)
                    {
                        // face south and move
                        FacingDirection = FacingDirectionType.south;
                        for (int i = 0; i < move.Distance; ++i)
                        {
                            yLocation--;
                            var thisLocation = new Tuple<int, int>(xLocation, yLocation);
                            if (VisitedLocations.Contains(thisLocation))
                            {
                                return true;
                            }
                            else
                            {
                                VisitedLocations.Add(thisLocation);
                            }
                        }
                    }
                    else
                    {
                        // face north and move
                        FacingDirection = FacingDirectionType.north;
                        for (int i = 0; i < move.Distance; ++i)
                        {
                            yLocation++;
                            var thisLocation = new Tuple<int, int>(xLocation, yLocation);
                            if (VisitedLocations.Contains(thisLocation))
                            {
                                return true;
                            }
                            else
                            {
                                VisitedLocations.Add(thisLocation);
                            }
                        }
                    }
                    
                }
                return false;
            }
        }

        static void Main(string[] args)
        {
            var rData = LoadData("input.txt");

            var state = new State();
            foreach(var movement in rData)
            {
                if(state.PerformMovement(movement))
                {
                    Console.WriteLine($"first place visited twice is {state.GetDistance()}");
                    Console.ReadKey();
                }
            }
        }

        private static List<Movement> LoadData(string path)
        {
            var rData = new List<Movement>();

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    var moveParse = s.Split(',');
                    foreach(var move in moveParse)
                    {
                        var mov = move.Trim();
                        var movementObject = new Movement();
                        if(mov[0] == 'L')
                        {
                            movementObject.Direction = Movement.DirectionType.left;
                        }
                        else
                        {
                            movementObject.Direction = Movement.DirectionType.right;
                        }
                        var numberString = mov.Remove(0, 1);
                        movementObject.Distance = int.Parse(numberString);
                        rData.Add(movementObject);
                    }
                }
            }

            return rData;
        }
    }
}

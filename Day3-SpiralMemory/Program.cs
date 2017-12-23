using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_SpiralMemory
{
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            var rData = new List<int> {1, 12, 23, 1024, 347991};

            foreach (var i in rData)
            {
                var coordinates = CalculateCoordinates(i);
                var distance = CalculateDistanceFromOrigin(coordinates);
                Console.WriteLine($"my way {i} is carried {distance} steps");
                Console.WriteLine($"New way {i} is carried {CalculateDistanceFromOrigin(WhatLocationIs(i))}");
            }
            
            Console.ReadKey();
        }

        private static Tuple<int, int> MoveUp(Tuple<int, int> inp)
        {
            return new Tuple<int, int>(inp.Item1, inp.Item2 + 1);
        }

        private static Tuple<int, int> MoveDown(Tuple<int, int> inp)
        {
            return new Tuple<int, int>(inp.Item1, inp.Item2 - 1);
        }

        private static Tuple<int, int> MoveLeft(Tuple<int, int> inp)
        {
            return new Tuple<int, int>(inp.Item1 - 1, inp.Item2);
        }

        private static Tuple<int, int> MoveRight(Tuple<int, int> inp)
        {
            return new Tuple<int, int>(inp.Item1 + 1, inp.Item2);
        }

        enum direction
        {
            up,
            down,
            left,
            right,
        }

        private static Tuple<int, int> WhatLocationIs(int inp)
        {
            var growValues = new Dictionary<Tuple<int, int>, int>
            {
                {new Tuple<int, int>(0,0), 1}, 
            };

            var location = new Tuple<int, int>(0,0);
            int maxX = 0;
            int maxY = 0;
            int minX = 0;
            int minY = 0;
            var dir = direction.right;

            for (int i = 1; i < inp; ++i)
            {
                if (dir == direction.right)
                {
                    if (location.Item1 <= maxX)
                    {
                        location = MoveRight(location);
                        growValues[location] = CalculateValue(growValues, location);
                    }
                    else
                    {
                        maxX = location.Item1;
                        dir = direction.up;
                        location = MoveUp(location);
                        growValues[location] = CalculateValue(growValues, location);
                    }
                }
                else if (dir == direction.up)
                {
                    if (location.Item2 <= maxY)
                    {
                        location = MoveUp(location);
                        growValues[location] = CalculateValue(growValues, location);
                    }
                    else
                    {
                        maxY = location.Item2;
                        dir = direction.left;
                        location = MoveLeft(location);
                        growValues[location] = CalculateValue(growValues, location);
                    }
                }
                else if (dir == direction.left)
                {
                    if (location.Item1 >= minX)
                    {
                        location = MoveLeft(location);
                        growValues[location] = CalculateValue(growValues, location);
                    }
                    else
                    {
                        minX = location.Item1;
                        dir = direction.down;
                        location = MoveDown(location);
                        growValues[location] = CalculateValue(growValues, location);
                    }
                }
                else // down
                {
                    if (location.Item2 >=  minY)
                    {
                        location = MoveDown(location);
                        growValues[location] = CalculateValue(growValues, location);
                    }
                    else
                    {
                        minY = location.Item2;
                        dir = direction.right;
                        location = MoveRight(location);
                        growValues[location] = CalculateValue(growValues, location);
                    }
                }
            }
            return location;
        }

        private static int CalculateValue(Dictionary<Tuple<int, int>, int> growValues, Tuple<int, int> location)
        {
            int value = 0;

            for (int i = -1; i <= 1; ++i)
            {
                for (int j = -1; j <= 1; ++j)
                {
                    if (growValues.ContainsKey(new Tuple<int, int>(location.Item1 + i, location.Item2 + j)))
                    {
                        value += growValues[new Tuple<int, int>(location.Item1 + i, location.Item2 + j)];
                    }
                }
            }
            if (value > 347991)
            {
                Console.WriteLine($"big value is {value}");
            }
            
            return value;
        }

        private static int CalculateDistanceFromOrigin(Tuple<int, int> coordinates)
        {
            return Math.Abs(coordinates.Item1) + Math.Abs(coordinates.Item2);
        }

        private static Tuple<int, int> CalculateCoordinates(int i)
        {
            if (i == 1)
            {
                return new Tuple<int, int>(0, 0);
            }

            var currentSteps = 1;
            var squareNumber = 1;
            var squareNumberFound = -1;
            while (squareNumberFound == -1)
            {
                var stepsInThisSquare = 8 * squareNumber;

                if (i < currentSteps + stepsInThisSquare)
                {
                    //Console.WriteLine($"{i} is in square {squareNumber}");
                    squareNumberFound = squareNumber;

                    var startingCoords = CalculateStartingLocationOfSquare(squareNumber);
                    var startingValue = currentSteps + 1;
                    var upperRightCoords = new Tuple<int, int>(startingCoords.Item1, startingCoords.Item2 + squareNumber * 2 - 1);
                    var upperRightValue = currentSteps + squareNumber * 2;
                    var upperLeftCoords = new Tuple<int, int>(-upperRightCoords.Item1, upperRightCoords.Item2);
                    var upperLeftValue = upperRightValue + squareNumber * 2;
                    var lowerLeftCoords = new Tuple<int, int>(upperLeftCoords.Item1, -upperLeftCoords.Item2);
                    var lowerLeftValue = upperLeftValue + squareNumber * 2;
                    var lowerRightCoords = new Tuple<int, int>(-lowerLeftCoords.Item1, lowerLeftCoords.Item2);
                    var lowerRightValue = lowerLeftValue + squareNumber * 2;

                    //Console.WriteLine($"square #{squareNumber}");
                    //Console.WriteLine($"{upperLeftCoords}={upperLeftValue}----------------------{upperRightCoords}={upperRightValue}\n\n");
                    //Console.WriteLine($"{lowerLeftCoords}={lowerLeftValue}----------------------{lowerRightCoords}={lowerRightValue}");

                    if (i < upperRightValue)
                    {
                        var location = new Tuple<int, int>(startingCoords.Item1, startingCoords.Item2 + (i - startingValue));
                       // Console.WriteLine($"{i} is on the right at location {location}");

                        return location;
                    }
                    else if (i < upperLeftValue)
                    {
                        var location = new Tuple<int, int>(upperRightCoords.Item1 - (i - upperRightValue), upperRightCoords.Item2);
                        //Console.WriteLine($"{i} is on the top at location {location}");

                        return location;
                    }
                    else if (i < lowerLeftValue )
                    {
                        var location = new Tuple<int, int>(upperLeftCoords.Item1, upperLeftCoords.Item2 - (i - upperLeftValue));
                        //Console.WriteLine($"{i} is on the left at location {location}");

                        return location;
                    }
                    else
                    {
                        var location = new Tuple<int, int>(lowerLeftCoords.Item1 + (i - lowerLeftValue), lowerLeftCoords.Item2);
                        //Console.WriteLine($"{i} is on the bottom at location {location}");

                        return location;
                    }
                }

                currentSteps += stepsInThisSquare;
                squareNumber++;
            }

            return null;
        }

        private static Tuple<int, int> CalculateStartingLocationOfSquare(int i)
        {
            return new Tuple<int, int>(i, 1 - i);
        }
    }
}

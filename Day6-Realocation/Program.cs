using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6_Realocation
{
    class Program
    {
        static void Main(string[] args)
        {
            var banks = new List<int> { 5  ,  1 ,  10 , 0  , 1  , 7  , 13 , 14  ,3  , 12 , 8  , 10 , 7   ,12  ,0   ,6 };
            //var banks = new List<int>{0, 2, 7, 0};

            var previousState = new List<List<int>> {};
            var steps = 0;
            var currentState = new List<int>(banks);
            previousState.Add(currentState);
            Console.WriteLine($"starting with {string.Join(",", currentState)}");

            while (true)
            {
                var maxValue = banks.Max();
                var maxIndex = banks.IndexOf(maxValue);
                banks[maxIndex] = 0;
                steps++;

                for (int i = maxValue; i > 0; --i)
                {
                    ++maxIndex;
                    if (maxIndex >= banks.Count)
                    {
                        maxIndex -= banks.Count;
                    }
                    banks[maxIndex]++;
                }

                var temp = new List<int>(banks);

                var foundIndex = 0;
                for (foundIndex = 0; foundIndex < previousState.Count; foundIndex++)
                {
                    if (previousState[foundIndex].SequenceEqual(temp))
                    {
                        break;
                    }
                }

                if (!previousState.Any(s=> s.SequenceEqual(temp)))
                {
                    Console.WriteLine($"adding {string.Join(",", temp)}");
                    previousState.Add(temp);
                }
                else
                {
                    Console.WriteLine($"already contains {string.Join(",", temp)} took {steps} and the loop is {steps - foundIndex}");
                    break;
                }
            }
            Console.ReadKey();
        }
    }
}

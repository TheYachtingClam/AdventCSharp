using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day20_InfinateElves
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i < 10000000; ++i)
            {
                var presents = PresentsInHouse(i);
                
                if(i % 10000 == 0)
                {
                    Console.WriteLine($"[{i}] = {string.Join(",", presents)}");
                }

                if(presents > 29000000)
                {
                    Console.WriteLine($"[{i}] = {string.Join(",", presents)}");
                    break;
                }
            }
            Console.ReadKey();
        }

        public static List<int> WhichElvesDeliver(int houseNumber)
        {
            var retVal = new List<int>();
            for(int i = 1;i <= houseNumber;++i)
            {
                if(houseNumber % i == 0 && houseNumber <= i * 50)
                {
                    retVal.Add(i);
                }
            }
            return retVal;
        }

        public static int PresentsInHouse(int houseNumber)
        {
            var retVal = 0;
            var elves = WhichElvesDeliver(houseNumber);
            for(int i = 0;i < elves.Count;++i)
            {
                retVal += elves[i] * 11;
            }
            
            return retVal;
        }
    }
}

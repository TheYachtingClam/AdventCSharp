using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day25_LetItSnow
{
    class Program
    {
        static void Main(string[] args)
        {
            long startingPos = 20151125;

            var val = GetValue(3019, 3010, startingPos);

            Console.WriteLine($"newVal = {val}");
            Console.ReadLine();
        }

        static long AdjustFunction(long input)
        {
            return (input * 252533) % 33554393;
        } 

        static long GetValue(int column, int row, long startingPosition)
        {
            var rowBaseNumber = row += (column - 1);
            var startRowIncrement = 0;
            for(int i = 1;i < rowBaseNumber;++i)
            {
                startRowIncrement += rowBaseNumber - i;
            }
             var totalIncs = startRowIncrement + column - 1;
            

            long retVal = startingPosition;
            for(int j = 0;j < totalIncs;++j)
            {
                retVal = AdjustFunction(retVal);
            }
            return retVal;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10_KnotHash
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new List<int> { 3, 4, 1, 5 };
            var input = new List<int> { 230, 1, 2, 221, 97, 252, 168, 169, 57, 99, 0, 254, 181, 255, 235, 167 };
            var myList = new List<int>();
            var skipSize = 0;
            var currentIndex = 0;

            for(int i = 0;i < 256;++i)
            {
                myList.Add(i);
            }

            var newList = myList;
            Console.WriteLine($"position {skipSize} - {string.Join(",", newList)}");

            foreach(var item in input)
            {
                newList = TieKnot(newList, currentIndex, item);
                currentIndex = (currentIndex + item + skipSize) % newList.Count;
                skipSize++;

                Console.WriteLine($"position {skipSize} - {string.Join(",", newList)}");
            }

            Console.ReadKey();
        }

        static List<int> TieKnot(List<int> list, int currentPosition, int length)
        {
            var shiftedList = Shift(list, -currentPosition);
            var listToReverse = shiftedList.GetRange(0, length);
            listToReverse.Reverse();
            var listToShiftBack = new List<int>();
            listToShiftBack.AddRange(listToReverse);
            listToShiftBack.AddRange(shiftedList.GetRange(length, list.Count - length));
            return Shift(listToShiftBack, currentPosition);
        }

        static List<int> Shift(List<int> list, int shiftValue)
        {
            var shiftAmount = shiftValue % list.Count();
            var rightString = new List<int>();
            var leftString = new List<int>();


            if (shiftValue >= 0)
            {
                leftString = list.GetRange(list.Count - shiftAmount, shiftAmount);
                rightString = list.GetRange(0, list.Count - shiftAmount);
            }
            else
            {
                rightString = list.GetRange(0, -shiftAmount);
                leftString = list.GetRange(-shiftAmount, list.Count + shiftAmount);
            }

            var retString = new List<int>();
            retString.AddRange(leftString);
            retString.AddRange(rightString);
            return retString;
        }
    }
}

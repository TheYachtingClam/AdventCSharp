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
            var inp = "230,1,2,221,97,252,168,169,57,99,0,254,181,255,235,167";
            var frank = ReadInput(inp);

            var bob = TransformList(frank);

            var sally = CreateDenseHash(bob);

            Console.WriteLine($"output = {string.Join("", sally.Select(s => s.ToString("X2")))}");

            Console.ReadKey();
        }

        static List<int> CreateDenseHash(List<int> input)
        {
            if(input.Count != 256)
            {
                throw new ApplicationException("CreateDenseHash can only take input lengths of 256");
            }

            var denseHash = new List<int>();
            for(int i = 0;i < 16;++i)
            {
                int denseItem = input[i * 16];
                for(int j = 1;j < 16;++j)
                {
                    denseItem ^= input[i * 16 + j];
                }
                denseHash.Add(denseItem);
            }
            return denseHash;
        }

        static List<int> ReadInput(string input)
        {
            var output = new List<int>();
            foreach(char item in input)
            {
                output.Add(item);
            }
            return output;
        }

        static List<int> TransformList(List<int> input)
        {
            var myList = new List<int>();
            input.AddRange(new List<int> { 17, 31, 73, 47, 23 });

            for (int i = 0; i < 256; ++i)
            {
                myList.Add(i);
            }

            var skipSize = 0;
            var currentIndex = 0;

            var newList = new List<int>(myList);

            for(int j = 0;j < 64;++j)
            {
                foreach (var item in input)
                {
                    newList = TieKnot(newList, currentIndex, item);
                    currentIndex = (currentIndex + item + skipSize) % newList.Count;
                    skipSize++;
                }
            }

            return newList;
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

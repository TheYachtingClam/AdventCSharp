using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day23_TuringLock
{
    class Program
    {
        static void Main(string[] args)
        {
            var rData = LoadData("input.txt");

            var state = new TuringState();
            Console.WriteLine($"InitialState: {state}");
            var steps = 0;

            while(true)
            {
                rData[state.ProgramCounter].DoSomething(state);
                Console.WriteLine($"{state.ToString()}");
                if (state.ProgramCounter < 0 || state.ProgramCounter >= rData.Count)
                {
                    break;
                }
                if(++steps % 10 == 0)
                {
                    Console.WriteLine("10 steps");
                }
            }

            Console.WriteLine($"All done Register a = {state.Registers["a"]}, b = {state.Registers["b"]}");
            Console.ReadKey();
        }

        private static List<Instruction> LoadData(string path)
        {
            var rData = new List<Instruction>();

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    var inst = new Instruction(s);
                    rData.Add(inst);
                }
            }

            return rData;
        }
    }
}

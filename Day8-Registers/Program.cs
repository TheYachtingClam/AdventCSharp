using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8_Registers
{
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            var rData = LoadData("input.txt");
            var registers = new Registers();

            foreach (var instruction in rData)
            {
                instruction.ModifyRegisters(registers);
            }

            Console.WriteLine($"highest values is {registers.registers.Values.Max()}");
            Console.WriteLine($"Highest value ever is {registers.HighestRegister}");
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
                    rData.Add(new Instruction(s));
                }
            }

            return rData;
        }
    }
}

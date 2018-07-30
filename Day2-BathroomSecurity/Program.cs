using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2_BathroomSecurity
{
    class Program
    {
        static void Main(string[] args)
        {
            var rData = LoadData("input.txt");

            var keyboard = new Keypad();

            foreach (var c in rData)
            {
                var finalKey = keyboard.Move(c);
                Console.Write(finalKey + ",");
            }
            Console.ReadKey();
        }

        private static List<List<Directions>> LoadData(string path)
        {
            var rData = new List<List<Directions>>();

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    var directions = new List<Directions>();
                    foreach (var dir in s)
                    {
                        switch(dir)
                        {
                            case 'U':
                                directions.Add(Directions.Up);
                                break;
                            case 'D':
                                directions.Add(Directions.Down);
                                break;
                            case 'L':
                                directions.Add(Directions.Left);
                                break;
                            case 'R':
                                directions.Add(Directions.Right);
                                break;
                        }
                    }
                    rData.Add(directions);
                }
            }

            return rData;
        }
    }
}

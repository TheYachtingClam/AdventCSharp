using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Day18_GifForYourYard
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = LoadData("input.txt");

            PrintData(data);

            for (int cnt = 0;cnt < 100;++cnt)
            {
                Thread.Sleep(100);
                data = Step(data);
                PrintData(data);
                Console.WriteLine($"step {cnt + 1}");
            }

            Console.WriteLine($"finish numberOfLightsOn={HowManyLightsOn(data)}");
            Console.ReadKey();
        }

        private static List<List<bool>> LoadData(string path)
        {
            var gif = new List<List<bool>>();

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    var bob = new List<bool>();
                    foreach(var item in s)
                    {
                        if(item == '.')
                        {
                            bob.Add(false);
                        }
                        else
                        {
                            bob.Add(true);
                        }
                    }
                    gif.Add(bob);
                }
            }

            return gif;
        }

        private static void PrintData(List<List<bool>> data)
        {
            Console.SetCursorPosition(Console.WindowLeft, Console.WindowTop);

            foreach(var line in data)
            {
                foreach(var col in line)
                {
                    if(col == true)
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.Write("\n");
            }
        }

        private static int HowManyLightsOn(List<List<bool>> data)
        {
            int count = 0;

            for (int i = 0; i < data.Count; ++i)
            {
                var bob = new List<bool>();

                for (int j = 0; j < data[i].Count; ++j)
                {
                    if(data[i][j])
                    {
                        ++count;
                    }
                }
            }
            return count;
        }

        private static List<List<bool>> Step(List<List<bool>> data)
        {
            var retGif = new List<List<bool>>();

            for (int i = 0; i < data.Count; ++i)
            {
                var bob = new List<bool>();

                for(int j = 0;j < data[i].Count;++j)
                {
                    if(i == 0 && j == 0 ||
                       i == 0 && j == data[i].Count - 1 || 
                       i == data.Count - 1 && j == 0 || 
                       i == data.Count - 1 && j == data[i].Count - 1)
                    {
                        bob.Add(true);
                        continue;
                    }

                    var count = 0;

                    // upper left
                    if(i != 0 && j != 0 && data[i-1][j-1])
                    {
                        ++count;
                    }

                    // upper
                    if (i != 0 && data[i-1][j])
                    {
                        ++count;
                    }

                    // upper right
                    if (i != 0 && j != data[i].Count - 1 && data[i-1][j+1])
                    {
                        ++count;
                    }

                    // left
                    if (j != 0 && data[i][j-1])
                    {
                        ++count;
                    }

                    // right
                    if (j != data[i].Count - 1 && data[i][j+1])
                    {
                        ++count;
                    }

                    // lower left
                    if (i != data.Count - 1 && j != 0 && data[i+1][j-1])
                    {
                        ++count;
                    }

                    // lower
                    if (i != data[i].Count - 1 && data[i+1][j])
                    {
                        ++count;
                    }

                    // lower right
                    if (i != data.Count - 1 && j != data[i].Count - 1 && data[i+1][j+1])
                    {
                        ++count;
                    }

                    //Console.WriteLine($"[{i}][{j}]({data[i][j]}) count={count}");
                    if (data[i][j])
                    {
                        if (count == 2 || count == 3)
                        {
                            bob.Add(true);
                        }
                        else
                        {
                            bob.Add(false);
                        }
                    }
                    else
                    {
                        if(count == 3)
                        {
                            bob.Add(true);
                        }
                        else
                        {
                            bob.Add(false);
                        }
                    }
                }
                retGif.Add(bob);
            }

            return retGif;
        }
    }
}

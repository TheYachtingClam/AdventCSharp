using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day15_Hungry
{
    class Program
    {
        static void Main(string[] args)
        {
            var pantry = LoadData("input.txt");
            int bestScore = 0;
            var bestAmounts = new int[] { 0, 0, 0, 0 };

            for(int i1 = 0;i1 <= 100;++i1)
            {
                for(int i2 = 0;i1 + i2 <= 100;++i2)
                {
                    for(int i3 = 0;i1 + i2 + i3 <= 100;++i3)
                    {
                        for(int i4 = 100 - i1 - i2 - i3;i1 + i2 + i3 + i4 <= 100;++i4)
                        {
                            var bob = new int[] { i1, i2, i3, i4 };
                            var val = Value(pantry, bob);
                            var calories = CalorieCount(pantry, bob);
                            if (val > bestScore && calories == 500)
                            {
                                bestScore = val;
                                bob.CopyTo(bestAmounts, 0);
                            }
                            Console.WriteLine($"i1={bob[0]} i2={bob[1]} i3={bob[2]} i4={bob[3]}......{val}");
                        }
                    }
                }
            }
            Console.WriteLine($"final score is {bestScore} with amounts [{bestAmounts[0]}][{bestAmounts[1]}][{bestAmounts[2]}][{bestAmounts[3]}]");
            Console.ReadKey();
        }

        private static int CalorieCount(List<Ingredient> pantry, int[] amounts)
        {
            var calCount = 0;
            for(int i = 0;i < pantry.Count;++i)
            {
                calCount += pantry[i].Calories * amounts[i];
            }
            return calCount;
        }

        private static int Value(List<Ingredient> pantry, int[] amounts)
        {
            int capacity = 0;
            int durability = 0;
            int flavor = 0;
            int texture = 0;

            for(int i = 0;i < pantry.Count;++i)
            {
                capacity += pantry[i].Capacity * amounts[i];
                durability += pantry[i].Durability * amounts[i];
                flavor += pantry[i].Flavor * amounts[i];
                texture += pantry[i].Texture * amounts[i];
            }

            if(capacity < 0 || durability < 0 || flavor < 0 || texture < 0)
            {
                return 0;
            }

            return capacity * durability * flavor * texture;
        }

        private static List<Ingredient> LoadData(string path)
        {
            var pantry = new List<Ingredient>();

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    var nameSplit = s.Split(':');
                    var name = nameSplit[0];
                    var attributeSplit = nameSplit[1].Split(',');
                    var capacity = int.Parse(attributeSplit[0].Split(' ')[2]);
                    var durability = int.Parse(attributeSplit[1].Split(' ')[2]);
                    var flavor = int.Parse(attributeSplit[2].Split(' ')[2]);
                    var texture = int.Parse(attributeSplit[3].Split(' ')[2]);
                    var calories = int.Parse(attributeSplit[4].Split(' ')[2]);

                    var newIngredient = new Ingredient
                    {
                        Name = name,
                        Capacity = capacity,
                        Durability = durability,
                        Flavor = flavor,
                        Texture = texture,
                        Calories = calories,
                    };
                    pantry.Add(newIngredient);
                }
            }

            return pantry;
        }
    }
}

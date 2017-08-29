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
            var pantry = LoadData("test.txt");


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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12_DigitalPlumber
{
    class MyPrograms
    {
        private static Dictionary<int, List<int>> data;

        public List<MyPrograms> ConnectedTo = new List<MyPrograms>();

        public static void SetData(Dictionary<int, List<int>> data)
        {
            MyPrograms.data = data;
        }

        public static List<int> ProgramsAbleToCommunicateTo(int id)
        {
            var items = new List<int>();
            foreach (var myProg in data)
            {
                if(CanProgramSeeId(myProg.Key, id, new List<int> (myProg.Key)))
                {
                    items.Add(myProg.Key);
                }
            }
            return items;
        }

        private static bool CanProgramSeeId(int prog, int id, List<int> alreadyVisited)
        {
            if (prog == id)
            {
                return true;
            }
            else
            {
                foreach(var p in data[prog])
                {
                    if(alreadyVisited.Contains(p))
                    {
                        continue;
                    }

                    var visited = new List<int>(alreadyVisited) {p};
                    if (CanProgramSeeId(p, id, visited))
                    {
                        return true;
                    }
                }

                return false;
            }
        }
    }
}

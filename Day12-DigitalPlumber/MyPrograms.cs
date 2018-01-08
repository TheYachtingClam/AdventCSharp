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
        private static Dictionary<int, bool> alreadyVisited;

        public List<MyPrograms> ConnectedTo = new List<MyPrograms>();

        public static void SetData(Dictionary<int, List<int>> data)
        {
            MyPrograms.data = data;
        }

        public static List<int> ProgramsAbleToCommunicateTo(int id)
        {
            alreadyVisited = new Dictionary<int, bool>();
            var items = new List<int>();
            foreach (var myProg in data)
            {
                if(CanProgramSeeId(myProg.Key, id))
                {
                    items.Add(myProg.Key);
                }
            }
            return items;
        }

        private static bool CanProgramSeeId(int prog, int id)
        {
            if (prog == id)
            {
                return true;
            }
            else
            {
                foreach(var p in data[prog])
                {
                    if(alreadyVisited.ContainsKey(p))
                    {
                        return alreadyVisited[p];
                    }

                    if(p == prog)
                    {
                        alreadyVisited[prog] = false;
                        return false;
                    }

                    var val = CanProgramSeeId(p, id);
                    alreadyVisited[p] = val;
                    return val;
                }
                alreadyVisited[prog] = false;
                return false;
            }
        }
    }
}

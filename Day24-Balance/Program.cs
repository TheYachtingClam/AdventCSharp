using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day24_Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            var rData = LoadData("input.txt");

            var frank = SplitValues(rData);

            int qe = int.MaxValue;
            foreach(var f in frank)
            {
                if(f.QuantumEntanglement != null && qe > f.QuantumEntanglement)
                {
                    qe = f.QuantumEntanglement.Value;
                }
            }

            Console.WriteLine($"All done best qe is {qe}");
            Console.ReadKey();
        }

        static List<Combo> SplitValues(List<int> values)
        {
            var retVal = new List<Combo>();

            var oneThirdValue = values.Sum() / 4;
            var vals = findSums(values, oneThirdValue);
            Console.WriteLine($"Found {vals.Count} for group one");
            vals.Sort(delegate (List<int> x, List<int> y)
            {
                if (x.Count > y.Count) return 1;
                if (x.Count == y.Count) return 0;
                else return -1;
            });
            var smallestAmount = vals.Where(num => num.Count == vals.First().Count);
            var c = 0;
            long  smallestQE = long.MaxValue;
            
            foreach (var v in smallestAmount)
            {
                if(++c % 10 == 0)
                {
                    Console.WriteLine($"I've gone through {c} of {smallestAmount.Count()}");
                }
                var newVals = new List<int>(values);
                newVals.RemoveAll(s => v.Contains(s));
                //var val2 = findSums(newVals, oneThirdValue);
                //if(val2.Any())
                {
                    long qe = v.Aggregate((long)1, (acc, val) => (long)acc * (long)val);
                    if(qe < smallestQE)
                    {
                        
                        smallestQE = qe;
                    }
                    //foreach(var v2 in val2)
                    //{
                    //    var newVals2 = new List<int>(newVals);
                    //    newVals2.RemoveAll(s2 => v2.Contains(s2));
                    //    if(newVals2.Any())
                    //    {
                            retVal.Add(new Combo
                            {
                                Passenger = new List<int>(v),
                                LeftContainer = new List<int>(),
                                RightContainer = new List<int>(),
                            });
                    //    }
                    //}
                }
                
            }
            Console.WriteLine($"FindSum ran {findSumCount} times");

            return retVal;
        }

        static int findSumCount = 0;
        
        static List<List<int>> findSums(List<int> values, int sum)
        {
            findSumCount++;
            if(findSumCount % 10 == 0)
            {
                //Console.WriteLine("break;");
            }

            //Console.WriteLine($"FindSums({string.Join(",", values)}, {sum})");
            var retVal = new List<List<int>>();
            var val = new List<int>(values);

            for(int i = 0;i < values.Count();++i)
            {
                var removeVal = val[0];
                val.Remove(removeVal);
                if(sum == 520)
                {
                    //Console.WriteLine($"for loop = {i}of{values.Count()}");
                }
                if(removeVal > sum)
                {
                    break;
                }
                else if(removeVal == sum)
                {
                    retVal.Add(new List<int> { removeVal });
                }
                else
                {
                    var bob = findSums(val, sum - removeVal);
                    foreach (var b in bob)
                    {
                        b.Add(removeVal);
                    }
                    retVal.AddRange(bob);
                }
            }

            //Console.WriteLine($"FindSums returned");
            //foreach (var s in retVal)
            //{
            //    Console.WriteLine($"\t({string.Join(",", s)})");
            //}

            return retVal;
        }



        private static List<int> LoadData(string path)
        {
            var rData = new List<int>();

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    var inst = int.Parse(s);
                    rData.Add(inst);
                }
            }

            return rData;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9_StreamProcessing
{
    class Garbage : IItem
    {
        public List<IItem> Items { get; } = new List<IItem>();

        public static int TotalGarbage;

        public string ProcessStream(string str, int value)
        {
            var tempString = str;
            while (tempString.Length > 0)
            {
                var controlChar = tempString[0];
                tempString = tempString.Remove(0, 1);
                if (controlChar == '!')
                {
                    tempString = tempString.Remove(0, 1);
                }
                else if (controlChar == '>')
                {
                    return tempString;
                }
                else
                {
                    TotalGarbage++;
                }
            }
            return null;
        }

        #region Implementation of IItem

        /// <inheritdoc />
        public int Value => 0;

        #endregion
    }
}

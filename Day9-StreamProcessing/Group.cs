using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9_StreamProcessing
{
    class Group : IItem
    {
        public List<IItem> Items { get; } = new List<IItem>();

        private int myValue = 0;

        public string ProcessStream(string str, int value)
        {
            myValue = value;

            var tempString = str;
            while (tempString.Length > 0)
            {
                var controlChar = tempString[0];
                tempString = tempString.Remove(0, 1);
                if (controlChar == '!')
                {
                    tempString = tempString.Remove(0, 1);
                }
                else if (controlChar == '{')
                {
                    var tGroup = new Group();
                    tempString = tGroup.ProcessStream(tempString, value + 1);
                    Items.Add(tGroup);
                }
                else if (controlChar == '<')
                {
                    var tGarbage = new Garbage();
                    tempString = tGarbage.ProcessStream(tempString, value);
                    Items.Add(tGarbage);
                }
                else if (controlChar == '}')
                {
                    return tempString;
                }
            }
            return null;
        }

        #region Implementation of IItem

        /// <inheritdoc />
        public int Value
        {
            get
            {
                var retValue = myValue;
                foreach (var item in Items)
                {
                    retValue += item.Value;
                }
                return retValue;
            }
        }

        #endregion
    }
}

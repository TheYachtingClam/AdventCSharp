using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9_StreamProcessing
{
    interface IItem
    {
        string ProcessStream(string inp, int value);

        int Value { get; }
    }
}

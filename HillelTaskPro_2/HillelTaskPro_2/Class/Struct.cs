using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HillelTaskPro_2.Struct
{
    public struct Converter
    {
        private int value;
        public Converter(int number)
        {
            value = number;
        }

        public string Binary()
        {
            return Convert.ToString(value, 2);
        }

        public string Octal()
        {
            return Convert.ToString(value, 10);
        }

        public string Hex()
        {
            return Convert.ToString(value, 16);
        }
    }
}

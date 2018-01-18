using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stringCalculator
{
    public class Calculator
    {
        public static int add(string input)
        {
            if (String.IsNullOrEmpty(input))
                return 0;
            else
                return Int32.Parse(input);
        }
    }
}

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
            {
                var stringNumbers = input.Split(',');
                if (stringNumbers.Length == 1)
                    return int.Parse(stringNumbers[0]);
                else
                {
                    int first = int.Parse(stringNumbers[0]);
                    int second = int.Parse(stringNumbers[1]);
                    return first + second;
                }

            }
        }
    }
}

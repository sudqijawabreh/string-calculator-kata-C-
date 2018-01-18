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
            int sum = 0;
            if (String.IsNullOrEmpty(input))
                sum = 0;
            else
            {
                var stringNumbers = input.Split(',');
                foreach (var number in stringNumbers)
                    sum += int.Parse(number);
            }
            return sum;
        }
    }
}

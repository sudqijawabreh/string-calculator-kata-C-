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
                var delimiter = ';';
                if (input.StartsWith("//"))
                {
                    delimiter = input[2];
                    input = input.Substring(4);
                }
                string[] stringNumbers = split(input, delimiter);
                foreach (var number in stringNumbers)
                    sum += int.Parse(number);
            }
            return sum;
        }

        public static string[] split(string input, char delimiter)
        {
            var delimiters = new char[] { ',', '\n', delimiter };
            return input.Split(delimiters);
        }
    }
}

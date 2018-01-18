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
                sum=sumLinq(stringNumbers);
            }
            return sum;
        }

        private static int sumNumbers( string[] stringNumbers)
        {
            int sum = 0;
                StringBuilder builder = new StringBuilder("negatives not allowed: ", stringNumbers.Length);
                Boolean negatives = false;
            foreach (var number in stringNumbers)
            {
                int intValue = int.Parse(number);
                if (intValue < 0)
                {
                    builder.Append(number + ",");
                    negatives = true;
                }
                else if (intValue > 1000)
                {
                    continue;
                }
                sum += intValue;
            }
            if (negatives)
            {
                builder.Remove(builder.Length - 1, 1);
                throw new ArgumentException(builder.ToString());
            }
            
            return sum;
        }
        public static int sumLinq(string [] input)
        {
            var intValues = input.Select(n => int.Parse(n));
            var negatives = intValues.Where(n => n < 0);
            StringBuilder builder = new StringBuilder("negatives not allowed: ");
            if (negatives.Count() > 0)
            {
                var error=negatives.Select(n => n.ToString()).Aggregate((a, b) => a + ',' + b);
                throw new ArgumentException(error);
            }
            var sum=intValues.Except(negatives).Where(c => c < 1000).Sum();
            return sum;
                


        }
        public static string[] split(string input, char delimiter)
        {
            var delimiters = new char[] { ',', '\n', delimiter };
            return input.Split(delimiters);
        }
    }
}

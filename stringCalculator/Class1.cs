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
                var delimiter = ";";
                List<string> delimiters = new List<string>( input.Length);
                delimiters.Add(",");
                delimiters.Add("\n");
                if (input.StartsWith("//"))
                {
                    var firstBracketIndex = 0;
                    var secondBracketIndex=0;
                    while(firstBracketIndex != -1)
                    {
                        firstBracketIndex = input.IndexOf('[', firstBracketIndex+1);
                        if (firstBracketIndex != -1)
                        {
                            secondBracketIndex = input.IndexOf(']', firstBracketIndex);
                        delimiters.Add(input.Substring(firstBracketIndex + 1, secondBracketIndex - firstBracketIndex - 1));
                        }

                    }

                    foreach(var item in delimiters)
                    {
                        Console.WriteLine(item);
                    }
                    if (delimiters.Count>2)
                    {
                        input = input.Substring(secondBracketIndex + 2);
                    }
                    else
                    {
                        delimiter = input.Substring(2, 1);
                    delimiters.Add(delimiter);
                        input = input.Substring(4);
                    }

                }
                string[] stringNumbers = split(input, delimiters.ToArray());
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
        public static string[] split(string input, string []delimiters)
        {
            return input.Split(delimiters,StringSplitOptions.RemoveEmptyEntries);
        }
    }
}

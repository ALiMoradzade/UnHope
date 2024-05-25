using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoradzadeHelperUtilityLibrary
{
    public static class Average
    {
        static double average = 0;
        static int totalNumbers = 0;
        public static double SetValues(int numbersWeight, params double[] numbers)
        {
            double sumOfNumbers = average * totalNumbers;
            for (int i = 0; i < numbers.Length; i++, totalNumbers += numbersWeight)
            {
                sumOfNumbers += numbersWeight * numbers[i];
            }
            average = sumOfNumbers / totalNumbers;
            return average;
        }
        public static void ResetValues()
        {
            average = 0;
            totalNumbers = 0;
        }
    }
}

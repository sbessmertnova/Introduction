using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_lesson1
{
    public class PrimeNumberChecker
    {
        public static bool IsPrimeNumber(int number)
        {
            int d = 0;
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    d++;
                }
            }
            if (d == 0)
            {
                return true;
            }
            else return false;
        }
    }
}

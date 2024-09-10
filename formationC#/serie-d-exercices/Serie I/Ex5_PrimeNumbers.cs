

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_I
{
    public static class PrimeNumbers
    {
        static bool IsPrime(int valeur)
        {
            double c = Math.Sqrt(valeur);
            int d = (int) c;
            for (int b = 2; b <= d; b++)
            {
                if (valeur % b == 0)
                    break;
                else 
                    continue;
            }
            if (b == d)
                return true;
            else
                return false;
        }

        public static void DisplayPrimes()
        {
            //TODO
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_I
{
    public static class Factorial
    {
        public static int Factorial_(int n)
        {
            int facto = 1;
            if (n < 0) // si negatif, retour -1
                return -1;
            else if (n == 0) // si = 0, factorielle = 1
                return 1;
            while (n >= 1) // tant que n n'est pas égale à 0, on calcule la factorielle de n
            { facto *= n;
                n--;
            }
            return facto;
        }

        public static int FactorialRecursive(int n)
        {
            if (n < 0) // si negatif, retour -1
                return -1;
            else if (n == 0) // si = 0, factorielle = 1
                return 1;
            else  // calcul de la factorielle de n
            {
                return n * FactorialRecursive(n - 1);
                
            }
           
        }
    }
}

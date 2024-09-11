using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_II
{
    public static class Search
    {
        public static int LinearSearch(int[] tableau, int valeur)
        {
            for (int i = 0; i < tableau.Length; i++)
            {
                if (tableau.Length == 0)
                    return -1;

                else if (valeur == tableau[i])
                {
                    return i;
                    break;
                }
                else if (i == tableau.Length)

                    return -1;


                else
                    continue;
            }
            return -1; 
        }

        public static int BinarySearch(int[] tableau, int valeur)
        {
            int i = tableau.Length / 2;
            if (tableau.Length == 0)
                return -1;

            if (valeur == tableau[i])
            {
                return i;
               
            }
            else if (valeur < tableau[i])
            {
                for (int j = 0; j < tableau.Length / 2; j++)
                {
                    if (valeur == tableau[j])
                    {
                        return j;
                        break;
                    }
                    else if (j == tableau.Length / 2)

                        return -1;

                    else
                        continue;
                }
            }
            else if (valeur > tableau[i])
            {
                for (int k = tableau.Length / 2; k < tableau.Length; k++)
                {
                    if (valeur == tableau[k])
                    {
                        return k;
                        break;
                    }
                    else if (k == tableau.Length)

                        return -1;

                    else
                        continue;
                }
            }
                return -1;
        }
    }
}

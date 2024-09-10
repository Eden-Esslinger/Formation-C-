using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_II
{
    public static class Search
    {
        public static int LinearSearch(int[] tableau, int valeur)
        {
            for (int i = 0; i < tableau.Length ; i++ )
            {
                if (valeur == tableau[i])
                    return i;
                else if (tableau[i] != valeur)

                    return -1;
                else
                    return -1;
            }
                
        }

        public static int BinarySearch(int[] tableau, int valeur)
        {
            //TODO
            return -1;
        }
    }
}

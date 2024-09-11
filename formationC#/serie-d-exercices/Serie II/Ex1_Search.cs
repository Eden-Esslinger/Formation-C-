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
            for (int i = 0; i < tableau.Length; i++) // recherche de la valeur dans le tableau
            {
                if (tableau.Length == 0) // tableau vide
                    return -1;

                else if (valeur == tableau[i]) // valeur trouvé, retour de l'indice du tableau
                {
                    return i;
                    break;
                }
                else if (i == tableau.Length) // valeur pas dans le tableau

                    return -1;


                else
                    continue;
            }
            return -1; 
        }

        public static int BinarySearch(int[] tableau, int valeur)

        {
            if (tableau.Length == 0) // tableau vide
                return -1;

            int i = tableau.Length / 2;
            int moit = i / 2;
            int cp = 0;
            {
                while (i < tableau.Length && i >= 0 && moit != 0)
                {
                    moit /= 2;

                    if (valeur == tableau[i]) // valeur trouvé, retour indice
                    {
                        return i;
                    }
                    else if (valeur < tableau[i]) // si valeur inférieur à valeur du milieu du tableau, on ne prend en compte que la 
                    {                             // premiere moitié du tableau
                        i -= moit;
                        cp++;
                    }
                    else if (valeur > tableau[i]) // si valeur inférieur à valeur du milieu du tableau, on ne prend en compte que la 
                    {                             // deuxieme moitié du tableau
                        i += moit;
                        cp++;
                    }

                }
                    return -1;
             }
        }
    }
}

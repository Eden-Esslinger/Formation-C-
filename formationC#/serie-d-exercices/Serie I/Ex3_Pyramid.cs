using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_I
{
    public static class Pyramid
    {
        public static void PyramidConstruction(int n, bool isSmooth)
        {// nombre de blocs pour j = 2 * j - 1
         // nombre total = n ^ 2
         // sommet de la pyramide = n
         // gauche = n - i + 1 et droite = n + i - 1
            for (int i = 1; i <= n; i++) // niveau de la pyramide
            {
                for (int j = 1; j <= 2 * n - 1; j++) // longueur pyramide
                {
                    if (j >= n - i + 1 && j <= n + i - 1) // borne où écrire + ou - 
                        if (isSmooth == true) // booleen vrai
                        {
                            Console.Write("+");
                        }
                        else if (i % 2 == 0) // niveau pair, et booleen faux
                        {
                            Console.Write("-");
                        }
                        else
                        { Console.Write("+"); }
                    
                    else
                    { Console.Write(" "); } 
                }
                    Console.WriteLine();
                
              //  j++;
                
            }      
        }
    }
}

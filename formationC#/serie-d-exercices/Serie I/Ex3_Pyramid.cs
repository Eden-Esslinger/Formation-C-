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
        {
            //  int blocs = 0;
          //  for (int j = 1; j <= 2 * j - 1; j++)
           // {
                //    blocs = 2 * j - 1;
           // }
            for (int i = 1; i <= n; i++) 
            {
                for (int j = 1; j <= 2 * n - 1; j++)
                {
                    if (j >= n - i + 1 && j <= n + i - 1)
                    {
                        if (isSmooth == true)
                        {
                            Console.Write("+");
                        }
                        else if (i % 2 == 0)
                        {
                            Console.Write("-");
                        }
                        else
                        { Console.Write("+"); }
                    }
                    else
                    { Console.Write(" "); }
                }
                    Console.WriteLine();
                
              //  j++;
                
            }      
        }
    }
}

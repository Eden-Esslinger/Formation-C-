using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Percolation.IsOpen();

            int n = 5; 
            Percolation Percolation = new Percolation(n);

            
            Percolation.Open(0, 0);
            Percolation.Open(1, 0);
            Percolation.Open(2, 0);
            Percolation.Open(3, 0);
            Percolation.Open(4, 0);

            Console.WriteLine("La grille percole-t-elle ? " + Percolation.Percolate());
            // Keep the console window open
            Console.WriteLine("----------------------");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}

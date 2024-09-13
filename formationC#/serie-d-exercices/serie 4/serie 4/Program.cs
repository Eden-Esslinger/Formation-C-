using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace serie_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Exercice II - Contrôle des parenthèses
            Console.WriteLine("------------------------------");
            Console.WriteLine("Exercice II - Contrôle des parenthèses");
            Console.WriteLine("------------------------------");

            Console.WriteLine("Contrôle des parenthèses");
            string v = "()";
           
            BracketsControl.BracketsControls(v);

            if (BracketsControl.BracketsControls(v) == false)
            {
                Console.WriteLine($"{v} : KO");
            }

            else if (BracketsControl.BracketsControls(v) == true)
            {
                Console.WriteLine($"{v} : OK");
            }

            // Keep the console window open
            Console.WriteLine("----------------------");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            #endregion
        }
    }
}

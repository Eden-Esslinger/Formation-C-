using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            string input = path + @"\Comptes.csv";
            Console.WriteLine(input);
            Compteslec(input);
            Comptes comptes = new Comptes();
         //   comptes.Compte = 3;
          //  comptes._solde = 500;
         //   var t = comptes.Affichagesolde();
         //   Console.WriteLine(t);




            // Keep the console window open
            Console.WriteLine("----------------------");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
        static public void Compteslec(string input)
        {
            var d = new Dictionary<int, decimal>();
            using (FileStream file = File.OpenRead(input))

            using (StreamReader str = new StreamReader(file))

                while (!str.EndOfStream)
                {
                    string line = str.ReadLine();
                      int numcpt; 
                    string[]
                       int.TryParse(line.Split(';')[0],out numcpt);
                       decimal solde;
                      var v = line.Split(";");
                    //    decimal.TryParse(line.Split(";")[1],out solde);
                    //   d.Add(numcpt, solde);
                 //   Console.WriteLine(d[1]);
                }
        }
    }
}

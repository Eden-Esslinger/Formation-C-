using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_
{
    public class Comptes
    {
        public int Compte;
        private decimal _solde;

          
        public void Compteslec(string input)
        {
            var d = new Dictionary<int, decimal>();
            using (FileStream file = File.OpenRead(input)) 

           using (StreamReader str = new StreamReader(file))

                while (!str.EndOfStream)
                {
                    string line = str.ReadLine();
                //    int numcpt; 
                //    int.TryParse(line.Split(';')[0],out numcpt);
                //    decimal solde;
                //    var v = line.Split(";");
                //    decimal.TryParse(line.Split(";")[1],out solde);
                 //   d.Add(numcpt, solde);
                    Console.WriteLine(d[1]);
                }
          //  {

           // }
            /*   public decimal Affichagesolde()
               {
                   return _solde;
               }*/

        }
    }







}



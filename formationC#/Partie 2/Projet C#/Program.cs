﻿using System;
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
            string input0 = path + @"\gestionnaires.csv";
            string input = path + @"\Comptes.csv";
            string input2 = path + @"\transactions.csv";
            string output = path + @"\statuts.csv";
            //   Console.WriteLine(input);
            Dictionary<int, Gestionnaires> dico0 = Gestionnaires.Gestionnaireslec(input0);
            List<Comptes> liste = Comptes.Compteslec(input,dico0);

            Dictionary<int, Transactions> dico2 = Transactions.Transactionslec(input2);
            Transactions.Transaction(dico2, liste);

            Transactions.Statuts(output, dico2);
            Comptes.Cloture(input,liste,dico0);

            //   comptes.Compte = 3;
            //  comptes.Solde = 500;
            //   var t = comptes.Affichagesolde();
            //   Console.WriteLine(t);




            // Keep the console window open
            Console.WriteLine("----------------------");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
      /*  static public void Compteslec(string input)
        {
            var d = new Dictionary<int, decimal>();
            using (FileStream file = File.OpenRead(input))

           /// using (StreamReader str = new StreamReader(file))

              /*  while (!str.EndOfStream)
                {
                    string line = str.ReadLine();
                      int numcpt;
                  //  decimal solde;
                 //   string[]
                  //     int.TryParse(line.Split(';')[0],out numcpt, out solde );
                   //    decimal solde;
                   //   var v = line.Split(";");
                    //    decimal.TryParse(line.Split(";")[1],out solde);
                    //   d.Add(numcpt, solde);
                 //   Console.WriteLine(d[1]);
                }*/
        
    }
}

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
        public decimal Solde;


        public void Compteslec(string input)
        {
            var d = new Dictionary<int, Comptes>();
            using (FileStream file = File.OpenRead(input))

            using (StreamReader str = new StreamReader(file))

                while (!str.EndOfStream)
                {
                    string line = str.ReadLine();
                    int numcpt;
                    var mot = line.Split(';');
                    int.TryParse(mot[0], out numcpt);
                    decimal solde;
                    decimal.TryParse(mot[1], out solde);

                    Comptes comptes = new Comptes();
                    comptes.Compte = numcpt;
                    comptes.Solde = solde;
                    d.Add(numcpt, comptes);
                    //   Console.WriteLine(d[1]);
                }
            //  {

            // }
            /*   public decimal Affichagesolde()
               {
                   return _solde;
               }*/

        }
    }

    public class Transactions
    {
        public int Identifiant;
        public decimal Montant;
        public int Expéditeur;
        public int Destinataire;


        public void Transactionslec(string input2)
        {
            var d2 = new Dictionary<int, Transactions>();
            using (FileStream file = File.OpenRead(input2))

            using (StreamReader str = new StreamReader(file))

                while (!str.EndOfStream)
                {
                    string line = str.ReadLine();
                    int id;
                    decimal montant;
                    int exp;
                    int dest;

                    var mot = line.Split(';');
                    int.TryParse(mot[0], out id);
                    decimal.TryParse(mot[1], out montant);
                    int.TryParse(mot[2], out exp);
                    int.TryParse(mot[3], out dest);

                    Transactions transactions = new Transactions();
                    transactions.Identifiant = id;
                    transactions.Montant = montant;
                    transactions.Expéditeur = exp;
                    transactions.Destinataire = dest;

                    d2.Add(id, transactions);

                }
        }
    }
}



         



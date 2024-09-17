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


        public static Dictionary<int, Comptes> Compteslec(string input)
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
                }
            return d;
        }
    }

    public class Transactions
    {
        public int Identifiant;
        public decimal Montant;
        public int Expéditeur;
        public int Destinataire;


        public static Dictionary<int, Transactions> Transactionslec(string input2)
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
            return d2;
        }

        public static void Transaction(Dictionary<int, Transactions> dico2, Dictionary<int, Comptes> dico)
        {
            foreach (KeyValuePair<int, Transactions> transaction in dico2) 
            {
                var t = 0;

               Transactions valeur = transaction.Value;

                int id = valeur.Identifiant;
                decimal montant = valeur.Montant;
                int exp = valeur.Expéditeur;
                int dest = valeur.Destinataire;

                decimal solde_exp;
                decimal solde_dest;
                decimal solde_final ;

                if (exp == 0)
                {
                    Comptes destinataire = dico[dest];
                    solde_dest = destinataire.Solde;
                    if (montant > 0)
                    {
                        solde_final = solde_dest + montant;
                        break;
                    }
                    else
                    {
                        // erreur
                    }
                }

                else if (dest == 0)
                {
                    Comptes expediteur = dico[exp];
                    solde_exp = expediteur.Solde;
                    if (solde_exp > montant && montant > 0)
                    {
                        solde_final = solde_exp - montant;
                        break;
                    }
                    else
                    {
                        // erreur
                    }
                }

                Comptes Expediteur = dico[exp];
                solde_exp = Expediteur.Solde;

                Comptes Destinataire = dico[dest];
                solde_dest = Destinataire.Solde;


                

             /*   foreach (KeyValuePair<int, Comptes> comptes in dico)
                {
                    solde_final = comptes.Value;

                    if (exp == 0 && dest == comptes.Key)
                    {
                        solde_final += montant;
                        break;
                    }

                    else if (dest == 0 && exp == comptes.Key)
                    {
                        solde_final -= montant;
                        break;
                    }

                    else if (exp == comptes.Key )
                    {
                        solde_final -= montant;
                        break;
                    }
                    else if (dest == comptes.Key )
                    {
                        solde_final += montant;
                        break;
                    }*/







                  /*  switch (comptes.Key)
                    {
                        case 
                    }

                } */


            }
        }
    }
}



         



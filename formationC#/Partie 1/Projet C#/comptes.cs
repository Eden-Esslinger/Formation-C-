using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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
                    if (d.ContainsKey(numcpt))
                        break;
                    else if (numcpt < 0)
                        break;
                    else
                    {
                        d.Add(numcpt, comptes);
                    }
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
        public string Statut;
        
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
                    if (d2.ContainsKey(id))
                        break;
                    else if (id < 1)
                        break;
                    else
                    {
                        d2.Add(id, transactions);
                    }

                }
            return d2;
        }

        public static void Transaction(Dictionary<int, Transactions> dico2, Dictionary<int, Comptes> dico)
        {
            foreach (KeyValuePair<int, Transactions> transaction in dico2) 
            {

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
                        destinataire.Solde = solde_final;
                        valeur.Statut = "OK";
                    }
                    else
                    {
                        valeur.Statut = "KO";
                    }
                }

                else if (dest == 0)
                {
                    Comptes expediteur = dico[exp];
                    solde_exp = expediteur.Solde;
                    if (solde_exp >= montant && montant > 0)
                    {
                        solde_final = solde_exp - montant;
                        expediteur.Solde = solde_final;
                        valeur.Statut = "OK";
                    }
                    else
                    {
                        valeur.Statut = "KO";
                    }
                }

                else if (dest > 0 && exp > 0)
                {
                    try
                    {
                        Comptes Expediteur = dico[exp];
                        solde_exp = Expediteur.Solde;

                        Comptes Destinataire = dico[dest];
                        solde_dest = Destinataire.Solde;

                        if (solde_exp >= montant && montant > 0)
                        {
                            solde_exp -= montant;
                            solde_dest += montant;
                            Expediteur.Solde = solde_exp;
                            Destinataire.Solde = solde_dest;
                            valeur.Statut = "OK";
                        }
                        else
                        {
                            valeur.Statut = "KO";
                        }
                    }
                    catch (KeyNotFoundException)
                    {
                        break;
                    }

                   

                   
                 }

            }

            foreach (var comptess in dico)
            {
                Console.WriteLine($"{comptess.Key} : {comptess.Value.Solde} €");
            }
        }

        public static void Statuts(string output, Dictionary<int, Transactions> dico2)
        {
            using (FileStream file3 = File.OpenWrite(output)) 
            using (StreamWriter sortie = new StreamWriter(file3))

            {
                foreach (KeyValuePair<int, Transactions> statut in dico2)
                {
                    Transactions statuts = statut.Value;
                    sortie.WriteLine($"{statuts.Identifiant};{statuts.Statut}");
                }
            }
        }
    }
}



         



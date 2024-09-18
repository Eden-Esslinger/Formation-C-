using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Globalization;

namespace Projet_C_
{
     
    public class Comptes
    {
        public int Compte;
        public decimal Solde;

        

        public static Dictionary<int, Comptes> Compteslec(string input)
        {
            CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.NumberFormat.NumberDecimalSeparator = ",";
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            var d = new Dictionary<int, Comptes>();
            using (FileStream file = File.OpenRead(input))

            using (StreamReader str = new StreamReader(file))

                while (!str.EndOfStream)
                {
                    string line = str.ReadLine();
                    int numcpt;
                    var mot = line.Split(';');
                    bool numvalide = int.TryParse(mot[0], out numcpt);
                    if (!numvalide)
                    {
                        continue;
                    }
                    decimal solde;
                    mot[1] = mot[1].Replace(".", ",");
                    if (string.IsNullOrWhiteSpace(mot[1]))
                    {
                        mot[1] = "0";
                    }

                    bool soldevalide = decimal.TryParse(mot[1], out solde);
                   
                    if (!soldevalide)
                    {
                        continue;
                    }

                    Comptes comptes = new Comptes();
                    comptes.Compte = numcpt;
                    comptes.Solde = solde;
                    if (d.ContainsKey(numcpt))
                        continue;
                    else if (numcpt < 1)
                        continue;
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
                    bool idvalide = int.TryParse(mot[0], out id);
                    if (!idvalide)
                    {
                        continue;
                    }
                    mot[1] = mot[1].Replace(".", ",");
                    if(string.IsNullOrWhiteSpace(mot[1]))
                    {
                        mot[1] = "0";
                    }

                    //int.TryParse(mot[0], out id);
                    bool montantvalide = decimal.TryParse(mot[1], out montant);
                    if (!montantvalide)
                    {
                        continue;
                    }
                    bool expvalide = int.TryParse(mot[2], out exp);
                    if (!expvalide)
                    {
                        continue;
                    }
                    bool destvalide = int.TryParse(mot[3], out dest);
                    if (!destvalide)
                    {
                        continue;
                    }

                    Transactions transactions = new Transactions();
                    transactions.Identifiant = id;
                    transactions.Montant = montant;
                    transactions.Expéditeur = exp;
                    transactions.Destinataire = dest;
                    if (d2.ContainsKey(id))
                        continue;
                    else if (id < 1)
                        continue;
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
                valeur.Statut = "KO";

                decimal solde_exp;
                decimal solde_dest;
                decimal solde_final ;

                if (exp == 0 && dest == 0)
                {
                    valeur.Statut = "KO";
                    continue;
                }

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
                else if (dest == exp)
                {
                    valeur.Statut = "OK";
                    continue;
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
                        {
                            valeur.Statut = "KO";
                            continue;
                        }
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



         



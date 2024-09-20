using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_
{
    public class Transactions
    {
        public int Identifiant;
        public DateTime Date_effet;
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
                    DateTime date;


                    var mot = line.Split(';');
                    bool idvalide = int.TryParse(mot[0], out id);
                    if (!idvalide)
                    {
                        continue;
                    }

                    DateTime.TryParse(mot[1], out date);

                    mot[2] = mot[2].Replace(".", ",");
                    if (string.IsNullOrWhiteSpace(mot[2]))
                    {
                        mot[2] = "0";
                    }

                    //int.TryParse(mot[0], out id);
                    bool montantvalide = decimal.TryParse(mot[2], out montant);
                    if (!montantvalide)
                    {
                        continue;
                    }
                    bool expvalide = int.TryParse(mot[3], out exp);
                    if (!expvalide)
                    {
                        continue;
                    }
                    bool destvalide = int.TryParse(mot[4], out dest);
                    if (!destvalide)
                    {
                        continue;
                    }

                    Transactions transactions = new Transactions();
                    transactions.Identifiant = id;
                    transactions.Date_effet = date;
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

        public static void Transaction(Dictionary<int, Transactions> dico2, List<Comptes> liste)
        {
            foreach (KeyValuePair<int, Transactions> transaction in dico2)
            {

                Transactions valeur = transaction.Value;

                int id = valeur.Identifiant;
                DateTime date = valeur.Date_effet;
                decimal montant = valeur.Montant;
                int exp = valeur.Expéditeur;
                int dest = valeur.Destinataire;
                valeur.Statut = "KO";

                decimal solde_exp;
                decimal solde_dest;
                decimal solde_final;

                if (exp == 0 && dest == 0)
                {
                    valeur.Statut = "KO";
                    continue;
                }
                else if (dest == exp)
                {
                    valeur.Statut = "OK";
                    continue;
                }

                
                Comptes compteexp = liste.Find(v => v.Compte == exp);
                Comptes comptedest = liste.Find(x => x.Compte == dest);
                if (compteexp == null || comptedest == null)
                {
                    valeur.Statut = "KO";
                    continue;
                }

                DateTime datecomptedest = comptedest.Date;
                DateTime datecompteexp = compteexp.Date;
                if (datecompteexp > date && datecomptedest > date)
                {
                    valeur.Statut = "KO";
                    continue;
                }


                if (exp == 0)
                {
                    Comptes destinataire = liste.Find(x => x.Compte == dest);
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
                    Comptes expediteur = liste.Find(x => x.Compte == exp);
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
                    Comptes Expediteur = liste.Find(x => x.Compte == exp);
                    solde_exp = Expediteur.Solde;

                    Comptes Destinataire = liste.Find(x => x.Compte == dest);
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

            }

            foreach (var comptess in liste)
            {
                Console.WriteLine(comptess.ToString());
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

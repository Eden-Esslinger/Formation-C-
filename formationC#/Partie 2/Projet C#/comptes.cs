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
    public class Gestionnaires
    {
        public int Identifiant;
        public string Type;
        public int Nbr_transactions;
        public List<Comptes> Comptes;

        public static Dictionary<int, Gestionnaires> Gestionnaireslec(string input0)
        {
            var d0 = new Dictionary<int, Gestionnaires>(); // création du dictionnaire de gestionnaires
            using (FileStream file0 = File.OpenRead(input0)) // ouverture du fichier gestionnaire

            using (StreamReader str = new StreamReader(file0)) // lecture du fichier gestionnaire

                while (!str.EndOfStream)
                {
                    string line = str.ReadLine();
                    int idgest; // id du gestionnaire
                    var mot = line.Split(';');
                    bool numvalide = int.TryParse(mot[0], out idgest); // verif si on a bien un entier
                    if (!numvalide)
                    {
                        continue;
                    }
                    int nbtrans; // nombre de transactions autorisées
                    
                    if (mot[1] == "Particulier")
                    {
                        // action
                    }
                    if (mot[1] == "Entreprise")
                    {
                        //action
                    }
                    bool nbtransvalide = int.TryParse(mot[2], out nbtrans);
                    if (!nbtransvalide)
                    {
                        continue;
                    }

                    Gestionnaires gestionnaire = new Gestionnaires();
                    gestionnaire.Identifiant = idgest;
                    gestionnaire.Type = mot[1];
                    gestionnaire.Nbr_transactions = nbtrans;
                     

                    if (d0.ContainsKey(idgest)) // est-ce que le gestionnaire existe déjà ?
                        continue;
                    else if (idgest < 1) // pas de gestionnaire négatif
                        continue;
                    else
                    {
                        d0.Add(idgest, gestionnaire); // ajout du gestionnaire dans le dictionnaire
                    }
                }
            return d0;
        }
    }
     
    public class Comptes
    {
        public int Compte;
        public DateTime Date;
        public decimal Solde;
        public string Entrée;
        public string Sortie;
        
        public string ToString()
        {
            return Compte + " " + Date.ToString() + " " + Solde + " " + Entrée + " " + Sortie; // affichage liste des Comptes
        }
        public static List<Comptes> Compteslec(string input, Dictionary<int, Gestionnaires> dico0)
        {
            
            List<Comptes> liste = new List<Comptes>();
            using (FileStream file = File.OpenRead(input))

            using (StreamReader str = new StreamReader(file))

                while (!str.EndOfStream)
                {
                    string line = str.ReadLine();
                    // numero du compte et test si numero valide
                    int numcpt;
                    var mot = line.Split(';');
                    bool numvalide = int.TryParse(mot[0], out numcpt);

                    if (!numvalide)
                    {
                        continue;
                    }
                    // solde du compte, remplacement . par , 
                    decimal solde;
                    mot[2] = mot[2].Replace(".", ",");
                    if (string.IsNullOrWhiteSpace(mot[2]))
                    {
                        mot[2] = "0";
                    }

                    bool soldevalide = decimal.TryParse(mot[2], out solde);

                    if (!soldevalide)
                    {
                        continue;
                    }

                    DateTime date;
                    DateTime.TryParse(mot[1], out date);
                    int entree;
                    if (string.IsNullOrWhiteSpace(mot[3]) && mot[4] != string.Empty && liste.Any(compte => compte.Compte.ToString() == mot[0])) // il n'y a pas de numero de gestionnaire en entrée
                                                                                                                                                // mais en sortie oui, est-ce que le compte est existant 
                    {
                        int.TryParse(mot[3], out entree);
                            Gestionnaires gestionnaire = dico0[entree];
                            List<Comptes> numcompte = gestionnaire.Comptes;
                            Comptes dateliste = liste[numcpt];
                            DateTime datecompte = dateliste.Date;

                                if (numcompte.Any(compte => compte.Compte == numcpt) && datecompte < date) // est-ce que le compte appartient au gestionnaire récupéré dans le fichier
                                                                                                           // et est-ce que la date renseigné dans le fichier à une date supérieure à la 
                                                                                                           // dernère opération du compte
                                {
                                   liste.Remove();// suppression compte
                                }
                       //     }
                         // present dans la liste
                        //    if ( bon Gestionnaires) 
                        //    if (date)
                        //
                    }
                    if (mot[3] != string.Empty && string.IsNullOrWhiteSpace(mot[4])) // pour la creation de compte
                    {
                        //  if (date)
                        //  if (Pas deja present dans la liste)
                        // ajout dans liste + ajout dans dico le gestionnaire correspondant
                    }

                    if (mot[3] != string.Empty && mot[4] != string.Empty)
                    {
                        // if(verif compte existant liste)
                        // if(verif date )
                        // if(verif bon gestionnaire)
                        // changement dans liste gestionnaire + changement date action
                    }

                    string sortie ;

                    
                    Comptes comptes = new Comptes();
                    comptes.Compte = numcpt;
                    comptes.Date = date;
                    comptes.Solde = solde;
                    comptes.Entrée = mot[3];
                    comptes.Sortie = mot[4];

                    if (numcpt < 1)
                        continue;
                    else
                    {
                        liste.Add(comptes);
                    }
                }
            return liste;
        }
    }

    public class Transactions
    {
        public int Identifiant;
        public string Date_effet;
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

        public static void Transaction(Dictionary<int, Transactions> dico2, List<Comptes> liste)
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
                    Comptes destinataire = liste[dest];
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
                    Comptes expediteur = liste[exp];
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
                        Comptes Expediteur = liste[exp];
                        solde_exp = Expediteur.Solde;

                        Comptes Destinataire = liste[dest];
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



         



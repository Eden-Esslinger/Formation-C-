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
            var d0 = new Dictionary<int, Gestionnaires>(); // cr�ation du dictionnaire de gestionnaires
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
                    int nbtrans; // nombre de transactions autoris�es
                    
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
                     

                    if (d0.ContainsKey(idgest)) // est-ce que le gestionnaire existe d�j� ?
                        continue;
                    else if (idgest < 1) // pas de gestionnaire n�gatif
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
        public string Entr�e;
        public string Sortie;
        
        public string ToString()
        {
            return Compte + " " + Date.ToString() + " " + Solde + " " + Entr�e + " " + Sortie; // affichage liste des Comptes
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

                    if (!numvalide && numcpt < 1)
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
                    int sortie;
                    if (string.IsNullOrWhiteSpace(mot[3]) && mot[4] != string.Empty && liste.Any(compte => compte.Compte.ToString() == mot[0])) // il n'y a pas de numero de gestionnaire en entr�e
                                                                                                                                                // mais en sortie oui, est-ce que le compte est existant 
                    {
                        int.TryParse(mot[4], out sortie);
                            Gestionnaires gestionnaire = dico0[sortie];
                            List<Comptes> numcompte = gestionnaire.Comptes;
                            Comptes compteclo = liste[numcpt];
                            DateTime datecompte = compteclo.Date;

                                if (numcompte.Any(compte => compte.Compte == numcpt) && datecompte < date) // est-ce que le compte appartient au gestionnaire r�cup�r� dans le fichier
                                                                                                           // et est-ce que la date renseign� dans le fichier � une date sup�rieure � la 
                                                                                                           // dern�re op�ration du compte
                                {
                                   liste.Remove(compteclo); // suppression compte
                                }
                    }
                    if (mot[3] != string.Empty && string.IsNullOrWhiteSpace(mot[4]) && !liste.Any(compte => compte.Compte.ToString() == mot[0])) //// il y a pas un numero de gestionnaire en entr�e
                                                                                                                                                 // mais pas en sortie, est-ce que le compte est existant ?
                    {
                        int.TryParse(mot[3], out entree);
                        if (dico0.ContainsKey(entree))
                        {
                            Comptes comptes = new Comptes(); // ajout dans liste
                            comptes.Compte = numcpt;
                            comptes.Date = date;
                            comptes.Solde = solde;
                            comptes.Entr�e = mot[3];
                            comptes.Sortie = mot[4];
                            liste.Add(comptes);

                            List<Comptes> listecpt = new List<Comptes>(); // ajout dans dico le gestionnaire
                            Gestionnaires gestionnaire = dico0[entree];
                            listecpt = gestionnaire.Comptes;
                            listecpt.Add(comptes);
                            gestionnaire.Comptes = listecpt;

                        }
                    }

                    if (mot[3] != string.Empty && mot[4] != string.Empty && liste.Any(compte => compte.Compte.ToString() == mot[0])) // si entree et sortie renseign�, verif si
                                                                                                                                     // compte existant
                    { 
                        int.TryParse(mot[3], out entree);
                        Comptes comptemodif = liste[numcpt];
                        DateTime datecompte = comptemodif.Date;
                        Gestionnaires gestionnaire = new Gestionnaires();

                        if (dico0.ContainsKey(entree) && dico0.TryGetValue(entree,out gestionnaire) &&  datecompte < date) // verif si compte appartient au bon gestionnaire
                                                                                                                           // et si date est coh�rente
                        {
                            Comptes comptes = liste[numcpt]; // modif dans liste Comptes des gestionnaires
                            comptes.Date = datecompte;
                            comptes.Entr�e = mot[3];
                            comptes.Sortie = mot[4];

                            int.TryParse(mot[4], out sortie);
                            Gestionnaires ajoutgest = dico0[sortie]; // ajout du compte sur le nouveau gestionnaire
                            List<Comptes> listecpt = new List<Comptes>();
                            listecpt = ajoutgest.Comptes;
                            listecpt.Add(comptes);
                            ajoutgest.Comptes = listecpt;

                            Gestionnaires suppgest = dico0[entree]; // suppression du compte dans le gestionnaire 
                            List<Comptes> listecpt2 = new List<Comptes>();
                            listecpt2 = suppgest.Comptes;
                            listecpt2.Remove(comptes);
                            suppgest.Comptes = listecpt2;

                        }
                    }

                }
            return liste;
        }
    }

    public class Transactions
    {
        public int Identifiant;
        public DateTime Date_effet;
        public decimal Montant;
        public int Exp�diteur;
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
                    if(string.IsNullOrWhiteSpace(mot[2]))
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
                    transactions.Exp�diteur = exp;
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
                int exp = valeur.Exp�diteur;
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



         



using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.Remoting.Messaging;

namespace Projet_C_
{
    /*public class Gestionnaires
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

        public Gestionnaires()
        {
            Comptes = new List<Comptes>();
        }
    }*/
     
    public class Comptes
    {
        public int Compte;
        public DateTime Date;
        public decimal Solde;
        public string Entrée;
        public string Sortie;
        
        public Comptes()
        {
            Date = DateTime.Now;
        }
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
                    /*   if (string.IsNullOrWhiteSpace(mot[3]) && mot[4] != string.Empty && liste.Any(compte => compte.Compte.ToString() == mot[0])) // il n'y a pas de numero de gestionnaire en entrée
                                                                                                                                                   // mais en sortie oui, est-ce que le compte est existant 
                       {
                           int.TryParse(mot[4], out sortie);
                               Gestionnaires gestionnaire = dico0[sortie];
                               List<Comptes> numcompte = gestionnaire.Comptes;
                               Comptes compteclo = liste.Find(x => x.Compte == numcpt);
                               DateTime datecompte = compteclo.Date;

                                   if (numcompte.Any(compte => compte.Compte == numcpt) && datecompte < date) // est-ce que le compte appartient au gestionnaire récupéré dans le fichier
                                                                                                              // et est-ce que la date renseigné dans le fichier à une date supérieure à la 
                                                                                                              // dernère opération du compte
                                   {
                                      liste.Remove(compteclo); // suppression compte
                                   }*/

                    if (mot[3] != string.Empty && string.IsNullOrWhiteSpace(mot[4]) && !liste.Any(compte => compte.Compte.ToString() == mot[0])) //// il y a pas un numero de gestionnaire en entrée
                                                                                                                                                 // mais pas en sortie, est-ce que le compte est existant ?
                    {
                        int.TryParse(mot[3], out entree);
                        if (dico0.ContainsKey(entree))
                        {
                            Comptes comptes = new Comptes(); // ajout dans liste
                            comptes.Compte = numcpt;
                            comptes.Date = date;
                            comptes.Solde = solde;
                            comptes.Entrée = mot[3];
                            comptes.Sortie = mot[4];
                            liste.Add(comptes);

                            List<Comptes> listecpt = new List<Comptes>(); // ajout dans dico le gestionnaire
                            Gestionnaires gestionnaire = dico0[entree];
                            listecpt = gestionnaire.Comptes;
                            listecpt.Add(comptes);
                            gestionnaire.Comptes = listecpt;

                        }
                    }

                    if (mot[3] != string.Empty && mot[4] != string.Empty && liste.Any(compte => compte.Compte.ToString() == mot[0])) // si entree et sortie renseigné, verif si
                                                                                                                                     // compte existant
                    {
                        int.TryParse(mot[3], out entree);
                        Comptes comptemodif = liste.Find(x => x.Compte == numcpt);
                        DateTime datecompte = comptemodif.Date;
                        Gestionnaires gestionnaire = new Gestionnaires();

                        if (dico0.ContainsKey(entree) && dico0.TryGetValue(entree, out gestionnaire) && datecompte < date) // verif si compte appartient au bon gestionnaire
                                                                                                                           // et si date est cohérente
                        {
                            Comptes comptes = liste.Find(x => x.Compte == numcpt); // modif dans liste Comptes des gestionnaires
                            comptes.Date = datecompte;
                            comptes.Entrée = mot[3];
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
            
        public static void Cloture(string input, List<Comptes> liste2, Dictionary<int, Gestionnaires> dico0)
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
                    if (string.IsNullOrWhiteSpace(mot[3]) && mot[4] != string.Empty && liste2.Any(compte => compte.Compte.ToString() == mot[0])) // il n'y a pas de numero de gestionnaire en entrée
                                                                                                                                                // mais en sortie oui, est-ce que le compte est existant 
                    {
                        int.TryParse(mot[4], out sortie);
                        Gestionnaires gestionnaire = dico0[sortie];
                        List<Comptes> numcompte = gestionnaire.Comptes;
                        Comptes compteclo = liste.Find(x => x.Compte == numcpt);
                        DateTime datecompte = compteclo.Date;

                        if (numcompte.Any(compte => compte.Compte == numcpt) && datecompte < date) // est-ce que le compte appartient au gestionnaire récupéré dans le fichier
                                                                                                   // et est-ce que la date renseigné dans le fichier à une date supérieure à la 
                                                                                                   // dernère opération du compte
                        {
                            liste.Remove(compteclo); // suppression compte
                        }
                    }



                }
        }
    }

  
}



         



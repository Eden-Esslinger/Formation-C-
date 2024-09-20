using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Gestionnaires()
        {
            Comptes = new List<Comptes>();
        }
    }
}

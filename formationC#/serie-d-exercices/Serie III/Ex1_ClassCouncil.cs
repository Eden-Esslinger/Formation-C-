using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Serie_III
{
    public static class ClassCouncil
    {
        public static void SchoolMeans(string input, string output)
        {
            var reader = new StreamReader(input);
                List<string> listA = new List<string>();
                List<string> listB = new List<string>();
                List<string> listC = new List<string>();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                listA.Add(line);
            }
            foreach (var line2 in listA)
            {
                if (line2.Contains("Histoire"))
                {
                    string[] valeurs = line2.Split(';');
                    foreach (var val in valeurs)
                    {

                        listB.Add(val);
                    }

                }
                else if (line2.Contains("Maths"))
                {
                    string[] valeurs2 = line2.Split(';');
                    foreach (var val2 in valeurs2)
                    {
                        listC.Add(val2);
                    }
                }
            }
                  listB.RemoveRange(0, 2);
                  listB.RemoveRange(1, 2);
                  listB.RemoveRange(2, 2);
                  listC.RemoveRange(0, 2);
                  listC.RemoveRange(1, 2);


                 double somme = 0;
                 int cp = 0;
            foreach (string line3 in listB)
            {
                double vals = Convert.ToDouble(line3);
                somme += vals;
                cp++;
            }
             double moyenneH = somme / cp;
             Console.WriteLine($"la moyenne en histoire est de {moyenneH:F1} ");

            double somme2 = 0;
            int cp2 = 0;
            foreach (string line4 in listC)
            {
                double vals2 = Convert.ToDouble(line4);
                somme2 += vals2;
                cp2++;
            }
            double moyenneM = somme2 / cp2;
            Console.WriteLine($"la moyenne en histoire est de {moyenneM:F1} ");
            string entete = $"Matière;Moyenne";
            string histoire = $"Histoire;{moyenneH:F1}";
            string maths = $"Maths;{moyenneM:F1}";

            StreamWriter sortie = new StreamWriter(output);
            sortie.WriteLine(entete);    
            sortie.WriteLine(histoire);
            sortie.WriteLine(maths) ;
            sortie.Close();
        }       
    }
}

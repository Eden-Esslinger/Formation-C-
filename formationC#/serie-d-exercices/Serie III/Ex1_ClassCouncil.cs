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
               Console.WriteLine(listA.Count);
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
                    //    listB.RemoveRange(0, 2);
                    //    listB.RemoveRange(3, 2);
                    //    listB.RemoveRange(6, 2);
                    //    Console.WriteLine(listB.Count);

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
                  Console.WriteLine(listB.Count);
                  listC.RemoveRange(0, 2);
                  listC.RemoveRange(1, 2);
                  Console.WriteLine(listC.Count);


                 double somme = 0;
                 int cp = 0;
            foreach (string line3 in listB)
            {
                double vals = Convert.ToDouble(line3);
                somme += vals;
                cp++;
            }
             double moyenneH = somme / cp;
             Console.WriteLine(moyenneH);

            //    string[] valeurs = line3.Split(';');
            //    foreach (string val in valeurs)
            //    { 
            //    Console.WriteLine(val);
            
                
               
            
                
        }       
    }
}

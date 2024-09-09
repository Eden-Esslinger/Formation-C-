using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_I
{
    public static class SpeakingClock
    {
        public static string GoodDay(int heure)
        {
            switch (heure)
            { // de minuit à avant 6 heures du matin
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    Console.WriteLine("Il est " + heure + " H, Merveilleuse nuit!");
                    break;
                // de 6 h du matin à avant midi
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                    Console.WriteLine("Il est " + heure + " H, Bonne matinée!");
                    break;
                case 12: // a midi
                    Console.WriteLine("Il est " + heure + " H, Bon appétit!");
                    break;
                // entre 13h et 18h
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                    Console.WriteLine("Il est " + heure + " H, Profitez de votre après-midi!");
                    break;
                // après 18h
                case 19:
                case 20:
                case 21:
                case 22:
                case 23:
                    Console.WriteLine("Il est " + heure + " H, Passez une bonne soirée!");
                    break;
            }
            return string.Empty;
        }
    }
}

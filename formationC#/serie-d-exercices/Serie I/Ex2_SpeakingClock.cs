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
            {
                case heure when (heure > 0 && heure < 6):
                 Console.WriteLine("Il est" + heure + "H, Merveilleuse nuit!");
                    break;
                case ==6 && <12:
                        Console.WriteLine("Il est" + heure + "H, Bonne matinée!");
                    break;
                case == 12:
                    Console.WriteLine("Il est" + heure + "H, Bon appétit!");
                    break;
                case 
            }
            return string.Empty;
        }
    }
}

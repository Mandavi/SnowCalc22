using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnowCalc.Services
{
    public class SnowCalcService
    {

        // Für Standorte, die höher liegen als in der Tabelle angegeben, gibt es eine Berechnungsformel, 
        // die unter Berücksichtigung der Höhe die Schneelast am Boden ausgibt

        public double CalcSkb(int zone = 1, int hoehe = 0)
        {
            double result = 0.65d;

            switch (zone)
            {
                case 1:
                    result = 0.19d + 0.91d * Math.Pow((hoehe + 140d) / 760d, 2);
                    if (result < 0.65d) result = 0.65d;
                    break;
                case 2:
                    result = 1.25d * (0.19d + 0.91d * Math.Pow((hoehe + 140d) / 760, 2));
                    if (result < 0.81d) result = 0.81d;
                    break;
                case 3:
                    result = 0.25d + 1.91d * Math.Pow((hoehe + 140d) / 760d, 2);
                    if (result < 0.85d) result = 0.85d;
                    break;
                case 4:
                    result = 1.25d * (0.25d + 1.91d * Math.Pow((hoehe + 140d) / 760d, 2));
                    if (result < 1.06d) result = 1.06d;
                    break;
                case 5:
                    result = 0.31d + 2.91d * Math.Pow((hoehe + 140d) / 760d, 2);
                    if (result < 1.10d) result = 1.10d;
                    break;
                default:
                    result = 0;
                    break;
            }
            return result;
        }
        public double CalcSkd(int neigung = 0, double skb = 0)
        {
            double result = 0;
            if (neigung <= 60)
            {
                result = skb * (0.8d * (60d - neigung) / 30d);
            }
            if (neigung <= 30)
            {
                result = skb * .8d;
            }
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace WeatherGetter
{
    static class Tutorial
    {
        public static void ShowTutorial()
        {
            Thread.Sleep(200);

            PrintSlowly("Witaj w Pobieraczu pogody !");
            Thread.Sleep(300);
            Console.WriteLine("Ten program pozwoli Ci wyświetlić pogodę w dowolnym mieście na całym świecie.");
            Thread.Sleep(400);
            Console.WriteLine("Aby rozpocząć wpisz: \"pogoda nazwa miasta\".");
            Thread.Sleep(500);
            Console.WriteLine("Aby wyświetlić pomoc wpisz: \"pomoc\".");

        }

        public static void PrintSlowly(string toPrint)
        {
            for (int i = 0; i < toPrint.Length; i++)
            {
                Console.Write(toPrint[i]);
                Thread.Sleep(30);
            }
            Console.WriteLine("");
        }
    }
}

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
        /// <summary>
        /// Displays initial tutorial to the user
        /// </summary>
        public static void ShowTutorial()
        {
            Thread.Sleep(200);

            if (Controller.language == Controller.Lang.pl)
            {
                PrintSlowly("Witaj w Pobieraczu pogody !");
                Thread.Sleep(200);
                Console.WriteLine("Ten program pozwoli Ci wyświetlić pogodę w dowolnym mieście na całym świecie.");
                Thread.Sleep(300);
                Console.WriteLine("- Aby pokazać obecną pogodę wpisz: \"teraz nazwa miasta\".");
                Thread.Sleep(400);
                Console.WriteLine("- Aby wyświetlić pomoc wpisz: \"pomoc\".");
            }
            else if (Controller.language == Controller.Lang.en)
            {
                PrintSlowly("Welcome to weather getter !");
                Thread.Sleep(200);
                Console.WriteLine("This program lets you to check the weather in any city in the world.");
                Thread.Sleep(300);
                Console.WriteLine("- To show current weather type: \"now city name\".");
                Thread.Sleep(400);
                Console.WriteLine("- To display help type: \"help\".");
            }

            Thread.Sleep(500);
            Console.WriteLine("- To change language type: \"lang language_letter_code (PL/EN)\".");
        }

        /// <summary>
        /// Slowly prints choosen string - character by character
        /// </summary>
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

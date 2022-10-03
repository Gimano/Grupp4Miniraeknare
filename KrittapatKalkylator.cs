using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp4Miniräknare
{
    internal class KrittapatKalkylator
    {
        public static void Program()
        {

            List<double> resultatHistorik;   //skapar en list
            Console.WriteLine("==================================");
            Console.WriteLine("           Välkommen till         ");
            Console.WriteLine("            Miniräknare           ");
            Console.WriteLine("==================================");

            resultatHistorik = new List<double>(); // En lista för att spara historik för räkningar 
            calculate();
            menu();

            void calculate()
            {
                string inputTal1;
                string inputTal2;
                double tal1;
                double tal2;

                bool felInput = true;

                while (felInput)
                {

                    // Användaren matar in tal och matematiska operation
                    Console.Write("Skriv in det första talet: ");
                    inputTal1 = Console.ReadLine();

                    bool okay = double.TryParse(inputTal1, out tal1);

                    if (okay)
                    {
                        felInput = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine(" Ogilig inmatning! ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    Console.WriteLine("Skriv in matematiska operation \n " +    //Jag vill att det fungerar som räknaren i verkligheten 
                    "+ för plus \n " +
                    "- för minus \n " +
                    "* för multiplikation\n " +
                    "/ för division ");

                    string operatör = Console.ReadLine();
                    Console.Write("Skriv in det andra talet: ");
                    inputTal2 = Console.ReadLine();

                    bool okay1 = double.TryParse(inputTal2, out tal2);

                    if (okay1)
                    {
                        felInput = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine(" Ogilig inmatning! ");
                        Console.ForegroundColor = ConsoleColor.Gray;

                    }


                    if (operatör == "/" && tal2 == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Går ej att dela med 0 ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.ReadLine();
                        return;
                    }


                    switch (operatör)
                    {
                        case "+":
                            double plusResultat = tal1 + tal2;
                            resultatHistorik.Add(plusResultat); // Lägga resultat till listan
                            Console.WriteLine(tal1 + " + " + tal2 + " = " + plusResultat);  //Visa resultat
                            break;
                        case "-":
                            double minusResultat = tal1 - tal2;
                            resultatHistorik.Add(minusResultat); // Lägga resultat till listan
                            Console.WriteLine(tal1 + " - " + tal2 + " = " + minusResultat);  //Visa resultat
                            break;
                        case "*":
                            double gångerResultat = tal1 * tal2;
                            resultatHistorik.Add(gångerResultat); // Lägga resultat till listan
                            Console.WriteLine(tal1 + " * " + tal2 + " = " + gångerResultat);  //Visa resultat
                            break;
                        case "/":
                            double divisionResultat = tal1 / tal2;
                            resultatHistorik.Add(divisionResultat); // Lägga resultat till listan
                            Console.WriteLine(tal1 + " / " + tal2 + " = " + divisionResultat);  //Visa resultat
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine(" Ogilig inmatning! ");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                    }
                }

                Console.ReadLine();
            }

            void printHistory()  //Fråga användaren om den vill visa tidigare resultat.
            {
                Console.Clear();
                Console.WriteLine("*Tidigare resultat*");
                foreach (var result in resultatHistorik)
                {
                    Console.WriteLine(result);  //Visa tidigare resultat 
                }
                Console.ReadLine();
            }
            void menu()   //Fråga användaren om den vill avsluta eller fortsätta  
            {
                bool avsluta = false;
                while (!avsluta)   //loopar genom menu
                {
                    Console.Clear();
                    Console.WriteLine("Välj mellan \n 1. fortsätta \n 2. avsluta \n 3. se tidigare resultat " +
                                  "\n Svara med 1, 2 eller 3 ");
                    string svar = Console.ReadLine();

                    switch (svar)
                    {
                        case "1":
                            calculate();
                            break;
                        case "2":
                            avsluta = true;  //avslutar menu, ändra menu avslutar till true 
                            break;
                        case "3":
                            printHistory();
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}

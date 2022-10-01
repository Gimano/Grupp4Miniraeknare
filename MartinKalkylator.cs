using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp4Miniräknare
{
    internal class MartinKalkylator
    {
        public static void Program()
        {
            Console.Title = "Miniräknaren";
            Console.WriteLine("Välkommen till miniräknaren!");
            Console.WriteLine("Tryck på valfri tangent.");
            Console.ReadKey();
            bool körs = true;
            List<string> historik = new List<string>();

            while (körs)
            {
                Console.Clear();

                string beräkning;
                double tal1 = 0;
                double tal2 = 0;
                string[] operatörer = new string[] { "+", "-", "/", "*" };
                int operatörIndex = 0;
                char operatör = 'a';
                double resultat = 0;

                bool formatering;
                do
                {
                    Console.Write("Skriv in din uträkning: ");
                    beräkning = Console.ReadLine();

                    for (int i = 0; i < 4; i++)
                    {
                        if (beräkning.Contains(operatörer[i]))
                        {
                            operatörIndex = beräkning.IndexOf(operatörer[i]);
                            operatör = char.Parse(operatörer[i]);
                        }
                    }

                    try
                    {
                        tal1 = double.Parse(beräkning[..operatörIndex]);
                        tal2 = double.Parse(beräkning[(operatörIndex + 1)..]);
                        formatering = true;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Formateringsfel. Försök igen.");
                        formatering = false;
                    }
                } while (!formatering);

                switch (operatör)
                {
                    case '+':
                        resultat = tal1 + tal2;
                        break;
                    case '-':
                        resultat = tal1 - tal2;
                        break;
                    case '/':
                        if (tal1 != 0 && tal2 != 0)
                            resultat = tal1 / tal2;
                        else
                            Console.WriteLine("Ogilitig inmatning!");
                        break;
                    case '*':
                        if (tal1 != 0 && tal2 != 0)
                            resultat = tal1 * tal2;
                        else
                            Console.WriteLine("Ogilitig inmatning!");
                        break;

                }

                if (resultat != 0)
                {
                    historik.Add(beräkning + "= " + resultat);
                    Console.WriteLine($"Resultatet av uträkningen blir: {resultat}");
                }

                string seHistorik = "";
                while (seHistorik != "y" && seHistorik != "n")
                {
                    Console.WriteLine();
                    Console.Write("Vill du se historiken? Y/N ");
                    seHistorik = Console.ReadLine().ToLower();
                    if (seHistorik.Contains("y"))
                    {
                        Console.WriteLine();
                        foreach (string i in historik)
                        {
                            Console.WriteLine(i);
                        }
                    }
                }

                string fortsätta = "";
                while (fortsätta != "y" && fortsätta != "n")
                {
                    Console.WriteLine();
                    Console.Write("Vill du göra en till uträkning? Y/N ");
                    fortsätta = Console.ReadLine().ToLower();
                    if (fortsätta.Contains("n"))
                    {
                        körs = false;
                    }
                }

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P_320__lucpardo_parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShowMenu();
            Parking voiture1 = new Parking("VD", 299572);
            voiture1.EntrerVoiture();
            Console.ReadLine();
        }
        static void ShowMenu()
        { 
            Console.WriteLine("==========Menu Principal==========");
            Console.WriteLine("1. Entrée d'un véhicule");
            Console.WriteLine("2. Sortie d'un véhicule");
            Console.WriteLine("3. Afficher l'état du parking");
            Console.WriteLine("4. Rechercher un véhicule");
            Console.WriteLine("5. Statistiques du jour");
            Console.WriteLine("6. Historique des transactions");
            Console.WriteLine("0. Quitter");
            Console.Write("Votre choix: ");

            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    Console.WriteLine("\n==========Entrée d'un véhicule==========\n");
                    break;

                case '2':
                    Console.WriteLine("\n==========Sortie d'un véhicule==========\n");
                    break;

                case '3':
                    Console.WriteLine("\n==========État du parking==========\n");
                    break;

                case '4':
                    Console.WriteLine("\n==========Rechercher un véhicule==========\n");
                    break;

                case '5':
                    Console.WriteLine("\n==========Statistiques du jour==========\n");
                    break;

                case '6':
                    Console.WriteLine("\n==========Historique des transactions==========\n");
                    break;

                case '0':
                    Console.WriteLine("\nAu revoir !\n");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("\nChoix invalide !\n");
                    Thread.Sleep(1000);
                    Console.Clear();
                    ShowMenu();
                    break;
            }
        }
    }
}

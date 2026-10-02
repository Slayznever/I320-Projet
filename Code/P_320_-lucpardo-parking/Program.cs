using System;

namespace P_320__lucpardo_parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Parking parking = new Parking();

            bool continuer = true;

            while (continuer)
            {
                ClearTotal();

                ShowMenu();

                string choix = Console.ReadLine() ?? "";

                ClearTotal();

                switch (choix)
                {
                    case "1":
                        Console.WriteLine("\n========== Entrée d'un véhicule ==========\n");

                        parking.EntrerVoiture();
                        break;

                    case "2":
                        Console.WriteLine("\n========== Sortie d'un véhicule ==========\n");

                        parking.SortirVoiture();
                        break;

                    case "3":
                        Console.WriteLine("\n========== État du parking ==========\n");

                        parking.Status();
                        break;

                    case "4":
                        Console.WriteLine("\n========== Rechercher un véhicule ==========\n");

                        parking.RechercherVoiture();
                        break;

                    case "5":
                        Console.WriteLine("\n========== Statistiques du jour ==========\n");

                        parking.StatistiquesDuJour();
                        break;

                    case "6":
                        Console.WriteLine("\n========== Historique des transactions ==========\n");

                        parking.HistoriqueTickets();
                        break;

                    case "0":
                        continuer = false;
                        break;

                    default:
                        Console.WriteLine("\nChoix invalide !");
                        break;
                }

                if (continuer)
                {
                    Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");

                    Console.ReadKey();
                }
            }
        }


        private static void ClearTotal()
        {
            Console.Clear();
            Console.Write("\x1b[3J");

        }

        public static void ShowMenu()
        {
            Console.WriteLine("========== Menu Principal ==========");
            Console.WriteLine("1. Entrée d'un véhicule");
            Console.WriteLine("2. Sortie d'un véhicule");
            Console.WriteLine("3. Afficher l'état du parking");
            Console.WriteLine("4. Rechercher un véhicule");
            Console.WriteLine("5. Statistiques du jour");
            Console.WriteLine("6. Historique des transactions");
            Console.WriteLine("0. Quitter");
            Console.Write("\nVotre choix : ");
        }
    }
}
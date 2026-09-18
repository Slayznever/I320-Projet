using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_320__lucpardo_parking
{
    internal class Parking
    {
        string canton;
        int matricule;
        const int PLACETOT = 20;
        int placeOccupee = 0;
        int placeLibre;
        public Parking(string canton, int matricule) 
        {
             this.canton = canton;
            this.matricule = matricule;
        }
        public void EntrerVoiture() 
        {
            Console.WriteLine("Veuillez entrer votre Canton ex: (Vaud = VD): ");
            canton = Console.ReadLine();
            while (canton.Length != 2) 
            {
                Console.WriteLine("\nValeur invalide");
                Console.WriteLine("Veuillez entrer votre Canton ex: (Vaud = VD): ");
                canton = Console.ReadLine();
            }
            Console.Write("Veuillez entrer votre matricule: ");
            string matriculestring = Console.ReadLine();
            bool matriculeInt = int.TryParse(matriculestring, out int nombre);
            while (matriculestring.Length != 6 || matriculeInt == false)
            {
                Console.WriteLine("Valeur invalide");
                Console.Write("Veuillez entrer votre matricule: ");
                matriculestring = Console.ReadLine();
                matriculeInt = int.TryParse(matriculestring, out nombre);
            }
            string plaque = $"{canton}-{matriculestring}";
            Console.WriteLine($"Bonjour {plaque}, voici les places libres: ");
            Console.Write($"Veuillez choisir votre place: ");
            Console.ReadLine();

        }
    }
}


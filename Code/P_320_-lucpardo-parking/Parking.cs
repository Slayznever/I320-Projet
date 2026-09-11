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
        public Parking(string canton, int matricule) 
        {
             this.canton = canton;
            this.matricule = matricule;
        }
        public void EntrerVoiture() 
        {
            Console.Write("Veuillez entrer votre Canton ex: (Vaud = VD): ");
            canton = Console.ReadLine();
            if (canton.Length != 2) 
            {
                Console.Write("\nValeur invalide");
                EntrerVoiture();
            }
            Console.Write("Veuillez entrer votre matricule: ");
            string matriculestring = matricule.ToString();
            matriculestring = Console.ReadLine();
            if (matriculestring.Length != 6 )
            {
                Console.WriteLine("Valeur invalide");
                EntrerVoiture();
            }
            Console.Write($"{canton}-{matriculestring}");
            
        }
    }
}



using System;

namespace P_320__lucpardo_parking
{
    internal class Parking
    {
        const int PLACETOT = 20;

        private Voiture[] _places = new Voiture[PLACETOT];

        public Parking()
        {
        }

        public void EntrerVoiture()
        {
            string canton;
            bool parkingPlein = true;

            for (int i = 0; i < PLACETOT; i++)
            {
                if (_places[i] == null)
                {
                    parkingPlein = false;
                    break;
                }
            }

            if (parkingPlein)
            {
                Console.WriteLine("Le parking est complet !");
                return;
            }

            Console.Write("Veuillez entrer votre canton (ex. Vaud = VD) : ");
            canton = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(canton) || canton.Length != 2)
            {
                Console.WriteLine("Valeur invalide.");
                Console.Write("Veuillez entrer votre canton (ex. Vaud = VD) : ");
                canton = Console.ReadLine();
            }

            canton = canton.ToUpper();

            Console.Write("Veuillez entrer votre matricule (6 chiffres) : ");
            string matriculestring = Console.ReadLine();

            bool matriculeInt = int.TryParse(matriculestring, out int nombre);

            while (matriculestring == null ||
                   matriculestring.Length != 6 ||
                   !matriculeInt)
            {
                Console.WriteLine("Valeur invalide.");
                Console.Write("Veuillez entrer votre matricule (6 chiffres) : ");

                matriculestring = Console.ReadLine();
                matriculeInt = int.TryParse(matriculestring, out nombre);
            }

            string plaque = $"{canton}-{matriculestring}";

            for (int i = 0; i < PLACETOT; i++)
            {
                if (_places[i] != null &&
                    _places[i].GetMatricule() == plaque)
                {
                    Console.WriteLine("Cette voiture est déjà dans le parking !");
                    return;
                }
            }

            Console.WriteLine($"\nBonjour {plaque}");
            Console.WriteLine("Voici les places libres :");

            for (int i = 0; i < PLACETOT; i++)
            {
                if (_places[i] == null)
                {
                    Console.WriteLine($"Place {i + 1} : libre");
                }
            }

            Console.Write("\nVeuillez choisir votre place (1-20) : ");

            bool choixValide = int.TryParse(Console.ReadLine(), out int choix);

            while (!choixValide ||
                   choix < 1 ||
                   choix > PLACETOT ||
                   (choixValide && _places[choix - 1] != null))
            {
                if (choixValide &&
                    choix >= 1 &&
                    choix <= PLACETOT &&
                    _places[choix - 1] != null)
                {
                    Console.WriteLine("Cette place est déjà occupée !");
                }
                else
                {
                    Console.WriteLine("Choix invalide !");
                }

                Console.Write("Veuillez choisir une place libre (1-20) : ");
                choixValide = int.TryParse(Console.ReadLine(), out choix);
            }

            Voiture voiture = new Voiture(plaque);

            _places[choix - 1] = voiture;

            Console.WriteLine(
                $"\nLa voiture {plaque} est garée à la place {choix}."
            );

        }

        public void SortirVoiture()
        {
            Console.Write("Entrez la plaque ou le numéro de place : ");
            string recherche = Console.ReadLine();

            Voiture voiture = null;
            int numeroPlace = -1;

            if (int.TryParse(recherche, out int place))
            {
                if (place >= 1 && place <= PLACETOT)
                {
                    if (_places[place - 1] != null)
                    {
                        voiture = _places[place - 1];
                        numeroPlace = place;
                    }
                }
            }
            else
            {
                for (int i = 0; i < PLACETOT; i++)
                {
                    if (_places[i] != null &&
                        _places[i].GetMatricule().Equals(
                            recherche,
                            StringComparison.OrdinalIgnoreCase))
                    {
                        voiture = _places[i];
                        numeroPlace = i + 1;
                        break;
                    }
                }
            }

            if (voiture == null)
            {
                Console.WriteLine("Véhicule introuvable.");
                return;
            }

            Console.WriteLine("\n========== SORTIE ==========");
            Console.WriteLine($"Plaque : {voiture.GetMatricule()}");
            Console.WriteLine($"Place : {numeroPlace}");
            Console.WriteLine("============================");

            Console.Write("\nVoulez-vous réellement sortir ? (O/N) : ");
            string confirmation = Console.ReadLine();

            if (string.Equals(
                confirmation,
                "O",
                StringComparison.OrdinalIgnoreCase))
            {
                _places[numeroPlace - 1] = null;

                Console.WriteLine(
                    $"La place {numeroPlace} est maintenant libre."
                );
            }
            else
            {
                Console.WriteLine("Sortie annulée.");
            }
        }

        public void Status()
        {
            for (int i = 0; i < PLACETOT; i++)
            {
                if (_places[i] == null)
                {
                    Console.Write($"[ {i + 1:00} O ]");
                }
                else
                {
                    Console.Write($"[ {i + 1:00} X ]");
                }

                if ((i + 1) % 4 == 0)
                {
                    Console.WriteLine();
                }
            }

            Console.WriteLine("\n=====================================");
        }

        public void RechercherVoiture()
        {
            Console.Write("Entrez la plaque ou le numéro de place : ");
            string recherche = Console.ReadLine();

            Voiture voiture = null;
            int numeroPlace = -1;

            if (int.TryParse(recherche, out int place))
            {
                if (place >= 1 && place <= PLACETOT)
                {
                    voiture = _places[place - 1];
                    numeroPlace = place;
                }
            }
            else
            {
                for (int i = 0; i < PLACETOT; i++)
                {
                    if (_places[i] != null &&
                        _places[i].GetMatricule().Equals(
                            recherche,
                            StringComparison.OrdinalIgnoreCase))
                    {
                        voiture = _places[i];
                        numeroPlace = i + 1;
                        break;
                    }
                }
            }

            if (voiture == null)
            {
                Console.WriteLine("\nVéhicule introuvable.");
                return;
            }

            Console.WriteLine("\n========== VÉHICULE TROUVÉ ==========");
            Console.WriteLine($"Immatriculation : {voiture.GetMatricule()}");
            Console.WriteLine($"N° place        : {numeroPlace}");
            Console.WriteLine("=====================================");
        }
    }
}

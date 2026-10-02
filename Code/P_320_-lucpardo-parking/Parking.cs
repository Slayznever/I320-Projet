using System;
using System.Collections.Generic;
using System.Linq;

namespace P_320__lucpardo_parking
{
    internal class Parking
    {
        private const int PLACETOT = 20;

        private Voiture[] _places = new Voiture[PLACETOT];
        private Ticket[] _tickets = new Ticket[PLACETOT];

        private List<Ticket> _historique = new List<Ticket>();

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


            Console.Write(
                "Veuillez entrer votre canton (ex. Vaud = VD) : ");

            canton = Console.ReadLine() ?? "";

            while (string.IsNullOrWhiteSpace(canton) || canton.Trim().Length != 2 || !canton.Trim().All(char.IsLetter))
            {
                Console.WriteLine("Valeur invalide.");

                Console.Write(
                    "Veuillez entrer votre canton (ex. Vaud = VD) : ");

                canton = Console.ReadLine() ?? "";
            }

            canton = canton.Trim().ToUpperInvariant();


            Console.Write(
                "Veuillez entrer votre matricule (6 chiffres) : ");

            string matriculestring =
                (Console.ReadLine() ?? "").Trim();

            while (matriculestring.Length != 6
                || !matriculestring.All(char.IsDigit))
            {
                Console.WriteLine("Valeur invalide.");

                Console.Write(
                    "Veuillez entrer votre matricule (6 chiffres) : ");

                matriculestring =
                    (Console.ReadLine() ?? "").Trim();
            }

            string plaque = $"{canton}-{matriculestring}";


            for (int i = 0; i < PLACETOT; i++)
            {
                if (_places[i] != null &&
                    _places[i].GetMatricule() == plaque)
                {
                    Console.WriteLine(
                        "Cette voiture est déjà dans le parking !");
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
            Console.Write( "\nVeuillez choisir votre place (1-20) : ");

            bool choixValide = int.TryParse(Console.ReadLine(), out int choix);

            while (!choixValide || choix < 1 || choix > PLACETOT || _places[choix - 1] != null)
            {
                if (choixValide && choix >= 1 && choix <= PLACETOT && _places[choix - 1] != null)
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
            Ticket ticket = new Ticket(plaque, choix);
            _tickets[choix - 1] = ticket;
            Console.WriteLine($"\nLa voiture {plaque} est garée à la place {choix}.");
            ticket.Afficher();


        }

        public void SortirVoiture()
        {
            Console.Write("Entrez la plaque ou le numéro de place : ");

            string recherche = Console.ReadLine() ?? "";

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
                            recherche.Trim(),
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

            Console.WriteLine(
                $"Plaque : {voiture.GetMatricule()}");

            Console.WriteLine(
                $"Place : {numeroPlace}");

            Console.WriteLine("============================");

            Console.Write("\nVoulez-vous réellement sortir ? (O/N) : ");

            string confirmation = Console.ReadLine() ?? "";

            if (string.Equals(confirmation.Trim(),"O",StringComparison.OrdinalIgnoreCase))
            {
                int index = numeroPlace - 1;
                Ticket ticket = _tickets[index];
                ticket.EnregistrerSortie();
                ticket.Afficher();
                _historique.Add(ticket);

                _tickets[index] = null;
                _places[index] = null;

                Console.WriteLine(
                    $"\nLa place {numeroPlace} est maintenant libre.");
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
            Console.Write(
                "Entrez la plaque ou le numéro de place : ");

            string recherche = Console.ReadLine() ?? "";

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
                            recherche.Trim(),
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

            Console.WriteLine(
                "\n========== VÉHICULE TROUVÉ ==========");

            Console.WriteLine(
                $"Immatriculation : {voiture.GetMatricule()}");

            Console.WriteLine(
                $"N° place        : {numeroPlace}");

            Console.WriteLine("=====================================");
        }

        public void StatistiquesDuJour()
        {
            int placesOccupees = 0;
            int placesLibres = 0;

            TimeSpan dureeTotale = TimeSpan.Zero;

            decimal montantTotal = 0;

            int nombreVehiculesActuels = 0;


            for (int i = 0; i < PLACETOT; i++)
            {
                if (_places[i] != null)
                {
                    placesOccupees++;
                    nombreVehiculesActuels++;

                    if (_tickets[i] != null)
                    {
                        dureeTotale += _tickets[i].GetDuree();
                    }
                }
                else
                {
                    placesLibres++;
                }
            }


            foreach (Ticket ticket in _historique)
            {
                montantTotal += ticket.CalculerPrix();
            }


            double pourcentageOccupation =
                (double)placesOccupees / PLACETOT * 100;
            Console.WriteLine(
                $"Nombre total de places : {PLACETOT}");

            Console.WriteLine(
                $"Places occupées        : {placesOccupees}");

            Console.WriteLine(
                $"Places libres          : {placesLibres}");

            Console.WriteLine(
                $"Taux d'occupation      : {pourcentageOccupation:F2} %");

            Console.WriteLine(
                $"Véhicules actuellement présents : " +
                $"{nombreVehiculesActuels}");

            Console.WriteLine(
                $"Montant total payé     : " +
                $"{montantTotal:F2} CHF");

            Console.WriteLine(
                $"Durée totale actuelle  : " +
                $"{(int)dureeTotale.TotalHours}h " +
                $"{dureeTotale.Minutes}min");

            Console.WriteLine(
                $"Nombre de sorties      : {_historique.Count}");

            Console.WriteLine(
                "\n===========================================");
        }

        public void HistoriqueTickets()
        {
            if (_historique.Count == 0)
            {
                Console.WriteLine(
                    "Aucune transaction terminée pour le moment.");
                return;
            }
            foreach (Ticket ticket in _historique)
            {
                TimeSpan duree = ticket.GetDuree();



                Console.WriteLine("\n---------------- TRANSACTION ----------------");
                Console.WriteLine($"Heure d'arrivée : {ticket.GetArrivee():dd/MM/yyyy HH:mm:ss}");
                Console.WriteLine( $"Plaque : {ticket.GetPlaque()}");
                Console.WriteLine($"Place : {ticket.GetNumeroPlace()}");
                if (ticket.GetSortie() != null)
                {
                    Console.WriteLine("\nSORTIE");
                    Console.WriteLine($"Heure de sortie : {ticket.GetSortie():dd/MM/yyyy HH:mm:ss}");
                    Console.WriteLine($"Plaque : {ticket.GetPlaque()}");
                    Console.WriteLine($"Place : {ticket.GetNumeroPlace()}");
                    Console.WriteLine($"Durée : {(int)duree.TotalHours}h " + $"{duree.Minutes}min");
                    Console.WriteLine($"Montant payé : " + $"{ticket.CalculerPrix():F2} CHF");
                }
            }
            Console.WriteLine("\n==============================================================");
        }
    }
}


using System;

namespace P_320__lucpardo_parking
{
    internal class Ticket
    {
        private string _plaque;
        private int _numeroPlace;
        private DateTime _arrivee;
        private DateTime? _sortie;

        private const decimal TARIF_HORAIRE = 30;

        public Ticket(string plaque, int numeroPlace)
        {
            _plaque = plaque;
            _numeroPlace = numeroPlace;
            _arrivee = DateTime.Now;
            _sortie = null;
        }

        public void EnregistrerSortie()
        {
            _sortie = DateTime.Now;
        }

        public void Afficher()
        {
            Console.WriteLine("\n========== TICKET DE PARKING ==========");
            Console.WriteLine($"Plaque  : {_plaque}");
            Console.WriteLine($"Place   : {_numeroPlace}");
            Console.WriteLine($"Arrivée : {_arrivee:dd/MM/yyyy HH:mm:ss}");

            if (_sortie == null)
            {
                Console.WriteLine("Sortie  : En cours de stationnement");
                Console.WriteLine("Prix    : Non disponible");
            }
            else
            {
                TimeSpan duree = _sortie.Value - _arrivee;
                decimal prix = (decimal)duree.TotalHours * TARIF_HORAIRE;

                Console.WriteLine($"Sortie  : {_sortie.Value:dd/MM/yyyy HH:mm:ss}");
                Console.WriteLine($"Durée   : {(int)duree.TotalHours}h " + $"{duree.Minutes}min");
                Console.WriteLine($"Tarif   : {TARIF_HORAIRE:F2} CHF/heure");
                Console.WriteLine($"À payer : {prix:F2} CHF");
            }

            Console.WriteLine("========================================");
        }
        public decimal CalculerPrix()
        {
            if (_sortie == null)
            {
                return 0;
            }

            TimeSpan duree = _sortie.Value - _arrivee;

            return (decimal)duree.TotalHours * TARIF_HORAIRE;
        }
    }
}

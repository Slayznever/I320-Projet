
namespace P_320__lucpardo_parking
{
    internal class Voiture
    {
        private string _matricule;

        public Voiture(string matricule)
        {
            this._matricule = matricule;
        }

        public string GetMatricule()
        {
            return _matricule;
        }
    }
}

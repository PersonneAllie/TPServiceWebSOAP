using System;

namespace HotelAgenceDistribue
{
    public class Offre
    {
        public string idOffre;
        public TypeChambre numChambre;
        public DateTime deb;
        public DateTime fin;
        public double prixTotalOffre;


        public Offre()
        {

        }

        public Offre(string id, TypeChambre chambre, DateTime deb, DateTime fin, double prix)
        {
            idOffre = id;
            numChambre = chambre;
            this.deb = deb;
            this.fin = fin;
            prixTotalOffre = prix;

        }

        public override string ToString()
        {
            return "Référence de l'offre : " + idOffre + "\n -" + "Nombre de lits présent : " + numChambre.nbLits + "\n -" + deb + "\n -" + fin + "\n -" + prixTotalOffre;
        }
    }
}
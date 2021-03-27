using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelAgenceDistribue
{
    public class Offre
    {
        public string idOffre;
        public int numChambre;
        public DateTime deb;
        public DateTime fin;
        public double prixTotalOffre;


        public Offre()
        {

        }

        public Offre(string id, int chambre,DateTime deb, DateTime fin, double prix)
        {
            this.idOffre = id;
            this.numChambre = chambre;
            this.deb = deb;
            this.fin = fin;
            this.prixTotalOffre = prix;

        }

        public override string ToString()
        {
            return base.ToString() + "\n -" + this.idOffre + "\n -" + this.numChambre + "\n -" + this.deb + "\n -" + this.fin + "\n -" + this.prixTotalOffre;
        }
    }
}
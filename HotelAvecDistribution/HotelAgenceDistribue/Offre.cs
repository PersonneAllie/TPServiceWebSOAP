using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelAgenceDistribue
{
    public class Offre
    {
        public int idOffre;
        public Chambre offreChambre;
        public string dateOffre;
        public int prixTotalOffre;


        public Offre()
        {

        }

        public Offre(int id, Chambre chambre, string date, int prix)
        {
            this.idOffre = id;
            this.offreChambre = chambre;
            this.dateOffre = date;
            this.prixTotalOffre = prix;

        }

        public override string ToString()
        {
            return base.ToString() + "\n -" + this.idOffre + "\n -" + this.offreChambre + "\n -" + this.dateOffre + "\n -" + this.prixTotalOffre;
        }
    }
}
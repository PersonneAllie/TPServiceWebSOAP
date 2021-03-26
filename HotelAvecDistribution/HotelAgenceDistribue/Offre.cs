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
        public DateTime deb;
        public DateTime fin;
        public int prixTotalOffre;


        public Offre()
        {

        }

        public Offre(int id, Chambre chambre,DateTime deb, DateTime fin, int prix)
        {
            this.idOffre = id;
            this.offreChambre = chambre;
            this.deb = deb;
            this.fin = fin;
            this.prixTotalOffre = prix;

        }

        public override string ToString()
        {
            return base.ToString() + "\n -" + this.idOffre + "\n -" + this.offreChambre + "\n -" + this.deb + "\n -" + this.fin + "\n -" + this.prixTotalOffre;
        }
    }
}
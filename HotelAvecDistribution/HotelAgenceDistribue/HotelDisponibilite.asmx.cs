using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace HotelAgenceDistribue
{
    /// <summary>
    /// Description résumée de HotelDisponibilite
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    // [System.Web.Script.Services.ScriptService]
     public class HotelDisponibilite : System.Web.Services.WebService
    {
        private IFormatProvider culture = new CultureInfo("en-US", false);

        public Hotel hotelPasCher = new Hotel("IbisBudget","230 Avenue des roses","Montpellier","France",2,35);

        public Agence agenceChoisis = new Agence();
        public Agence agencePartenaire1 = new Agence(1, "Agence des Oliviers", "87 Route des eaux, Montpellier", (float)0.2, "loginAgence1", "admin");
        public Agence agencePartenaire2 = new Agence(2, "Agence des Roses", "187 Avenue des eaux, Anger", (float)0.1, "loginAgence2", "admin");

        public HotelDisponibilite()
        {
            agencePartenaire1.HotelPartenaire.Add(hotelPasCher);
            agencePartenaire2.HotelPartenaire.Add(hotelPasCher);
        }

        //Afficher les offres disponible
        [WebMethod]
        public List<Offre> AfficherOffreDisponible(int id, string login, string password,string dateArrive, string dateDepart,int nbPersonne)
        {
            List<Offre> testList = new List<Offre>();
           Offre testOffre = new Offre(1, new Chambre(0,3), "25/03/2021 to 27/03/2021", 230);
           testList.Add(testOffre);
           return testList;
        }
    }
}

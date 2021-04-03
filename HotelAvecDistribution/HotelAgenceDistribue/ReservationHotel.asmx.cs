using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace HotelAgenceDistribue
{
    /// <summary>
    /// Description résumée de ReservationHotel
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    // [System.Web.Script.Services.ScriptService]
    public class ReservationHotel : System.Web.Services.WebService
    {

        public Hotel hotelPasCher = new Hotel("IbisBudget", "230 Avenue des roses", "Montpellier", "France", 2, 35);

        public Agence agenceChoisis = new Agence();
        public Agence agencePartenaire1 = new Agence(1, "Agence des Oliviers", "87 Route des eaux, Montpellier", (float)0.2, "loginAgence1", "admin1");
        public Agence agencePartenaire2 = new Agence(2, "Agence des Roses", "187 Avenue des eaux, Anger", (float)0.1, "loginAgence2", "admin2");

        public TypeChambre chambre1 = new TypeChambre(0, 2);
        public TypeChambre chambre2 = new TypeChambre(1, 1);
        public TypeChambre chambre3 = new TypeChambre(2, 3);
        public TypeChambre chambre4 = new TypeChambre(3, 4);
        public TypeChambre chambre5 = new TypeChambre(4, 2);

        public Offre offreTest1 = new Offre("IbisBudget-1", new TypeChambre(0, 2), DateTime.ParseExact("03/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), DateTime.ParseExact("10/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), 40);
        public Offre offreTest2 = new Offre("IbisBudget-2", new TypeChambre(1, 1), DateTime.ParseExact("06/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), DateTime.ParseExact("10/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), 40);
        public Offre offreTest3 = new Offre("IbisBudget-3", new TypeChambre(2, 3), DateTime.ParseExact("03/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), DateTime.ParseExact("06/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), 90);
        public Offre offreTest4 = new Offre("IbisBudget-4", new TypeChambre(3, 4), DateTime.ParseExact("09/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), DateTime.ParseExact("13/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), 200);

        public List<Offre> listTemp = new List<Offre>();


        HotelDisponibilite hotel = new HotelDisponibilite();

        [WebMethod (EnableSession = true)]
        public Reservation faireReservation(string login, string password, string idOffre, string nomPersonne, string prenom, int numeroCB,int nbPersonne)
        {
            
            
            hotel.checkConnexion(login, password);
            Reservation resFinal = new Reservation();

                foreach (Offre x in hotel.listTemp)
                {
                    
                    if (x.idOffre == idOffre)
                    {
                        
                        Reservation res = new Reservation(nomPersonne, prenom, numeroCB, x.deb, x.fin, nbPersonne, x.prixTotalOffre);
                        resFinal = res;
                        //recherche la premiere chambre libre et fais la reservation 
                        //si elle n'existe pas/la reservation n'a pas pu etre effectuer renvoie null
                        TypeChambre chambre = hotel.hotelPasCher.Reserver(res);
                        return resFinal;
                    }
                }
            return resFinal;
            }

        }

}

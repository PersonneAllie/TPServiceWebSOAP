using System;
using System.Collections.Generic;
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

        HotelDisponibilite hotel = new HotelDisponibilite();

        [WebMethod]
        public Reservation faireReservation(string login, string password, string idOffre, string nomPersonne, string prenom, int numeroCB,int nbPersonne)
        {
            
           
            hotel.checkConnexion(login, password);
            Reservation resFinal = new Reservation();
            hotel.AfficherOffreDisponible(login, password, "27/03/2020", "30/03/2020", 2);

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
                    else
                    {
                        Console.WriteLine("Aucune offre correspond à cet id");
                        return resFinal;
                    }
                }
            return resFinal;
            }

        }

}

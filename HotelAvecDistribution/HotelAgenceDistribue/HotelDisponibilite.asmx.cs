using System;
using System.Collections.Generic;
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
     class HotelDisponibilite : System.Web.Services.WebService
    {

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

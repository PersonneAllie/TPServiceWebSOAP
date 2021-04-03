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
        public Agence agencePartenaire1 = new Agence(1, "Agence des Oliviers", "87 Route des eaux, Montpellier", (float)0.2, "loginAgence1", "admin1");
        public Agence agencePartenaire2 = new Agence(2, "Agence des Roses", "187 Avenue des eaux, Anger", (float)0.1, "loginAgence2", "admin2");

        public TypeChambre chambre1 = new TypeChambre(0, 2);
        public TypeChambre chambre2 = new TypeChambre(1, 1);
        public TypeChambre chambre3 = new TypeChambre(2, 3);
        public TypeChambre chambre4 = new TypeChambre(3, 4);
        public TypeChambre chambre5 = new TypeChambre(4, 2);

        public DateTime deb1 =  DateTime.ParseExact("03/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false));
        public DateTime fin1 = DateTime.ParseExact("10/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false));

        public DateTime deb2 = DateTime.ParseExact("06/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false));
        public DateTime fin2 = DateTime.ParseExact("13/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false));

        public Offre offreTest1 = new Offre("IbisBudget-1", new TypeChambre(0, 2), DateTime.ParseExact("03/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), DateTime.ParseExact("10/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), 40);
        public Offre offreTest2 = new Offre("IbisBudget-2", new TypeChambre(1, 1), DateTime.ParseExact("06/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), DateTime.ParseExact("10/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), 40);
        public Offre offreTest3 = new Offre("IbisBudget-3",new TypeChambre(2, 3), DateTime.ParseExact("03/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), DateTime.ParseExact("06/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), 90);
        public Offre offreTest4 = new Offre("IbisBudget-4", new TypeChambre(3, 4), DateTime.ParseExact("09/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), DateTime.ParseExact("13/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), 200);

        public List<Offre> listTemp = new List<Offre>();

        public HotelDisponibilite()
        {
            agencePartenaire1.HotelPartenaire.Add(hotelPasCher);
            agencePartenaire2.HotelPartenaire.Add(hotelPasCher);
            hotelPasCher.ListChambres.Add(chambre1);
            hotelPasCher.ListChambres.Add(chambre2);
            hotelPasCher.ListChambres.Add(chambre3);
            hotelPasCher.ListChambres.Add(chambre4);
            hotelPasCher.ListChambres.Add(chambre5);

            listTemp.Add(offreTest1);
            listTemp.Add(offreTest2);
            listTemp.Add(offreTest3);
            listTemp.Add(offreTest4);
        }

        //Afficher les offres disponible
        [WebMethod (EnableSession =true)]
        public List<Offre> AfficherOffreDisponible(string login, string password,string dateArrive, string dateDepart,int nbPersonne)
        {

            DateTime dt1 = DateTime.ParseExact(dateArrive, "dd/MM/yyyy", culture);
            DateTime dt2 = DateTime.ParseExact(dateDepart, "dd/MM/yyyy", culture);
            this.agenceChoisis =  checkConnexion(login, password);
            List<Offre> Listres = new List<Offre>();
            if (this.agenceChoisis != null)
            {
                Listres = listTemp;
                
            }
            else
            {
                Console.WriteLine("Désoler votre identification a échoué ! ");
            }

            return Listres;
        }

       

        public Agence checkConnexion(string log, string mdp)
        {
            if(log.Equals("loginAgence1") && mdp.Equals("admin1"))
            {
                Console.WriteLine("Agence 1 bien connecté ! ");
                this.agenceChoisis = this.agencePartenaire1;
                return agenceChoisis;
            }
            else if(log.Equals("loginAgence2") && mdp.Equals("admin2"))
            {
                Console.WriteLine("Agence 2 bien connecté ! ");
                this.agenceChoisis = this.agencePartenaire2;
                return agenceChoisis;
            }
            else
            {
                Console.WriteLine("Echec connexion ! ");
                this.agenceChoisis = null;
                return null;
            }
        }


        public void afficherOffre(List<Offre> list)
        {
            foreach(Offre x in list)
            {
                Console.WriteLine("- Id Offre : " + x.idOffre + "\n -" + " Chambre :" + x.numChambre + "\n -" + "Prix Total : " + x.prixTotalOffre + "(Prix base =" + hotelPasCher.prixNuit + " + commision Agence = " + agenceChoisis.commissionAgence + ")");
            }
        }


        public List<Offre> createOffre()
        {
            List<Offre> testList = new List<Offre>();
            Offre offreTemp = new Offre();
            float prix;
            Random r = new Random();
            DateTime deb = DateTime.ParseExact("03/04/2021", "dd/MM/yyyy", culture);
            DateTime fin = DateTime.ParseExact("10/04/2021", "dd/MM/yyyy", culture);


            foreach (TypeChambre i in hotelPasCher.ListChambres)
            {
                prix = hotelPasCher.prixNuit +  (hotelPasCher.prixNuit * agenceChoisis.commissionAgence);
                offreTemp = new Offre(hotelPasCher.nomHotel + r.Next(40), i,deb,fin, prix);
                testList.Add(offreTemp);
            }

            return testList;


        }


        
    }
}

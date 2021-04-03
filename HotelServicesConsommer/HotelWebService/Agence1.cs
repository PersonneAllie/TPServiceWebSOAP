using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelWebService
{
    class Agence1
    {
        private readonly static string login = "loginAgence1";
        private readonly static string mdp = "admin1";
        public static ServiceDisponibilite.HotelDisponibiliteSoapClient hotel = new ServiceDisponibilite.HotelDisponibiliteSoapClient();
        public static ServiceReservation.ReservationHotelSoapClient reservation = new ServiceReservation.ReservationHotelSoapClient();

        static void Main(string[] args)

        {
            string date1 = "06/04/2021";
            string date2 = "10/04/2021";
            int nbPersonnes;

            string nom;
            string prenom;
            int numeroCarte;
            string idOffre;

            List<ServiceDisponibilite.Offre> listOffres;
            ServiceDisponibilite.Offre[] tabOffres;

            Console.WriteLine("Bienvenue dans notre espace agence !");

            


            String cmd = "10";
            while (cmd != "0")
            {
                Console.WriteLine("Saisir le chiffre correspondant à la fonctionnalité désiré : 0 : Quittez l'application | 1 : Afficher les offres disponibles de notre agence | 2 : Sélectionnez votre offre et passez réservation");
                cmd = Console.ReadLine();
                switch (cmd)
                {
                    case "0":
                        Console.WriteLine("Aurevoir, bonne journée à vous !");
                        break;
                    case "1":
                        Console.WriteLine("Entrez le nombre de personnes : ");
                        nbPersonnes = Convert.ToInt32(Console.ReadLine());
                        tabOffres = hotel.AfficherOffreDisponible(login, mdp, date1, date2, nbPersonnes);

                        listOffres = new List<ServiceDisponibilite.Offre>(tabOffres);
                        foreach (ServiceDisponibilite.Offre x in listOffres)
                        {
                            Console.WriteLine("- Id Offre : " + x.idOffre + "\n -" + " Numéro Chambre :" + x.numChambre + "\n -" + "Prix Total : " + x.prixTotalOffre + "\n");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Veuillez entrez l'ID de l'offre choisis, votre nom, votre prénom, le nombre de personne et votre numéro de carte bancaire pour la réservation");
                        idOffre = Console.ReadLine();
                        nom = Console.ReadLine();
                        prenom = Console.ReadLine();
                        nbPersonnes = Convert.ToInt32(Console.ReadLine());
                        numeroCarte = Convert.ToInt32(Console.ReadLine());
                        ServiceReservation.Reservation test = new ServiceReservation.Reservation();
                        test = reservation.faireReservation(login, mdp, idOffre, nom, prenom, numeroCarte, nbPersonnes);
                        Console.WriteLine(test.nomClient + "\n - " + test.prenomClient + "\n - " + test.dateArrivee + "\n - " + test.dateDepart + "\n - " + "Prix total de votre réservation : " + test.prixTotal);
                        break;
                }
            }

            
        }
    }
}

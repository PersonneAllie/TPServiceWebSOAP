using System;
using System.Collections.Generic;
using System.Text;

namespace LogiqueMetierHotel
{
    class Reservation
    {
        public  static int idReservation = 0;
        public String nomClient;
        public String prenomClient;
        public DateTime dateArrivée;
        public DateTime dateDepart;
        public int numCarteBancaire;
        public int nbPersonne;
        public int numChambre;
        public int dureeSejour;

        public Reservation(String newNomClient, String newPrenomClient, int newNumCarteBancaire, int newNumChambre, DateTime newDateArrivée, DateTime newDateDepart, int newNbPersonne)
        {
            idReservation += 1;
            this.nomClient = newNomClient;
            this.prenomClient = newPrenomClient;
            this.dateArrivée = newDateArrivée;
            this.numChambre = newNumChambre;
            this.dateDepart = newDateDepart;
            this.numCarteBancaire = newNumCarteBancaire;
            this.nbPersonne = newNbPersonne;
            this.dureeSejour = (dateDepart - dateArrivée).Days;
        }

        public Reservation()
        {

        }

        public override string ToString()
        {
            return base.ToString() + "\n - " + this.nomClient + "\n - " + this.prenomClient + "\n - " + this.dateArrivée + "\n - " + this.dateDepart + "\n - " + this.numChambre;
        }

        public void reservationHotel(List<Hotel> resList,List<Hotel> baseList)
        {
            String nom;
            String nomPersonne;
            String prenom;
            int numeroCarte;
            int nbPersonne;
            DateTime dateArrivee;
            DateTime dateDepart;
            Console.WriteLine("Veuillez indiquer le nom de l'hotel que vous voulez sélectionnez");
            nom = Console.ReadLine();

            Console.WriteLine("Veuillez indiquez les informations suivantes pour que votre réservation soit prise en compte : Nom, Prénom, Numéro de carte bancaire, Nombre de personnes, Date d'arrivé et de départ");
            nomPersonne = Console.ReadLine();
            prenom = Console.ReadLine();
            numeroCarte = Convert.ToInt32(Console.ReadLine());
            nbPersonne = Convert.ToInt32(Console.ReadLine());
            dateArrivee = Convert.ToDateTime(Console.ReadLine());
            dateDepart = Convert.ToDateTime(Console.ReadLine());
            int num = 100;
            Hotel resHotel = new Hotel();
            foreach (Hotel x in baseList)
            {
                if(x.nomHotel.Equals(nom))
                {
                    resHotel = x;
                    num = x.chambreDisponible(dateArrivee, dateDepart, nbPersonne).numChambre;
                    Console.WriteLine(num);
                }
            }

            if (num != 100)
            {
                Reservation res = new Reservation(nomPersonne, prenom, numeroCarte, num, dateArrivee, dateDepart, nbPersonne);
                foreach (Hotel x in baseList)
                {
                    if (x.nomHotel.Equals(nom))
                    {
                        x.ListReservations.Add(res);
                        x.ToStringListReservation();
                    }
                }
                Console.WriteLine("Votre réservation a été effectué, à plus sous l'abri_bus");
            }
            else
            {
                Console.WriteLine("Désoler il n'y a pas de chambre disponible dans cet hotel pour vous, victime");
            }
        }

    }
}

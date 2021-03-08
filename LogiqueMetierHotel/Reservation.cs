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

    }
}

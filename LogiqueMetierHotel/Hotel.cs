using System;
using System.Collections.Generic;
using System.Text;

namespace LogiqueMetierHotel
{
    class Hotel
    {
        public static int idHotel = 0;
        public List<Reservation> ListReservations;
        public List<Chambre> ListChambres;
        public String nomHotel;
        public String adresseHotel;
        public String ville;
        public String paysHotel;
        public int nbEtoiles;
        public float prixNuit;

        public Hotel(String newNomHotel, String newAdresse, String newVille, String newPays, int nbEtoiles, float prix)
        {
            idHotel += 1;
            this.ListReservations = new List<Reservation>();
            this.ListChambres = new List<Chambre>();
            this.nomHotel = newNomHotel;
            this.adresseHotel = newAdresse;
            this.ville = newVille;
            this.paysHotel = newPays;
            this.nbEtoiles = nbEtoiles;
            this.prixNuit = prix;
        }


        public void ajoutReservation(Reservation r)
        {
            this.ListReservations.Add(r);
        }

        public void retraitReservation(Reservation r)
        {
            this.ListReservations.Remove(r);
        }

        public Chambre chambreDisponible(DateTime debut, DateTime fin, int nbLits)
        {
            foreach(Chambre x in this.ListChambres)
            {
                if(x.nbLits >= nbLits)
                {
                    return x;
                }
                else
                {
                    return x;
                }
            }
            return null;
        }

    }
}

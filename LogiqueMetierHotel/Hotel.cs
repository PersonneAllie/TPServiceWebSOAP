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
            if(DateTime.Now > r.dateDepart) { 
            this.ListReservations.Remove(r);
                }
        }

        public void InitChambre()
        {
            var rand = new Random();
            int numChambre = 0;
            int x = rand.Next(10, 40);
            for(int i = 0; i < x; i++)
            {
                int lits = rand.Next(1, 4);
                Chambre chambre = new Chambre(numChambre, lits);
                numChambre += 1;
                this.ListChambres.Add(chambre);

            }
        }

        public void afficherChambre()
        {
            foreach(Chambre x in this.ListChambres)
            {
                Console.WriteLine(x.ToString());
            }
        }

        public Chambre chambreDisponible(DateTime debut, DateTime fin, int nbLits)
        {
            foreach(Chambre x in this.ListChambres)
            {
                if(x.nbLits >= nbLits)
                {
                    return x;
                }
            }
          
            return null;
        }

        public override string ToString()
        {
            return base.ToString() + "\n - " + this.nomHotel + "\n - " + this.adresseHotel + "\n - " + this.ville + "\n - " + this.paysHotel + "\n - " + this.nbEtoiles + "\n - " + this.prixNuit;
        }
    }
}

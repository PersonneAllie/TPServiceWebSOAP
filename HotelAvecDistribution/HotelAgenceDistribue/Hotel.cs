using System;
using System.Collections.Generic;
using System.Text;

namespace HotelAgenceDistribue
{
    public class Hotel
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

        public Hotel()
        {

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

     /*   public Chambre chambreDisponible(DateTime debut, DateTime fin, int nbLits)
        {
            foreach(Chambre x in this.ListChambres)
            {
                if(x.nbLits >= nbLits)
                {
                    return x;
                }
            }
          
            return null;
        }*/

        public Chambre chambreDisponible(DateTime debut, DateTime fin, int nbLits)
        {
            foreach (Chambre x in this.ListChambres)
            {
                if (x.nbLits >= nbLits) //On trouve une chambre au nombre de lits convenable
                {
                    bool alwaysAvailable = true;
                    bool usedInTheTimeFrame = false;
                    foreach (Reservation y in this.ListReservations)
                    {
                        if (y.numChambre == x.numChambre)
                        {
                            alwaysAvailable = false; //la chambre est utilisé au moins une fois car elle est dans la liste
                            if ((y.dateArrivée >= debut & y.dateDepart <= fin)//cas 1 de reservation dans la période 
                                   | (y.dateArrivée < debut & y.dateDepart > fin)//cas 2 de reservation avant et et après la période 
                                   | (y.dateArrivée < debut & y.dateDepart <= fin)//cas 3 de reservation avant la période et qui se termine pendant
                                   | (y.dateArrivée >= debut & y.dateDepart < fin)//cas 4 de reservation pendant la période mais que se termine avant
                            )
                            {
                                usedInTheTimeFrame = true;
                            }
                        }
                    }
                    if (alwaysAvailable == true)//la chambre n'est jamais utilisé 
                    {
                        return x;
                    }

                    if (alwaysAvailable == false & usedInTheTimeFrame == false)//la chambre n'est jamais utilisé dans la période
                    {
                        return x;
                    }
                    //ici le cas echec donc on continue a parcourir la liste ce chambres de l'hotel
                }
            }
            return null; //l'hotel n'as pas de chambre ou on n'a rien trouvé
        }

        public override string ToString()
        {
            return base.ToString() + "\n - " + this.nomHotel + "\n - " + this.adresseHotel + "\n - " + this.ville + "\n - " + this.paysHotel + "\n - " + this.nbEtoiles + "\n - " + this.prixNuit;
        }

        public void ToStringListReservation()
        {
                foreach (Reservation z in this.ListReservations)
                {
                    Console.WriteLine(z.ToString());
                }
        }

      
    }
}

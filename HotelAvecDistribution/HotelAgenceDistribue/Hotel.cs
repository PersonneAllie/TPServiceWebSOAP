using System;
using System.Collections.Generic;

namespace HotelAgenceDistribue
{
    public class Hotel
    {
        public static int idHotel = 0;
        public List<TypeChambre> ListChambres;
        public String nomHotel;
        public String adresseHotel;
        public String ville;
        public String paysHotel;
        public int nbEtoiles;
        public float prixNuit;

        public Hotel(String newNomHotel, String newAdresse, String newVille, String newPays, int nbEtoiles, float prix)
        {
            idHotel += 1;
            ListChambres = new List<TypeChambre>();
            nomHotel = newNomHotel;
            adresseHotel = newAdresse;
            ville = newVille;
            paysHotel = newPays;
            this.nbEtoiles = nbEtoiles;
            prixNuit = prix;
        }

        public Hotel()
        {

            ListChambres = new List<TypeChambre>();
        }


        public void InitChambre()
        {
            var rand = new Random();
            int numChambre = 0;
            int x = rand.Next(10, 40);
            for (int i = 0; i < x; i++)
            {
                int lits = rand.Next(1, 4);
                TypeChambre chambre = new TypeChambre(numChambre, lits);
                numChambre += 1;
                ListChambres.Add(chambre);

            }
        }

        public void afficherChambre()
        {
            foreach (TypeChambre x in ListChambres)
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

        public TypeChambre chambreDisponible(DateTime debut, DateTime fin, int nbLits)
        {
            TypeChambre z = null;
            foreach (TypeChambre x in ListChambres)
            {
                //vérifie si la chambre est disponible
                if (x.estDisponible(debut, fin, nbLits))
                {
                    return x;
                }

            }
            //l'hotel n'as pas de chambre (vide) ou elles sont toute occupé pendant la période
            return z;
        }

        public TypeChambre Reserver(Reservation r)
        {
            TypeChambre chambre = chambreDisponible(r.dateArrivee, r.dateDepart, r.nbPersonne);
            TypeChambre z = null;
            if (chambre.Equals(z))
            {   //pas de chambre disponible
                return z;
            }
            else
            {
                chambre.ajoutReservation(r);
            }
            return chambre;

        }

        public override string ToString()
        {
            return base.ToString() + "\n - " + nomHotel + "\n - " + adresseHotel + "\n - " + ville + "\n - " + paysHotel + "\n - " + nbEtoiles + "\n - " + prixNuit;
        }



    }
}

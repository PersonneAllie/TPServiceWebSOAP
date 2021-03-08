using System;
using System.Collections.Generic;
using System.Text;

namespace LogiqueMetierHotel
{
    class Recherche
    {
        public static int idRecherche = 0;
        public String villeDeSejour;
        public DateTime DateArrivee;
        public DateTime DateDepart;
        public int intervallePrixBas;
        public int intervallePrixHaut;
        public int nbEtoilesVoulu;
        public int nbPersonnes;

        public Recherche(String newVilleDeSejour, DateTime newDateArrivee, DateTime newDateDepart, int newIntervalleBas, int newIntervalleHaut, int nbEtoiles, int nbPersonnes)
        {
            idRecherche += 1;
            this.villeDeSejour = newVilleDeSejour;
            this.DateArrivee = newDateArrivee;
            this.DateDepart = newDateDepart;
            this.intervallePrixBas = newIntervalleBas;
            this.intervallePrixHaut = newIntervalleHaut;
            this.nbEtoilesVoulu = nbEtoiles;
            this.nbPersonnes = nbPersonnes;

        }


    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace HotelAgenceDistribue
{
    public class TypeChambre
    {
        public int numChambre;
        public int nbLits;
        public List<Reservation> ListReservations = new List<Reservation>();

        public TypeChambre() { }
        public TypeChambre(int num, int nbLits)
        {
            this.numChambre = num;
            this.nbLits = nbLits;
            this.ListReservations = new List<Reservation>();
        }

        public void ajoutReservation(Reservation r)
        {
            this.ListReservations.Add(r);
        }

        public void retraitReservation(Reservation r)
        {
            if (DateTime.Now > r.dateDepart)
            {
                this.ListReservations.Remove(r);
            }
        }

        public void ToStringListReservation()
        {
            foreach (Reservation z in this.ListReservations)
            {
                Console.WriteLine(z.ToString());
            }
        }

        public bool estDisponible(DateTime debut, DateTime fin, int nbLits)
        {
            //ne rentre pas dans le critère
            if (this.nbLits <= nbLits)
            {
                return false;
            }

            //pas de réservation donc libre
            if (ListReservations.Count == 0)
            {
                return true;
            }

            else
            {
                foreach (Reservation r in this.ListReservations)
                {
                    DateTime dateDebut = r.dateArrivee;
                    DateTime dateFin = r.dateDepart;

                     bool occupee =((debut.CompareTo(dateDebut) >= 0 & fin.CompareTo(dateFin) <= 0)//cas 1 de reservation dans la période 
                                   | (debut.CompareTo(dateDebut) < 0 & fin.CompareTo(dateFin) > 0)//cas 2 de reservation avant et et après la période 
                                   | (debut.CompareTo(dateDebut) < 0 & fin.CompareTo(dateFin) <= 0)//cas 3 de reservation avant la période et qui se termine pendant
                                   | (debut.CompareTo(dateDebut) >= 0 & fin.CompareTo(dateFin) < 0)//cas 4 de reservation pendant la période mais que se termine avant
                                   );
                    //La chambre est occuper pendant la période
                    if (occupee)
                    {
                        return false;
                    }
                }
            }

            //le foreach n'a jamais trouvé de reservation qui gene;
            return true;
        }




        public override string ToString()
        {
            return "Numéro : " + this.numChambre + " | " + "Nombre de lits : " + this.nbLits;
        }
    }
}

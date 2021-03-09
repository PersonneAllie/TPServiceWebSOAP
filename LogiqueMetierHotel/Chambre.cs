using System;
using System.Collections.Generic;
using System.Text;

namespace LogiqueMetierHotel
{
    class Chambre
    {
        public int numChambre;
        public int nbLits;

        public Chambre(int num, int lits)
        {
            this.numChambre = num;
            this.nbLits = lits;
        }


        public override string ToString()
        {
            return "Numéro : " + this.numChambre + " | " + "Nombre de lits : " + this.nbLits;
        }
    }
}

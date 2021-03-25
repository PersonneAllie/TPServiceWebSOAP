using System;
using System.Collections.Generic;
using System.Text;

namespace LogiqueMetierHotel
{
    public class Client
    {
        public static int idClient = 0;
        public String nomClient;
        public String prenomClient;
        public String emailClient;
        public int numeroCarteBancaire;

        public Client(String newNomClient, String newPrenomClient, String newEmailClient, int newNumeroCarteBancaire)
        {
            idClient += 1;
            this.nomClient = newNomClient;
            this.prenomClient = newPrenomClient;
            this.emailClient = newEmailClient;
            this.numeroCarteBancaire = newNumeroCarteBancaire;
        }

        public Client()
        {

        }



    }
}

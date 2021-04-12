using System;

namespace HotelAgenceDistribue
{
    public class Client
    {
        public static int idClient = 0;
        public String nomClient;
        public String prenomClient;
        public int numeroCarteBancaire;

        public Client(String newNomClient, String newPrenomClient, int newNumeroCarteBancaire)
        {
            idClient += 1;
            nomClient = newNomClient;
            prenomClient = newPrenomClient;
            numeroCarteBancaire = newNumeroCarteBancaire;
        }

        public Client()
        {

        }



    }
}

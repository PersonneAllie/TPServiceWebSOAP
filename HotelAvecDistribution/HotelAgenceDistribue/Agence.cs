using System.Collections.Generic;

namespace HotelAgenceDistribue
{
    public class Agence
    {
        public int idAgence;
        public string nomAgence;
        public string adresse;
        public float commissionAgence;

        private string login;
        private string password;

        private List<Hotel> hotelPartenaire;
        private List<Client> clientAgence;


        public Agence(int id, string nom, string adresse, float com, string login, string password)
        {
            hotelPartenaire = new List<Hotel>();
            clientAgence = new List<Client>();
            idAgence = id;
            nomAgence = nom;
            this.adresse = adresse;
            commissionAgence = com;
            this.login = login;
            this.password = password;
        }

        public Agence()
        {
            hotelPartenaire = new List<Hotel>();
            clientAgence = new List<Client>();
        }


        public List<Hotel> HotelPartenaire { get => hotelPartenaire; set => hotelPartenaire = value; }
        public List<Client> ClientAgence { get => clientAgence; set => clientAgence = value; }
        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }
    }
}
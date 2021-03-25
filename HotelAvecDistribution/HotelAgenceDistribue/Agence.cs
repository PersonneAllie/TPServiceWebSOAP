using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelAgenceDistribue
{
    public class Agence
    {
        public int idAgence;
        public string nonAgence;
        public string adresse;
        public int commissionAgence;

        private string login;
        private string password;

        private List<Hotel> hotelPartenaire;
        private List<Client> clientAgence;


        public Agence()
        {
            this.hotelPartenaire = new List<Hotel>();
            this.clientAgence = new List<Client>();
        }


        public List<Hotel> HotelPartenaire { get => hotelPartenaire; set => hotelPartenaire = value; }
        public List<Client> ClientAgnece { get => clientAgence; set => clientAgence = value; }
        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }
    }
}
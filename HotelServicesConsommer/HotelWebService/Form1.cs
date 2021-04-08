using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelWebService
{
    public partial class Form1 : Form
    {
        private int prix = 0;
        private readonly static string login = "loginAgence1";
        private readonly static string mdp = "admin1";
        public Form1(ServiceDisponibilite.Offre f,String url, String info)
        {

            InitializeComponent();

            label1.Text = "Id de l'offre : " + f.idOffre;
            label2.Text = info;
            pictureBox1.Load(url);
            textBox1.Text = f.idOffre;
            label3.Text = "Prix total de l'offre : " + Convert.ToString(f.prixTotalOffre) + "€";
            prix = Convert.ToInt32(f.prixTotalOffre);
            label10.Text = "Date de disponibilité : " + "\n" + "Arriver : " +  f.deb.ToString("dd/MM/yyyy") + "\n" + "Départ : "  + f.fin.ToString("dd/MM/yyyy");
            ServiceDisponibilite.Hotel infoHotel = Agence1.hotel.getHotel();
            label11.Text = "Nom de l'hotel : " + infoHotel.nomHotel + "\n" + "Adresse : " + infoHotel.adresseHotel + "\n" + "Etoiles : " + infoHotel.nbEtoiles + "\n" + "Prix nuit/personne : " + infoHotel.prixNuit;
            label12.Text = "Cette offre vous plaît ?  " + "\n" + "Remplissez notre formulaire" + "\n" +  "de réservation : ";

        }

        public Form1()
        {

            InitializeComponent();

        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string id = this.textBox1.Text;
            string nom = this.textBox2.Text;
            string prenom = this.textBox4.Text;
            int NbPersonnes = Convert.ToInt32(this.textBox3.Text);
            int cb = Convert.ToInt32(this.textBox5.Text);
            ServiceDisponibilite.Reservation test = new ServiceDisponibilite.Reservation();
            test = Agence1.hotel.faireReservation(login, mdp, id, nom, prenom, cb, NbPersonnes);
            MessageBox.Show("Nom de réservation : " + test.nomClient + " " + test.prenomClient + "\n - " + "Date d'arrivée : " + test.dateArrivee.ToString("dd/MM/yyyy") + "\n - " + "Date de départ : " + test.dateDepart.ToString("dd/MM/yyyy") + "\n - " + "Prix total de votre réservation : " + prix);
            this.Close();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Reset_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Globalization;
using System.Windows.Forms;

namespace HotelWebService
{
    class Agence1
    {
        private readonly static string login = "loginAgence1";
        private readonly static string mdp = "admin1";
        public static ServiceDisponibilite.HotelDisponibiliteSoapClient hotel = new ServiceDisponibilite.HotelDisponibiliteSoapClient();

        public static Image byteArrayToImage(byte[] bytesArr)
        {
            using (MemoryStream memstr = new MemoryStream(bytesArr))
            {
                Image img = Image.FromStream(memstr);
                return img;
            }
        }

        static void Main(string[] args)

        {

            string date1 = "06/04/2021";
            string date2 = "10/04/2021";
            int nbPersonnes;

            string nom;
            string prenom;
            int numeroCarte;
            string idOffre;

            List<ServiceDisponibilite.Offre> listOffres;
            ServiceDisponibilite.Offre[] tabOffres;

            Console.WriteLine("Bienvenue dans notre espace agence !");

            DateTime dt;
            //DateTime dD;
            //DateTime dF;
            //String dateD;
            //String dateF;

            String cmd = "10";
            while (cmd != "0")
            {
                Console.WriteLine("Saisir le chiffre correspondant à la fonctionnalité désiré :" + "\n" + "0 : Quittez l'application" + "\n" + "1 : Afficher les offres disponibles de notre agence (sans image)" + "\n" + "2 : Afficher les offres disponible de notre agence (avec image téléchargez : vérifiez le PATH)" + "\n" + "3 : Afficher les offres disponible de notre agence selon vos dates (avec GUI)" + "\n" + "4 : Afficher toutes les offres disponible (avec GUI)" + "\n" + "5 : Sélectionnez votre offre et passez réservation");
                cmd = Console.ReadLine();
                switch (cmd)
                {
                    case "0":
                        Console.WriteLine("Aurevoir, bonne journée à vous !");
                        break;
                    case "1":
                        Console.WriteLine("Entrez le nombre de personnes : ");
                        nbPersonnes = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Entrez la date de debut au format dd/mm/yyyy : ");
                        String dateD = Convert.ToString(Console.ReadLine());
                        while (!DateTime.TryParseExact(dateD, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
                        {
                            Console.WriteLine("Réessayez");
                            dateD = Convert.ToString(Console.ReadLine());
                        }
                        Console.WriteLine("Entrez la date de fin au format dd/mm/yyyy : ");
                        String dateF = Convert.ToString(Console.ReadLine());
                        while (!DateTime.TryParseExact(dateF, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
                        {
                            Console.WriteLine("Réessayez");
                            dateF = Convert.ToString(Console.ReadLine());
                        }
                        DateTime dD = DateTime.ParseExact(dateD, "dd/MM/yyyy", new CultureInfo("en-US", false));
                        DateTime dF = DateTime.ParseExact(dateF, "dd/MM/yyyy", new CultureInfo("en-US", false));
                        if (dD > dF)
                        {
                            Console.WriteLine("Inversion des dates");
                            DateTime tmp = dD;
                            dD = dF;
                            dF = tmp;
                        }

                        tabOffres = hotel.AfficherOffreDisponible(login, mdp, date1, date2, nbPersonnes);
                        listOffres = new List<ServiceDisponibilite.Offre>(tabOffres);
                        foreach (ServiceDisponibilite.Offre x in listOffres)
                        {
                            if (x.deb <= dD && x.fin >= dF && x.numChambre.nbLits >= nbPersonnes)
                                Console.WriteLine("- Id Offre (pour votre réservation) : " + x.idOffre + "\n -" + " Numéro Chambre et nombre de lits : " + x.numChambre.numChambre + " | " + x.numChambre.nbLits + " lits" + "\n -" + "Prix Total : " + x.prixTotalOffre + "\n");
                        }
                        break;

                    case "2":

                        Console.WriteLine("Entrez le nombre de personnes : ");
                        nbPersonnes = Convert.ToInt32(Console.ReadLine());
                        tabOffres = hotel.AfficherOffreDisponibleAvecImage(login, mdp, date1, date2, nbPersonnes);
                        listOffres = new List<ServiceDisponibilite.Offre>(tabOffres);
                        foreach (ServiceDisponibilite.Offre x in listOffres)
                        {
                            if (x.deb <= DateTime.ParseExact(date1, "dd/MM/yyyy", new CultureInfo("en-US", false)) && x.fin >= DateTime.ParseExact(date2, "dd/MM/yyyy", new CultureInfo("en-US", false)) && x.numChambre.nbLits >= nbPersonnes)
                            {
                                Console.WriteLine("- Id Offre (pour votre réservation) : " + x.idOffre + "\n -" + " Numéro Chambre et nombre de lits : " + "Numéro : " + x.numChambre.numChambre + " | " + x.numChambre.nbLits + " lits" + "\n -" + "Prix Total : " + x.prixTotalOffre + "\n");
                                Image image = byteArrayToImage(x.numChambre.image);
                                image.Save(x.idOffre + "_PhotoChambre.png", ImageFormat.Png);
                            }
                        }
                        break;
                    case "3":
                        Console.WriteLine("Entrez le nombre de personnes : ");
                        nbPersonnes = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Entrez la date de debut au format dd/mm/yyyy : ");
                        dateD = Convert.ToString(Console.ReadLine());
                        while (!DateTime.TryParseExact(dateD, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
                        {
                            Console.WriteLine("Réessayez");
                            dateD = Convert.ToString(Console.ReadLine());
                        }
                        Console.WriteLine("Entrez la date de fin au format dd/mm/yyyy : ");
                        dateF = Convert.ToString(Console.ReadLine());
                        while (!DateTime.TryParseExact(dateF, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
                        {
                            Console.WriteLine("Réessayez");
                            dateF = Convert.ToString(Console.ReadLine());
                        }
                        dD = DateTime.ParseExact(dateD, "dd/MM/yyyy", new CultureInfo("en-US", false));
                        dF = DateTime.ParseExact(dateF, "dd/MM/yyyy", new CultureInfo("en-US", false));
                        if (dD > dF)
                        {
                            Console.WriteLine("Inversion des dates");
                            DateTime tmp = dD;
                            dD = dF;
                            dF = tmp;
                        }

                        tabOffres = hotel.AfficherOffreDisponibleGUI(login, mdp, date1, date2, nbPersonnes);
                        listOffres = new List<ServiceDisponibilite.Offre>(tabOffres);
                        Console.WriteLine("Notre système de GUI va bientôt apparaitre, veuillez patientez");
                        foreach (ServiceDisponibilite.Offre x in listOffres)
                        {
                            if (x.deb <= dD && x.fin >= dF && x.numChambre.nbLits >= nbPersonnes)
                            {
                                String info = " Photo de la chambre (ci-dessous) et Nombre de lits : " + x.numChambre.nbLits + " lits";
                                Form1 form = new Form1(x, x.numChambre.imageURL, info);
                                form.ShowDialog();
                            }

                        }
                        break;
                    case "4":

                        Console.WriteLine("Entrez le nombre de personnes : ");
                        nbPersonnes = Convert.ToInt32(Console.ReadLine());
                        tabOffres = hotel.AfficherOffreDisponibleGUI(login, mdp, date1, date2, nbPersonnes);
                        listOffres = new List<ServiceDisponibilite.Offre>(tabOffres);
                        Console.WriteLine("Notre système de GUI va bientôt apparaitre, veuillez patientez");
                        foreach (ServiceDisponibilite.Offre x in listOffres)
                        {

                            String info = " Photo de la chambre (ci-dessous) et Nombre de lits : " + x.numChambre.nbLits + " lits";
                            Form1 form = new Form1(x, x.numChambre.imageURL, info);
                            form.ShowDialog();

                        }
                        break;
                    case "5":
                        Console.WriteLine("Veuillez entrez l'ID de l'offre choisis, votre nom, votre prénom, le nombre de personne et votre numéro de carte bancaire pour la réservation");
                        idOffre = Console.ReadLine();
                        nom = Console.ReadLine();
                        prenom = Console.ReadLine();
                        nbPersonnes = Convert.ToInt32(Console.ReadLine());
                        numeroCarte = Convert.ToInt32(Console.ReadLine());
                        ServiceDisponibilite.Reservation test = new ServiceDisponibilite.Reservation();
                        test = hotel.faireReservation(login, mdp, idOffre, nom, prenom, numeroCarte, nbPersonnes);
                        Console.WriteLine("Nom de réservation : " + test.nomClient + " " + test.prenomClient + "\n - " + "Date d'arrivée : " + test.dateArrivee + "\n - " + "Date de départ : " + test.dateDepart + "\n - " + "Prix total de votre réservation : " + test.prixTotal);
                        break;
                }
            }




        }
    }
}

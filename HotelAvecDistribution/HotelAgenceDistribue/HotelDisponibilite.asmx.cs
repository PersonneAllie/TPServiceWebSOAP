using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.IO;
using System.Web.Services;

namespace HotelAgenceDistribue
{
    /// <summary>
    /// Description résumée de HotelDisponibilite
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    // [System.Web.Script.Services.ScriptService]
    public class HotelDisponibilite : System.Web.Services.WebService
    {

        private IFormatProvider culture = new CultureInfo("en-US", false);


        /// <summary>
        ///  J'ai supprimé tes initialisations static ci dessous par d'autre dans depuis la bdd dans le constructeur.
        ///  Il faudrait que tu fasse une méthode pour update la bdd avec des requetes du style "Update Hotel ..."
        ///  Comme ça, le constructeur récupère toujours la dernière version.
        ///  Si jamais tu veux refaire un truc propre, tu supprime le fichier database.db
        ///  le createDatabase() se charge de le refaire... c'est fait salement mais au moins tu a une bdd XD !
        /// </summary>

        public static string path = @"E:\github.com\PersonneAllie-TPServiceWebSOAP\assets\";
        public static string DB_NAME_FILENAME = "database.db";
        public static string DB_INSERT_FILENAME = "insert.sql";
        public static string DB_CREATE_FILENAME = "drop_create.sql";
        public static string pathDB_NAME_FILENME = path + DB_NAME_FILENAME;
        private static string dataSource = @"Data Source=" + pathDB_NAME_FILENME;
        private static SQLiteConnection myConnection = new SQLiteConnection(dataSource);


        public Agence agenceChoisis = new Agence();

        public Hotel hotelPasCher;

        public Agence agencePartenaire1;
        public Agence agencePartenaire2;

        public TypeChambre chambre1;
        public TypeChambre chambre2;
        public TypeChambre chambre3;
        public TypeChambre chambre4;
        public TypeChambre chambre5;

        public DateTime deb1 = DateTime.ParseExact("03/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false));
        public DateTime fin1 = DateTime.ParseExact("10/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false));

        public DateTime deb2 = DateTime.ParseExact("06/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false));
        public DateTime fin2 = DateTime.ParseExact("13/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false));

        public Offre offreTest1 = new Offre("IbisBudget-1", new TypeChambre(0, 2, path + "chambre1.png"), DateTime.ParseExact("03/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), DateTime.ParseExact("10/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), 40);
        public Offre offreTest2 = new Offre("IbisBudget-2", new TypeChambre(1, 1, path + "chambre2.png"), DateTime.ParseExact("06/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), DateTime.ParseExact("10/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), 40);
        public Offre offreTest3 = new Offre("IbisBudget-3", new TypeChambre(2, 3, path + "chambre2.png"), DateTime.ParseExact("03/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), DateTime.ParseExact("06/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), 90);
        public Offre offreTest4 = new Offre("IbisBudget-4", new TypeChambre(3, 4, path + "chambre1.png"), DateTime.ParseExact("09/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), DateTime.ParseExact("13/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), 200);

        public Offre offreGUI1 = new Offre("IbisBudget-1", new TypeChambre(0, 2, "https://lemistral.eu/wp-content/uploads/quintuple/chambre-quintuple-chambre-3-lits-768x432.jpg", ""), DateTime.ParseExact("03/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), DateTime.ParseExact("10/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), 40);
        public Offre offreGUI2 = new Offre("IbisBudget-2", new TypeChambre(1, 1, "https://www.usine-digitale.fr/mediatheque/3/9/8/000493893_homePageUne/hotel-c-o-q-paris.jpg", ""), DateTime.ParseExact("06/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), DateTime.ParseExact("10/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), 40);
        public Offre offreGUI3 = new Offre("IbisBudget-3", new TypeChambre(2, 3, "https://media-cdn.tripadvisor.com/media/photo-s/09/75/9f/d5/mariafe-inn.jpg", ""), DateTime.ParseExact("03/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), DateTime.ParseExact("06/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), 90);
        public Offre offreGUI4 = new Offre("IbisBudget-4", new TypeChambre(3, 4, "https://www.vendee-hotel-restaurant.com/wp-content/uploads/2014/10/IMG_9063-700x467.jpg", ""), DateTime.ParseExact("09/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), DateTime.ParseExact("13/04/2021", "dd/MM/yyyy", new CultureInfo("en-US", false)), 200);

        public List<Offre> listTemp = new List<Offre>();
        public List<Offre> listTempGUI = new List<Offre>();

        public HotelDisponibilite()
        {
            routineInitDatabase();

            hotelPasCher = GetHotelFromDB(0);

            agencePartenaire1 = GetAgenceFromDB(1);
            agencePartenaire2 = GetAgenceFromDB(2);

            chambre1 = GetTypeChambreFromDB(0);
            chambre2 = GetTypeChambreFromDB(1);
            chambre3 = GetTypeChambreFromDB(2);
            chambre4 = GetTypeChambreFromDB(3);
            chambre5 = GetTypeChambreFromDB(4);


            agencePartenaire1.HotelPartenaire.Add(hotelPasCher);
            agencePartenaire2.HotelPartenaire.Add(hotelPasCher);
            hotelPasCher.ListChambres.Add(chambre1);
            hotelPasCher.ListChambres.Add(chambre2);
            hotelPasCher.ListChambres.Add(chambre3);
            hotelPasCher.ListChambres.Add(chambre4);
            hotelPasCher.ListChambres.Add(chambre5);

            listTemp.Add(offreTest1);
            listTemp.Add(offreTest2);
            listTemp.Add(offreTest3);
            listTemp.Add(offreTest4);

            offreTest1.prixTotalOffre = Convert.ToInt32((offreTest1.fin - offreTest1.deb).TotalDays * (hotelPasCher.prixNuit + (agencePartenaire1.commissionAgence * hotelPasCher.prixNuit)));
            offreTest2.prixTotalOffre = Convert.ToInt32((offreTest2.fin - offreTest2.deb).TotalDays * (hotelPasCher.prixNuit + (agencePartenaire1.commissionAgence * hotelPasCher.prixNuit)));
            offreTest3.prixTotalOffre = Convert.ToInt32((offreTest3.fin - offreTest3.deb).TotalDays * (hotelPasCher.prixNuit + (agencePartenaire1.commissionAgence * hotelPasCher.prixNuit)));
            offreTest4.prixTotalOffre = Convert.ToInt32((offreTest4.fin - offreTest4.deb).TotalDays * (hotelPasCher.prixNuit + (agencePartenaire1.commissionAgence * hotelPasCher.prixNuit)));

            offreGUI1.prixTotalOffre = Convert.ToInt32((offreGUI1.fin - offreGUI1.deb).TotalDays * (hotelPasCher.prixNuit + (agencePartenaire1.commissionAgence * hotelPasCher.prixNuit)));
            offreGUI2.prixTotalOffre = Convert.ToInt32((offreGUI2.fin - offreGUI2.deb).TotalDays * (hotelPasCher.prixNuit + (agencePartenaire1.commissionAgence * hotelPasCher.prixNuit)));
            offreGUI3.prixTotalOffre = Convert.ToInt32((offreGUI3.fin - offreGUI3.deb).TotalDays * (hotelPasCher.prixNuit + (agencePartenaire1.commissionAgence * hotelPasCher.prixNuit)));
            offreGUI4.prixTotalOffre = Convert.ToInt32((offreGUI4.fin - offreGUI4.deb).TotalDays * (hotelPasCher.prixNuit + (agencePartenaire1.commissionAgence * hotelPasCher.prixNuit)));

            listTempGUI.Add(offreGUI1);
            listTempGUI.Add(offreGUI2);
            listTempGUI.Add(offreGUI3);
            listTempGUI.Add(offreGUI4);

        }

        private void routineInitDatabase()
        {
            OpenConnection();
            if (!File.Exists(pathDB_NAME_FILENME))
            {
                SQLiteConnection.CreateFile(pathDB_NAME_FILENME);
            }
            OpenConnection();
            createDatabase();
        }

        //Afficher les offres disponible
        [WebMethod(EnableSession = true)]
        public List<Offre> AfficherOffreDisponible(string login, string password, string dateArrive, string dateDepart, int nbPersonne)
        {

            DateTime dt1 = DateTime.ParseExact(dateArrive, "dd/MM/yyyy", culture);
            DateTime dt2 = DateTime.ParseExact(dateDepart, "dd/MM/yyyy", culture);
            agenceChoisis = checkConnexion(login, password);
            List<Offre> Listres = new List<Offre>();
            if (agenceChoisis != null)
            {

                Listres = listTemp;

            }
            else
            {
                Console.WriteLine("Désoler votre identification a échoué ! ");
            }

            return Listres;
        }

        //Afficher les offres disponible
        [WebMethod(EnableSession = true)]
        public List<Offre> AfficherOffreDisponibleAvecImage(string login, string password, string dateArrive, string dateDepart, int nbPersonne)
        {

            DateTime dt1 = DateTime.ParseExact(dateArrive, "dd/MM/yyyy", culture);
            DateTime dt2 = DateTime.ParseExact(dateDepart, "dd/MM/yyyy", culture);
            agenceChoisis = checkConnexion(login, password);
            List<Offre> Listres = new List<Offre>();
            if (agenceChoisis != null)
            {
                Listres = listTemp;

            }
            else
            {
                Console.WriteLine("Désoler votre identification a échoué ! ");
            }

            return Listres;
        }





        //Afficher les offres disponible
        [WebMethod(EnableSession = true)]
        public List<Offre> AfficherOffreDisponibleGUI(string login, string password, string dateArrive, string dateDepart, int nbPersonne)
        {

            DateTime dt1 = DateTime.ParseExact(dateArrive, "dd/MM/yyyy", culture);
            DateTime dt2 = DateTime.ParseExact(dateDepart, "dd/MM/yyyy", culture);
            agenceChoisis = checkConnexion(login, password);
            List<Offre> Listres = new List<Offre>();
            if (agenceChoisis != null)
            {

                Listres = listTempGUI;

            }
            else
            {
                Console.WriteLine("Désoler votre identification a échoué ! ");
            }

            return Listres;
        }


        public Agence checkConnexion(string log, string mdp)
        {
            if (log.Equals("loginAgence1") && mdp.Equals("admin1"))
            {
                Console.WriteLine("Agence 1 bien connecté ! ");
                agenceChoisis = agencePartenaire1;
                return agenceChoisis;
            }
            else if (log.Equals("loginAgence2") && mdp.Equals("admin2"))
            {
                Console.WriteLine("Agence 2 bien connecté ! ");
                agenceChoisis = agencePartenaire2;
                return agenceChoisis;
            }
            else
            {
                Console.WriteLine("Echec connexion ! ");
                agenceChoisis = null;
                return null;
            }
        }

        [WebMethod(EnableSession = true)]
        public Hotel getHotel()
        {
            return hotelPasCher;
        }


        public void afficherOffre(List<Offre> list)
        {
            foreach (Offre x in list)
            {
                Console.WriteLine("- Id Offre : " + x.idOffre + "\n -" + " Chambre :" + x.numChambre + "\n -" + "Prix Total : " + x.prixTotalOffre + "(Prix base =" + hotelPasCher.prixNuit + " + commision Agence = " + agenceChoisis.commissionAgence + ")");
            }
        }


        public List<Offre> createOffre()
        {
            List<Offre> testList = new List<Offre>();
            Offre offreTemp = new Offre();
            float prix;
            Random r = new Random();
            DateTime deb = DateTime.ParseExact("03/04/2021", "dd/MM/yyyy", culture);
            DateTime fin = DateTime.ParseExact("10/04/2021", "dd/MM/yyyy", culture);


            foreach (TypeChambre i in hotelPasCher.ListChambres)
            {
                prix = hotelPasCher.prixNuit + (hotelPasCher.prixNuit * agenceChoisis.commissionAgence);
                offreTemp = new Offre(hotelPasCher.nomHotel + r.Next(40), i, deb, fin, prix);
                testList.Add(offreTemp);
            }

            return testList;


        }

        [WebMethod(EnableSession = true)]
        public Reservation faireReservation(string login, string password, string idOffre, string nomPersonne, string prenom, int numeroCB, int nbPersonne)
        {


            checkConnexion(login, password);
            Reservation resFinal = new Reservation();

            foreach (Offre x in listTemp)
            {

                if (x.idOffre == idOffre)
                {

                    Reservation res = new Reservation(nomPersonne, prenom, numeroCB, x.deb, x.fin, nbPersonne, x.prixTotalOffre);
                    resFinal = res;
                    Client temp = new Client(nomPersonne, prenom, numeroCB);
                    agenceChoisis.ClientAgence.Add(temp);
                    //recherche la premiere chambre libre et fais la reservation 
                    //si elle n'existe pas/la reservation n'a pas pu etre effectuer renvoie null
                    TypeChambre chambre = hotelPasCher.Reserver(res);
                    return resFinal;
                }
            }
            return resFinal;
        }

        public static void OpenConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Open)
            {
                myConnection.Open();
            }
        }
        public static void CloseConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Closed)
            {
                myConnection.Close();
            }
        }
        private static void createDatabase()
        {
            string createTables = File.ReadAllText(path + DB_CREATE_FILENAME);
            string insertRows = File.ReadAllText(path + DB_INSERT_FILENAME);
            SQLiteCommand command = new SQLiteCommand(createTables, myConnection);
            command.ExecuteNonQuery();
            command = new SQLiteCommand(insertRows, myConnection);
            command.ExecuteNonQuery();
        }
        public static Hotel GetHotelFromDB(int identifiant)
        {
            Hotel hotelARetourner = new Hotel();
            SQLiteCommand command;
            SQLiteDataReader dataReader;
            string sql = "SELECT * FROM Hotel H WHERE H.idHotel = " + identifiant.ToString();
            command = new SQLiteCommand(sql, myConnection);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                hotelARetourner.nomHotel = dataReader.GetString(1);
                hotelARetourner.adresseHotel = dataReader.GetString(2);
                hotelARetourner.ville = dataReader.GetString(3);
                hotelARetourner.paysHotel = dataReader.GetString(4);
                hotelARetourner.nbEtoiles = dataReader.GetInt32(5);
                hotelARetourner.prixNuit = dataReader.GetFloat(6);
            }
            dataReader.Close();
            return hotelARetourner;
        }

        private static TypeChambre GetTypeChambreFromDB(int identifiant)
        {
            TypeChambre typeChambreARetourner = new TypeChambre();
            SQLiteCommand command;
            SQLiteDataReader dataReader;
            string sql = "SELECT * FROM TypeChambre TC WHERE TC.numChambre = " + identifiant.ToString();
            command = new SQLiteCommand(sql, myConnection);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                typeChambreARetourner.numChambre = dataReader.GetInt32(0);
                typeChambreARetourner.nbLits = dataReader.GetInt32(1);
                typeChambreARetourner.imageURL = dataReader.GetString(2);
                typeChambreARetourner.image = typeChambreARetourner.StreamToByteArray(typeChambreARetourner.imageURL);
            }
            dataReader.Close();
            return typeChambreARetourner;
        }
        private static Agence GetAgenceFromDB(int identifiant)
        {

            Agence agenceARetourner = new Agence();
            SQLiteCommand command;
            SQLiteDataReader dataReader;
            string sql = "SELECT * FROM Agence A WHERE A.idAgence = " + identifiant.ToString();
            command = new SQLiteCommand(sql, myConnection);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                agenceARetourner.idAgence = dataReader.GetInt32(0);
                agenceARetourner.nomAgence = dataReader.GetString(1);
                agenceARetourner.adresse = dataReader.GetString(2);
                agenceARetourner.commissionAgence = dataReader.GetFloat(3);
                agenceARetourner.Login = dataReader.GetString(4);
                agenceARetourner.Password = dataReader.GetString(5);
            }

            dataReader.Close();

            return agenceARetourner;
        }

    }
}

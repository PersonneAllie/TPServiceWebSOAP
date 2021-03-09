using System;

namespace LogiqueMetierHotel
{
    class Program
    {

        static void Main(string[] args)
        {
            Client Denis = new Client("Beauget", "Denis", "denis.beauget@etu.umontpellier.fr", 123456789);
            Client Hayaat = new Client("Hebiret", "Hayaat", "hayaat.hebiret@etu.umontpelier.fr", 123456789);

            Hotel ibis = new Hotel("Ibis", "2220 Avenue du pigeon", "Montpellier", "France", 2, 45);
            Hotel richou = new Hotel("ArgentPlus", "450 Route du Gange", "Paris", "France", 4, 130);
            Hotel FormuleE = new Hotel("BipCoyote", "700 Chemin du lapin", "Madrid", "Espagne", 1, 19);


            Console.WriteLine(ibis);
            ibis.InitChambre();
            ibis.afficherChambre();

            Console.WriteLine(richou);
            richou.InitChambre();
            richou.afficherChambre();

            Console.WriteLine(FormuleE);
            FormuleE.InitChambre();
            FormuleE.afficherChambre();
        }
    }
}

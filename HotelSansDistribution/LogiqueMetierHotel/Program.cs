﻿using System;
using System.Collections.Generic;

namespace LogiqueMetierHotel
{
    class Program
    {

        static void Main(string[] args)
        {


            Hotel ibis = new Hotel("Ibis", "2220 Avenue du pigeon", "Montpellier", "France", 2, 45);
            Hotel richou = new Hotel("ArgentPlus", "450 Route du Gange", "Paris", "France", 4, 130);
            Hotel FormuleE = new Hotel("BipCoyote", "700 Chemin du lapin", "Madrid", "Espagne", 1, 19);

            List<Hotel> baseList = new List<Hotel>();
            baseList.Add(ibis);
            baseList.Add(richou);
            baseList.Add(FormuleE);


            List<Hotel> research = baseList;






            Console.WriteLine(ibis);
            ibis.InitChambre();
            ibis.afficherChambre();

            Console.WriteLine(richou);
            richou.InitChambre();
            richou.afficherChambre();

            Console.WriteLine(FormuleE);
            FormuleE.InitChambre();
            FormuleE.afficherChambre();


            String cmd = "10";
            while (cmd != "0")
            {
                Console.WriteLine("Saisir le chiffre correspondant à la fonctionnalité désiré :" + "\n" +  "0 : Quittez l'application" + "\n" + "1 : Faire une recherche " + "\n" + "2 : Sélectionnez votre Hotel et passez réservation");
                cmd = Console.ReadLine();
                switch (cmd)
                {
                    case "0":
                        Console.WriteLine("Aurevoir, bonne journée à vous !");
                        break;
                    case "1":
                        Recherche x = new Recherche();
                        x.ToStringList(research);
                        x.rechercheHotel(research);
                        break;
                    case "2":
                        Reservation y = new Reservation();
                        y.reservationHotel(research,baseList);
                        research = baseList;
                        break;
                }
            }
        }
    }
}

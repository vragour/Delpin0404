﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class DBController
    {
        DBManager connection = new DBManager();

        public List<Ressource> ressources = new List<Ressource>();
        public List<DebitorObj> debitor = new List<DebitorObj>();
        public List<AfdRessObj> afdRessObjs = new List<AfdRessObj>();

        public void HentAllFrieRessourcer(string startdate, string slutdate)
        {
            ressources = connection.FindAlleFrieRessourcer(startdate, slutdate);
        }

        public void FindLedigeResourcerForAfdeling( )//USE CASE: U1 / U2
        {
            /*Populate the List with Database Elements and let the controller keep the list*/
            afdRessObjs = connection.HentLedigeResourcerForAfdeling();
            
        }

        public void ShowAllfrieRessourcer(string startdate, string slutdate)
        {
            HentAllFrieRessourcer(startdate, slutdate);

            foreach (var item in ressources)
            {
                Console.WriteLine(item.Navn);
            }

        }

        public void InsertDebitor(string navn, string adresse, int postNr, string by, string medarbejderNr, string kundeType, string tlf, string kundeNr)
        {
            DebitorObj debitorObj = new DebitorObj(navn, adresse, postNr, by, medarbejderNr, kundeType, tlf, kundeNr);
            connection.InserDebitor(debitorObj);
        }
    }
}

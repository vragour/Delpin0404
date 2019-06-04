using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class DBController
    {
        DBManager connection = new DBManager();

        List<Ressource> ressources = new List<Ressource>();

        public void HentAllFrieRessourcer(string startdate, string slutdate)
        {
            ressources = connection.FindAlleFrieRessourcer(startdate, slutdate);
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

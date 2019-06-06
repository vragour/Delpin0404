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

        public List<Ressource> ressources = new List<Ressource>();
        public List<DebitorObj> debitor = new List<DebitorObj>();
        public List<AfdRessObj> afdRessObjs = new List<AfdRessObj>();
        public List<Booking> bookings = new List<Booking>();
        public List<resserversline> resline = new List<resserversline>();

        public void HentAllFrieRessourcer(string startdate, string slutdate, string whereString = null)
        {
            ressources = connection.FindAlleFrieRessourcer(startdate, slutdate, whereString);
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

        public void UpdatetDebitor(string navn, string adresse, int postNr, string by, string medarbejderNr, string kundeType, string tlf, string kundeNr)
        {
            DebitorObj debitorObj = new DebitorObj(navn, adresse, postNr, by, medarbejderNr, kundeType, tlf, kundeNr);
            connection.UpdateDebitor(debitorObj);
        }

        public void DeleteDebitor(string debitorTlf)
        {
            connection.DeleteDebitor(debitorTlf);
        }

        public DebitorObj HentDebitor(string debitorTlf)
        {
            DebitorObj debitor = connection.FindDebitor(debitorTlf);
            return debitor;
        }

        public void FindFrieRessourcerMaerkelNavn(string startdate, string slutdate, string search)
        {
            ressources = connection.FindFrieRessourcerMaerkelNavn(startdate, slutdate, search);
        }

        public void HentRessourcerPaaRr(string startdate, string slutdate, string rnr)
        {
            ressources = connection.HentRessourcerPaaRnr(startdate, slutdate, rnr);
        }

        public void insertBooking(int dnr, int bookid)
        {
            connection.insertBooking(dnr, bookid);
        }

        public void insertReserveringsline(int Resnr, string orderstart, string orderslut, double pris, int rnr, int bookid)
        {
            connection.insertReserveringsline(Resnr, orderstart, orderslut, pris, rnr, bookid);
        }

    }
}

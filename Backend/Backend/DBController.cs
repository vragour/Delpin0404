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
        public List<TilbehoerObj> tilbehoer = new List<TilbehoerObj>();
        public List<DebitorRessBookObj> ressBookList;
        public void HentAllFrieRessourcer(string startdate, string slutdate, string whereString = null)
        {
            ressources = connection.FindAlleFrieRessourcer(startdate, slutdate, whereString);
        }
        //Michael
        public void FindLedigeResourcerForAfdeling( )//USE CASE: U1 / U2
        {
            /*Populate the List with Database Elements and let the controller keep the list*/
            afdRessObjs = connection.HentLedigeResourcerForAfdeling();
        }

        public void FindDebitorRessourceBookinger(int debitorID)//Michael
        {
            /*Populate the List with Database Elements and let the controller keep the list*/
            ressBookList = connection.FindDebitorRessourceBookinger(debitorID);
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
            DebitorObj debitorInsertObj = new DebitorObj(navn, adresse, postNr, by, medarbejderNr, kundeType, tlf, kundeNr);
            connection.InserDebitor(debitorInsertObj);
        }//Michael

        public void UpdatetDebitor(string navn, string adresse, int postNr, string by,string medarbejderNr, string debitorNr, string kundeType, string tlf, string kundeNr)
        {
            DebitorObj debitorObj = new DebitorObj(navn, adresse, postNr, by, medarbejderNr, debitorNr, kundeType, tlf, kundeNr);
            connection.UpdateDebitor(debitorObj);
        }//Michael

        public void DeleteDebitor(string debitorTlf)
        {
            connection.DeleteDebitor(debitorTlf);
        }//Michael

        public void HentDebitor(string debitorTlf)
        {
            DebitorObj debitorObj = connection.FindDebitor(debitorTlf);
            debitor.Add(debitorObj);
        }//Michael

        public void FindFrieRessourcerMaerkelNavn(string startdate, string slutdate, string search)
        {
            ressources = connection.FindFrieRessourcerMaerkelNavn(startdate, slutdate, search);
        }//Holger


        public void HentRessourcerPaaRr(string startdate, string slutdate, string rnr)
        {
            ressources = connection.HentRessourcerPaaRnr(startdate, slutdate, rnr);
        }//Holger

        public void insertBooking(int dnr)
        {
            connection.insertBooking(dnr);
        }//Holger

        public void insertReserveringsline(string orderstart, string orderslut, double pris, int rnr, int bookid)
        {
            connection.insertReserveringsline(orderstart, orderslut, pris, rnr, bookid);
        }//Holger

        public void hentsidsteBooking()
        {
            //henter sidste række i booking og ikke booking + reserveringlinjer
           bookings = connection.hentsidsteBooking();
        }//Holger

        public void FindFrietilbehoerMaerkelNavn(string startdate, string slutdate, string search)
        {
            tilbehoer = connection.FindFrietilbehoerMaerkelNavn(startdate, slutdate, search);
        }//Holger

        public void UpdateReserveringlinjeTilbehoer(int ResNr, string orderstart, string orderslut, double total)
        { connection.UpdateReserveringlinjeTilbehoer(ResNr, orderstart, orderslut, total); }//Holger

        public void UpdateReserveringlinjeRessourcer(int ResNr, string orderstart, string orderslut, double total)
        
        { connection.UpdateReserveringlinjeRessourcer(ResNr, orderstart, orderslut, total); }//Holger
        public void SletReserveringlinjeTilbehoer(int Resnr)
        { connection.SletReserveringlinjeTilbehoer(Resnr); }//Holger
        public void SletReserveringlinjeRessourcer(int Resnr)
        { connection.SletReserveringlinjeRessourcer(Resnr); }//Holger

        public void FindRessourceBookinger(int Book_ID)
        {
            ressBookList = connection.FindRessourceBookinger(Book_ID);
        }//Holger

    }
}

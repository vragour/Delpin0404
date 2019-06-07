using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
   public class DebitorRessBookObj
    {
        private int resNr;
        private int rnr;
        private int bookingID;
        private string navn;
        private string maerke;
        private string startDato;
        private string slutDato;
        private int pris;
        private int aargang;

        public DebitorRessBookObj(int resNr, int rnr, int bookingID, string navn, string maerke, string startDato, string slutDato, int pris, int aargang)
        {
            this.resNr = resNr;
            this.rnr = rnr;
            this.bookingID = bookingID;
            this.navn = navn;
            this.maerke = maerke;
            this.startDato = startDato;
            this.slutDato = slutDato;
            this.pris = pris;
            this.aargang = aargang;
        }//This Constructor represents DebitorRessBook as it appers in the DataBase and is used in Reads.
        public int ResNr
        {
            get { return resNr; }
        }
        public int Rnr
        {
            get { return rnr; }
        }
        public int BookingID
        {
            get { return bookingID; }
        }
        public string Navn
        {
            get { return navn; }
        }
        public string Maerke
        {
            get { return maerke; }
        }
        public string StartDato
        {
            get { return startDato; }
        }
        public string SlutDato
        {
            get { return slutDato; }
        }
        public int Pris
        {
            get { return pris; }
        }
        public int Aargang
        {
            get { return aargang; }
        }

    }
}

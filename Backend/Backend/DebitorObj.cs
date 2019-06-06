using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Backend
{
    public class DebitorObj
    {
        private string navn;
        private string adresse;
        private int postNr;
        private string by;
        private string debitorNr;
        private string kundeType;
        private string tlf;
        private string kundeNr;

        public DebitorObj(string navn, string adresse, int postNr, string by, string debitorNr, string kundeType, string tlf, string kundeNr)
        {
            this.navn = navn;
            this.adresse = adresse;
            this.postNr = postNr;
            this.by = by;
            this.debitorNr = debitorNr;
            this.kundeType = kundeType;
            this.tlf = tlf;
            this.kundeNr = kundeNr;
        }
        public DebitorObj(string navn, string adresse, int postNr, string by, string kundeType, string tlf, string kundeNr)
        {
            this.navn = navn;
            this.adresse = adresse;
            this.postNr = postNr;
            this.by = by;
            this.kundeType = kundeType;
            this.tlf = tlf;
            this.kundeNr = kundeNr;
        }

        public string Navn
        {
            get { return navn; }
        }

        public string Adresse
        {
            get { return adresse; }
        }

        public int PostNr
        {
            get { return postNr; }
        }

        public string By
        {
            get { return by; }
        }

        public string DebitorNr
        {
            get { return debitorNr; }
        }

        public string KundeType
        {
            get { return kundeType; }
        }

        public string Tlf
        {
            get { return tlf; }
        }

        public string KundeNr
        {
            get { return kundeNr; }
        }




    }
}


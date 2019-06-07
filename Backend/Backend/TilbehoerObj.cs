using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class TilbehoerObj//Holger
    {
        private string Navn;
        private int Tnr;
        private int Aargang;
        private string Maerke;
        private double Pris;
        private int Anr;
        private int Rnr;
        public TilbehoerObj(string navn, int tnr, int aagang, string maerke, double pris, int rnr, int anr)
        {
            Navn = navn;
            Tnr = rnr;
            Aargang = aagang;
            Maerke = maerke;
            Pris = pris;
            Rnr = rnr;
            Anr = anr;
        }

        public string navn
        {
            get{return Navn;}
        }

        public int aargang
        {
            get
            {
                return Aargang;
            }
        }

        public string maerke
        {
            get
            {
                return Maerke;
            }
        }

        public double pris
        {

            get
            {
                return Pris;
            }

        }

        public int anr
        {

            get
            {
                return Anr;
            }
        }

        public int rnr
        {

            get
            {
                return Rnr;
            }
        }

        public int tnr
        {
            get { return Tnr; }
        }
    }
}

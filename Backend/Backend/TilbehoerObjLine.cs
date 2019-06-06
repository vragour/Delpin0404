using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class TilbehoerObjLine
    {
        private int ResNr;
        private string OrderStart;
        private string OrderSlut;
        private double Pris;
        private int Tnr;
        private int Book_ID;

        public TilbehoerObjLine(int resnr, string orderstart, string orderslut, double pris, int tnr, int book_Id)
        {
            ResNr = resnr;
            OrderStart = orderstart;
            OrderSlut = orderslut;
            Pris = pris;
            Tnr = tnr;
            Book_ID = book_Id;

        }

        public int resnr {
            get{ return ResNr; }
        }

        public string orderstart
        {
            get{ return OrderStart; }

        }

        public string orderslut
        {
            get{ return OrderSlut; }

        }

        public double pris
        {
            get { return Pris; }
        }
        public int tnr
        {
            get { return Tnr; }
        } 

        public int book_Id
        {
            get
            {
                return Book_ID;
            }
        }




    }
}

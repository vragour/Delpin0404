using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class resserversline
    {

        int _ResNr;
        string _Orderstart;
        string _OrderSlut;
        double _Pris;
        int _rnr;
        int _Book_ID;

        public resserversline(int resnr, string orderstart, string orderslut, double pris, int rnr, int bookid)
        {
            _ResNr = resnr;
            _Orderstart = orderstart;
            _OrderSlut = orderslut;
            _Pris = pris;
            _rnr = rnr;
            _Book_ID = bookid;
        }

        public int resnr
        {
            get { return _ResNr; }
        }

        public string orderstart
        {
            get { return _Orderstart; }
        }

        public string orderslut
        {
            get { return _OrderSlut; }
        }

        public double pris
        {
            get { return _Pris; }
        }

        public int rnr
        {
            get { return _rnr; }
        }

        public int book_id
        {
            get
            {
                return _Book_ID;
            }
        }

    }
}

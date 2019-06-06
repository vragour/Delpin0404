using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class Booking
    {
        private int _Dnr;
        private int _Book_ID;

        public Booking(int dnr, int book_ID)
        {
            _Dnr = dnr;
            _Book_ID = book_ID;

        }

        public int dnr
        {
            get
            {
                return _Dnr;
            }
        }


        public int book_ID
        {
            get
            {
                return _Book_ID;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Backend
{
    public class DBManager
    {
        private const string username = "user id = delpin1;";
        private const string server = "server = den1.mssql7.gear.host;";
        private const string pwd = "password=Ju67eM1Z!?q1;";
        private const string db = "database = delpin1;";

        SqlConnection conn = new SqlConnection(server + db + username + pwd);

        //Finder alle frie resourcer med mulig for at tilføre en string med sql
        //startdate: hvornår man have ressourcen
        //slutdate: hvornår man formoder man er færdig med ressourcen
        //opt : whereString mulighed for at tilføre mere sql.
        public List<Ressource> FindAlleFrieRessourcer(string startdate, string slutdate, string whereString = null)
        {

            conn.Open();
            SqlCommand com = new SqlCommand();
            com.Connection = conn;

            string sql = "select * from v2_Ressourcer " +
                "where not exists" +
                    "(select '' from v2_Reservation_Line_Ressourcer " +
                    "where '" + startdate + "' <= v2_Reservation_Line_Ressourcer.Orderslut " +
                    "and '" + slutdate + "' >= v2_Reservation_Line_Ressourcer.OrderStart " +
                    "and v2_Reservation_Line_Ressourcer.rnr = v2_Ressourcer.rnr) " + whereString + ";";

            com.CommandText = sql;

            List<Ressource> ressources = new List<Ressource>();
            SqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                //string navn, int rnr, int aagang, string maerke, double pris, int anr

                //DateTime dateTime = (dateTime) 


                Ressource r = new Ressource(
                    Convert.ToString(reader["Navn"]),
                    Convert.ToInt32(reader["rnr"]),
                    Convert.ToInt32(reader["Aargang"]),
                    Convert.ToString(reader["Maerke"]),
                    Convert.ToDouble(reader["Pris"]),
                    Convert.ToInt32(reader["anr"])
                );
                ressources.Add(r);
            }
            reader.Close();
            conn.Close();
            return ressources;
        }
        
        public List<DebitorRessBookObj> FindDebitorRessourceBookinger(int debitorID)
        {
            List<DebitorRessBookObj> ressBookList = new List<DebitorRessBookObj>();
            string sqlCmdText = "select * from v2_Booking " +
                         " join v2_Reservation_Line_Ressourcer" +
                         " on v2_Reservation_Line_Ressourcer.Book_ID = v2_Booking.Book_ID" +
                         " join v2_Ressourcer " +
                         " on v2_Reservation_Line_Ressourcer.rnr = v2_Ressourcer.rnr" +
                         " where v2_Booking.dnr = " + debitorID;

            SqlCommand comm = new SqlCommand(sqlCmdText, conn);
            comm.Connection.Open();

            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                ressBookList.Add(new DebitorRessBookObj(
                          Convert.ToInt32(reader["ResNr"]),
                          Convert.ToInt32(reader["rnr"]),
                          Convert.ToInt32(reader["Book_ID"]),
                          Convert.ToString(reader["Navn"]),
                          Convert.ToString(reader["Maerke"]),
                          Convert.ToString(reader["OrderStart"]),
                          Convert.ToString(reader["Orderslut"]),
                          Convert.ToInt32(reader["Pris"]),
                          Convert.ToInt32(reader["Aargang"])
                          ));
            }

            reader.Close();
            comm.Connection.Close();

            return ressBookList;
        }

        public List<DebitorRessBookObj> FindRessourceBookinger(int Book_ID)
        {
            List<DebitorRessBookObj> ressBookList = new List<DebitorRessBookObj>();
            string sqlCmdText = "select* from v2_Booking " +
                         " join v2_Reservation_Line_Ressourcer" +
                         " on v2_Reservation_Line_Ressourcer.Book_ID = v2_Booking.Book_ID" +
                         " join v2_Ressourcer on v2_Reservation_Line_Ressourcer.rnr = v2_Ressourcer.rnr" +
                         " where v2_Booking.Book_ID = " + Book_ID;

            SqlCommand comm = new SqlCommand(sqlCmdText, conn);
            comm.Connection.Open();

            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                ressBookList.Add(new DebitorRessBookObj(
                          Convert.ToInt32(reader["ResNr"]),
                          Convert.ToInt32(reader["rnr"]),
                          Convert.ToInt32(reader["Book_ID"]),
                          Convert.ToString(reader["Navn"]),
                          Convert.ToString(reader["Maerke"]),
                          Convert.ToString(reader["OrderStart"]),
                          Convert.ToString(reader["Orderslut"]),
                          Convert.ToInt32(reader["Pris"]),
                          Convert.ToInt32(reader["Aargang"])
                          ));
            }

            reader.Close();
            comm.Connection.Close();

            return ressBookList;
        }




        public void InserDebitor(DebitorObj debitorObj)
        {
            string sqlCmdText = $"insert into v2_Debitor ( Navn, Adresse, Postnr, [By], manr, Kundetype, TLF, Kundenr) " +
            $"values ('{debitorObj.Navn}'," +
                   $" '{debitorObj.Adresse}'," +
                   $" {debitorObj.PostNr}," +
                   $" '{debitorObj.By}'," +
                   $" '{debitorObj.MedarbejderNr}'," +
                   $" '{debitorObj.KundeType}'," +
                   $" {debitorObj.Tlf}," +
                   $" '{debitorObj.KundeNr}')";
            /*Initalizing SqlCommand object comm with two paramerets: 
             * @parm conn, gives comm connection abilities.
             * @param sqlCmdText, QueryText to be executed at Database server.*/
            SqlCommand comm = new SqlCommand(sqlCmdText, conn);
            comm.Connection.Open();
            comm.ExecuteNonQuery();
            comm.Connection.Close();
        }
        /*insert into v2_Debitor(Navn, Adresse, PostNr, [By], KundeType, TLF, Kundenr)
values('Jens Holger', 'KoldingVej',7545, 'Vejle', 'P', '75412356', 'KO4575')*/

        public DebitorObj FindDebitor(string debitorTlf)
        {
            /* DebitorObj is assigned null and will remain null
             * unless an occurrence,@param debitorTlf ,is found in the database.*/
            DebitorObj debitorObj = null;

            string sqlCmdText = $"select * from v2_Debitor where Tlf ='{debitorTlf}'";
            SqlCommand comm = new SqlCommand(sqlCmdText, conn);
            comm.Connection.Open();

            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                debitorObj = new DebitorObj(
                          Convert.ToString(reader["Navn"]),
                          Convert.ToString(reader["Adresse"]),
                          Convert.ToInt32(reader["Postnr"]),
                          Convert.ToString(reader["By"]),
                          Convert.ToString(reader["manr"]),
                          Convert.ToString(reader["dnr"]),
                          Convert.ToString(reader["Kundetype"]),
                          Convert.ToString(reader["TLF"]),
                          Convert.ToString(reader["Kundenr"])
                      );
                break;
            }
            reader.Close();
            comm.Connection.Close();
            return debitorObj;
        }

        public void UpdateDebitor(DebitorObj debitorObj)
        {
            string sqlCmdText = $"Update v2_Debitor set " +
                $" Navn='{debitorObj.Navn}'," +
                $" Adresse='{debitorObj.Adresse}'," +
                $" PostNr={debitorObj.PostNr}, " +
                $" [By]='{debitorObj.By}', " +
                $" KundeType='{debitorObj.KundeType}', " +
                $" TLF='{debitorObj.Tlf}', " +
                $" Kundenr='{debitorObj.KundeNr}'" +
                $" where TLF = '{debitorObj.Tlf}'";
            /*Initalizing SqlCommand object comm with two paramerets: 
             * @parm conn, gives comm connection abilities.
             * @param sqlCmdText, QueryText to be executed at Database server.*/
            SqlCommand comm = new SqlCommand(sqlCmdText, conn);
            comm.Connection.Open();
            comm.ExecuteNonQuery();
            comm.Connection.Close();
        }

        public void DeleteDebitor(string debitorTlf)
        {
            string sqlCmdText = $"Delete from v2_Debitor " +
                                  $" where Tlf = '{debitorTlf}'";
            SqlCommand comm = new SqlCommand(sqlCmdText, conn);
            comm.Connection.Open();
            comm.ExecuteNonQuery();
            comm.Connection.Close();
        }

        public void updateRessource(string Navn, int rnr, int Aargang, string Maerke, int Pris, int anr)
        {
            conn.Open();
            SqlCommand com = new SqlCommand();
            com.Connection = conn;

            //string navn, int rnr, int aagang, string maerke, double pris, int anr

            string sql = "update v2_Ressourcer " +
                        "set" +
                            " Navn = " + Navn +
                            " Aagang = " + Aargang +
                            " Maerke = " + Maerke +
                            " Pris = " + Pris +
                            " anr = " + anr +
                        " Where rnr =" + rnr;

            com.CommandText = sql;
            com.ExecuteNonQuery();
            conn.Close();
        }

        public void deleteReservering(int rnr)
        {
            conn.Open();
            SqlCommand com = new SqlCommand();
            com.Connection = conn;

            //string navn, int rnr, int aagang, string maerke, double pris, int anr

            string sql = "delete reserveret where rnr = " + rnr;

            com.CommandText = sql;
            com.ExecuteNonQuery();
            conn.Close();
        }

        public List<AfdRessObj> HentLedigeResourcerForAfdeling()
        {
            List<AfdRessObj> ressources = new List<AfdRessObj>();
            string sqlCmdText = "select r.Navn, r.rnr, r.Maerke, r.Pris, a.Adresse, a.Postnr " +
                         "from v2_Ressourcer r join v2_Afdeling a on not exists" +
                         "(select '' from v2_Reservation_Line_Ressourcer rs where rs.rnr = r.rnr)";

            SqlCommand comm = new SqlCommand(sqlCmdText, conn);
            comm.Connection.Open();

            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                ressources.Add(
                    new AfdRessObj(
                    Convert.ToString(reader["Navn"]),
                    Convert.ToInt32(reader["rnr"]),
                    Convert.ToString(reader["Maerke"]),
                    Convert.ToInt32(reader["Pris"]),
                    Convert.ToString(reader["Adresse"]),
                    Convert.ToInt16(reader["Postnr"])
                    ));
            }

            reader.Close();
            comm.Connection.Close();

            return ressources;
        }

        public List<Ressource> FindFrieRessourcerMaerkelNavn(string startdate, string slutdate, string search)
        {

            conn.Open();
            SqlCommand com = new SqlCommand();
            com.Connection = conn;

            string sql = "select * from v2_Ressourcer " +
                "where not exists" +
                    "(select '' from v2_Reservation_Line_Ressourcer " +
                    "where '" + startdate + "' <= v2_Reservation_Line_Ressourcer.Orderslut " +
                    "and '" + slutdate + "' >= v2_Reservation_Line_Ressourcer.OrderStart " +
                    "and v2_Reservation_Line_Ressourcer.rnr = v2_Ressourcer.rnr) " +
                    "and (v2_Ressourcer.Navn like '%" + search + "%' " +
                    "or v2_Ressourcer.Maerke like '%" + search + "%') order by anr;";

            com.CommandText = sql;
            List<Ressource> ressources = new List<Ressource>();
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                Ressource r = new Ressource(
                    Convert.ToString(reader["Navn"]),
                    Convert.ToInt32(reader["rnr"]),
                    Convert.ToInt32(reader["Aargang"]),
                    Convert.ToString(reader["Maerke"]),
                    Convert.ToDouble(reader["Pris"]),
                    Convert.ToInt32(reader["anr"])
                );
                ressources.Add(r);
            }
            reader.Close();
            conn.Close();
            return ressources;
        }

        public List<Ressource> HentRessourcerPaaRnr(string startdate, string slutdate, string rnr)
        {

            conn.Open();
            SqlCommand com = new SqlCommand();
            com.Connection = conn;

            string sql = "select * from v2_Ressourcer where rnr = " + rnr;


            com.CommandText = sql;
            List<Ressource> ressources = new List<Ressource>();
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                Ressource r = new Ressource(
                    Convert.ToString(reader["Navn"]),
                    Convert.ToInt32(reader["rnr"]),
                    Convert.ToInt32(reader["Aargang"]),
                    Convert.ToString(reader["Maerke"]),
                    Convert.ToDouble(reader["Pris"]),
                    Convert.ToInt32(reader["anr"])
                );
                ressources.Add(r);
            }
            reader.Close();
            conn.Close();
            return ressources;
        }


        public void insertBooking(int dnr)
        {

            conn.Open();
            SqlCommand com = new SqlCommand();
            com.Connection = conn;

            string sql = "insert into v2_Booking (dnr) " +
                "values (" + dnr + ");";
            com.CommandText = sql;
            com.ExecuteNonQuery();
            conn.Close();

        }

        public void insertReserveringsline(string orderstart, string orderslut, double pris, int rnr, int bookid)
        {

            conn.Open();
            SqlCommand com = new SqlCommand();
            com.Connection = conn;

            string sql = "insert into v2_Reservation_Line_Ressourcer " +
                "values ('" + orderstart + "', '" + orderslut + "', '" + pris + "', " + rnr + ", " + bookid + ");";
            com.CommandText = sql;
            com.ExecuteNonQuery();
            conn.Close();
        }

        public List<Booking> hentsidsteBooking(){
            conn.Open();
            SqlCommand com = new SqlCommand();
            com.Connection = conn;
            string sql = "SELECT TOP 1 * FROM v2_Booking ORDER BY Book_ID DESC";
            com.CommandText = sql;
            List<Booking> booking = new List<Booking>();
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read()) {

                Booking b = new Booking(Convert.ToInt32(reader["dnr"]), Convert.ToInt32(reader["Book_ID"]));
                booking.Add(b);
            }

            reader.Close();
            conn.Close();
            return booking;
        }

        public List<TilbehoerObj> FindFrietilbehoerMaerkelNavn(string startdate, string slutdate, string search)
        {

            conn.Open();
            SqlCommand com = new SqlCommand();
            com.Connection = conn;

            string sql = "select * from v2_Tilbehoer " +
                "where not exists" +
                    "(select '' from v2_Reservation_Line_Tilbehoer " +
                    "where '" + startdate + "' <= v2_Reservation_Line_Tilbehoer.Orderslut " +
                    "and '" + slutdate + "' >= v2_Reservation_Line_Tilbehoer.OrderStart " +
                    "and v2_Reservation_Line_Tilbehoer.tnr = v2_Tilbehoer.tnr) " +
                    "and (v2_Tilbehoer.Navn like '%" + search + "%' " +
                    "or v2_Tilbehoer.Maerke like '%" + search + "%') order by anr;";

            com.CommandText = sql;
            List<TilbehoerObj> tilbehoerObjs = new List<TilbehoerObj>();
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                TilbehoerObj t = new TilbehoerObj(
                    Convert.ToString(reader["Navn"]),
                    Convert.ToInt32(reader["tnr"]),
                    Convert.ToInt32(reader["Aargang"]),
                    Convert.ToString(reader["Maerke"]),
                    Convert.ToDouble(reader["Pris"]),
                    Convert.ToInt32(reader["rnr"]),
                    Convert.ToInt32(reader["anr"])
                );
                tilbehoerObjs.Add(t);
            }
            reader.Close();
            conn.Close();
            return tilbehoerObjs;
        }

        public void SletReserveringlinjeRessourcer(int Resnr)
        {
            conn.Open();
            SqlCommand com = new SqlCommand();
            com.Connection = conn;

            string sql = "delete v2_Reservation_Line_Ressourcer where rnr = " + Resnr;

            com.CommandText = sql;
            com.ExecuteNonQuery();
            conn.Close();
        }

        public void SletReserveringlinjeTilbehoer(int Resnr)
        {
            conn.Open();
            SqlCommand com = new SqlCommand();
            com.Connection = conn;
            string sql = "delete v2_Reservation_Line_Tilbehoer where ResNr = " + Resnr;

            com.CommandText = sql;
            com.ExecuteNonQuery();
            conn.Close();
        }

        public void UpdateReserveringlinjeTilbehoer(string ResNr, string orderstart, string orderslut, double total, int tnr, int book_ID)
        {
            string sql = "update v2_Reservering_linje_Tilbehoer " +
            "set" +
                " OrderStart = " + orderstart +
                " Orderslut = " + orderslut +
                " Total = " + total +
                " tnr = " + tnr +
                " Book_ID = " + book_ID +
            " Where ResNr =" + ResNr;
            conn.Open();
            SqlCommand com = new SqlCommand();
            com.Connection = conn;
            com.CommandText = sql;
            com.ExecuteNonQuery();
            conn.Close();


        }
        public void UpdateReserveringlinjeRessourcer(string ResNr, string orderstart, string orderslut, double total) {
                string sql = "update v2_Reservering_linje_Ressourcer " +
                            "set" +
                            " OrderStart = " + orderstart +
                            " Orderslut = " + orderslut +
                            " Total = " + total +
                            " Where ResNr =" + ResNr;
            conn.Open();
            SqlCommand com = new SqlCommand();
            com.Connection = conn;
            com.CommandText = sql;
            com.ExecuteNonQuery();
            conn.Close();


        }
    }
}

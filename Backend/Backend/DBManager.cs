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
                    "and v2_Reservation_Line_Ressourcer.rnr = v2_Ressourcer.rnr) " + whereString +";";

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

        public void InserDebitor(DebitorObj debitorObj)
        {
            string sqlCmdText = $"insert into v2_Debitor ( Navn, Adresse, Postnr, [By], manr, Kundetype, TLF, Kundenr) " +
            $"values ('{debitorObj.Navn}'," +
                   $" '{debitorObj.Adresse}'," +
                   $" {debitorObj.PostNr}," +
                   $" '{debitorObj.By}'," +
                   $" {debitorObj.MedarbejderNr}," +
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
                        Convert.ToString(reader["dnr"]),
                        Convert.ToString(reader["Kundetype"]),
                        Convert.ToString(reader["TLF"]),
                        Convert.ToString(reader["Kundenr"])
                    );
                break;//Dibitors can have the same phonenumber, don't know why.
            }
            reader.Close();
            comm.Connection.Close();
            return debitorObj;
        }

        public void UpdateDebitor(DebitorObj debitorObj)
        {
            string sqlCmdText = $"Update v2_Debitor set " +
                $"Navn='{debitorObj.Navn}'," +
                $"Adresse='{debitorObj.Adresse}'," +
                $"PostNr={debitorObj.PostNr}, " +
                $"[By]='{debitorObj.By}', " +
                $"KundeType='{debitorObj.KundeType}', " +
                $"TLf='{debitorObj.Tlf}', " +
                $"Kundenr='{debitorObj.KundeNr}'" +
                $" where Tlf = '{debitorObj.Tlf}'";
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
            
            SqlCommand comm = new SqlCommand(sqlCmdText,conn);
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


        public insertBooking()
        {

        }
    }
}

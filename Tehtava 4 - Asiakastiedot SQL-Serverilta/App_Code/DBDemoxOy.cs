using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT
{
    public static class DBDemoxOy
    {
        public static DataTable GetDataSimple()
        {
            //DB-kerros
            //taulu
            DataTable dt = new DataTable();
            //sarakkeet
            dt.Columns.Add("astunnus", typeof(string));
            dt.Columns.Add("asnimi", typeof(string));
            //tietueet eli rivit
            dt.Rows.Add("KalleI", "Kalle Isokallio");
            dt.Rows.Add("MN01", "Matt Nickerson");
            return dt;
        }
        public static DataTable GetDataReal()
        {
            //DBkerros, haetaan DemoxOy-tietokannasta taulun asiakas tietueet, metodi palauttaa DataTablen
            try
            {
                string sql = "";
                sql = "SELECT astunnus, asnimi, yhteyshlo, postitmp FROM asiakas"; // WHERE asioid='salesa'";
                string connStr = @"Data source=twelve.labranet.jamk.fi;initial catalog=DemoxOy;user=koodari;password=koodari16";
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    //avataan yhteys
                    conn.Open();
                    //luodaan komento = command-olio
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "asiakas");
                        return ds.Tables["asiakas"];
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
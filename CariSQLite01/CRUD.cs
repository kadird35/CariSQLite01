using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CariSQLite01
{
  public class CRUD
    {
        static DataTable dt;
        public static DataTable Listele(string sql)
        {
            dt = new DataTable();
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, Baglan.conn);
            da.Fill(dt);
            return dt;
        }

        public static bool ESG(string sql)
        {
            int dogrula = 0;
            SQLiteCommand cmd = new SQLiteCommand(sql, Baglan.conn);
            Baglan.conn.Open();
            dogrula = cmd.ExecuteNonQuery();
            Baglan.conn.Close();
            if (dogrula == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }
    }









}

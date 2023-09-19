using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CariSQLite01
{
    
 
    public class Baglan
    {
     // static string DB_MSSQL = "Data Source=DESKTOP-R2AG8UU;Initial Catalog=caridb;Integrated Security=True";
        static string DB_SQLite = "Data Source=.\\caridb.db;Version=3";
       
        // SQLite Connection kullanabilmek için, Solution Explorer a sağ tıklayıp
        // Manage NuGet Packages ten "System.Data.SQLite" şeklinde aratmali çıkan ilk seçeneği indime ikonuna tıklanmalı
        // çıkacak ekranda 4 veya 5 paket indireceğini gösteren ekranı onaylamalı ve indirmeli.
        public static SQLiteConnection conn = new SQLiteConnection(DB_SQLite);
    }
}

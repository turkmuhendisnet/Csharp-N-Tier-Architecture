using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Baglanti
    {
        SqlConnection conn = new SqlConnection(@"Server=ALICAKIR\SQLEXPRESS;Database=Test;Integrated Security=true;");

        public SqlConnection BaglantiAc ()
        {           
            conn.Open();
            return conn;
        }

        public SqlConnection BaglantiKapat()
        {
            conn.Close();
            return conn;
        }
    }
}

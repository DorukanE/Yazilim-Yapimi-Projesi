using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Yazılım_Yapımı_Projesi
{
    public class SqlBaglanti
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=LAPTOP-6UFOC7K3\MSSQLSERVER01;Initial Catalog=İngilizceTurkceSozluk;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}

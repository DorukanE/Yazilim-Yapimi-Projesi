using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Yazılım_Yapımı_Projesi
{
    public partial class FormIstatistik : DevExpress.XtraEditors.XtraForm 
    {
        public FormIstatistik()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection(@"Data Source=LAPTOP-6UFOC7K3\MSSQLSERVER01;Initial Catalog=İngilizceTurkceSozluk;Integrated Security=True");

        private void FormIstatistik_Load(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("select Seviye,count(*) from Table_Kelimeler group by Seviye", baglan);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartIstatistik.Series["Seviye-Ogrenilenler"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            baglan.Close();
        }
    }
}

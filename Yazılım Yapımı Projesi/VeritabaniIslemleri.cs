using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Yazılım_Yapımı_Projesi
{
    public class VeritabaniIslemleri
    {        
        SqlConnection baglan = new SqlConnection(@"Data Source=LAPTOP-6UFOC7K3\MSSQLSERVER01;Initial Catalog=İngilizceTurkceSozluk;Integrated Security=True");

        public void KelimeEkle(Kelime kelime)
        {
            baglan.Open();
            SqlCommand ekle = new SqlCommand("insert into Table_Kelimeler (KelimeTuru,İngilizceKelime,TurkceKarsılıgı,OrnekCumle,Seviye,Tarih) values (@kelimeTur,@ingKelime,@turkceKarsiligi,@ornekCumle,@seviye,@tarih)",baglan);
            ekle.Parameters.AddWithValue("@kelimeTur", kelime.kelimeTuru);
            ekle.Parameters.AddWithValue("@ingKelime", kelime.ingKelime);
            ekle.Parameters.AddWithValue("@turkceKarsiligi", kelime.turkceKelime);
            ekle.Parameters.AddWithValue("@ornekCumle", kelime.ornekCumle);
            ekle.Parameters.AddWithValue("@seviye", kelime.seviye);
            ekle.Parameters.AddWithValue("@tarih", kelime.tarih);
            ekle.ExecuteNonQuery();
            baglan.Close();
        }

        public DataTable KelimeGetir()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("select * from Table_Kelimeler ", baglan);
            SqlDataReader dr = komut.ExecuteReader();
            List<Kelime> kelimeler = new List<Kelime>();
            DataTable dataTable = new DataTable();
            dataTable.Load(dr);
            dr.Close();
            baglan.Close();
            return dataTable;
        }

        public void  TarihiAyarla(Kelime kelime)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("select İngilizceKelime,TurkceKarsılıgı,Seviye from Table_Kelimeler where TurkceKarsılıgı=@Turkce", baglan);
            komut.Parameters.AddWithValue("@Turkce", kelime.turkceKelime);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            
            if(dt.Rows.Count != 0)
            {
                kelime.ingKelime = dt.Rows[0].Field<string>("İngilizceKelime");
                kelime.turkceKelime = dt.Rows[0].Field<string>("TurkceKarsılıgı");
                kelime.seviye = dt.Rows[0].Field<string>("Seviye").ToString();

                if(kelime.seviye == "1")
                {
                    kelime.tarih = DateTime.Now.AddDays(1).ToShortDateString();
                }
                else if(kelime.seviye == "2")
                {
                    kelime.tarih = DateTime.Now.AddDays(6).ToShortDateString();
                }
                else if(kelime.seviye == "3")
                {
                    kelime.tarih = DateTime.Now.AddDays(23).ToShortDateString();
                }
                else if(kelime.seviye == "4")
                {
                    kelime.tarih = DateTime.Now.AddDays(150).ToShortDateString();
                }
                else if(kelime.seviye == "5")
                {
                    kelime.tarih = DateTime.Now.AddDays(0).ToShortDateString();
                }
                else if(kelime.seviye == "6")
                {
                    kelime.tarih = DateTime.Now.AddDays(0).ToShortDateString();
                }
                else if(kelime.seviye == "0")
                {
                    kelime.tarih = DateTime.Now.AddDays(1).ToShortDateString();
                }
               
                SqlCommand komut1 = new SqlCommand("update Table_Kelimeler set Tarih=@tarih where İngilizceKelime=@ingKelime", baglan);
                komut1.Parameters.AddWithValue("@tarih", kelime.tarih);
                komut1.Parameters.AddWithValue("@ingKelime", kelime.ingKelime);
                komut1.ExecuteNonQuery();
                baglan.Close();
            }
        }

        public void SeviyeArttir(Kelime kelime)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("update Table_Kelimeler set Seviye+=1 where TurkceKarsılıgı=@turkce", baglan);
            komut.Parameters.AddWithValue("@turkce", kelime.turkceKelime);
            komut.ExecuteNonQuery();
            baglan.Close();
        }

        public void SeviyeAzalt(Kelime kelime)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("update Table_Kelimeler set Seviye=1 where TurkceKarsılıgı=@turkce", baglan);
            komut.Parameters.AddWithValue("@turkce", kelime.turkceKelime);
            komut.ExecuteNonQuery();
            baglan.Close();
        }

        public void KelimeSil(int id)
        {
            baglan.Open();
            SqlCommand delete = new SqlCommand("delete from Table_Kelimeler where KelimeID=@id", baglan);
            delete.Parameters.AddWithValue("@id", id);
            delete.ExecuteNonQuery();
            baglan.Close();
        }

        public void KelimeGuncelle(Kelime kelime)
        {
            baglan.Open();
            SqlCommand guncelle = new SqlCommand("update Table_Kelimeler set İngilizceKelime=@ingKelime,TurkceKarsılıgı=@turkce,KelimeTuru=@tur,OrnekCumle=@cumle where KelimeID=@id ", baglan);
            guncelle.Parameters.AddWithValue("@id", kelime.kelimeId);
            guncelle.Parameters.AddWithValue("@ingKelime", kelime.ingKelime);
            guncelle.Parameters.AddWithValue("@turkce", kelime.turkceKelime);
            guncelle.Parameters.AddWithValue("@cumle", kelime.ornekCumle);
            guncelle.Parameters.AddWithValue("@tur", kelime.kelimeTuru);           
            guncelle.ExecuteNonQuery();
            baglan.Close();
        }       
    }
}

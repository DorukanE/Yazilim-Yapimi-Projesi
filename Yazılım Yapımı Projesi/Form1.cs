using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Yazılım_Yapımı_Projesi
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();

        }

        // Global verilerimiz:

        VeritabaniIslemleri islem = new VeritabaniIslemleri();
        List<Kelime> kelimeler = new List<Kelime>();
        Kelime kelime = new Kelime();
        SqlConnection baglan = new SqlConnection(@"Data Source=LAPTOP-6UFOC7K3\MSSQLSERVER01;Initial Catalog=İngilizceTurkceSozluk;Integrated Security=True");
        int dogruSayac = 0, yanlisSayac = 0;

        //  ***************** Kelime Ezberleme Bölümü ************************

        private void Form1_Load(object sender, EventArgs e)
        {
            this.table_KelimelerTableAdapter1.Fill(this.İngilizceTurkceSozlukDataSet4.Table_Kelimeler);
            this.table_KelimelerTableAdapter.Fill(this.İngilizceTurkceSozlukDataSet3.Table_Kelimeler);

            KelimeGetir();
            islem.SeviyeArttir(kelime);
            Guncelle();
            SoruGetir();
        }

        private void smpBtnIlerle_Click(object sender, EventArgs e)
        {
            KelimeGetir();
            islem.SeviyeArttir(kelime);
            Guncelle();
        }

        void KelimeGetir()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("select top 1 KelimeID,KelimeTuru,İngilizceKelime,TurkceKarsılıgı,OrnekCumle,Seviye,Tarih from Table_Kelimeler where Seviye=0 order by NEWID()", baglan);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                kelime.kelimeId = Convert.ToInt32(dr["KelimeID"]);
                kelime.kelimeTuru = dr["KelimeTuru"].ToString();
                kelime.ingKelime = dr["İngilizceKelime"].ToString();
                kelime.turkceKelime = dr["TurkceKarsılıgı"].ToString();
                kelime.ornekCumle = dr["OrnekCumle"].ToString();
                kelime.seviye = dr["Seviye"].ToString();
                kelime.tarih = dr["Tarih"].ToString();
                kelimeler.Add(kelime);
                lblCtrlIngilizce.Text = kelime.ingKelime;
                lblCtrlTür.Text = kelime.kelimeTuru;
                lblCtrlCumle.Text = kelime.ornekCumle;
                lblCtrlTurkce.Text = kelime.turkceKelime;
            }
            baglan.Close();
        }

        void Guncelle()
        {
            kelime.tarih = DateTime.Now.AddDays(1).ToShortDateString();
            baglan.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglan;
            komut.CommandText = "update Table_Kelimeler set Tarih='" + kelime.tarih + "'where TurkceKarsılıgı='" + lblCtrlTurkce.Text + "'";
            komut.Parameters.AddWithValue("@TurkceKarsılıgı", lblCtrlTurkce.Text);
            komut.Parameters.AddWithValue("@Tarih", kelime.tarih);
            komut.ExecuteNonQuery();
            baglan.Close();
        }
        // ******************************************************************************************

        // ************* Kelime Ekleme Bölümü *******************

        private void smpBtnEkle_Click(object sender, EventArgs e)
        {
            string currentDate = DateTime.Now.Year + "." + DateTime.Now.Month + "." + DateTime.Now.Day;

            Kelime kelime = new Kelime();
            kelime.ingKelime = txtEditIngilizce.Text;
            kelime.turkceKelime = txtEditTurkce.Text;
            kelime.kelimeTuru = cmbBoxEditTur.Text;
            kelime.ornekCumle = txtEditCumle.Text;
            kelime.tarih = currentDate;
            kelime.seviye = 0.ToString();

            VeritabaniIslemleri islem = new VeritabaniIslemleri();

            if (KontrolEt())
            {
                islem.KelimeEkle(kelime);
                MessageBox.Show("Kelime basariyla eklendi. :)", "BILGI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();
            }
            else
                MessageBox.Show("Lütfen tüm alanları doldurun.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void Temizle()
        {
            cmbBoxEditTur.Text = "";
            txtEditIngilizce.Text = "";
            txtEditTurkce.Text = "";
            txtEditCumle.Text = "";
        }

        public bool KontrolEt() // Kelime ekleme kısmındaki tüm textbox'ların doldurulması için kontrol ediyoruz.
        {
            bool isTrue = true;

            if ((txtEditTurkce.Text == "") || (txtEditIngilizce.Text == "") || (txtEditCumle.Text == "") || (cmbBoxEditTur.Text == ""))
                isTrue = false;
            else
                isTrue = true;

            return isTrue;
        }
        // *************************************************************************
        
        // ************************ Kelime Güncelleme ve Silme Bölümü **************************

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) //GridKontrol'deki verileri textbox'lara çekiyoruz.
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtIslemId.Text = dr[0].ToString();
            txtIslemTur.Text = dr[1].ToString();
            txtIslemIng.Text = dr[2].ToString();
            txtIslemTurkce.Text = dr[3].ToString();
            txtIslemCumle.Text = dr[4].ToString();
        }

        private void btnIslemGuncelle_Click(object sender, EventArgs e)
        {
            Kelime kelime = new Kelime();
            kelime.kelimeId = Convert.ToInt32(txtIslemId.Text);
            kelime.ingKelime = txtIslemIng.Text;
            kelime.turkceKelime = txtIslemTurkce.Text;
            kelime.kelimeTuru = txtIslemTur.Text;
            kelime.ornekCumle = txtIslemCumle.Text;

            VeritabaniIslemleri islem = new VeritabaniIslemleri();
            islem.KelimeGuncelle(kelime);
            MessageBox.Show("Kelime başarıyla güncellendi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnIslemSil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtIslemId.Text);
            VeritabaniIslemleri islem = new VeritabaniIslemleri();
            islem.KelimeSil(id);
            MessageBox.Show("Kelime başarıyla silindi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //****************************************************************************

        // ********************** Test Bölümü ******************************

        private void btnTestTamam_Click(object sender, EventArgs e)
        {
            CevapKonrol();
        }

        private void btnTestIlerle_Click(object sender, EventArgs e)
        {
            txtTestCevap.Text = "";
            SoruGetir();
        }

        void SoruGetir()
        {
            baglan.Open();
            kelime.tarih = DateTime.Now.ToShortDateString();
            SqlCommand komut = new SqlCommand("select top 1 KelimeID,KelimeTuru,İngilizceKelime,TurkceKarsılıgı,OrnekCumle,Tarih from Table_Kelimeler where Seviye>=1 and Seviye<=5 and Tarih=@tarih order by NEWID()", baglan);
            komut.Parameters.AddWithValue("@tarih", kelime.tarih);
            komut.ExecuteNonQuery();
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                kelime.kelimeId = Convert.ToInt32(dr["KelimeID"]);
                kelime.kelimeTuru = dr["KelimeTuru"].ToString();
                kelime.ingKelime = dr["İngilizceKelime"].ToString();
                kelime.turkceKelime = dr["TurkceKarsılıgı"].ToString();
                kelime.ornekCumle = dr["OrnekCumle"].ToString();
                kelimeler.Add(kelime);
                lblTestIng.Text = kelime.ingKelime;
                lblTestTur.Text = kelime.kelimeTuru;
                lblTestCumle.Text = kelime.ornekCumle;
            }
            dr.Close();
            baglan.Close();
        }

        void CevapKonrol()
        {          
            baglan.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglan;
            komut.CommandText = "select * from Table_Kelimeler where TurkceKarsılıgı='" + kelime.turkceKelime + "'and İngilizceKelime='" + kelime.ingKelime + "' ";
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                if (txtTestCevap.Text.ToLower() == kelime.turkceKelime)
                {                 
                    islem.SeviyeArttir(kelime);
                    islem.TarihiAyarla(kelime);
                    dogruSayac++;
                    txtDogru.Text = dogruSayac.ToString();
                }
                else
                {
                    MessageBox.Show("Yanlış cevap !! Doğrusu: " + kelime.turkceKelime,"UYARI",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    yanlisSayac++;                    
                    txtYanlis.Text = yanlisSayac.ToString();
                    islem.SeviyeAzalt(kelime);
                    islem.TarihiAyarla(kelime);
                }
            }
            dr.Close();
            baglan.Close();
        }
        //**************************************************************************************

        // Textbox'lara rakam girişini engelliyoruz.

        private void txtEditIngilizce_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                     && !char.IsSeparator(e.KeyChar);
        }

        private void txtEditTurkce_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                     && !char.IsSeparator(e.KeyChar);
        }

        private void txtEditCumle_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                    && !char.IsSeparator(e.KeyChar);
        }
    }
}

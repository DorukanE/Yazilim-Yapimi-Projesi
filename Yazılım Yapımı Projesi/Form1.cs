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

        SqlBaglanti bgl = new SqlBaglanti();
        Random rnd = new Random();
        int dogruSayac = 0;
        int yanlisSayac = 0;
/*
        public void KelimeEzberle()
        {
            SqlCommand komut = new SqlCommand("select count (distinct (KelimeID)) from Table_Kelimeler", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            int topEleman = 0;
            while (dr.Read())
            {
                topEleman = Convert.ToInt32(dr[0]);
            }
            bgl.baglanti().Close();

            List<string> secilenTurkceKelime = new List<string>();
            List<string> secilenIngilizceKelime = new List<string>();
            List<string> secilenOrnekCumle = new List<string>();
            List<string> secilenKelimeTur = new List<string>();

           
            SqlCommand komut1 = new SqlCommand("select KelimeTuru,İngilizceKelime,TurkceKarsılıgı,OrnekCumle  FROM Table_Kelimeler", bgl.baglanti());
            SqlDataReader dr1 = komut1.ExecuteReader();
                
                while (dr1.Read())
                {
                    secilenOrnekCumle.Add(dr1["OrnekCumle"].ToString());
                    secilenIngilizceKelime.Add(dr1["İngilizceKelime"].ToString());
                    secilenTurkceKelime.Add(dr1["TurkceKarsılıgı"].ToString());
                    secilenKelimeTur.Add(dr1["KelimeTuru"].ToString());
                }
                bgl.baglanti().Close();
                
          
            string[] secilenTurkceKelimeDizi = secilenTurkceKelime.ToArray();
            string[] secilenIngilizceKelimeDizi = secilenIngilizceKelime.ToArray();
            string[] secilenOrnekCumleDizi = secilenOrnekCumle.ToArray();
            string[] secilenKelimeTurDizi = secilenKelimeTur.ToArray();
            
                SqlCommand komut2 = new SqlCommand("select top (3) KelimeTuru,İngilizceKelime,TurkceKarsılıgı,OrnekCumle  FROM Table_Kelimeler order by NEWID();", bgl.baglanti());
                SqlDataReader dr2 = komut2.ExecuteReader();
                List<string> rndTurkceKelime = new List<string>();
                List<string> rndIngilizceKelime = new List<string>();
                List<string> rndOrnekCumle = new List<string>();
                List<string> rndKelimeTur = new List<string>();
                while (dr2.Read())
                {
                    rndOrnekCumle.Add(dr2["OrnekCumle"].ToString());
                    rndIngilizceKelime.Add(dr2["İngilizceKelime"].ToString());
                    rndTurkceKelime.Add(dr2["TurkceKarsılıgı"].ToString());
                    rndKelimeTur.Add(dr2["KelimeTuru"].ToString());
                }
                bgl.baglanti().Close();
                string[] rndTurkceKelimeDizi = rndTurkceKelime.ToArray();
                string[] rndIngilizceKelimeDizi = rndIngilizceKelime.ToArray();
                string[] rndOrnekCumleDizi = rndOrnekCumle.ToArray();
                string[] rndKelimeTurDizi = rndKelimeTur.ToArray();

            int i = 0;
           
                int randSayi = rnd.Next(1, 5);

                switch (randSayi)
                {
                    case 1:
                        rdBtnA.Text = secilenTurkceKelimeDizi[i];
                        lblCtrlIngilizce.Text = secilenIngilizceKelimeDizi[i];
                        lblCtrlTür.Text = secilenKelimeTurDizi[i];
                        lblCtrlCumle.Text = secilenOrnekCumleDizi[i];
                        rdBtnB.Text = rndTurkceKelimeDizi[0];
                        rdBtnC.Text = rndTurkceKelimeDizi[1];
                        rdBtnD.Text = rndTurkceKelimeDizi[2];
                        if (rdBtnA.Checked == true)
                        {
                            dogruSayac++;
                            txtEditDogru.Text = dogruSayac.ToString();
                        }
                        else
                        {
                            yanlisSayac++;
                            txtEditYanlis.Text = yanlisSayac.ToString();
                        }
                        rdBtnA.Checked = false;
                        i++;
                        break;
                    case 2:
                        rdBtnB.Text = secilenTurkceKelimeDizi[i];
                        lblCtrlIngilizce.Text = secilenIngilizceKelimeDizi[i];
                        lblCtrlTür.Text = secilenKelimeTurDizi[i];
                        lblCtrlCumle.Text = secilenOrnekCumleDizi[i];
                        rdBtnA.Text = rndTurkceKelimeDizi[0];
                        rdBtnC.Text = rndTurkceKelimeDizi[1];
                        rdBtnD.Text = rndTurkceKelimeDizi[2];
                        if (rdBtnB.Checked == true)
                        {
                            dogruSayac++;
                            txtEditDogru.Text = dogruSayac.ToString();
                        }
                        else
                        {
                            yanlisSayac++;
                            txtEditYanlis.Text = yanlisSayac.ToString();
                        }
                        rdBtnB.Checked = false;
                        i++;
                        break;
                    case 3:
                        rdBtnC.Text = secilenTurkceKelimeDizi[i];
                        lblCtrlIngilizce.Text = secilenIngilizceKelimeDizi[i];
                        lblCtrlTür.Text = secilenKelimeTurDizi[i];
                        lblCtrlCumle.Text = secilenOrnekCumleDizi[i];
                        rdBtnA.Text = rndTurkceKelimeDizi[0];
                        rdBtnB.Text = rndTurkceKelimeDizi[1];
                        rdBtnD.Text = rndTurkceKelimeDizi[2];
                        if (rdBtnC.Checked == true)
                        {
                            dogruSayac++;
                            txtEditDogru.Text = dogruSayac.ToString();
                        }
                        else
                        {
                            yanlisSayac++;
                            txtEditYanlis.Text = yanlisSayac.ToString();
                        }
                        rdBtnC.Checked = false;
                        i++;
                        break;
                    case 4:
                        rdBtnD.Text = secilenTurkceKelimeDizi[i];
                        lblCtrlIngilizce.Text = secilenIngilizceKelimeDizi[i];
                        lblCtrlTür.Text = secilenKelimeTurDizi[i];
                        lblCtrlCumle.Text = secilenOrnekCumleDizi[i];
                        rdBtnA.Text = rndTurkceKelimeDizi[0];
                        rdBtnB.Text = rndTurkceKelimeDizi[1];
                        rdBtnC.Text = rndTurkceKelimeDizi[2];
                        if (rdBtnD.Checked == true)
                        {
                            dogruSayac++;
                            txtEditDogru.Text = dogruSayac.ToString();
                        }
                        else
                        {
                            yanlisSayac++;
                            txtEditYanlis.Text = yanlisSayac.ToString();
                        }
                        rdBtnD.Checked = false;
                        i++;
                        break;
                }

            

        }
*/
        private void Form1_Load(object sender, EventArgs e)
        {

            this.table_KelimelerTableAdapter.Fill(this.İngilizceTurkceSozlukDataSet.Table_Kelimeler);
           
            SqlCommand komut = new SqlCommand("select count (distinct (KelimeID)) from Table_Kelimeler",bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            int topEleman = 0;
            while (dr.Read())
            {
              topEleman=Convert.ToInt32(dr[0]);
            }
            bgl.baglanti().Close();
           

            SqlCommand komut1 = new SqlCommand("select top (4) KelimeID,KelimeTuru,İngilizceKelime,TurkceKarsılıgı,OrnekCumle  FROM Table_Kelimeler order by NEWID();", bgl.baglanti());
            SqlDataReader dr1 = komut1.ExecuteReader();
            List<string> turkceKelime = new List<string>();
            List<int> kelimeId = new List<int>();
            List<string> ingilizceKelime = new List<string>();
            List<string> ornekCumle = new List<string>();
            List<string> kelimeTur = new List<string>();
            while (dr1.Read())
            {
                ornekCumle.Add(dr1["OrnekCumle"].ToString());
                ingilizceKelime.Add(dr1["İngilizceKelime"].ToString());
                kelimeId.Add(Convert.ToInt32(dr1["KelimeID"]));
                turkceKelime.Add(dr1["TurkceKarsılıgı"].ToString());
                kelimeTur.Add(dr1["KelimeTuru"].ToString());
            }
            bgl.baglanti().Close();
            string[] turkceKelimeDizi = turkceKelime.ToArray();
            string[] ingilizceKelimeDizi = ingilizceKelime.ToArray();
            string[] ornekCumleDizi = ornekCumle.ToArray();
            string[] kelimeTurDizi = kelimeTur.ToArray();
            int[] kelimeIdDizi = kelimeId.ToArray();

            rdBtnA.Text = turkceKelimeDizi[0].ToString();
            rdBtnB.Text = turkceKelimeDizi[1].ToString();
            rdBtnC.Text = turkceKelimeDizi[2].ToString();
            rdBtnD.Text = turkceKelimeDizi[3].ToString();

            int randSayi = rnd.Next(1, 5);


            switch (randSayi)
            {
                case 1:
                    rdBtnA.Text = turkceKelimeDizi[0];
                    lblCtrlIngilizce.Text = ingilizceKelimeDizi[0];
                    lblCtrlCumle.Text = ornekCumleDizi[0];
                    lblCtrlTür.Text = kelimeTurDizi[0];
                    txtEditDogru.Text = dogruSayac.ToString();
                    txtEditYanlis.Text = yanlisSayac.ToString();
                    break;
                case 2:
                    rdBtnB.Text = turkceKelimeDizi[1];
                    lblCtrlIngilizce.Text = ingilizceKelimeDizi[1];
                    lblCtrlCumle.Text = ornekCumleDizi[1];
                    lblCtrlTür.Text = kelimeTurDizi[1];
                    txtEditDogru.Text = dogruSayac.ToString();
                    txtEditYanlis.Text = yanlisSayac.ToString();
                    break;
                case 3:
                    rdBtnC.Text = turkceKelimeDizi[2];
                    lblCtrlIngilizce.Text = ingilizceKelimeDizi[2];
                    lblCtrlCumle.Text = ornekCumleDizi[2];
                    lblCtrlTür.Text = kelimeTurDizi[2];
                    txtEditDogru.Text = dogruSayac.ToString();
                    txtEditYanlis.Text = yanlisSayac.ToString();
                    break;
                case 4:
                    rdBtnD.Text = turkceKelimeDizi[3];
                    lblCtrlIngilizce.Text = ingilizceKelimeDizi[3];
                    lblCtrlCumle.Text = ornekCumleDizi[3];
                    lblCtrlTür.Text = kelimeTurDizi[3];
                    txtEditDogru.Text = dogruSayac.ToString();
                    txtEditYanlis.Text = yanlisSayac.ToString();
                    break;


            }

          
        }

        public void KelimeEkle()
        {
            if (KontrolEt())
            {
                SqlCommand komut = new SqlCommand("insert into Table_Kelimeler (KelimeTuru,İngilizceKelime,TurkceKarsılıgı,OrnekCumle) values (@p1,@p2,@p3,@p4)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", cmbBoxEditTur.Text);
                komut.Parameters.AddWithValue("@p2", txtEditIngilizce.Text);
                komut.Parameters.AddWithValue("@p3", txtEditTurkce.Text);
                komut.Parameters.AddWithValue("@p4", txtEditCumle.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
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

        public bool KontrolEt()
        {
            bool isTrue = true;

            if ((txtEditTurkce.Text == "") || (txtEditIngilizce.Text == "") || (txtEditCumle.Text == "") || (cmbBoxEditTur.Text == ""))
                isTrue = false;
            else
                isTrue = true;

            return isTrue;
        }

        private void smpBtnEkle_Click(object sender, EventArgs e)
        {
            KelimeEkle();
        }

        private void smpBtnTamam_Click(object sender, EventArgs e)
        {
           
            /*
            SqlCommand komut = new SqlCommand("select count (distinct (KelimeID)) from Table_Kelimeler", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            int topEleman = 0;
            while (dr.Read())
            {
                topEleman = Convert.ToInt32(dr[0]);
            }
            bgl.baglanti().Close();
            */
          
            SqlCommand komut1 = new SqlCommand("select top (4) KelimeID,KelimeTuru,İngilizceKelime,TurkceKarsılıgı,OrnekCumle  FROM Table_Kelimeler order by NEWID();", bgl.baglanti());
            SqlDataReader dr1 = komut1.ExecuteReader();
            List<string> turkceKelime = new List<string>();
            List<int> kelimeId = new List<int>();
            List<string> ingilizceKelime = new List<string>();
            List<string> ornekCumle = new List<string>();
            List<string> kelimeTur = new List<string>();
            while (dr1.Read())
            {
                ornekCumle.Add(dr1["OrnekCumle"].ToString());
                ingilizceKelime.Add(dr1["İngilizceKelime"].ToString());
                kelimeId.Add(Convert.ToInt32(dr1["KelimeID"]));
                turkceKelime.Add(dr1["TurkceKarsılıgı"].ToString());
                kelimeTur.Add(dr1["KelimeTuru"].ToString());
            }
            bgl.baglanti().Close();
            string[] turkceKelimeDizi = turkceKelime.ToArray();
            string[] ingilizceKelimeDizi = ingilizceKelime.ToArray();
            string[] ornekCumleDizi = ornekCumle.ToArray();
            string[] kelimeTurDizi = kelimeTur.ToArray();
            int[] kelimeIdDizi = kelimeId.ToArray();

            rdBtnA.Text = turkceKelimeDizi[0].ToString();
            rdBtnB.Text = turkceKelimeDizi[1].ToString();
            rdBtnC.Text = turkceKelimeDizi[2].ToString();
            rdBtnD.Text = turkceKelimeDizi[3].ToString();

            int randSayi = rnd.Next(1, 5);


            switch (randSayi)
            {
                case 1:
                    rdBtnA.Text = turkceKelimeDizi[0];
                    lblCtrlIngilizce.Text = ingilizceKelimeDizi[0];
                    lblCtrlCumle.Text = ornekCumleDizi[0];
                    lblCtrlTür.Text = kelimeTurDizi[0];
                    if (rdBtnA.Checked == true)
                    {
                        dogruSayac++;
                        txtEditDogru.Text = dogruSayac.ToString();
                    }

                    else
                    {
                        yanlisSayac++;
                        txtEditYanlis.Text = yanlisSayac.ToString();
                    }
                    rdBtnA.Checked = false;
                    break;
                case 2:
                    rdBtnB.Text = turkceKelimeDizi[1];
                    lblCtrlIngilizce.Text = ingilizceKelimeDizi[1];
                    lblCtrlCumle.Text = ornekCumleDizi[1];
                    lblCtrlTür.Text = kelimeTurDizi[1];
                    if (rdBtnB.Checked == true)
                    {

                        dogruSayac++;
                        txtEditDogru.Text = dogruSayac.ToString();
                    }

                    else
                    {
                        yanlisSayac++;
                        txtEditYanlis.Text = yanlisSayac.ToString();
                    }
                    rdBtnB.Checked = false;
                    break;
                case 3:
                    rdBtnC.Text = turkceKelimeDizi[2];
                    lblCtrlIngilizce.Text = ingilizceKelimeDizi[2];
                    lblCtrlCumle.Text = ornekCumleDizi[2];
                    lblCtrlTür.Text = kelimeTurDizi[2];
                    if (rdBtnC.Checked == true)
                    {

                        dogruSayac++;
                        txtEditDogru.Text = dogruSayac.ToString();
                    }

                    else
                    {
                        yanlisSayac++;
                        txtEditYanlis.Text = yanlisSayac.ToString();
                    }
                    rdBtnC.Checked = false;
                    break;
                case 4:
                    rdBtnD.Text = turkceKelimeDizi[3];
                    lblCtrlIngilizce.Text = ingilizceKelimeDizi[3];
                    lblCtrlCumle.Text = ornekCumleDizi[3];
                    lblCtrlTür.Text = kelimeTurDizi[3];
                    if (rdBtnD.Checked == true)
                    {

                        dogruSayac++;
                        txtEditDogru.Text = dogruSayac.ToString();
                    }

                    else
                    {
                        yanlisSayac++;
                        txtEditYanlis.Text = yanlisSayac.ToString();
                    }
                    rdBtnD.Checked = false;
                    break;


            }
          
        }

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

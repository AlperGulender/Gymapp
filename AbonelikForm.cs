using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Gymapp
{
    public partial class AbonelikForm : Form
    {
        string aktifKullanici;
        string baglantiAdresi = @"Server=(localdb)\MSSQLLocalDB;Database=GymOtomasyon;Trusted_Connection=True;";

        public AbonelikForm(string girenKisi)
        {
            InitializeComponent();
            aktifKullanici = girenKisi;
        }

        private void AbonelikForm_Load(object sender, EventArgs e)
        {
            BilgileriGetir();
        }

        void BilgileriGetir()
        {
            using (SqlConnection baglanti = new SqlConnection(baglantiAdresi))
            {
                baglanti.Open();
                string sorgu = "SELECT UyelikTipi, BitisTarihi FROM Uyeler WHERE KullaniciAdi=@p1";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@p1", aktifKullanici);
                SqlDataReader dr = komut.ExecuteReader();

                if (dr.Read())
                {
                    string tip = dr["UyelikTipi"]?.ToString() ?? "Yok";
                    string tarih = dr["BitisTarihi"] != DBNull.Value ?
                                   Convert.ToDateTime(dr["BitisTarihi"]).ToShortDateString() : "Belirlenmedi";

                    lblMevcutDurum.Text = $"Paket: {tip} | Bitiş: {tarih}";
                }
                baglanti.Close();
            }
        }

        private void btnAboneOl_Click(object sender, EventArgs e)
        {
            if (cmbPaketler.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir paket seçin!");
                return;
            }

            DateTime bitis = DateTime.Now;

            // .Trim() komutu sağdaki soldaki yanlışlıkla konulmuş boşlukları temizler
            string secilen = cmbPaketler.SelectedItem.ToString().Trim();

            // Tarih Hesaplama
            if (secilen == "Günlük") bitis = bitis.AddDays(1);
            else if (secilen == "Haftalık") bitis = bitis.AddDays(7);
            else if (secilen == "1 Aylık") bitis = bitis.AddMonths(1);
            else if (secilen == "3 Aylık") bitis = bitis.AddMonths(3);
            else if (secilen == "6 Aylık") bitis = bitis.AddMonths(6);
            else
            {
                // EĞER İSİMLER EŞLEŞMEZSE UYARI VERECEK VE KAYDETMEYECEK
                MessageBox.Show("Hata: Kutuya yazdığınız '" + secilen + "' ismi kodla eşleşmedi! Lütfen ComboBox içindeki yazıları kontrol edin.");
                return; // İşlemi iptal et
            }

            using (SqlConnection baglanti = new SqlConnection(baglantiAdresi))
            {
                string sorgu = "UPDATE Uyeler SET UyelikTipi=@p1, BitisTarihi=@p2 WHERE KullaniciAdi=@p3";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@p1", secilen);
                komut.Parameters.AddWithValue("@p2", bitis);
                komut.Parameters.AddWithValue("@p3", aktifKullanici);

                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show($"Tebrikler! {secilen} paketiniz tanımlandı. Bitiş: {bitis.ToShortDateString()}");
                BilgileriGetir(); // Ekranı tazele
            }
        }
        private void btnGeri_Click(object sender, EventArgs e)
        {
            SecimForm secim = new SecimForm(aktifKullanici);
            secim.Show();
            this.Hide();
        }
    }
}

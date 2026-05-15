using Gymapp;
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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            // 1. Önce giriş yapan kişi "Patron" (Admin) mu diye kontrol edelim:
            if (txtKullaniciAdi.Text == "Gazi" && txtSifre.Text == "1926")
            {
                AdminForm adminEkrani = new AdminForm();
                adminEkrani.Show();
                this.Hide();
                return; // Admin girdiyse kodu burada kes, aşağıya inme!
            }

            // 2. Admin değilse, veritabanına bakıp "Bu kişi normal bir üye mi?" diye soralım:
            string baglantiAdresi = @"Server=(localdb)\MSSQLLocalDB;Database=GymOtomasyon;Trusted_Connection=True;";
            using (SqlConnection baglanti = new SqlConnection(baglantiAdresi))
            {
                baglanti.Open();

                string sorgu = "SELECT * FROM Uyeler WHERE KullaniciAdi=@k1 AND Sifre=@k2";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@k1", txtKullaniciAdi.Text);
                komut.Parameters.AddWithValue("@k2", txtSifre.Text);

                // ...
                SqlDataReader dr = komut.ExecuteReader();

                if (dr.Read())
                {
                    string uyeKullaniciAdi = dr["KullaniciAdi"].ToString();

                    // ESKİ KOD: UyeForm uyeEkrani = new UyeForm(uyeKullaniciAdi);
                    // YENİ KOD: Artık Seçim ekranını açıyoruz
                    SecimForm secimEkrani = new SecimForm(uyeKullaniciAdi);
                    secimEkrani.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı! Tekrar deneyin.");
                }
                // ...

                baglanti.Close();
            }
        }
        // 2. HESAP AÇ BUTONU (Yeni Kayıt için)
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 kayitEkrani = new Form1();
            kayitEkrani.ShowDialog(); // ShowDialog kullanıyoruz ki kayıt bitince bu ekranı kapatıp logine dönebilsin
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

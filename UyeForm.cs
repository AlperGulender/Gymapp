using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Gymapp
{
    public partial class UyeForm : Form
    {
        string aktifKullanici;
        string baglantiAdresi = @"Server=(localdb)\MSSQLLocalDB;Database=GymOtomasyon;Trusted_Connection=True;";

        public UyeForm(string girenKisi)
        {
            InitializeComponent();
            aktifKullanici = girenKisi;
        }

        // Tabloyu doldurma işlemini ayrı bir fonksiyona aldık ki her yerde kolayca çağıralım
        void ProgramlariGetir()
        {
            using (SqlConnection baglanti = new SqlConnection(baglantiAdresi))
            {
                string sorgu = "SELECT Gun, Egzersizler FROM SporProgrami WHERE KullaniciAdi=@k1";
                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);

                da.SelectCommand.Parameters.AddWithValue("@k1", aktifKullanici);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewProgram.DataSource = dt;
            }
        }

        private void UyeForm_Load(object sender, EventArgs e)
        {
            lblHosgeldin.Text = "Hoş Geldin, " + aktifKullanici + "! İşte Haftalık Programın:";
            ProgramlariGetir(); // Form açılırken listeyi getir
        }

        // YENİ EKLEDİĞİMİZ BUTONUN KODU:
        private void btnProgramEkle_Click(object sender, EventArgs e)
        {
            using (SqlConnection baglanti = new SqlConnection(baglantiAdresi))
            {
                string sorgu = "INSERT INTO SporProgrami (KullaniciAdi, Gun, Egzersizler) VALUES (@p1, @p2, @p3)";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);

                // @p1'e sistemdeki aktifKullanici'yi veriyoruz ki güvenli olsun
                komut.Parameters.AddWithValue("@p1", aktifKullanici);
                komut.Parameters.AddWithValue("@p2", cmbGun.SelectedItem?.ToString() ?? "");
                komut.Parameters.AddWithValue("@p3", txtEgzersizler.Text);

                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Egzersiz başarıyla eklendi!");

                // Kutu temizlensin ve yeni program anında tabloda görünsün:
                txtEgzersizler.Clear();
                ProgramlariGetir();
            }
        }

        private void btnProgramSil_Click(object sender, EventArgs e)
        {
            // 1. Önce kullanıcı tablodan gerçekten bir satır seçmiş mi diye kontrol ediyoruz
            if (dataGridViewProgram.SelectedRows.Count > 0)
            {
                // 2. Seçilen satırdaki "Gun" ve "Egzersizler" verilerini alıyoruz
                string secilenGun = dataGridViewProgram.SelectedRows[0].Cells["Gun"].Value.ToString();
                string secilenEgzersiz = dataGridViewProgram.SelectedRows[0].Cells["Egzersizler"].Value.ToString();

                // 3. Yanlışlıkla basmalara karşı emin misin diye soralım (Profesyonel bir detaydır)
                DialogResult cevap = MessageBox.Show(secilenGun + " günündeki programı silmek istediğine emin misin?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (cevap == DialogResult.Yes)
                {
                    using (SqlConnection baglanti = new SqlConnection(baglantiAdresi))
                    {
                        // SADECE aktif kullanıcının, seçtiği gün ve egzersizle eşleşen kaydını sil
                        string sorgu = "DELETE FROM SporProgrami WHERE KullaniciAdi=@p1 AND Gun=@p2 AND Egzersizler=@p3";
                        SqlCommand komut = new SqlCommand(sorgu, baglanti);

                        komut.Parameters.AddWithValue("@p1", aktifKullanici);
                        komut.Parameters.AddWithValue("@p2", secilenGun);
                        komut.Parameters.AddWithValue("@p3", secilenEgzersiz);

                        baglanti.Open();
                        komut.ExecuteNonQuery();
                        baglanti.Close();

                        MessageBox.Show("Egzersiz başarıyla silindi!");

                        // Tabloyu saniyesinde yenileyelim ki silinen veri ekrandan gitsin
                        ProgramlariGetir();
                    }
                }
            }
            else
            {
                // Eğer kullanıcı sadece bir hücreye tıkladıysa veya hiçbir şey seçmediyse uyaralım
                MessageBox.Show("Lütfen silmek istediğiniz programın satırını tamamen seçin (Satırın en solundaki boş kısma tıklayarak).");
            }
        }

        private void AdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); // Tüm gizli formları ve programı tamamen kapatır
        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            // Seçim ekranını tekrar oluştururken, kimin geri döndüğünü bilsin diye adını çantasına koyuyoruz
            SecimForm secimEkrani = new SecimForm(aktifKullanici);
            secimEkrani.Show();

            // Şu anki bulunduğumuz Spor Programı ekranını gizliyoruz
            this.Hide();
        }
    }
}

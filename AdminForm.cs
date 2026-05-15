using Microsoft.Data.SqlClient;
using System.Data;

namespace Gymapp
{
    public partial class AdminForm : Form
    {
        string baglantiAdresi = @"Server=(localdb)\MSSQLLocalDB;Database=GymOtomasyon;Trusted_Connection=True;";

        public AdminForm()
        {
            InitializeComponent();
        }

        // 1. YARDIMCI FONKSİYON: Tabloyu doldurma işlemini buraya aldık
        // 1. MEVCUT LİSTELEME FONKSİYONUMUZ (Bunun sadece sonuna KazancHesapla ekledik)
        void UyeleriListele()
        {
            using (SqlConnection baglanti = new SqlConnection(baglantiAdresi))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Uyeler", baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }

            // TABLO YENİLENDİKTEN HEMEN SONRA KAZANCI HESAPLA!
            KazancHesapla();
        }

        // 2. YENİ EKLEYECEĞİMİZ KAZANÇ HESAPLAMA FONKSİYONU
        void KazancHesapla()
        {
            int toplamKazanc = 0;

            // Tablodaki tüm satırları tek tek dönüyoruz
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                // Boş "yeni kayıt" satırını atla
                if (!dataGridView1.Rows[i].IsNewRow)
                {
                    // O satırdaki kişinin paketini al (Boşsa hata vermemesi için önlem alıyoruz)
                    string paket = dataGridView1.Rows[i].Cells["UyelikTipi"].Value?.ToString() ?? "";

                    // Paketine göre kasaya para ekle
                    if (paket == "Günlük") toplamKazanc += 50;
                    else if (paket == "Haftalık") toplamKazanc += 350;
                    else if (paket == "1 Aylık") toplamKazanc += 1400;
                    else if (paket == "3 Aylık") toplamKazanc += 4200;
                    else if (paket == "6 Aylık") toplamKazanc += 8400;
                }
            }

            // Çıkan sonucu Label'a yazdır
            lblToplamKazanc.Text = "Toplam Kazanç: " + toplamKazanc.ToString() + " TL";
        }

        // 2. FORM AÇILDIĞINDA ÇALIŞACAK KOD
        private void AdminForm_Load(object sender, EventArgs e)
        {
            UyeleriListele(); // Form açılır açılmaz üyeleri listele
        }

        // 3. ARAMA KUTUSU KODLARI (TextBox'ın TextChanged olayı)
        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection baglanti = new SqlConnection(baglantiAdresi))
            {
                // LIKE ve % ile ismin içinde geçen harfleri ararız
                string sorgu = "SELECT * FROM Uyeler WHERE AdSoyad LIKE '%' + @p1 + '%'";
                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);

                da.SelectCommand.Parameters.AddWithValue("@p1", txtArama.Text);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt; // Tabloyu çıkan sonuçlarla güncelle
            }
        }

        // 4. SİLME BUTONU KODLARI
        private void btnUyeSil_Click(object sender, EventArgs e)
        {
            // Kullanıcı gerçekten tablodan birini seçmiş mi?
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // ARTIK SİLME İŞLEMİNİ GARANTİ OLAN "Id" NUMARASINDAN YAPACAĞIZ
                int seciliId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
                string seciliIsim = dataGridView1.SelectedRows[0].Cells["AdSoyad"].Value.ToString();

                // Kullanıcı adı boş olabilir diye '?.' ve '??' koyarak önlem alıyoruz
                string seciliKullaniciAdi = dataGridView1.SelectedRows[0].Cells["KullaniciAdi"].Value?.ToString() ?? "";

                DialogResult cevap = MessageBox.Show(seciliIsim + " isimli üyeyi sistemden kalıcı olarak silmek istediğinize emin misiniz?", "Kalıcı Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                if (cevap == DialogResult.Yes)
                {
                    using (SqlConnection baglanti = new SqlConnection(baglantiAdresi))
                    {
                        baglanti.Open();

                        // 1. Eğer kullanıcının bir kullanıcı adı varsa, önce spor programlarını temizle
                        if (!string.IsNullOrEmpty(seciliKullaniciAdi))
                        {
                            SqlCommand komutProgramSil = new SqlCommand("DELETE FROM SporProgrami WHERE KullaniciAdi=@k1", baglanti);
                            komutProgramSil.Parameters.AddWithValue("@k1", seciliKullaniciAdi);
                            komutProgramSil.ExecuteNonQuery();
                        }

                        // 2. ÜYEYİ KESİN OLARAK EŞSİZ "Id" NUMARASINA GÖRE SİL
                        SqlCommand komutUyeSil = new SqlCommand("DELETE FROM Uyeler WHERE Id=@id", baglanti);
                        komutUyeSil.Parameters.AddWithValue("@id", seciliId);
                        komutUyeSil.ExecuteNonQuery();

                        baglanti.Close();

                        MessageBox.Show("Üye sistemden tamamen temizlendi.");
                        UyeleriListele(); // Tabloyu yenile
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz üyenin üzerine tıklayarak seçin.");
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            // Yeni bir giriş ekranı oluştur ve göster
            LoginForm loginEkrani = new LoginForm();
            loginEkrani.Show();

            // Şu anki açık olan Admin panelini kapat
            this.Hide();
        }

        private void AdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); // Tüm gizli formları ve programı tamamen kapatır
        }

        // Bunu formun üst kısımlarına, baglantiAdresi'nin hemen altına ekleyin:
        int seciliUyeId = 0;

        // Bu da az önce çift tıklayarak oluşturduğunuz CellClick fonksiyonu:
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Eğer başlık satırına değil de gerçekten bir veriye tıklandıysa (RowIndex >= 0)
            if (e.RowIndex >= 0)
            {
                // Tıklanan satırı hafızaya al
                DataGridViewRow satir = dataGridView1.Rows[e.RowIndex];

                // Tıklanan kişinin eşsiz Id'sini hafızada tutuyoruz ki kimi güncelleyeceğimizi bilelim
                seciliUyeId = Convert.ToInt32(satir.Cells["Id"].Value);

                // Satırdaki diğer bilgileri kutulara doldur
                txtAdSoyad.Text = satir.Cells["AdSoyad"].Value.ToString();
                txtTelefon.Text = satir.Cells["Telefon"].Value.ToString();
                txtYas.Text = satir.Cells["Yas"].Value.ToString();
                cmbCinsiyet.Text = satir.Cells["Cinsiyet"].Value.ToString();
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            // 0. SEÇİM KONTROLÜ: Yönetici tablodan birini seçmiş mi?
            if (seciliUyeId == 0)
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz üyeyi tablodan seçin.");
                return;
            }

            // 1. BOŞLUK KONTROLÜ: Herhangi bir kutu boş bırakılmış mı?
            if (string.IsNullOrWhiteSpace(txtAdSoyad.Text) ||
                string.IsNullOrWhiteSpace(txtTelefon.Text) ||
                string.IsNullOrWhiteSpace(txtYas.Text) ||
                cmbCinsiyet.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen üye bilgilerini eksiksiz doldurun!", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. TELEFON KONTROLÜ: Numara eksik mi girilmiş?
            if (!txtTelefon.MaskFull)
            {
                MessageBox.Show("Lütfen telefon numarasını eksiksiz girin!", "Eksik Numara", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. YAŞ KONTROLÜ: Yaş 0 veya negatif mi?
            int yas;
            if (!int.TryParse(txtYas.Text, out yas) || yas <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir yaş girin! Yaş 0 veya negatif olamaz.", "Hatalı Yaş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. GÜNCELLEME AŞAMASI: Tüm güvenlik testlerinden geçildiyse SQL'i güncelle
            using (SqlConnection baglanti = new SqlConnection(baglantiAdresi))
            {
                string sorgu = "UPDATE Uyeler SET AdSoyad=@p1, Telefon=@p2, Yas=@p3, Cinsiyet=@p4 WHERE Id=@id";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);

                komut.Parameters.AddWithValue("@p1", txtAdSoyad.Text.Trim());
                komut.Parameters.AddWithValue("@p2", txtTelefon.Text.Trim());
                komut.Parameters.AddWithValue("@p3", yas); // Güvenlikten geçen 'yas' değişkenini kullandık
                komut.Parameters.AddWithValue("@p4", cmbCinsiyet.SelectedItem.ToString());
                komut.Parameters.AddWithValue("@id", seciliUyeId); // Kimi güncellediğimizi unutmuyoruz

                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Üye bilgileri başarıyla güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                UyeleriListele(); // Tabloyu yenile

                // Kutuları temizleyelim
                seciliUyeId = 0;
                txtAdSoyad.Clear();
                txtTelefon.Clear();
                txtYas.Clear();
                cmbCinsiyet.SelectedIndex = -1;
            }
        }
    }
}

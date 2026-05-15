using System.Data;
using Microsoft.Data.SqlClient;

namespace Gymapp
{
    public partial class Form1 : Form
    {
        string baglantiAdresi = @"Server=(localdb)\MSSQLLocalDB;Database=GymOtomasyon;Trusted_Connection=True;";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // 1. BOŞLUK KONTROLÜ: Herhangi bir kutu boş bırakılmış mı?
            if (string.IsNullOrWhiteSpace(txtAdSoyad.Text) ||
                string.IsNullOrWhiteSpace(txtTelefon.Text) ||
                string.IsNullOrWhiteSpace(txtYas.Text) ||
                cmbCinsiyet.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtKullaniciAdi.Text) ||
                string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                MessageBox.Show("Lütfen hesap açmak için tüm bilgileri eksiksiz doldurun!", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. TELEFON KONTROLÜ: Numara eksik mi girilmiş?
            // Eğer telefonu MaskedTextBox ile yaptıysan '.MaskFull' komutu maskenin tamamen dolup dolmadığına bakar.
            // (Eğer normal TextBox kullanıyorsan bu satırı silip yerine şunu yazabilirsin: if (txtTelefon.Text.Length < 10) )
            if (!txtTelefon.MaskFull)
            {
                MessageBox.Show("Lütfen telefon numarasını eksiksiz girin!", "Eksik Numara", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. YAŞ KONTROLÜ: Yaş 0 veya negatif mi? Sayı yerine harf mi yazılmış?
            int yas;
            // int.TryParse komutu kutudaki yazıyı tam sayıya (int) çevirmeye çalışır. 
            // Çeviremezse (harf vs. varsa) VEYA sayı 0 ve daha küçükse hata verir.
            if (!int.TryParse(txtYas.Text, out yas) || yas <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir yaş girin! Yaş 0 veya negatif olamaz.", "Hatalı Yaş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. KAYIT AŞAMASI: Tüm güvenlik testlerinden geçildiyse SQL'e kaydet
            using (SqlConnection baglanti = new SqlConnection(baglantiAdresi))
            {
                string sorgu = "INSERT INTO Uyeler (AdSoyad, Telefon, Yas, Cinsiyet, KullaniciAdi, Sifre) VALUES (@p1, @p2, @p3, @p4, @p5, @p6)";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);

                komut.Parameters.AddWithValue("@p1", txtAdSoyad.Text.Trim());
                komut.Parameters.AddWithValue("@p2", txtTelefon.Text.Trim());
                komut.Parameters.AddWithValue("@p3", yas); // Artık yukarıda kontrol ettiğimiz güvenli 'yas' değişkenini kullanıyoruz
                komut.Parameters.AddWithValue("@p4", cmbCinsiyet.SelectedItem.ToString());
                komut.Parameters.AddWithValue("@p5", txtKullaniciAdi.Text.Trim());
                komut.Parameters.AddWithValue("@p6", txtSifre.Text.Trim());

                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Hesap başarıyla oluşturuldu! Artık giriş yapabilirsiniz.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Login'e dön
            }
        }
        private void txtAdSoyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Eğer basılan tuş harf değilse (IsLetter),
            // kontrol tuşu (Backspace gibi) değilse (IsControl)
            // ve boşluk karakteri değilse (IsSeparator)
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                e.Handled = true; // Bu tuş basımını yok say (kutuya yazma)
            }
        }
    }
}

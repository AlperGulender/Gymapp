using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Gymapp
{
    public partial class SecimForm : Form
    {
        string aktifKullanici;

        // Login'den gelen ismi burada karşılıyoruz
        public SecimForm(string girenKisi)
        {
            InitializeComponent();
            aktifKullanici = girenKisi;
        }

        // SPOR PROGRAMIM BUTONU KODLARI
        private void btnProgram_Click(object sender, EventArgs e)
        {
            // İsmi UyeForm'a paslıyoruz
            UyeForm uyeEkrani = new UyeForm(aktifKullanici);
            uyeEkrani.Show();
            this.Hide(); // Seçim ekranını gizle
        }

        // ABONELİK YÖNETİMİ BUTONU KODLARI
        private void btnAbonelik_Click(object sender, EventArgs e)
        {
            // İsmi AbonelikForm'a paslıyoruz
            AbonelikForm abonelikEkrani = new AbonelikForm(aktifKullanici);
            abonelikEkrani.Show();
            this.Hide(); // Seçim ekranını gizle
        }

        private void SecimForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); // Çarpıdan kapanırsa programı bitir
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

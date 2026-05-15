namespace Gymapp
{
    partial class AbonelikForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblMevcutDurum = new Label();
            cmbPaketler = new ComboBox();
            btnAboneOl = new Button();
            btnGeri = new Button();
            SuspendLayout();
            // 
            // lblMevcutDurum
            // 
            lblMevcutDurum.AutoSize = true;
            lblMevcutDurum.Location = new Point(573, 26);
            lblMevcutDurum.Name = "lblMevcutDurum";
            lblMevcutDurum.Size = new Size(50, 20);
            lblMevcutDurum.TabIndex = 0;
            lblMevcutDurum.Text = "label1";
            // 
            // cmbPaketler
            // 
            cmbPaketler.FormattingEnabled = true;
            cmbPaketler.Items.AddRange(new object[] { "Günlük", "Haftalık", "1 Aylık", "3 Aylık", "6 Aylık" });
            cmbPaketler.Location = new Point(474, 65);
            cmbPaketler.Name = "cmbPaketler";
            cmbPaketler.Size = new Size(241, 28);
            cmbPaketler.TabIndex = 1;
            // 
            // btnAboneOl
            // 
            btnAboneOl.Location = new Point(507, 99);
            btnAboneOl.Name = "btnAboneOl";
            btnAboneOl.Size = new Size(178, 29);
            btnAboneOl.TabIndex = 2;
            btnAboneOl.Text = "Üyeliği Başlat / Güncelle";
            btnAboneOl.UseVisualStyleBackColor = true;
            btnAboneOl.Click += btnAboneOl_Click;
            // 
            // btnGeri
            // 
            btnGeri.Location = new Point(507, 134);
            btnGeri.Name = "btnGeri";
            btnGeri.Size = new Size(178, 29);
            btnGeri.TabIndex = 3;
            btnGeri.Text = "Seçim Ekranına Dön";
            btnGeri.UseVisualStyleBackColor = true;
            btnGeri.Click += btnGeri_Click;
            // 
            // AbonelikForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1330, 450);
            Controls.Add(btnGeri);
            Controls.Add(btnAboneOl);
            Controls.Add(cmbPaketler);
            Controls.Add(lblMevcutDurum);
            Name = "AbonelikForm";
            Text = "AbonelikForm";
            Load += AbonelikForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMevcutDurum;
        private ComboBox cmbPaketler;
        private Button btnAboneOl;
        private Button btnGeri;
    }
}

namespace Gymapp
{
    partial class AdminForm
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
            dataGridView1 = new DataGridView();
            label1 = new Label();
            txtArama = new TextBox();
            btnUyeSil = new Button();
            btnCikis = new Button();
            label2 = new Label();
            txtAdSoyad = new TextBox();
            label3 = new Label();
            txtTelefon = new MaskedTextBox();
            label4 = new Label();
            txtYas = new TextBox();
            cmbCinsiyet = new ComboBox();
            label5 = new Label();
            btnGuncelle = new Button();
            lblToplamKazanc = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 134);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1305, 182);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(281, 35);
            label1.Name = "label1";
            label1.Size = new Size(110, 20);
            label1.TabIndex = 1;
            label1.Text = "İsim ile Üye ara";
            // 
            // txtArama
            // 
            txtArama.Location = new Point(433, 35);
            txtArama.Name = "txtArama";
            txtArama.Size = new Size(261, 27);
            txtArama.TabIndex = 2;
            txtArama.TextChanged += txtArama_TextChanged;
            // 
            // btnUyeSil
            // 
            btnUyeSil.BackColor = Color.Brown;
            btnUyeSil.ForeColor = SystemColors.Control;
            btnUyeSil.Location = new Point(433, 90);
            btnUyeSil.Name = "btnUyeSil";
            btnUyeSil.Size = new Size(94, 29);
            btnUyeSil.TabIndex = 3;
            btnUyeSil.Text = "Üye Sil";
            btnUyeSil.UseVisualStyleBackColor = false;
            btnUyeSil.Click += btnUyeSil_Click;
            // 
            // btnCikis
            // 
            btnCikis.BackColor = SystemColors.ControlDark;
            btnCikis.Location = new Point(559, 90);
            btnCikis.Name = "btnCikis";
            btnCikis.Size = new Size(94, 29);
            btnCikis.TabIndex = 4;
            btnCikis.Text = "Geri Dön";
            btnCikis.UseVisualStyleBackColor = false;
            btnCikis.Click += btnCikis_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(67, 336);
            label2.Name = "label2";
            label2.Size = new Size(28, 20);
            label2.TabIndex = 5;
            label2.Text = "Ad";
            // 
            // txtAdSoyad
            // 
            txtAdSoyad.Location = new Point(23, 359);
            txtAdSoyad.Name = "txtAdSoyad";
            txtAdSoyad.Size = new Size(125, 27);
            txtAdSoyad.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(212, 336);
            label3.Name = "label3";
            label3.Size = new Size(28, 20);
            label3.TabIndex = 5;
            label3.Text = "Tel";
            // 
            // txtTelefon
            // 
            txtTelefon.Location = new Point(168, 359);
            txtTelefon.Mask = "(999) 000-0000";
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new Size(125, 27);
            txtTelefon.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(363, 336);
            label4.Name = "label4";
            label4.Size = new Size(30, 20);
            label4.TabIndex = 5;
            label4.Text = "Yaş";
            // 
            // txtYas
            // 
            txtYas.Location = new Point(322, 359);
            txtYas.Name = "txtYas";
            txtYas.Size = new Size(125, 27);
            txtYas.TabIndex = 8;
            // 
            // cmbCinsiyet
            // 
            cmbCinsiyet.FormattingEnabled = true;
            cmbCinsiyet.Items.AddRange(new object[] { "Erkek", "Kadın" });
            cmbCinsiyet.Location = new Point(477, 358);
            cmbCinsiyet.Name = "cmbCinsiyet";
            cmbCinsiyet.Size = new Size(151, 28);
            cmbCinsiyet.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(516, 335);
            label5.Name = "label5";
            label5.Size = new Size(60, 20);
            label5.TabIndex = 5;
            label5.Text = "Cinsiyet";
            // 
            // btnGuncelle
            // 
            btnGuncelle.Location = new Point(669, 359);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new Size(94, 29);
            btnGuncelle.TabIndex = 10;
            btnGuncelle.Text = "Güncelle";
            btnGuncelle.UseVisualStyleBackColor = true;
            btnGuncelle.Click += btnGuncelle_Click;
            // 
            // lblToplamKazanc
            // 
            lblToplamKazanc.BackColor = Color.FromArgb(128, 255, 128);
            lblToplamKazanc.ForeColor = SystemColors.ControlText;
            lblToplamKazanc.ImageAlign = ContentAlignment.TopCenter;
            lblToplamKazanc.Location = new Point(23, 411);
            lblToplamKazanc.Name = "lblToplamKazanc";
            lblToplamKazanc.Size = new Size(740, 25);
            lblToplamKazanc.TabIndex = 11;
            lblToplamKazanc.Text = "Toplam Kazanç: 0 TL";
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1329, 655);
            Controls.Add(lblToplamKazanc);
            Controls.Add(btnGuncelle);
            Controls.Add(cmbCinsiyet);
            Controls.Add(txtYas);
            Controls.Add(txtTelefon);
            Controls.Add(txtAdSoyad);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnCikis);
            Controls.Add(btnUyeSil);
            Controls.Add(txtArama);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "AdminForm";
            Text = " ";
            FormClosed += AdminForm_FormClosed;
            Load += AdminForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private TextBox txtArama;
        private Button btnUyeSil;
        private Button btnCikis;
        private Label label2;
        private TextBox txtAdSoyad;
        private Label label3;
        private MaskedTextBox txtTelefon;
        private Label label4;
        private TextBox txtYas;
        private ComboBox cmbCinsiyet;
        private Label label5;
        private Button btnGuncelle;
        private Label lblToplamKazanc;
    }
}

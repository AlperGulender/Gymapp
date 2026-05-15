namespace Gymapp
{
    partial class UyeForm
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
            dataGridViewProgram = new DataGridView();
            cmbGun = new ComboBox();
            txtEgzersizler = new TextBox();
            label1 = new Label();
            Eg = new Label();
            label2 = new Label();
            btnProgramEkle = new Button();
            btnProgramSil = new Button();
            lblHosgeldin = new Label();
            btnGeriDon = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProgram).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewProgram
            // 
            dataGridViewProgram.AllowUserToAddRows = false;
            dataGridViewProgram.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProgram.Location = new Point(280, 52);
            dataGridViewProgram.Name = "dataGridViewProgram";
            dataGridViewProgram.RowHeadersWidth = 51;
            dataGridViewProgram.Size = new Size(773, 188);
            dataGridViewProgram.TabIndex = 1;
            // 
            // cmbGun
            // 
            cmbGun.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGun.FormattingEnabled = true;
            cmbGun.Items.AddRange(new object[] { "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi", "Pazar" });
            cmbGun.Location = new Point(297, 260);
            cmbGun.Name = "cmbGun";
            cmbGun.Size = new Size(151, 28);
            cmbGun.TabIndex = 2;
            // 
            // txtEgzersizler
            // 
            txtEgzersizler.Location = new Point(523, 255);
            txtEgzersizler.Multiline = true;
            txtEgzersizler.Name = "txtEgzersizler";
            txtEgzersizler.Size = new Size(472, 34);
            txtEgzersizler.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(280, 29);
            label1.Name = "label1";
            label1.Size = new Size(66, 20);
            label1.TabIndex = 4;
            label1.Text = "Program";
            // 
            // Eg
            // 
            Eg.AutoSize = true;
            Eg.Location = new Point(256, 263);
            Eg.Name = "Eg";
            Eg.Size = new Size(35, 20);
            Eg.TabIndex = 5;
            Eg.Text = "Gün";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(454, 263);
            label2.Name = "label2";
            label2.Size = new Size(63, 20);
            label2.TabIndex = 6;
            label2.Text = "Egzersiz";
            // 
            // btnProgramEkle
            // 
            btnProgramEkle.Location = new Point(297, 294);
            btnProgramEkle.Name = "btnProgramEkle";
            btnProgramEkle.Size = new Size(330, 29);
            btnProgramEkle.TabIndex = 7;
            btnProgramEkle.Text = "Programa Ekle";
            btnProgramEkle.UseVisualStyleBackColor = true;
            btnProgramEkle.Click += btnProgramEkle_Click;
            // 
            // btnProgramSil
            // 
            btnProgramSil.ForeColor = Color.Brown;
            btnProgramSil.Location = new Point(658, 294);
            btnProgramSil.Name = "btnProgramSil";
            btnProgramSil.Size = new Size(337, 29);
            btnProgramSil.TabIndex = 8;
            btnProgramSil.Text = "Program Sil";
            btnProgramSil.UseVisualStyleBackColor = true;
            btnProgramSil.Click += btnProgramSil_Click;
            // 
            // lblHosgeldin
            // 
            lblHosgeldin.AutoSize = true;
            lblHosgeldin.Location = new Point(604, 9);
            lblHosgeldin.Name = "lblHosgeldin";
            lblHosgeldin.Size = new Size(50, 20);
            lblHosgeldin.TabIndex = 9;
            lblHosgeldin.Text = "label3";
            // 
            // btnGeriDon
            // 
            btnGeriDon.Location = new Point(536, 329);
            btnGeriDon.Name = "btnGeriDon";
            btnGeriDon.Size = new Size(195, 29);
            btnGeriDon.TabIndex = 10;
            btnGeriDon.Text = "Seçim Ekranına Dön";
            btnGeriDon.UseVisualStyleBackColor = true;
            btnGeriDon.Click += btnGeriDon_Click;
            // 
            // UyeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1359, 450);
            Controls.Add(btnGeriDon);
            Controls.Add(lblHosgeldin);
            Controls.Add(btnProgramSil);
            Controls.Add(btnProgramEkle);
            Controls.Add(label2);
            Controls.Add(Eg);
            Controls.Add(label1);
            Controls.Add(txtEgzersizler);
            Controls.Add(cmbGun);
            Controls.Add(dataGridViewProgram);
            Name = "UyeForm";
            Text = "UyeForm";
            Load += UyeForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewProgram).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridViewProgram;
        private ComboBox cmbGun;
        private TextBox txtEgzersizler;
        private Label label1;
        private Label Eg;
        private Label label2;
        private Button btnProgramEkle;
        private Button btnProgramSil;
        private Label lblHosgeldin;
        private Button btnGeriDon;
    }
}

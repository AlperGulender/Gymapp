namespace Gymapp
{
    partial class SecimForm
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
            btnProgram = new Button();
            btnAbonelik = new Button();
            label1 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // btnProgram
            // 
            btnProgram.Location = new Point(498, 147);
            btnProgram.Name = "btnProgram";
            btnProgram.Size = new Size(320, 29);
            btnProgram.TabIndex = 0;
            btnProgram.Text = "Spor Programım";
            btnProgram.UseVisualStyleBackColor = true;
            btnProgram.Click += btnProgram_Click;
            // 
            // btnAbonelik
            // 
            btnAbonelik.Location = new Point(498, 216);
            btnAbonelik.Name = "btnAbonelik";
            btnAbonelik.Size = new Size(320, 29);
            btnAbonelik.TabIndex = 1;
            btnAbonelik.Text = "Abonelik Yönetim";
            btnAbonelik.UseVisualStyleBackColor = true;
            btnAbonelik.Click += btnAbonelik_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(526, 103);
            label1.Name = "label1";
            label1.Size = new Size(269, 20);
            label1.TabIndex = 2;
            label1.Text = "Lütfen yapmak istediğiniz işlemi seçiniz";
            // 
            // button1
            // 
            button1.Location = new Point(607, 265);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 3;
            button1.Text = "Çıkış";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // SecimForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1319, 450);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(btnAbonelik);
            Controls.Add(btnProgram);
            Name = "SecimForm";
            Text = "SecimForm";
            FormClosed += SecimForm_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnProgram;
        private Button btnAbonelik;
        private Label label1;
        private Button button1;
    }
}

namespace GelirGiderAnaliziUI
{
    partial class GiderIslem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">True if managed resources should be disposed; otherwise, False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            dgvGiderIslemler = new DataGridView();
            btnListele = new Button();
            btnEkle = new Button();
            btnSil = new Button();
            btnGuncelle = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvGiderIslemler).BeginInit();
            SuspendLayout();
            // 
            // dgvGiderIslemler
            // 
            dgvGiderIslemler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGiderIslemler.Location = new Point(12, 12);
            dgvGiderIslemler.Name = "dgvGiderIslemler";
            dgvGiderIslemler.RowHeadersWidth = 51;
            dgvGiderIslemler.Size = new Size(760, 400);
            dgvGiderIslemler.TabIndex = 0;
            // 
            // btnListele
            // 
            btnListele.Location = new Point(236, 420);
            btnListele.Name = "btnListele";
            btnListele.Size = new Size(75, 29);
            btnListele.TabIndex = 1;
            btnListele.Text = "Listele";
            btnListele.UseVisualStyleBackColor = true;
            btnListele.Click += btnListele_Click;
            // 
            // btnEkle
            // 
            btnEkle.Location = new Point(317, 420);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(75, 29);
            btnEkle.TabIndex = 2;
            btnEkle.Text = "Ekle";
            btnEkle.UseVisualStyleBackColor = true;
            btnEkle.Click += btnEkle_Click;
            // 
            // btnSil
            // 
            btnSil.Location = new Point(398, 420);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(75, 29);
            btnSil.TabIndex = 3;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // btnGuncelle
            // 
            btnGuncelle.Location = new Point(479, 420);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new Size(75, 29);
            btnGuncelle.TabIndex = 4;
            btnGuncelle.Text = "Güncelle";
            btnGuncelle.UseVisualStyleBackColor = true;
            btnGuncelle.Click += btnGuncelle_Click;
            // 
            // GiderIslem
            // 
            ClientSize = new Size(784, 461);
            Controls.Add(btnGuncelle);
            Controls.Add(btnSil);
            Controls.Add(btnEkle);
            Controls.Add(btnListele);
            Controls.Add(dgvGiderIslemler);
            Name = "GiderIslem";
            Text = "Gider İşlemleri";
            Load += GiderIslem_Load;
            ((System.ComponentModel.ISupportInitialize)dgvGiderIslemler).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGiderIslemler;
        private System.Windows.Forms.Button btnListele;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnGuncelle;
    }
}

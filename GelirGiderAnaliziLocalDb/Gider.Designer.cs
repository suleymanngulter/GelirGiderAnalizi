namespace GelirGiderAnaliziLocalDb
{
    partial class Gider
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Kullanılan tüm kaynakları temizler.
        /// </summary>
        /// <param name="disposing">Yönetilen kaynakları bırakmak için true; aksi halde false.</param>
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
        /// Tasarımcı desteği için gerekli metot - bu metodun içeriğini kod düzenleyicisiyle değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            dgvGiderler = new DataGridView();
            btnEkle = new Button();
            btnSil = new Button();
            btnGuncelle = new Button();
            lblTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvGiderler).BeginInit();
            SuspendLayout();
            // 
            // dgvGiderler
            // 
            dgvGiderler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGiderler.Location = new Point(16, 57);
            dgvGiderler.Margin = new Padding(4, 5, 4, 5);
            dgvGiderler.Name = "dgvGiderler";
            dgvGiderler.RowHeadersWidth = 51;
            dgvGiderler.Size = new Size(1013, 462);
            dgvGiderler.TabIndex = 0;
            // 
            // btnEkle
            // 
            btnEkle.Location = new Point(358, 529);
            btnEkle.Margin = new Padding(4, 5, 4, 5);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(100, 46);
            btnEkle.TabIndex = 1;
            btnEkle.Text = "Ekle";
            btnEkle.UseVisualStyleBackColor = true;
            btnEkle.Click += btnEkle_Click;
            // 
            // btnSil
            // 
            btnSil.Location = new Point(475, 529);
            btnSil.Margin = new Padding(4, 5, 4, 5);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(100, 46);
            btnSil.TabIndex = 2;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // btnGuncelle
            // 
            btnGuncelle.Location = new Point(595, 529);
            btnGuncelle.Margin = new Padding(4, 5, 4, 5);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new Size(100, 46);
            btnGuncelle.TabIndex = 3;
            btnGuncelle.Text = "Güncelle";
            btnGuncelle.UseVisualStyleBackColor = true;
            btnGuncelle.Click += btnGuncelle_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(16, 14);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(188, 29);
            lblTitle.TabIndex = 4;
            lblTitle.Text = "Gider Yönetimi";
            // 
            // Gider
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1045, 586);
            Controls.Add(lblTitle);
            Controls.Add(btnGuncelle);
            Controls.Add(btnSil);
            Controls.Add(btnEkle);
            Controls.Add(dgvGiderler);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Gider";
            Text = "Gider Yönetim Formu";
            ((System.ComponentModel.ISupportInitialize)dgvGiderler).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGiderler;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Label lblTitle;
    }
}

namespace GelirGiderAnaliziLocalDb
{
    partial class GiderIslem
    {
        /// <summary>
        /// Gereksiz bileşenleri temizlemek için kullanılan bileşen.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Temizleme işlemi.
        /// </summary>
        /// <param name="disposing">Yönetilen kaynaklar temizlenecek mi?</param>
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
        /// Gerekli olan yöntemler için tasarımcı desteği. 
        /// Bu metodu form tasarımcı tarafından kullanılacak şekilde değiştirilemez. 
        /// Kodunuzu burada yazmak yerine, bu dosyadaki tasarımcıyı kullanın.
        /// </summary>
        private void InitializeComponent()
        {
            dgvGiderler = new DataGridView();
            btnListeleGiderler = new Button();
            btnEkle = new Button();
            btnSil = new Button();
            btnGuncelle = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvGiderler).BeginInit();
            SuspendLayout();
            // 
            // dgvGiderler
            // 
            dgvGiderler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGiderler.Location = new Point(12, 12);
            dgvGiderler.Name = "dgvGiderler";
            dgvGiderler.RowHeadersWidth = 51;
            dgvGiderler.Size = new Size(760, 400);
            dgvGiderler.TabIndex = 0;
            // 
            // btnListeleGiderler
            // 
            btnListeleGiderler.Location = new Point(233, 418);
            btnListeleGiderler.Name = "btnListeleGiderler";
            btnListeleGiderler.Size = new Size(75, 31);
            btnListeleGiderler.TabIndex = 1;
            btnListeleGiderler.Text = "Listele";
            btnListeleGiderler.UseVisualStyleBackColor = true;
            btnListeleGiderler.Click += btnListeleGiderler_Click;
            // 
            // btnEkle
            // 
            btnEkle.Location = new Point(314, 418);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(75, 31);
            btnEkle.TabIndex = 2;
            btnEkle.Text = "Ekle";
            btnEkle.UseVisualStyleBackColor = true;
            btnEkle.Click += btnEkle_Click;
            // 
            // btnSil
            // 
            btnSil.Location = new Point(395, 418);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(75, 31);
            btnSil.TabIndex = 3;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // btnGuncelle
            // 
            btnGuncelle.Location = new Point(476, 418);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new Size(75, 31);
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
            Controls.Add(btnListeleGiderler);
            Controls.Add(dgvGiderler);
            Name = "GiderIslem";
            Text = "Gider İşlemleri";
            Load += GiderIslem_Load;
            ((System.ComponentModel.ISupportInitialize)dgvGiderler).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGiderler;
        private System.Windows.Forms.Button btnListeleGiderler;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnGuncelle;
    }
}

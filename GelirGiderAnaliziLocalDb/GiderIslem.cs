using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using GelirGiderAnalizi.Models;
using GeliGiderAnaliziClassLib;

namespace GelirGiderAnaliziLocalDb
{
    public partial class GiderIslem : Form
    {
        private readonly string _connectionString;

        public GiderIslem()
        {
            InitializeComponent();
            _connectionString = CustomConfigurationManager.ConnectionString;
        }

        // Gider listeleme işlemi
        private void ListeleGiderIslemler()
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM giderislmodels";
                    var adapter = new MySqlDataAdapter(query, connection);
                    var dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dgvGiderler.DataSource = dataTable;

                    dgvGiderler.Columns["GiderId"].HeaderText = "Gider ID";
                    dgvGiderler.Columns["KasaId"].HeaderText = "Kasa ID";
                    dgvGiderler.Columns["EvrakNo"].HeaderText = "Evrak No";
                    dgvGiderler.Columns["Aciklama"].HeaderText = "Açıklama";
                    dgvGiderler.Columns["OdemeDurumu"].HeaderText = "Ödeme Durumu";
                    dgvGiderler.Columns["OdemeSekli"].HeaderText = "Ödeme Şekli";
                    dgvGiderler.Columns["SubeAdi"].HeaderText = "Şube Adı";
                    dgvGiderler.Columns["Tutar"].HeaderText = "Tutar";
                    dgvGiderler.Columns["Tarih"].HeaderText = "Tarih";
                    dgvGiderler.Columns["Turu"].HeaderText = "Türü";

                    dgvGiderler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Gider ekleme işlemi
        private void EkleGider()
        {
            string query = @"INSERT INTO giderislmodels 
                             (GiderId, KasaId, EvrakNo, Aciklama, OdemeDurumu, OdemeSekli, SubeAdi, Tutar, Tarih, Turu)
                             VALUES (@GiderId, @KasaId, @EvrakNo, @Aciklama, @OdemeDurumu, @OdemeSekli, @SubeAdi, @Tutar, @Tarih, @Turu)";

            ExecuteQuery(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@GiderId", 1);
                cmd.Parameters.AddWithValue("@KasaId", 1);
                cmd.Parameters.AddWithValue("@EvrakNo", "EVR001");
                cmd.Parameters.AddWithValue("@Aciklama", "Gider Açıklaması");
                cmd.Parameters.AddWithValue("@OdemeDurumu", "Ödendi");
                cmd.Parameters.AddWithValue("@OdemeSekli", "Nakit");
                cmd.Parameters.AddWithValue("@SubeAdi", "Merkez");
                cmd.Parameters.AddWithValue("@Tutar", 1000.50m);
                cmd.Parameters.AddWithValue("@Tarih", DateTime.Now);
                cmd.Parameters.AddWithValue("@Turu", "Aylık");
            }, "Gider başarıyla eklendi.");
        }

        // Gider silme işlemi
        private void SilGider()
        {
            if (dgvGiderler.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvGiderler.SelectedRows[0].Cells["Id"].Value);
                string query = "DELETE FROM giderislmodels WHERE Id = @Id";

                ExecuteQuery(query, cmd => cmd.Parameters.AddWithValue("@Id", id), "Gider başarıyla silindi.");
                ListeleGiderIslemler();
            }
            else
            {
                MessageBox.Show("Silmek için bir gider seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Gider güncelleme işlemi
        private void GuncelleGider()
        {
            if (dgvGiderler.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvGiderler.SelectedRows[0].Cells["Id"].Value);
                string query = @"UPDATE giderislmodels 
                                 SET GiderId = @GiderId, KasaId = @KasaId, EvrakNo = @EvrakNo, Aciklama = @Aciklama, 
                                     OdemeDurumu = @OdemeDurumu, OdemeSekli = @OdemeSekli, SubeAdi = @SubeAdi, 
                                     Tutar = @Tutar, Tarih = @Tarih, Turu = @Turu 
                                 WHERE Id = @Id";

                ExecuteQuery(query, cmd =>
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@GiderId", 1);
                    cmd.Parameters.AddWithValue("@KasaId", 1);
                    cmd.Parameters.AddWithValue("@EvrakNo", "EVR002");
                    cmd.Parameters.AddWithValue("@Aciklama", "Güncellenmiş Gider Açıklaması");
                    cmd.Parameters.AddWithValue("@OdemeDurumu", "Ödendi");
                    cmd.Parameters.AddWithValue("@OdemeSekli", "Kredi Kartı");
                    cmd.Parameters.AddWithValue("@SubeAdi", "Şube");
                    cmd.Parameters.AddWithValue("@Tutar", 1200.75m);
                    cmd.Parameters.AddWithValue("@Tarih", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Turu", "Yıllık");
                }, "Gider başarıyla güncellendi.");
            }
            else
            {
                MessageBox.Show("Güncellemek için bir gider seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ExecuteQuery(string query, Action<MySqlCommand> addParameters, string successMessage)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        addParameters(cmd);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show(successMessage, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GiderIslem_Load(object sender, EventArgs e)
        {
        }

        private void btnListeleGiderler_Click(object sender, EventArgs e)
        {
            ListeleGiderIslemler();
        }

        private void btnEkle_Click(object sender, EventArgs e) => EkleGider();
        private void btnSil_Click(object sender, EventArgs e) => SilGider();
        private void btnGuncelle_Click(object sender, EventArgs e) => GuncelleGider();
    }
}

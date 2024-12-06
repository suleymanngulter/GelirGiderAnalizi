using System;
using System.Data;
using System.Windows.Forms;
using GeliGiderAnaliziClassLib;
using MySql.Data.MySqlClient;

namespace GelirGiderAnaliziLocalDb
{
    public partial class Gider : Form
    {
        private readonly string _connectionString;

        public Gider()
        {
            InitializeComponent();
            _connectionString = CustomConfigurationManager.ConnectionString;
        }

        private async void ListeleGiderler()
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string query = "SELECT * FROM gidermodels";
                    var adapter = new MySqlDataAdapter(query, connection);

                    var dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dgvGiderler.DataSource = dataTable;

                    foreach (DataGridViewColumn column in dgvGiderler.Columns)
                    {
                        column.ReadOnly = false; 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void ListeleGiderIslemler()
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM gidermodels";
                    var adapter = new MySqlDataAdapter(query, connection);

                    var dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dgvGiderler.DataSource = dataTable;
                    foreach (DataGridViewColumn column in dgvGiderler.Columns)
                    {
                        column.ReadOnly = false; 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO gidermodels (AboneNo, GiderAciklama, GiderAdi, GiderKategori, GiderKodu, GiderTuru, KullaniciAdi, SubeAdi) " +
                                   "VALUES (@AboneNo, @GiderAciklama, @GiderAdi, @GiderKategori, @GiderKodu, @GiderTuru, @KullaniciAdi, @SubeAdi)";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AboneNo", "AboneNo değeri");
                        command.Parameters.AddWithValue("@GiderAciklama", "Açıklama değeri");
                        command.Parameters.AddWithValue("@GiderAdi", "Gider Adı değeri");
                        command.Parameters.AddWithValue("@GiderKategori", "Kategori değeri");
                        command.Parameters.AddWithValue("@GiderKodu", "Kod değeri");
                        command.Parameters.AddWithValue("@GiderTuru", "Tür değeri");
                        command.Parameters.AddWithValue("@KullaniciAdi", "Kullanıcı Adı değeri");
                        command.Parameters.AddWithValue("@SubeAdi", "Şube Adı değeri");

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Gider başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListeleGiderler();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvGiderler.SelectedRows.Count > 0)
                {
                    int id = Convert.ToInt32(dgvGiderler.SelectedRows[0].Cells["Id"].Value);

                    using (var connection = new MySqlConnection(_connectionString))
                    {
                        connection.Open();

                        string query = "DELETE FROM gidermodels WHERE Id = @Id";

                        using (var command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Id", id);
                            command.ExecuteNonQuery();
                        }

                        MessageBox.Show("Gider başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListeleGiderler();
                    }
                }
                else
                {
                    MessageBox.Show("Silmek için bir gider seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvGiderler.SelectedRows.Count > 0)
                {
                    int id = Convert.ToInt32(dgvGiderler.SelectedRows[0].Cells["Id"].Value);

                    using (var connection = new MySqlConnection(_connectionString))
                    {
                        connection.Open();

                        string query = "UPDATE gidermodels SET AboneNo = @AboneNo, GiderAciklama = @GiderAciklama, " +
                                       "GiderAdi = @GiderAdi, GiderKategori = @GiderKategori, GiderKodu = @GiderKodu, " +
                                       "GiderTuru = @GiderTuru, KullaniciAdi = @KullaniciAdi, SubeAdi = @SubeAdi WHERE Id = @Id";

                        using (var command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Id", id);
                            command.Parameters.AddWithValue("@AboneNo", dgvGiderler.SelectedRows[0].Cells["AboneNo"].Value);
                            command.Parameters.AddWithValue("@GiderAciklama", dgvGiderler.SelectedRows[0].Cells["GiderAciklama"].Value);
                            command.Parameters.AddWithValue("@GiderAdi", dgvGiderler.SelectedRows[0].Cells["GiderAdi"].Value);
                            command.Parameters.AddWithValue("@GiderKategori", dgvGiderler.SelectedRows[0].Cells["GiderKategori"].Value);
                            command.Parameters.AddWithValue("@GiderKodu", dgvGiderler.SelectedRows[0].Cells["GiderKodu"].Value);
                            command.Parameters.AddWithValue("@GiderTuru", dgvGiderler.SelectedRows[0].Cells["GiderTuru"].Value);
                            command.Parameters.AddWithValue("@KullaniciAdi", dgvGiderler.SelectedRows[0].Cells["KullaniciAdi"].Value);
                            command.Parameters.AddWithValue("@SubeAdi", dgvGiderler.SelectedRows[0].Cells["SubeAdi"].Value);

                            command.ExecuteNonQuery();
                        }

                        MessageBox.Show("Gider başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListeleGiderler();
                    }
                }
                else
                {
                    MessageBox.Show("Güncellemek için bir gider seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

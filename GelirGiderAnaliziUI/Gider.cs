using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using GelirGiderAnalizi.Services.GiderService;
using GelirGiderAnalizi.Dtos.GiderDto;

namespace GelirGiderAnaliziUI
{
    public partial class Gider : Form
    {
        private readonly GiderService _giderService;
        private string _token; // Kullanıcıdan alınan oturum token'ı.

        public Gider(GiderService giderService, string token)
        {
            InitializeComponent();
            _giderService = giderService;
            _token = token;
        }

        private async void btnListele_Click(object sender, EventArgs e)
        {
            try
            {
                var filtre = new GiderGetAllDto(); // Filtre kriterleri buraya eklenebilir.
                var giderler = await _giderService.GetAllGiderlerAsync(filtre, _token);

                if (giderler != null)
                {
                    dgvGiderler.DataSource = giderler;
                }
                else
                {
                    MessageBox.Show("Giderler listelenirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvGiderler.SelectedRows.Count > 0)
                {
                    var selectedRow = dgvGiderler.SelectedRows[0];

                    // DataGridView'den alınan verilerle GiderAddDto oluşturuluyor
                    var giderDto = new GiderAddDto
                    {
                        AboneNo = selectedRow.Cells["AboneNo"].Value?.ToString(),
                        GiderAciklama = selectedRow.Cells["GiderAciklama"].Value?.ToString(),
                        GiderAdi = selectedRow.Cells["GiderAdi"].Value?.ToString(),
                        GiderKategori = selectedRow.Cells["GiderKategori"].Value?.ToString(),
                        GiderKodu = selectedRow.Cells["GiderKodu"].Value?.ToString(),
                        GiderTuru = selectedRow.Cells["GiderTuru"].Value?.ToString(),
                        KullaniciAdi = selectedRow.Cells["KullaniciAdi"].Value?.ToString(),
                        SubeAdi = selectedRow.Cells["SubeAdi"].Value?.ToString()
                    };

                    // GiderService'e bağlanarak veriyi ekle
                    await _giderService.AddAsync(giderDto, _token);
                    MessageBox.Show("Gider başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Eklemek için bir gider seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvGiderler.SelectedRows.Count > 0)
                {
                    var id = Convert.ToInt32(dgvGiderler.SelectedRows[0].Cells["Id"].Value);
                    await _giderService.DeleteByIdAsync(id, _token);
                    MessageBox.Show("Gider başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private async void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvGiderler.SelectedRows.Count > 0)
                {
                    var selectedRow = dgvGiderler.SelectedRows[0];
                    var giderDto = new GiderUpdateDto
                    {
                        Id = Convert.ToInt32(selectedRow.Cells["Id"].Value),
                        AboneNo = selectedRow.Cells["AboneNo"].Value?.ToString(),
                        GiderAciklama = selectedRow.Cells["GiderAciklama"].Value?.ToString(),
                        GiderAdi = selectedRow.Cells["GiderAdi"].Value?.ToString(),
                        GiderKategori = selectedRow.Cells["GiderKategori"].Value?.ToString(),
                        GiderKodu = selectedRow.Cells["GiderKodu"].Value?.ToString(),
                        GiderTuru = selectedRow.Cells["GiderTuru"].Value?.ToString(),
                        KullaniciAdi = selectedRow.Cells["KullaniciAdi"].Value?.ToString(),
                        SubeAdi = selectedRow.Cells["SubeAdi"].Value?.ToString()
                    };

                    await _giderService.UpdateAsync(giderDto, _token);
                    MessageBox.Show("Gider başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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



        private void Gider_Load(object sender, EventArgs e)
        {

        }

        private void Gider_Load_1(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using GelirGiderAnalizi.Services.GiderService;
using GelirGiderAnalizi.Dtos.GiderIslDto;
using GelirGiderAnalizi.Services;
using Newtonsoft.Json.Linq;

namespace GelirGiderAnaliziUI
{
    public partial class GiderIslem : Form
    {
        private readonly GiderIslService _giderIslService;
        private string _token;
        public GiderIslem(GiderIslService giderIslService, string token)
        {
            InitializeComponent();
            _giderIslService = giderIslService;
            _token = token;
        }

        private async void btnListele_Click(object sender, EventArgs e)
        {
            try
            {
                var filtre = new GiderIslGetAllDto(); 

                var giderIslemler = await _giderIslService.GetAllGiderIslAsync(filtre, _token);

                if (giderIslemler != null)
                {
                    dgvGiderIslemler.DataSource = giderIslemler;
                }
                else
                {
                    MessageBox.Show("Gider işlemleri listelenirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (dgvGiderIslemler.SelectedRows.Count > 0)
                {
                    var selectedRow = dgvGiderIslemler.SelectedRows[0];

                    var giderIslemDto = new GiderIslAddDto
                    {
                        Aciklama = selectedRow.Cells["Aciklama"].Value?.ToString(),
                        BankaIslId = selectedRow.Cells["BankaIslId"].Value as int?,
                        EvrakNo = selectedRow.Cells["EvrakNo"].Value?.ToString(),
                        GiderId = selectedRow.Cells["GiderId"].Value as int?,
                        Id = selectedRow.Cells["Id"].Value as int?,
                        KasaId = selectedRow.Cells["KasaId"].Value as int?,
                        KullaniciAdi = selectedRow.Cells["KullaniciAdi"].Value?.ToString(),
                        OdemeDurumu = selectedRow.Cells["OdemeDurumu"].Value?.ToString(),
                        OdemeSekli = selectedRow.Cells["OdemeSekli"].Value?.ToString(),
                        SubeAdi = selectedRow.Cells["SubeAdi"].Value?.ToString(),
                        Tarih = selectedRow.Cells["Tarih"].Value as DateTime?,
                        Tip = selectedRow.Cells["Tip"].Value?.ToString(),
                        Tutar = selectedRow.Cells["Tutar"].Value as double?
                    };

                    // GiderService'e bağlanarak veriyi ekle
                    await _giderIslService.AddAsync(giderIslemDto, _token);
                    MessageBox.Show("Gider işlemi başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Eklemek için bir gider işlemi seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                if (dgvGiderIslemler.SelectedRows.Count > 0)
                {
                    var id = Convert.ToInt32(dgvGiderIslemler.SelectedRows[0].Cells["Id"].Value);
                    await _giderIslService.DeleteByIdAsync(id, _token);
                    MessageBox.Show("Gider işlemi başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Silmek için bir gider işlemi seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                if (dgvGiderIslemler.SelectedRows.Count > 0)
                {
                    var selectedRow = dgvGiderIslemler.SelectedRows[0];

                    // DataGridView'den alınan verilerle GiderIslUpdateDto oluşturuluyor
                    var giderIslemDto = new GiderIslUpdateDto
                    {
                        Id = Convert.ToInt32(selectedRow.Cells["Id"].Value),
                        GiderId = selectedRow.Cells["GiderId"].Value as int?,
                        KasaId = selectedRow.Cells["KasaId"].Value as int?,
                        EvrakNo = selectedRow.Cells["EvrakNo"].Value?.ToString(),
                        Aciklama = selectedRow.Cells["Aciklama"].Value?.ToString(),
                        OdemeDurumu = selectedRow.Cells["OdemeDurumu"].Value?.ToString(),
                        OdemeSekli = selectedRow.Cells["OdemeSekli"].Value?.ToString(),
                        SubeAdi = selectedRow.Cells["SubeAdi"].Value?.ToString(),
                        Tarih = selectedRow.Cells["Tarih"].Value as DateTime?,
                        Tip = selectedRow.Cells["Tip"].Value?.ToString(),
                        Tutar = selectedRow.Cells["Tutar"].Value as decimal?,
                        KullaniciAdi = selectedRow.Cells["KullaniciAdi"].Value?.ToString(),
                        BankaIslId = selectedRow.Cells["BankaIslId"].Value as int?
                    };

                    // GiderService'e bağlanarak veriyi güncelle
                    await _giderIslService.UpdateAsync(giderIslemDto, _token);
                    MessageBox.Show("Gider işlemi başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Güncellemek için bir gider işlemi seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void GiderIslem_Load(object sender, EventArgs e)
        {
        }
    }
}

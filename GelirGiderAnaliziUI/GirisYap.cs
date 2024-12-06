using GelirGiderAnalizi.Models;
using GelirGiderAnalizi.Models.GelirGiderAnalizi.Models;
using GelirGiderAnalizi.Services;
using GelirGiderAnalizi.Services.GiderService;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GelirGiderAnaliziUI
{
    public partial class GirisYap : Form
    {
        private readonly LoginService _loginService;

        public GirisYap()
        {
            InitializeComponent();
            var httpClient = new HttpClient();
            _loginService = new LoginService(httpClient);
        }
        GiderService giderService;
        GiderIslService giderIslService;
        LoginResponse loginResponse;
        private async void btnGirisYap_Click(object sender, EventArgs e)
        {
            var loginModel = new LoginModel
            {
                VergiNumarasi = txtVergiNumarasi.Text,
                KullaniciAdi = txtKullaniciAdi.Text,
                KullaniciSifre = txtSifre.Text,
                VeritabaniAd = txtVeritabaniAd.Text,
                DonemYil = txtDonemYil.Text,
                SubeAd = txtSubeAd.Text,
                ApiKullaniciAdi = txtApiKullaniciAd.Text,
                ApiKullaniciSifre = txtApiKullaniciSifre.Text
            };

            try
            {
                var response = await _loginService.LoginAsync(loginModel);

                if (response != null && !string.IsNullOrEmpty(response.Data!.Token))
                {
                    MessageBox.Show("Giriş başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Giriş başarılı olduğunda yapılacak işlemler.
                    this.Hide();
                    Menu menu = new Menu(giderService, giderIslService, token: response.Data.Token);

                    menu.ShowDialog();  
                    this.Close(); 
                }
                else
                {
                    MessageBox.Show("Giriş başarısız! Lütfen bilgilerinizi kontrol edin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                var errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show($"Hata: {errorMessage}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void GirisYap_Load(object sender, EventArgs e)
        {

        }

    }
}

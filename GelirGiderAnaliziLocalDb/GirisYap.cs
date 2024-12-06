using GeliGiderAnaliziClassLib;
using GelirGiderAnalizi.Models;
using System;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GelirGiderAnaliziLocalDb
{
    public partial class GirisYap : Form
    {
        public GirisYap()
        {
            InitializeComponent();
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
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

            using (var context = new GelirGiderAnaliziContext())
            {
                // Kullanıcı doğrulama
                var user = context.LoginModels
                    .FirstOrDefault(u =>
                        u.KullaniciAdi == loginModel.KullaniciAdi &&
                        u.KullaniciSifre == loginModel.KullaniciSifre &&
                        u.VergiNumarasi == loginModel.VergiNumarasi &&
                        u.VeritabaniAd==loginModel.VeritabaniAd &&
                        u.DonemYil==loginModel.DonemYil &&
                        u.SubeAd==loginModel.SubeAd &&
                        u.ApiKullaniciAdi==loginModel.ApiKullaniciAdi &&
                        u.ApiKullaniciSifre==loginModel.ApiKullaniciSifre);
                        

                if (user != null)
                {
                    MessageBox.Show("Giriş başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();

                    // Menu formuna yönlendirme
                    var menu = new Menu(); // Menu formunuzu oluşturun
                    menu.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Giriş başarısız! Lütfen bilgilerinizi kontrol edin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void GirisYap_Load(object sender, EventArgs e)
        {
        }
    }
}

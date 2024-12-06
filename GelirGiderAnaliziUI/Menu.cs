using GelirGiderAnalizi.Services;
using GelirGiderAnalizi.Services.GiderService;
using System;
using System.Windows.Forms;

namespace GelirGiderAnaliziUI
{
    public partial class Menu : Form
    {
        public Menu(GiderService giderService,GiderIslService giderIslService, string token)
        {
            InitializeComponent();
            this.giderService = giderService;
            this._token = token;
        }


        GiderService giderService;
        private string _token;
        GiderIslService giderIslService;

        private void btnGider_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Token: {_token}");
            if (giderService == null)
            {
                MessageBox.Show("GiderService null.");
                return;
            }

            this.Hide();
            var giderForm = new Gider(giderService, _token);
            giderForm.Show();
        }


        private void btnGiderIslem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var giderIslemForm = new GiderIslem(giderIslService,_token); // Gider İşlem sayfası
            giderIslemForm.Show(); // Yeni formu göster
            this.Close();
        }
    }
}

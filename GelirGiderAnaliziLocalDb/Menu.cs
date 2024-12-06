using System;
using System.Windows.Forms;

namespace GelirGiderAnaliziLocalDb
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnGider_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Gider = new Gider();
            Gider.Show();
            this.Close();

        }


        private void btnGiderIslem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var GiderIslem = new GiderIslem();
            GiderIslem.Show();
            this.Close();

        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }
    }
}

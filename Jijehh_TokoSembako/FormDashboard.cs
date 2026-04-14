using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jijehh_TokoSembako
{
    public partial class FormDashboard : Form
    {
        public FormDashboard()
        {
            InitializeComponent();
        }

        private void btnDistributor_Click(object sender, EventArgs e)
        {
            FormDistributor fDistri = new FormDistributor();
            fDistri.ShowDialog();
        }

        private void btnLaporan_Click(object sender, EventArgs e)
        {
            FormLaporan fLapor = new FormLaporan();
            fLapor.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Apakah Anda yakin ingin keluar dari sistem?", "Konfirmasi Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
                FormLogin fLogin = new FormLogin();
                fLogin.Show();
            }
        }

        private void btnStok_Click(object sender, EventArgs e)
        {
            FormUtama fUtama = new FormUtama();
            fUtama.ShowDialog();    
        }
    }
}

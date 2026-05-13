using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Jijehh_TokoSembako
{
    public partial class FormDistributor : Form
    {
        SqlConnection conn = new SqlConnection("Server=LAPTOP-M60LBIQK\\ZIDANEAS;Database=DB_TokoSembako;Integrated Security=True;");

        public FormDistributor()
        {
            InitializeComponent();
        }

        private void FormDistributor_Load(object sender, EventArgs e)
        {
            TampilData();
        }

        private void TampilData()
        {
            try
            {
                conn.Open();
                SqlDataReader rd = new SqlCommand("SELECT * FROM Distributor", conn).ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                dgvDistributor.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }

        private void dgvDistributor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvDistributor.Rows[e.RowIndex];
                txtID.Text = row.Cells["ID_Distributor"].Value.ToString();
                txtNama.Text = row.Cells["Nama_Distributor"].Value.ToString();
                txtTelepon.Text = row.Cells["No_Telepon"].Value.ToString();
                txtAlamat.Text = row.Cells["Alamat"].Value.ToString();
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (txtNama.Text.Trim() == "")
            {
                MessageBox.Show("Nama Distributor tidak boleh kosong!", "Validasi Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNama.Focus(); // Bikin kursor kedip-kedip di kotak nama
                return; // Hentikan proses simpan
            }
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Distributor VALUES (@id, @nama, @telp, @alamat)", conn);
                cmd.Parameters.AddWithValue("@id", txtID.Text);
                cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                cmd.Parameters.AddWithValue("@telp", txtTelepon.Text);
                cmd.Parameters.AddWithValue("@alamat", txtAlamat.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Distributor berhasil ditambahkan!");
                conn.Close();
                TampilData();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); if (conn.State == ConnectionState.Open) conn.Close(); }
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Distributor SET Nama_Distributor=@nama, No_Telepon=@telp, Alamat=@alamat WHERE ID_Distributor=@id", conn);
                cmd.Parameters.AddWithValue("@id", txtID.Text);
                cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                cmd.Parameters.AddWithValue("@telp", txtTelepon.Text);
                cmd.Parameters.AddWithValue("@alamat", txtAlamat.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil diubah!");
                conn.Close();
                TampilData();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); if (conn.State == ConnectionState.Open) conn.Close(); }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Distributor WHERE ID_Distributor=@id", conn);
                cmd.Parameters.AddWithValue("@id", txtID.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil dihapus!");
                conn.Close();
                TampilData();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); if (conn.State == ConnectionState.Open) conn.Close(); }
        }

        private void ValidasiTelepon_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Hanya izinkan angka, backspace, tanda plus (+), dan strip (-)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '+' && e.KeyChar != '-')
            {
                e.Handled = true;
                MessageBox.Show("Nomor telepon hanya boleh berisi angka atau simbol + dan -", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtNama_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Hanya izinkan Huruf, Angka, Spasi, Backspace (Control), dan simbol tertentu (titik, koma, &, strip)
            if (!char.IsLetterOrDigit(e.KeyChar) &&
                !char.IsControl(e.KeyChar) &&
                !char.IsWhiteSpace(e.KeyChar) &&
                e.KeyChar != '.' &&
                e.KeyChar != ',' &&
                e.KeyChar != '&' &&
                e.KeyChar != '-')
            {
                e.Handled = true; // Tolak karakter lain
                MessageBox.Show("Nama distributor hanya boleh berisi huruf, angka, dan tanda baca umum (titik, koma, &, -).", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void ValidasiID_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Hanya izinkan huruf, angka, dan tombol hapus (backspace)
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Kolom ID/Username hanya boleh diisi Huruf dan Angka tanpa spasi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
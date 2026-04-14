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

        private void txtTelepon_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Hanya mengizinkan angka dan tombol Backspace untuk No Telepon
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Nomor Telepon wajib diisi dengan angka!", "Validasi Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
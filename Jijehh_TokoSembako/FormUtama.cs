using System;
using System.Data;
using System.Data.SqlClient; 
using System.Windows.Forms;

namespace Jijehh_TokoSembako 
{
    public partial class FormUtama : Form
    {
        
        SqlConnection conn = new SqlConnection("Server=LAPTOP-M60LBIQK\\ZIDANEAS;Database=DB_TokoSembako;Integrated Security=True;");

        public FormUtama()
        {
            InitializeComponent();
        }

        
        private void FormUtama_Load(object sender, EventArgs e)
        {
            CekKoneksiDatabase(); 
            TampilData();         
            HitungTotal();        
        }

        
        private void CekKoneksiDatabase()
        {
            try
            {
                conn.Open(); 

                
                MessageBox.Show("Koneksi ke Database DB_TokoSembako Berhasil!", "Status Koneksi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                conn.Close(); 
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Gagal terhubung ke database!\nError: " + ex.Message, "Koneksi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void TampilData()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Barang", conn);

                
                SqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);

                
                dgvData.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menampilkan data: " + ex.Message);
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }

        
        private void HitungTotal()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Barang", conn);

                
                int total = (int)cmd.ExecuteScalar();

                
                lblTotalRecord.Text = "Total Record: " + total.ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menghitung total: " + ex.Message);
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvData.Rows[e.RowIndex];

                
                txtID.Text = row.Cells["ID_Barang"].Value.ToString();
                txtNama.Text = row.Cells["Nama_Barang"].Value.ToString();
                txtKategori.Text = row.Cells["Kategori"].Value.ToString();
                txtStok.Text = row.Cells["Stok"].Value.ToString();
                txtHarga.Text = row.Cells["Harga_Jual"].Value.ToString();
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            // Syarat UCP: Validasi input agar tidak ada field penting yang kosong
            if (txtID.Text == "" || txtNama.Text == "" || txtKategori.Text == "" || txtStok.Text == "" || txtHarga.Text == "")
            {
                MessageBox.Show("Data tidak boleh kosong! Harap isi semua kotak.", "Validasi Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                conn.Open();
                // Syarat UCP: Implementasikan query INSERT menggunakan SqlCommand
                SqlCommand cmd = new SqlCommand("INSERT INTO Barang (ID_Barang, Nama_Barang, Kategori, Stok, Harga_Jual) VALUES (@id, @nama, @kategori, @stok, @harga)", conn);
                cmd.Parameters.AddWithValue("@id", txtID.Text);
                cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                cmd.Parameters.AddWithValue("@kategori", txtKategori.Text);
                cmd.Parameters.AddWithValue("@stok", int.Parse(txtStok.Text));
                cmd.Parameters.AddWithValue("@harga", decimal.Parse(txtHarga.Text));

                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();

                TampilData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan data!\nError: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Pilih dulu data yang mau diubah dari tabel!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Apakah Anda yakin ingin mengubah data ini?", "Konfirmasi Ubah", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Barang SET Nama_Barang=@nama, Kategori=@kategori, Stok=@stok, Harga_Jual=@harga WHERE ID_Barang=@id", conn);
                    cmd.Parameters.AddWithValue("@id", txtID.Text);
                    cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                    cmd.Parameters.AddWithValue("@kategori", txtKategori.Text);
                    cmd.Parameters.AddWithValue("@stok", int.Parse(txtStok.Text));
                    cmd.Parameters.AddWithValue("@harga", decimal.Parse(txtHarga.Text));

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil diubah!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();

                    TampilData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal mengubah data: " + ex.Message);
                    if (conn.State == ConnectionState.Open) conn.Close();
                }
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Pilih dulu data yang mau dihapus dari tabel!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Yakin data barang ini mau dihapus permanen?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Barang WHERE ID_Barang=@id", conn);
                    cmd.Parameters.AddWithValue("@id", txtID.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();

                    TampilData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menghapus data: " + ex.Message);
                    if (conn.State == ConnectionState.Open) conn.Close();
                }
            }
        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                // Syarat UCP: Menggunakan query pencarian dengan klausa LIKE
                SqlCommand cmd = new SqlCommand("SELECT * FROM Barang WHERE Nama_Barang LIKE '%' + @cari + '%'", conn);
                cmd.Parameters.AddWithValue("@cari", txtCari.Text);

                SqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);

                // Langsung timpa isi tabel dengan hasil pencarian
                dgvData.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mencari data: " + ex.Message);
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }

        private void btnBersih_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtNama.Text = "";
            txtKategori.Text = "";
            txtStok.Text = "";
            txtHarga.Text = "";
            txtID.Focus();
        }

        private void txtStok_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Hanya mengizinkan angka dan tombol Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Tolak inputan jika bukan angka
                MessageBox.Show("Stok hanya boleh diisi dengan angka!", "Validasi Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtHarga_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Hanya mengizinkan angka dan tombol Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Harga hanya boleh diisi dengan nominal angka!", "Validasi Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
using System;
using System.Data;
using System.Data.SqlClient; 
using System.Windows.Forms;

namespace Jijehh_TokoSembako 
{
    public partial class FormUtama : Form
    {
 /* * =========================================================
 * MODUL KELOLA DATA BARANG (CRUD)
 * Fungsi: Menambah, mengubah, menghapus, dan mencari data
 * Dilengkapi dengan validasi tipe data pada input numerik
 * =========================================================
 */

        SqlConnection conn = new SqlConnection("Server=LAPTOP-M60LBIQK\\ZIDANEAS;Database=DB_TokoSembako;Integrated Security=True;");
        BindingSource bindingSource = new BindingSource();
        public FormUtama()
        {                                                                       
            InitializeComponent();
        }

        
        private void FormUtama_Load(object sender, EventArgs e)
        {
            CekKoneksiDatabase(); 
            LoadData();         
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

        private void LoadData()
        {
            try
            {
                conn.Open();
                // Menggunakan VIEW sesuai syarat UCP
                SqlCommand cmd = new SqlCommand("SELECT * FROM vw_TampilBarang", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Menggunakan BINDING sesuai syarat UCP
                bindingSource.DataSource = dt;
                dgvData.DataSource = bindingSource;
                bindingNavigator1.BindingSource = bindingSource;
                // Format kolom Harga_Jual menjadi mata uang Rupiah
                dgvData.Columns["Harga_Jual"].DefaultCellStyle.Format = "C0";
                dgvData.Columns["Harga_Jual"].DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("id-ID");
                // Kunci tabel dan percantik warna baris selang-seling
                dgvData.ReadOnly = true;
                dgvData.AllowUserToAddRows = false;
                dgvData.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LightGray;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message);
                if (conn.State == ConnectionState.Open) conn.Close();
            }
            HitungTotal();
        }


        private void HitungTotal()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_CountBarang", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter outputParam = new SqlParameter("@Total", SqlDbType.Int);
                outputParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outputParam);

                cmd.ExecuteNonQuery();
                lblTotalRecord.Text = "Total Record: " + outputParam.Value.ToString();
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

            // Tambahkan pengecekan agar tidak error saat klik area kosong
            if (e.RowIndex >= 0 && dgvData.Rows[e.RowIndex].Cells[0].Value != null)
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
            if (txtID.Text == "" || txtNama.Text == "" || txtStok.Text == "" || txtHarga.Text == "")
            {
                MessageBox.Show("Data tidak boleh kosong!");
                return;
            }

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_InsertBarang", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID_Barang", txtID.Text);
                cmd.Parameters.AddWithValue("@Nama_Barang", txtNama.Text);
                cmd.Parameters.AddWithValue("@Kategori", txtKategori.Text);
                cmd.Parameters.AddWithValue("@Stok", short.Parse(txtStok.Text));
                cmd.Parameters.AddWithValue("@Harga_Jual", decimal.Parse(txtHarga.Text));

                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan: " + ex.Message);
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Pilih data dulu!");
                return;
            }

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_UpdateBarang", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID_Barang", txtID.Text);
                cmd.Parameters.AddWithValue("@Nama_Barang", txtNama.Text);
                cmd.Parameters.AddWithValue("@Kategori", txtKategori.Text);
                cmd.Parameters.AddWithValue("@Stok", short.Parse(txtStok.Text));
                cmd.Parameters.AddWithValue("@Harga_Jual", decimal.Parse(txtHarga.Text));

                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil diubah!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengubah: " + ex.Message);
                if (conn.State == ConnectionState.Open) conn.Close();
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

                    LoadData();
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

                // KODINGAN RENTAN (VULNERABLE) UNTUK DEMO SQL INJECTION!
                // Dilarang pakai Parameter (@) atau Stored Procedure di sini.
                string queryRentan = "SELECT * FROM vw_TampilBarang WHERE Nama_Barang = '" + txtCari.Text + "'";

                SqlCommand cmd = new SqlCommand(queryRentan, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                bindingSource.DataSource = dt;
                dgvData.DataSource = bindingSource;
                conn.Close();
            }
            catch (Exception ex)
            {
                // Sengaja kita tampilkan error asli SQL-nya agar hacker (dosen) tahu celahnya
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

        private void ValidasiAngka_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Hanya izinkan ketikan Angka dan tombol Control (seperti Backspace untuk menghapus)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Langsung tolak ketikan selain angka
                MessageBox.Show("Kolom ini hanya boleh diisi dengan angka bulat!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private void ValidasiHuruf_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Hanya izinkan huruf, spasi, dan tombol hapus
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Kolom ini hanya boleh diisi dengan huruf!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
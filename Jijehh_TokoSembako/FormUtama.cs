using System;
using System.Data;
using System.Data.SqlClient; // Wajib untuk SQL Server
using System.Windows.Forms;

namespace Jijehh_TokoSembako // Nama namespace sesuai nama project
{
    public partial class FormUtama : Form
    {
        // 1. Setup String Koneksi
        SqlConnection conn = new SqlConnection("Server=LAPTOP-M60LBIQK\\ZIDANEAS;Database=DB_TokoSembako;Integrated Security=True;");

        public FormUtama()
        {
            InitializeComponent();
        }

        // 2. Fungsi yang otomatis jalan pas aplikasi dibuka
        private void FormUtama_Load(object sender, EventArgs e)
        {
            CekKoneksiDatabase(); // Yang tadi udah ada
            TampilData();         // Munculin data ke tabel
            HitungTotal();        // Munculin angka total ke label
        }

        // 3. Logika untuk ngecek koneksi
        private void CekKoneksiDatabase()
        {
            try
            {
                conn.Open(); // Coba buka gerbang ke database

                // Syarat UCP: Muncul notifikasi sukses
                MessageBox.Show("Koneksi ke Database DB_TokoSembako Berhasil!", "Status Koneksi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                conn.Close(); // Langsung tutup lagi biar aman
            }
            catch (Exception ex)
            {
                // Kalau error, munculin pesan errornya
                MessageBox.Show("Gagal terhubung ke database!\nError: " + ex.Message, "Koneksi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void TampilData()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Barang", conn);

                // Membaca data pakai SqlDataReader
                SqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);

                // Memasukkan data ke DataGridView
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

                // Menghitung jumlah baris data pakai ExecuteScalar
                int total = (int)cmd.ExecuteScalar();

                // Menampilkan hasilnya ke Label
                lblTotalRecord.Text = "Total Record: " + total.ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menghitung total: " + ex.Message);
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }

    }
}
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
            CekKoneksiDatabase();
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
    }
}
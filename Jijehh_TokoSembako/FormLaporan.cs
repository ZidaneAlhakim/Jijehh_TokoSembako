using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting; // Wajib buat grafik!

namespace Jijehh_TokoSembako
{
    public partial class FormLaporan : Form
    {
        SqlConnection conn = new SqlConnection("Server=LAPTOP-M60LBIQK\\ZIDANEAS;Database=DB_TokoSembako;Integrated Security=True;");

        public FormLaporan()
        {
            InitializeComponent();
        }

        private void FormLaporan_Load(object sender, EventArgs e)
        {
            MuatLaporan();
            MuatGrafik();
        }

        private void MuatLaporan()
        {
            try
            {
                conn.Open();
                SqlDataReader rd = new SqlCommand("SELECT ID_Transaksi, Tanggal, Nama_Barang, Jumlah_Beli, Total_Harga FROM Transaksi", conn).ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                dgvLaporan.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex) { MessageBox.Show("Error Laporan: " + ex.Message); if (conn.State == ConnectionState.Open) conn.Close(); }
        }

        /*
         * Menggunakan komponen DataVisualization.Charting
         * Query SQL mengambil aggregasi SUM() dari tabel Transaksi
         * untuk memvisualisasikan produk Best Seller.
         */
        private void MuatGrafik()
        {
            try
            {
                conn.Open();
                // Query sakti untuk ngitung Best Seller
                SqlCommand cmd = new SqlCommand("SELECT Nama_Barang, SUM(Jumlah_Beli) as Total_Terjual FROM Transaksi GROUP BY Nama_Barang", conn);
                SqlDataReader rd = cmd.ExecuteReader();

                // Konfigurasi Grafik
                chartBestSeller.Series.Clear();
                Series series = chartBestSeller.Series.Add("Terjual");
                series.ChartType = SeriesChartType.Column; // Bentuk diagram batang
                series.IsValueShownAsLabel = true; // Munculin angka di atas diagram

                // Memasukkan data ke dalam grafik
                while (rd.Read())
                {
                    series.Points.AddXY(rd["Nama_Barang"].ToString(), Convert.ToInt32(rd["Total_Terjual"]));
                }
                conn.Close();
            }
            catch (Exception ex) { MessageBox.Show("Error Grafik: " + ex.Message); if (conn.State == ConnectionState.Open) conn.Close(); }
        }
    }
}
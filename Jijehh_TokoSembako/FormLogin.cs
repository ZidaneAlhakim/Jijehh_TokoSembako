using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Jijehh_TokoSembako
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Username dan Password harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SqlConnection conn = new SqlConnection("Server=LAPTOP-M60LBIQK\\ZIDANEAS;Database=DB_TokoSembako;Integrated Security=True;");
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT Role FROM Users WHERE Username=@user AND Password=@pass", conn);
                cmd.Parameters.AddWithValue("@user", txtUsername.Text);
                cmd.Parameters.AddWithValue("@pass", txtPassword.Text);

                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.Read()) // Kalau akunnya ketemu
                {
                    string role = rd["Role"].ToString();
                    MessageBox.Show("Login Berhasil!\nSelamat datang, " + role, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide(); // Sembunyikan form login

                    // LOGIKA PENGALIHAN HALAMAN BERDASARKAN ROLE
                    if (role == "Owner" || role == "Kasir")
                    {
                        // Owner dan Kasir masuk ke Dashboard Utama
                        FormDashboard fDashboard = new FormDashboard();
                        fDashboard.Show();
                    }
                    else if (role == "StokBarang")
                    {
                        // Orang Gudang langsung masuk ke form kelola stok (FormUtama)
                        FormUtama fUtama = new FormUtama();
                        fUtama.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Username atau Password salah!", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Database: " + ex.Message);
            }
        }
    }
}

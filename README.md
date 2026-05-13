## 🛡️ Skenario Pengujian Keamanan: SQL Injection (Syarat UCP 2)

Aplikasi ini sengaja disisipi satu celah kerentanan **SQL Injection** pada modul Pencarian Barang (`FormUtama.cs` -> `txtCari`) untuk mendemonstrasikan bahaya *String Concatenation* tanpa validasi parameter.

### 1. Titik Kerentanan (Vulnerability Point)
Celah terdapat pada eksekusi query pencarian yang menggabungkan input *user* secara langsung ke dalam string SQL:
`string query = "SELECT * FROM vw_TampilBarang WHERE Nama_Barang = '" + txtCari.Text + "'";`

### 2. Skenario Serangan: UNION Based SQL Injection (Data Leakage)
Skenario ini bertujuan untuk membocorkan data rahasia dari tabel lain (misalnya tabel `Users` yang berisi Username dan Password) dengan cara memanipulasi kolom pada `DataGridView` Barang.

**Payload (Kode Serangan) yang dimasukkan ke kotak pencarian:**
`' UNION SELECT Username, Password, Role, 0, 0 FROM Users --`

**Logika Eksekusi di Database:**
Ketika payload dimasukkan, query di SQL Server akan berubah menjadi:
`SELECT * FROM vw_TampilBarang WHERE Nama_Barang = '' UNION SELECT Username, Password, Role, 0, 0 FROM Users --'`

### 3. Hasil Serangan (Impact)
* Tanda `'` pertama akan menutup string pencarian.
* Perintah `UNION SELECT` akan menggabungkan hasil pencarian (yang kosong) dengan data dari tabel `Users`.
* Angka `0, 0` digunakan untuk menyamakan jumlah tipe data kolom (karena tabel Barang memiliki 5 kolom: ID, Nama, Kategori, Stok, Harga).
* Tanda `--` akan mengomentari sisa query asli di belakangnya agar tidak *error*.
* **Hasil Akhir:** Aplikasi akan menampilkan secara telanjang daftar `Username` dan `Password` administrator ke layar pengguna biasa.

### 4. Mitigasi (Cara Pencegahan)
Untuk mencegah serangan ini, kodingan pencarian **harus dikembalikan** menggunakan Stored Procedure (`sp_SearchBarang`) yang dilengkapi dengan `Parameterized Query` (misal: `cmd.Parameters.AddWithValue()`), seperti yang sudah diterapkan pada modul Simpan, Ubah, dan Hapus di aplikasi ini.

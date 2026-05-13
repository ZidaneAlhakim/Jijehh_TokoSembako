USE DB_TokoSembako;
GO

-- 1. Revisi Tabel Users
ALTER TABLE Users ALTER COLUMN Username VARCHAR(20) NOT NULL;
ALTER TABLE Users ALTER COLUMN Password VARCHAR(20);
ALTER TABLE Users ALTER COLUMN Role VARCHAR(15);

-- 2. Revisi Tabel Barang
ALTER TABLE Barang ALTER COLUMN ID_Barang VARCHAR(5) NOT NULL;
ALTER TABLE Barang ALTER COLUMN Nama_Barang VARCHAR(50);
ALTER TABLE Barang ALTER COLUMN Kategori VARCHAR(25);

-- 3. Revisi Tabel Distributor
ALTER TABLE Distributor ALTER COLUMN ID_Distributor VARCHAR(5) NOT NULL;
ALTER TABLE Distributor ALTER COLUMN Nama_Distributor VARCHAR(50);
ALTER TABLE Distributor ALTER COLUMN No_Telepon VARCHAR(15);
ALTER TABLE Distributor ALTER COLUMN Alamat VARCHAR(100);

-- 4. Revisi Tabel Transaksi
-- (ID_Transaksi tetap 10)
ALTER TABLE Transaksi ALTER COLUMN Nama_Barang VARCHAR(50);
GO
CREATE DATABASE DB_TokoSembako;
GO


USE DB_TokoSembako;
GO

CREATE TABLE Barang (
    ID_Barang VARCHAR(10) PRIMARY KEY,
    Nama_Barang VARCHAR(100) NOT NULL,
    Kategori VARCHAR(50) NOT NULL,
    Stok INT NOT NULL,
    Harga_Jual DECIMAL(18,2) NOT NULL
);


INSERT INTO Barang (ID_Barang, Nama_Barang, Kategori, Stok, Harga_Jual) 
VALUES ('B001', 'Beras Cianjur 5kg', 'Sembako', 50, 75000);

USE DB_TokoSembako;
GO

-- 1. Bikin Tabel Users (Buat Role Kasir, Owner, Stok Barang)
CREATE TABLE Users (
    Username VARCHAR(50) PRIMARY KEY,
    Password VARCHAR(50) NOT NULL,
    Role VARCHAR(20) NOT NULL -- Isinya nanti: 'Kasir', 'Owner', 'StokBarang'
);

-- Masukin data akun default biar bisa langsung dipake login
INSERT INTO Users (Username, Password, Role) VALUES 
('kasir1', '123', 'Kasir'),
('owner1', 'admin', 'Owner'),
('gudang1', '123', 'StokBarang');

-- 2. Bikin Tabel Distributor (Sesuai Syarat Dosen)
CREATE TABLE Distributor (
    ID_Distributor VARCHAR(10) PRIMARY KEY,
    Nama_Distributor VARCHAR(100) NOT NULL,
    No_Telepon VARCHAR(20) NOT NULL,
    Alamat VARCHAR(200) NOT NULL
);

-- Masukin 1 data distributor bohongan
INSERT INTO Distributor VALUES ('D001', 'PT. Indofood Makmur', '08123456789', 'Jl. Sudirman No. 1');

-- 3. Bikin Tabel Transaksi (Buat Laporan & Grafik Best Seller)
CREATE TABLE Transaksi (
    ID_Transaksi VARCHAR(10) PRIMARY KEY,
    Tanggal DATE NOT NULL,
    Nama_Barang VARCHAR(100) NOT NULL,
    Jumlah_Beli INT NOT NULL,
    Total_Harga DECIMAL(18,2) NOT NULL
);

-- Masukin data transaksi bohongan bulan April buat ngetes grafik nanti
INSERT INTO Transaksi VALUES 
('T001', '2026-04-10', 'Beras Cianjur 5kg', 10, 750000),
('T002', '2026-04-12', 'Minyak Goreng 2L', 25, 875000),
('T003', '2026-04-14', 'Beras Cianjur 5kg', 5, 375000);
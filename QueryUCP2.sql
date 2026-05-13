CREATE VIEW vw_TampilBarang AS
SELECT * FROM Barang;
GO

CREATE PROCEDURE sp_InsertBarang
    @ID_Barang VARCHAR(5),
    @Nama_Barang VARCHAR(50),
    @Kategori VARCHAR(25),
    @Stok SMALLINT,
    @Harga_Jual DECIMAL(9,0)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Barang (ID_Barang, Nama_Barang, Kategori, Stok, Harga_Jual)
    VALUES (@ID_Barang, @Nama_Barang, @Kategori, @Stok, @Harga_Jual)
END
GO
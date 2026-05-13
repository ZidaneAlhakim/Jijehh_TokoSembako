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


CREATE PROCEDURE sp_UpdateBarang
    @ID_Barang VARCHAR(5),
    @Nama_Barang VARCHAR(50),
    @Kategori VARCHAR(25),
    @Stok SMALLINT,
    @Harga_Jual DECIMAL(9,0)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Barang 
    SET Nama_Barang = @Nama_Barang, Kategori = @Kategori, Stok = @Stok, Harga_Jual = @Harga_Jual
    WHERE ID_Barang = @ID_Barang
END
GO

CREATE PROCEDURE sp_DeleteBarang
    @ID_Barang VARCHAR(5)
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Barang WHERE ID_Barang = @ID_Barang
END
GO

CREATE PROCEDURE sp_SearchBarang
    @Cari VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    -- Search memanfaatkan VIEW yang sudah dibuat
    SELECT * FROM vw_TampilBarang WHERE Nama_Barang LIKE '%' + @Cari + '%'
END
GO
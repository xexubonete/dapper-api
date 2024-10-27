GO
PRINT '---------------------Iniciando script dbo_init.sql---------------------'
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Client]') AND type in (N'U'))
BEGIN
    CREATE TABLE Client (
        Id INT PRIMARY KEY IDENTITY(1,1),  -- Clave primaria autoincremental
        Name NVARCHAR(100) NULL,           -- Nombre del cliente (puede ser NULL)
        Surname NVARCHAR(100) NULL         -- Apellido del cliente (puede ser NULL)
    );
END
PRINT '---------------------Terminando script dbo_init.sql---------------------'
GO
SELECT * FROM Client
GO

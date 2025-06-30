CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Nombre] NCHAR(20) NOT NULL, 
    [PalabraPaso] NCHAR(20) NOT NULL, 
    [Categoria] NCHAR(20) NULL, 
    [EsValido] BIT NOT NULL
)

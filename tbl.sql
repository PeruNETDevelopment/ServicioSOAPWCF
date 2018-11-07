CREATE TABLE [dbo].[Usuario](
	[cUsuario] [int] IDENTITY(1,1) NOT NULL,
	[sUsuario] [nvarchar](50) NULL,
	[dContraseña] [nvarchar](50) NULL,
	[nDocumento] [int] NULL,
	[sEstado] [char](1) NULL
) ON [PRIMARY]

GO
USE [GestionBank]
GO
/****** Object:  Table [dbo].[client]    Script Date: 29/03/2023 01:50:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[client](
	[cin] [varchar](50) NOT NULL,
	[numC] [numeric](12, 0) NOT NULL,
	[titulaireC] [varchar](50) NOT NULL,
	[tel] [varchar](50) NOT NULL,
	[sexe] [varchar](1) NOT NULL,
	[solde] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_client] PRIMARY KEY CLUSTERED 
(
	[numC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 29/03/2023 01:50:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[numTran] [int] IDENTITY(1,1) NOT NULL,
	[type] [varchar](50) NOT NULL,
	[montant] [decimal](18, 0) NOT NULL,
	[dateT] [datetime] NOT NULL,
	[numC] [numeric](12, 0) NULL,
 CONSTRAINT [PK__Transact__195B04FA782438A2] PRIMARY KEY CLUSTERED 
(
	[numTran] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_client1] FOREIGN KEY([numC])
REFERENCES [dbo].[client] ([numC])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_client1]
GO

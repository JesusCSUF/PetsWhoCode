USE [Pets]
GO

/****** Object:  Table [dbo].[PetsInfo]    Script Date: 7/19/2019 3:58:07 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TABLE [dbo].[PetsInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Breed_Desc] [nvarchar](200) NULL,
	[Traits] [nvarchar](2000) NULL,
	[Issues] [nvarchar](2000) NULL,
	[AccordingTo] [nvarchar](200) NULL,
	[Link] [nvarchar](200) NULL,
	[Originated] [nvarchar](200) NULL,
	[BM_Breed_Code] [int] NULL,
	[BM_Species_Code] [nvarchar](2) NULL,
 CONSTRAINT [PK_PetsInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO



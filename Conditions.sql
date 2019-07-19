USE [Pets]
GO

/****** Object:  Table [dbo].[Conditions]    Script Date: 7/19/2019 3:57:56 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Conditions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CLAIM_DIAGNOSIS_CODE] [int] NULL,
	[DIAGNOSIS_CODE_DESC] [nvarchar](400) NULL,
	[BREED_DESC] [nvarchar](100) NULL,
	[WRITTEN_STATE] [nvarchar](5) NULL,
	[CLAIMED_AMT] [decimal](10, 5) NULL,
	[PAID_AMT] [decimal](10, 5) NULL,
	[RANK] [int] NULL,
 CONSTRAINT [PK_ConditionsNew] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO



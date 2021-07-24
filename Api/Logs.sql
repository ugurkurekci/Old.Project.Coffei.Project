USE [CoffeiSoft]
GO
/****** Object:  Table [dbo].[Logs]    Script Date: 24.07.2021 21:33:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[Detail] [nvarchar](max) NULL,
	[Date] [datetime] NOT NULL,
	[Audit] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

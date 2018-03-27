USE [TestNew]
GO

/****** Object:  Table [dbo].[TestOutput]    Script Date: 07/09/2015 15:37:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TestOutput](
	[ID] [int] NOT NULL,
	[A0] [int] NULL,
	[A1] [int] NULL,
	[A2] [int] NULL,
	[A3] [int] NULL,
	[A4] [int] NULL,
	[A5] [int] NULL,
	[A6] [int] NULL,
	[A7] [int] NULL,
	[A8] [int] NULL,
	[A9] [int] NULL,
	[FLAG] [int] NULL,
	[A10] [int] NULL,
	[A11] [int] NULL,
	[A12] [nvarchar](300) NULL,
	[A13] [nvarchar](300) NULL,
	[A14] [nvarchar](300) NULL,
	[A15] [nvarchar](300) NULL,
	[A16] [nvarchar](300) NULL,
	[A17] [nvarchar](300) NULL,
	[A18] [nvarchar](300) NULL,
	[A19] [nvarchar](300) NULL,
	[A20] [nvarchar](300) NULL,
	[A21] [nvarchar](300) NULL,
	[A22] [nvarchar](300) NULL,
	[A23] [nvarchar](300) NULL,
	[A24] [nvarchar](300) NULL,
	[A25] [nvarchar](300) NULL,
	[A26] [nvarchar](300) NULL,
	[A27] [nvarchar](300) NULL,
	[A28] [nvarchar](300) NULL,
	[A29] [nvarchar](300) NULL,
	[A30] [nvarchar](300) NULL,
	[ROUND] [nvarchar](50) NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TestOutput] ADD  CONSTRAINT [DF_TestOutput_A0]  DEFAULT ((0)) FOR [A0]
GO

ALTER TABLE [dbo].[TestOutput] ADD  CONSTRAINT [DF_TestOutput_A1]  DEFAULT ((0)) FOR [A1]
GO

ALTER TABLE [dbo].[TestOutput] ADD  CONSTRAINT [DF_TestOutput_A2]  DEFAULT ((0)) FOR [A2]
GO

ALTER TABLE [dbo].[TestOutput] ADD  CONSTRAINT [DF_TestOutput_A3]  DEFAULT ((0)) FOR [A3]
GO

ALTER TABLE [dbo].[TestOutput] ADD  CONSTRAINT [DF_TestOutput_A4]  DEFAULT ((0)) FOR [A4]
GO

ALTER TABLE [dbo].[TestOutput] ADD  CONSTRAINT [DF_TestOutput_A5]  DEFAULT ((0)) FOR [A5]
GO

ALTER TABLE [dbo].[TestOutput] ADD  CONSTRAINT [DF_TestOutput_A6]  DEFAULT ((0)) FOR [A6]
GO

ALTER TABLE [dbo].[TestOutput] ADD  CONSTRAINT [DF_TestOutput_A7]  DEFAULT ((0)) FOR [A7]
GO

ALTER TABLE [dbo].[TestOutput] ADD  CONSTRAINT [DF_TestOutput_A8]  DEFAULT ((0)) FOR [A8]
GO

ALTER TABLE [dbo].[TestOutput] ADD  CONSTRAINT [DF_TestOutput_A9]  DEFAULT ((0)) FOR [A9]
GO

ALTER TABLE [dbo].[TestOutput] ADD  CONSTRAINT [DF_TestOutput_FLAG]  DEFAULT ((0)) FOR [FLAG]
GO

ALTER TABLE [dbo].[TestOutput] ADD  CONSTRAINT [DF_TestOutput_A10]  DEFAULT ((0)) FOR [A10]
GO

ALTER TABLE [dbo].[TestOutput] ADD  CONSTRAINT [DF_TestOutput_A11]  DEFAULT ((0)) FOR [A11]
GO



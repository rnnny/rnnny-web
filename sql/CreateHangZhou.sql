USE [Test]
GO

/****** Object:  Table [dbo].[HangZhou]    Script Date: 11/19/2016 16:24:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[HangZhou](
	[Round] [nvarchar](50) NOT NULL,
	[Flag] [nvarchar](50) NULL,
	[ResultOne] [nvarchar](50) NULL,
	[ResultTwo] [nvarchar](50) NULL,
	[UPUP_NoCount] [int] NULL,
	[NearRepeat22_NoCount] [int] NULL,
	[Repeat22_Select] [int] NULL,
	[StrMiniRed] [int] NULL,
	[Str456] [int] NULL,
	[IsPrime] [int] NULL,
	[IsTwo] [int] NULL,
	[IsNearRepeat] [int] NULL,
	[SubSub] [int] NULL,
	[SumUP30Ball] [int] NULL,
	[SumUPUPBall] [int] NULL,
	[PrimeTwoNearRepeat] [int] NULL,
	[SixBallSum] [int] NULL,
	[FindCount0] [int] NULL,
	[FindCount1] [int] NULL,
	[FindCount2] [int] NULL,
	[FindCount3] [int] NULL,
	[FindCount4] [int] NULL,
	[FindCount5] [int] NULL,
	[FindCount6] [int] NULL,
	[FindCount7] [int] NULL,
	[Data] [float] NULL,
	[Data1] [float] NULL,
	[Data2] [float] NULL,
	[Data3] [float] NULL,
	[Data33] [nvarchar](400) NULL,
	[Mini0] [float] NULL,
	[Mini1] [float] NULL,
	[Mini2] [float] NULL,
	[Mini3] [float] NULL,
	[Mini4] [float] NULL,
	[Mini5] [float] NULL,
	[TwoSpss] [float] NULL,
	[PrimeSpss] [float] NULL,
	[NearRepeatSpss] [float] NULL,
	[TPNRSum] [float] NULL,
	[Add0] [nvarchar](50) NULL,
	[Add1] [nvarchar](50) NULL,
	[Add2] [nvarchar](50) NULL,
	[Add3] [nvarchar](50) NULL,
	[Add4] [int] NULL,
	[Add5] [int] NULL,
	[Add6] [int] NULL,
	[Add7] [float] NULL,
	[Add8] [float] NULL,
	[Add9] [float] NULL,
 CONSTRAINT [PK_HangZhou] PRIMARY KEY CLUSTERED 
(
	[Round] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[HangZhou] ADD  CONSTRAINT [DF_HangZhou_UPUP_NoCount]  DEFAULT ((0)) FOR [UPUP_NoCount]
GO

ALTER TABLE [dbo].[HangZhou] ADD  CONSTRAINT [DF_HangZhou_NearRepeat22_NoCount]  DEFAULT ((0)) FOR [NearRepeat22_NoCount]
GO

ALTER TABLE [dbo].[HangZhou] ADD  CONSTRAINT [DF_HangZhou_Repeat22_Select]  DEFAULT ((0)) FOR [Repeat22_Select]
GO

ALTER TABLE [dbo].[HangZhou] ADD  CONSTRAINT [DF_HangZhou_StrMiniRed]  DEFAULT ((0)) FOR [StrMiniRed]
GO

ALTER TABLE [dbo].[HangZhou] ADD  CONSTRAINT [DF_HangZhou_Str456]  DEFAULT ((0)) FOR [Str456]
GO

ALTER TABLE [dbo].[HangZhou] ADD  CONSTRAINT [DF_HangZhou_IsPrime]  DEFAULT ((0)) FOR [IsPrime]
GO

ALTER TABLE [dbo].[HangZhou] ADD  CONSTRAINT [DF_HangZhou_IsTwo]  DEFAULT ((0)) FOR [IsTwo]
GO

ALTER TABLE [dbo].[HangZhou] ADD  CONSTRAINT [DF_HangZhou_IsNearRepeat]  DEFAULT ((0)) FOR [IsNearRepeat]
GO

ALTER TABLE [dbo].[HangZhou] ADD  CONSTRAINT [DF_HangZhou_SubSub]  DEFAULT ((0)) FOR [SubSub]
GO

ALTER TABLE [dbo].[HangZhou] ADD  CONSTRAINT [DF_HangZhou_SumUP30Ball]  DEFAULT ((0)) FOR [SumUP30Ball]
GO

ALTER TABLE [dbo].[HangZhou] ADD  CONSTRAINT [DF_HangZhou_SumUPUPBall]  DEFAULT ((0)) FOR [SumUPUPBall]
GO

ALTER TABLE [dbo].[HangZhou] ADD  CONSTRAINT [DF_HangZhou_PrimeTwoNearRepeat]  DEFAULT ((0)) FOR [PrimeTwoNearRepeat]
GO

ALTER TABLE [dbo].[HangZhou] ADD  CONSTRAINT [DF_HangZhou_SixBallSum]  DEFAULT ((0)) FOR [SixBallSum]
GO

ALTER TABLE [dbo].[HangZhou] ADD  CONSTRAINT [DF_HangZhou_FindCount0]  DEFAULT ((0)) FOR [FindCount0]
GO

ALTER TABLE [dbo].[HangZhou] ADD  CONSTRAINT [DF_HangZhou_FindCount1]  DEFAULT ((0)) FOR [FindCount1]
GO

ALTER TABLE [dbo].[HangZhou] ADD  CONSTRAINT [DF_HangZhou_FindCount2]  DEFAULT ((0)) FOR [FindCount2]
GO

ALTER TABLE [dbo].[HangZhou] ADD  CONSTRAINT [DF_HangZhou_FindCount3]  DEFAULT ((0)) FOR [FindCount3]
GO

ALTER TABLE [dbo].[HangZhou] ADD  CONSTRAINT [DF_HangZhou_FindCount4]  DEFAULT ((0)) FOR [FindCount4]
GO

ALTER TABLE [dbo].[HangZhou] ADD  CONSTRAINT [DF_HangZhou_FindCount5]  DEFAULT ((0)) FOR [FindCount5]
GO

ALTER TABLE [dbo].[HangZhou] ADD  CONSTRAINT [DF_HangZhou_FindCount6]  DEFAULT ((0)) FOR [FindCount6]
GO

ALTER TABLE [dbo].[HangZhou] ADD  CONSTRAINT [DF_HangZhou_FindCount7]  DEFAULT ((0)) FOR [FindCount7]
GO

ALTER TABLE [dbo].[HangZhou] ADD  CONSTRAINT [DF_HangZhou_Data]  DEFAULT ((0)) FOR [Data]
GO

ALTER TABLE [dbo].[HangZhou] ADD  CONSTRAINT [DF_HangZhou_Data1]  DEFAULT ((0)) FOR [Data1]
GO

ALTER TABLE [dbo].[HangZhou] ADD  CONSTRAINT [DF_HangZhou_Data2]  DEFAULT ((0)) FOR [Data2]
GO

ALTER TABLE [dbo].[HangZhou] ADD  CONSTRAINT [DF_HangZhou_Data3]  DEFAULT ((0)) FOR [Data3]
GO

ALTER TABLE [dbo].[HangZhou] ADD  CONSTRAINT [DF_HangZhou_Data33]  DEFAULT ((0)) FOR [Data33]
GO

ALTER TABLE [dbo].[HangZhou] ADD  CONSTRAINT [DF_HangZhou_Mini0]  DEFAULT ((0)) FOR [Mini0]
GO

ALTER TABLE [dbo].[HangZhou] ADD  CONSTRAINT [DF_HangZhou_Mini1]  DEFAULT ((0)) FOR [Mini1]
GO

ALTER TABLE [dbo].[HangZhou] ADD  CONSTRAINT [DF_HangZhou_Mini2]  DEFAULT ((0)) FOR [Mini2]
GO

ALTER TABLE [dbo].[HangZhou] ADD  CONSTRAINT [DF_HangZhou_Mini3]  DEFAULT ((0)) FOR [Mini3]
GO

ALTER TABLE [dbo].[HangZhou] ADD  CONSTRAINT [DF_HangZhou_Mini4]  DEFAULT ((0)) FOR [Mini4]
GO

ALTER TABLE [dbo].[HangZhou] ADD  CONSTRAINT [DF_HangZhou_Mini5]  DEFAULT ((0)) FOR [Mini5]
GO

ALTER TABLE [dbo].[HangZhou] ADD  CONSTRAINT [DF_HangZhou_Two]  DEFAULT ((0)) FOR [TwoSpss]
GO

ALTER TABLE [dbo].[HangZhou] ADD  CONSTRAINT [DF_HangZhou_Prime]  DEFAULT ((0)) FOR [PrimeSpss]
GO

ALTER TABLE [dbo].[HangZhou] ADD  CONSTRAINT [DF_HangZhou_NearRepeat]  DEFAULT ((0)) FOR [NearRepeatSpss]
GO


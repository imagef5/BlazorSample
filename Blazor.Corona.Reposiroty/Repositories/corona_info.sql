USE [corona]
GO
/****** Object:  Table [dbo].[board_195]    Script Date: 2020-03-05 오후 5:46:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[board_195](
	[seq] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](200) NULL,
	[content] [varchar](max) NULL,
	[created] [datetime] NULL,
	[readnum] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[seq] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[board_196]    Script Date: 2020-03-05 오후 5:46:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[board_196](
	[seq] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](200) NULL,
	[content] [varchar](max) NULL,
	[created] [datetime] NULL,
	[readnum] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[seq] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Coronavirus_incheon]    Script Date: 2020-03-05 오후 5:46:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Coronavirus_local](
	[idx] [int] IDENTITY(1,1) NOT NULL,
	[whole_confirmed_cnt] [int] NULL,
	[death_cnt] [int] NULL,
	[checkup_cnt] [int] NULL,
	[negative_cnt] [int] NULL,
	[local_confirmed_cnt] [int] NULL,
	[confirmd_increase_cnt] [int] NULL,
	[local_contacted_cnt] [int] NULL,
	[contacted_increase_cnt] [int] NULL,
	[local_similar_cnt] [int] NULL,
	[similar_increase_cnt] [int] NULL,
	[local_self_isolation_cnt] [int] NULL,
	[self_isolation_increase_cnt] [int] NULL,
	[from_wuhan_cnt] [int] NULL,
	[wuhan_increase_cnt] [int] NULL,
	[offered] [datetime] NULL,
	[created] [datetime] NULL,
	[modified] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[idx] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Coronavirus_info]    Script Date: 2020-03-05 오후 5:46:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Coronavirus_info](
	[idx] [int] IDENTITY(1,1) NOT NULL,
	[contacted_self_isolation] [int] NULL,
	[clear_contacted_self_isolation] [int] NULL,
	[isolation_cnt] [int] NULL,
	[clear_isolation_cnt] [int] NULL,
	[self_isolation] [int] NULL,
	[clear_self_isolation] [int] NULL,
	[created] [datetime] NULL,
	[modified] [datetime] NULL,
	[offered] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[idx] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[board_195] ADD  DEFAULT (getdate()) FOR [created]
GO
ALTER TABLE [dbo].[board_195] ADD  DEFAULT ((0)) FOR [readnum]
GO
ALTER TABLE [dbo].[board_196] ADD  DEFAULT (getdate()) FOR [created]
GO
ALTER TABLE [dbo].[board_196] ADD  DEFAULT ((0)) FOR [readnum]
GO
ALTER TABLE [dbo].[Coronavirus_local] ADD  DEFAULT (getdate()) FOR [created]
GO
ALTER TABLE [dbo].[Coronavirus_local] ADD  DEFAULT (getdate()) FOR [modified]
GO
ALTER TABLE [dbo].[Coronavirus_info] ADD  DEFAULT (getdate()) FOR [created]
GO
ALTER TABLE [dbo].[Coronavirus_info] ADD  DEFAULT (getdate()) FOR [modified]
GO

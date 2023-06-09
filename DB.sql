USE [DemoChatDB]
GO
/****** Object:  Table [dbo].[ChatMessage]    Script Date: 11.03.2023 10:41:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChatMessage](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SenderID] [int] NULL,
	[ChatroomID] [int] NULL,
	[Date] [datetime] NULL,
	[Message] [varchar](69) NULL,
 CONSTRAINT [PK_ChatMessage] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Chatroom]    Script Date: 11.03.2023 10:41:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chatroom](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Topic] [varchar](30) NULL,
 CONSTRAINT [PK_Chatroom] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 11.03.2023 10:41:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 11.03.2023 10:41:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NULL,
	[DepartmentID] [int] NULL,
	[Username] [varchar](40) NULL,
	[Password] [varchar](40) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeesChatrooms]    Script Date: 11.03.2023 10:41:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeesChatrooms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeesID] [int] NULL,
	[ChatroomsID] [int] NULL,
 CONSTRAINT [PK_EmployeesChatrooms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ChatMessage] ON 

INSERT [dbo].[ChatMessage] ([ID], [SenderID], [ChatroomID], [Date], [Message]) VALUES (1, 1, 1, CAST(N'2023-03-11T09:35:20.567' AS DateTime), N'Цветёт герань')
INSERT [dbo].[ChatMessage] ([ID], [SenderID], [ChatroomID], [Date], [Message]) VALUES (2, 2, 1, CAST(N'2023-03-11T09:40:11.280' AS DateTime), N'Почему так')
SET IDENTITY_INSERT [dbo].[ChatMessage] OFF
GO
SET IDENTITY_INSERT [dbo].[Chatroom] ON 

INSERT [dbo].[Chatroom] ([Id], [Topic]) VALUES (1, N'Как там дела у хохлов?')
SET IDENTITY_INSERT [dbo].[Chatroom] OFF
GO
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([Id], [Name]) VALUES (1, N'Admin')
INSERT [dbo].[Department] ([Id], [Name]) VALUES (2, N'IT Helpdesk')
INSERT [dbo].[Department] ([Id], [Name]) VALUES (3, N'Sales')
INSERT [dbo].[Department] ([Id], [Name]) VALUES (4, N'Marketing')
SET IDENTITY_INSERT [dbo].[Department] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([ID], [Name], [DepartmentID], [Username], [Password]) VALUES (1, N'Marsel', 1, N'silense', N'1337')
INSERT [dbo].[Employee] ([ID], [Name], [DepartmentID], [Username], [Password]) VALUES (2, N'Vitya', 4, N'qwe', N'rty')
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[EmployeesChatrooms] ON 

INSERT [dbo].[EmployeesChatrooms] ([Id], [EmployeesID], [ChatroomsID]) VALUES (1, 1, 1)
INSERT [dbo].[EmployeesChatrooms] ([Id], [EmployeesID], [ChatroomsID]) VALUES (2, 2, 1)
SET IDENTITY_INSERT [dbo].[EmployeesChatrooms] OFF
GO
ALTER TABLE [dbo].[ChatMessage]  WITH CHECK ADD  CONSTRAINT [FK_ChatMessage_Chatroom] FOREIGN KEY([ChatroomID])
REFERENCES [dbo].[Chatroom] ([Id])
GO
ALTER TABLE [dbo].[ChatMessage] CHECK CONSTRAINT [FK_ChatMessage_Chatroom]
GO
ALTER TABLE [dbo].[ChatMessage]  WITH CHECK ADD  CONSTRAINT [FK_ChatMessage_Employee] FOREIGN KEY([SenderID])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[ChatMessage] CHECK CONSTRAINT [FK_ChatMessage_Employee]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Department] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Department]
GO
ALTER TABLE [dbo].[EmployeesChatrooms]  WITH CHECK ADD  CONSTRAINT [FK_EmployeesChatrooms_Chatroom] FOREIGN KEY([ChatroomsID])
REFERENCES [dbo].[Chatroom] ([Id])
GO
ALTER TABLE [dbo].[EmployeesChatrooms] CHECK CONSTRAINT [FK_EmployeesChatrooms_Chatroom]
GO
ALTER TABLE [dbo].[EmployeesChatrooms]  WITH CHECK ADD  CONSTRAINT [FK_EmployeesChatrooms_Employee] FOREIGN KEY([EmployeesID])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[EmployeesChatrooms] CHECK CONSTRAINT [FK_EmployeesChatrooms_Employee]
GO

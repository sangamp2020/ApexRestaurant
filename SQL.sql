CREATE DATABASE [ApexRestaurantDB]
USE [ApexRestaurantDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Customers]
(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](200) NULL,
	[LastName] [nvarchar](200) NULL,
	[Address] [nvarchar](500) NULL,
	[PhoneRes] [nvarchar](50) NULL,
	[PhoneMob] [nvarchar](50) NULL,
	[EnrollDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [nvarchar](200) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [nvarchar](200) NULL,
	[UpdatedOn] [datetime] NULL,
	PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MealDishes]
(
	[MealDishesId] [int] IDENTITY(1,1) NOT NULL,
	[MealId] [int] NULL,
	[MenuItemId] [int] NULL,
	[Quantity] [nvarchar](60) NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [nvarchar](200) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [nvarchar](200) NULL,
	[UpdatedOn] [datetime] NULL,
	PRIMARY KEY CLUSTERED 
(
	[MealDishesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Meals]
(
	[MealId] [int] IDENTITY(1,1) NOT NULL,
	[StaffId] [int] NULL,
	[CustomerId] [int] NULL,
	[Date_of_Meal] [datetime] NULL,
	[Cost_of_Meal] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [nvarchar](200) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [nvarchar](200) NULL,
	[UpdatedOn] [datetime] NULL,
	PRIMARY KEY CLUSTERED 
(
	[MealId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MenuItems]
(
	[MenuItemId] [int] IDENTITY(1,1) NOT NULL,
	[MenuId] [int] NULL,
	[Menu_Items_Name] [nvarchar](200) NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [nvarchar](200) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [nvarchar](200) NULL,
	[UpdatedOn] [datetime] NULL,
	PRIMARY KEY CLUSTERED 
(
	[MenuItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Menus]
(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Menu_Name] [nvarchar](200) NULL,
	[Available_Date_From] [datetime] NULL,
	[Available_Date_To] [datetime] NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [nvarchar](200) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [nvarchar](200) NULL,
	[UpdatedOn] [datetime] NULL,
	PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [StaffRoles]
(
	[Staff_Roles_Id] [int] IDENTITY(1,1) NOT NULL,
	[Staff_Roles_Description] [nvarchar](200) NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [nvarchar](200) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [nvarchar](200) NULL,
	[UpdatedOn] [datetime] NULL,
	PRIMARY KEY CLUSTERED 
(
	[Staff_Roles_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Staffs]
(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Staff_Role_Id] [int] NULL,
	[FirstName] [nvarchar](200) NULL,
	[LastName] [nvarchar](200) NULL,
	[Address] [nvarchar](500) NULL,
	[PhoneRes] [nvarchar](50) NULL,
	[PhoneMob] [nvarchar](50) NULL,
	[EnrollDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [nvarchar](200) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [nvarchar](200) NULL,
	[UpdatedOn] [datetime] NULL,
	PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [Customers] ON

INSERT [Customers]
	([Id], [FirstName], [LastName], [Address], [PhoneRes], [PhoneMob], [EnrollDate], [IsActive], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn])
VALUES
	(1, N'Sangam', N'Pudasaini', N'Kathmandu', N'041234567', N'98765432', CAST(N'2020-07-09T00:00:00.000' AS DateTime), 1, N'admin', CAST(N'2020-07-09T00:00:00.000' AS DateTime), N'admin', CAST(N'2020-09-19T00:00:00.000' AS DateTime))
INSERT [Customers]
	([Id], [FirstName], [LastName], [Address], [PhoneRes], [PhoneMob], [EnrollDate], [IsActive], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn])
VALUES
	(2, N'Hari', N'User', N'Ram', N'12347642', N'987615231', CAST(N'2020-03-19T12:00:00.123' AS DateTime), 1, N'admin', CAST(N'2020-03-19T12:20:00.123' AS DateTime),N'shyam', CAST(N'2020-03-19T12:00:00.123' AS DateTime))

SET IDENTITY_INSERT [Customers] OFF
SET IDENTITY_INSERT [MealDishes] ON

INSERT [MealDishes]
	([MealDishesId], [MealId], [MenuItemId], [Quantity], [IsActive], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn])
VALUES
	(9, 5, 5, N'7', 2, N'waiter', CAST(N'2020-03-19T12:00:00.123' AS DateTime), N'shyam', CAST(N'2020-03-19T12:00:00.123' AS DateTime))
SET IDENTITY_INSERT [MealDishes] OFF
SET IDENTITY_INSERT [Meals] ON

INSERT [Meals]
	([MealId], [StaffId], [CustomerId], [Date_of_Meal], [Cost_of_Meal], [IsActive], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn])
VALUES
	(1, 2, 3, CAST(N'2020-07-19T00:00:00.000' AS DateTime), N'120', 1, N'shyam', CAST(N'2020-07-19T00:00:00.000' AS DateTime), N'Shyam', CAST(N'2020-07-19T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [Meals] OFF
SET IDENTITY_INSERT [MenuItems] ON

INSERT [MenuItems]
	([MenuItemId], [MenuId], [Menu_Items_Name], [IsActive], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn])
VALUES
	(1, 2, N'chowmein', 1, N'ram', CAST(N'2020-03-19T12:00:00.123' AS DateTime), N'admin', CAST(N'2020-03-19T12:20:00.123' AS DateTime))
INSERT [MenuItems]
	([MenuItemId], [MenuId], [Menu_Items_Name], [IsActive], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn])
VALUES
	(2, 1, N'sekuwa', 1, N'chef', CAST(N'2020-03-19T12:00:00.123' AS DateTime), N'chef', CAST(N'2020-03-19T12:20:00.123' AS DateTime))
SET IDENTITY_INSERT [MenuItems] OFF
SET IDENTITY_INSERT [Menus] ON

INSERT [Menus]
	([Id], [Menu_Name], [Available_Date_From], [Available_Date_To], [IsActive], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn])
VALUES
	(1, N'Japanese', CAST(N'2020-03-19T12:00:00.123' AS DateTime), CAST(N'2020-07-19T12:00:00.123' AS DateTime),1, N'admin', CAST(N'2020-03-19T12:20:00.123' AS DateTime), N'Hari', CAST(N'2020-05-23T01:30:25.234' AS DateTime))
INSERT [Menus]
	([Id], [Menu_Name], [Available_Date_From], [Available_Date_To], [IsActive], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn])
VALUES
    (2, N'continental', CAST(N'2020-04-26T00:00:00.000' AS DateTime), CAST(N'2020-04-30T00:00:00.000' AS DateTime), 1, N'admin', CAST(N'2020-04-26T00:00:00.000' AS DateTime), N'admin', CAST(N'2020-04-26T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [Menus] OFF
SET IDENTITY_INSERT [StaffRoles] ON

INSERT [StaffRoles]
	([Staff_Roles_Id], [Staff_Roles_Description], [IsActive], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn])
VALUES
	(1, N'waiter', 1, N'admin', CAST(N'2020-03-19T12:00:00.123' AS DateTime), N'admin', CAST(N'2020-03-19T12:20:00.123' AS DateTime))
SET IDENTITY_INSERT [StaffRoles] OFF
SET IDENTITY_INSERT [Staffs] ON

INSERT [Staffs]
	([Id], [Staff_Role_Id], [FirstName], [LastName], [Address], [PhoneRes], [PhoneMob], [EnrollDate], [IsActive], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn])
VALUES
	(1, 1, N'Shyam', N'Sharma', N'Kathmandu', N'4567899', N'987654421', CAST(N'2020-03-19T12:20:00.123' AS DateTime), 1, N'admin', CAST(N'2020-03-19T12:20:00.123' AS DateTime), N'Admin', CAST(N'2020-03-19T12:00:00.123' AS DateTime))
SET IDENTITY_INSERT [Staffs] OFF
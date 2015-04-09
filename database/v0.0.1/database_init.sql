/* Uncomment if you want to create the SQL Server login
USE [master]
GO
CREATE LOGIN [FeatureGenieUser] WITH PASSWORD=N'password', DEFAULT_DATABASE=[FeatureGenieDB], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO

CREATE USER [FeatureGenieUser] FOR LOGIN [FeatureGenieUser] WITH DEFAULT_SCHEMA=[genie]
GO
*/

/****** Object:  Schema [genie]    Script Date: 3/14/2015 8:43:50 PM ******/
CREATE SCHEMA [genie]
GO


/****** Object:  Table [genie].[Feature]    Script Date: 3/14/2015 8:57:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [genie].[Application](
	[ApplicationId] [INT] IDENTITY(1,1) NOT NULL,
	[Name] [VARCHAR](50) NOT NULL,
	[Description] [VARCHAR](MAX) NULL,
 CONSTRAINT [PK_Application] PRIMARY KEY CLUSTERED 
(
	[ApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [genie].[Feature](
	[FeatureId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [VARCHAR](50) NOT NULL,
	[Description] [varchar](max) NULL,
	[IsEnabled] [bit] NOT NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[Ratio] [int] NULL,
	[ApplicationId] [INT] NOT NULL,
 CONSTRAINT [PK_Feature] PRIMARY KEY CLUSTERED 
(
	[FeatureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [genie].[Feature]  WITH CHECK ADD  CONSTRAINT [FK_Feature_Application] FOREIGN KEY([ApplicationId])
REFERENCES [genie].[Application] ([ApplicationId])
GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [genie].[Feature] ADD  CONSTRAINT [DF_Feature_IsEnabled]  DEFAULT ((0)) FOR [IsEnabled]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'If set to false then the feature will no be enabled.  If set to true the feature will be enabled unless the optional start time and/or end time is set.' , @level0type=N'SCHEMA',@level0name=N'genie', @level1type=N'TABLE',@level1name=N'Feature', @level2type=N'COLUMN',@level2name=N'IsEnabled'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date and time the feature will be turned on.  If the feature is enabled and the start time is greater than now then the feature will effectively be disabled.' , @level0type=N'SCHEMA',@level0name=N'genie', @level1type=N'TABLE',@level1name=N'Feature', @level2type=N'COLUMN',@level2name=N'StartTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date and time the feature will be turned off.  If the feature is enabled and the end time is less than now then the feature will effectively be disabled.' , @level0type=N'SCHEMA',@level0name=N'genie', @level1type=N'TABLE',@level1name=N'Feature', @level2type=N'COLUMN',@level2name=N'EndTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The ratio of users that will see this feature.  Express as a percentage.  50 will be interpreted as 50%.' , @level0type=N'SCHEMA',@level0name=N'genie', @level1type=N'TABLE',@level1name=N'Feature', @level2type=N'COLUMN',@level2name=N'Ratio'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Features that can be turned on or off.' , @level0type=N'SCHEMA',@level0name=N'genie', @level1type=N'TABLE',@level1name=N'Feature'
GO




GRANT INSERT ON SCHEMA :: genie TO FeatureGenieUser;
GRANT SELECT ON SCHEMA :: genie TO FeatureGenieUser;
GRANT DELETE ON SCHEMA :: genie TO FeatureGenieUser;

/****** Object:  Table [genie].[ValueType]    Script Date: 4/5/2015 10:21:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [genie].[ValueType](
	[ValueTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varbinary](50) NULL,
 CONSTRAINT [PK_ValueType] PRIMARY KEY CLUSTERED 
(
	[ValueTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Describes the value type for a configuration setting.  Types can be any primitive type like int, double, string, etc or a custom regex value like phone number or email address, or it can be a fixed selection based on a list of values.' , @level0type=N'SCHEMA',@level0name=N'genie', @level1type=N'TABLE',@level1name=N'ValueType'
GO

/****** Object:  Table [genie].[Configuration]    Script Date: 4/5/2015 10:22:43 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [genie].[Configuration](
	[ConfigurationId] [int] IDENTITY(1,1) NOT NULL,
	[ApplicationId] [int] NOT NULL,
	[ValueTypeId] [int] NULL,
	[Name] [varchar](50) NOT NULL,
	[Value] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Configuration] PRIMARY KEY CLUSTERED 
(
	[ConfigurationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [genie].[Configuration]  WITH CHECK ADD  CONSTRAINT [FK_Configuration_Application] FOREIGN KEY([ApplicationId])
REFERENCES [genie].[Application] ([ApplicationId])
GO

ALTER TABLE [genie].[Configuration] CHECK CONSTRAINT [FK_Configuration_Application]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Application configuration settings' , @level0type=N'SCHEMA',@level0name=N'genie', @level1type=N'TABLE',@level1name=N'Configuration'
GO

/****** Object:  Table [genie].[SelectionType]    Script Date: 4/5/2015 10:34:23 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [genie].[SelectionType](
	[SelectionTypeId] [int] IDENTITY(1,1) NOT NULL,
	[ApplicationId] [int] NOT NULL,
	[ConfigurationId] [int] NOT NULL,
	[SelectionValue] [varchar](50) NOT NULL,
	[SortOrder] [int] NULL,
 CONSTRAINT [PK_SelectionType] PRIMARY KEY CLUSTERED 
(
	[SelectionTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [genie].[SelectionType]  WITH CHECK ADD  CONSTRAINT [FK_SelectionType_Application] FOREIGN KEY([ApplicationId])
REFERENCES [genie].[Application] ([ApplicationId])
GO

ALTER TABLE [genie].[SelectionType] CHECK CONSTRAINT [FK_SelectionType_Application]
GO

ALTER TABLE [genie].[SelectionType]  WITH CHECK ADD  CONSTRAINT [FK_SelectionType_Configuration] FOREIGN KEY([ConfigurationId])
REFERENCES [genie].[Configuration] ([ConfigurationId])
GO

ALTER TABLE [genie].[SelectionType] CHECK CONSTRAINT [FK_SelectionType_Configuration]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Represents an enumeration for a given application configuration setting.' , @level0type=N'SCHEMA',@level0name=N'genie', @level1type=N'TABLE',@level1name=N'SelectionType'
GO


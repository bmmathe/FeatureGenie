USE FeatureGenieDB
GO	

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

ALTER TABLE genie.Feature ADD CONSTRAINT
	FK_Feature_Application FOREIGN KEY
	(
	FeatureId
	) REFERENCES genie.Application
	(
	ApplicationId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
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


USE [master]
GO
CREATE LOGIN [FeatureGenieUser] WITH PASSWORD=N'password', DEFAULT_DATABASE=[FeatureGenieDB], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO

USE [FeatureGenieDB]
GO
CREATE USER [FeatureGenieUser] FOR LOGIN [FeatureGenieUser] WITH DEFAULT_SCHEMA=[genie]
GO

GRANT INSERT ON SCHEMA :: genie TO FeatureGenieUser;
GRANT SELECT ON SCHEMA :: genie TO FeatureGenieUser;
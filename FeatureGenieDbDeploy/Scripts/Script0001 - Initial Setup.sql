/*
Script created by SQL Compare version 11.1.3 from Red Gate Software Ltd at 4/13/2015 10:37:15 PM
*/
SET NUMERIC_ROUNDABORT OFF
GO
SET ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT, QUOTED_IDENTIFIER, ANSI_NULLS ON
GO
SET XACT_ABORT ON
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE

BEGIN TRANSACTION
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating schemas'
GO
CREATE SCHEMA [genie]
AUTHORIZATION [dbo]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [genie].[Feature]'
GO
CREATE TABLE [genie].[Feature]
(
[FeatureId] [int] NOT NULL IDENTITY(1, 1),
[Name] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Description] [varchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[IsEnabled] [bit] NOT NULL CONSTRAINT [DF_Feature_IsEnabled] DEFAULT ((0)),
[StartTime] [datetime] NULL,
[EndTime] [datetime] NULL,
[Ratio] [int] NULL,
[ApplicationId] [int] NOT NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_Feature] on [genie].[Feature]'
GO
ALTER TABLE [genie].[Feature] ADD CONSTRAINT [PK_Feature] PRIMARY KEY CLUSTERED  ([FeatureId])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [genie].[Application]'
GO
CREATE TABLE [genie].[Application]
(
[ApplicationId] [int] NOT NULL IDENTITY(1, 1),
[Name] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Description] [varchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_Application] on [genie].[Application]'
GO
ALTER TABLE [genie].[Application] ADD CONSTRAINT [PK_Application] PRIMARY KEY CLUSTERED  ([ApplicationId])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [genie].[Configuration]'
GO
CREATE TABLE [genie].[Configuration]
(
[ConfigurationId] [int] NOT NULL IDENTITY(1, 1),
[ApplicationId] [int] NOT NULL,
[ValueTypeId] [int] NULL,
[Name] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Value] [varchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_Configuration] on [genie].[Configuration]'
GO
ALTER TABLE [genie].[Configuration] ADD CONSTRAINT [PK_Configuration] PRIMARY KEY CLUSTERED  ([ConfigurationId])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [genie].[SelectionType]'
GO
CREATE TABLE [genie].[SelectionType]
(
[SelectionTypeId] [int] NOT NULL IDENTITY(1, 1),
[ApplicationId] [int] NOT NULL,
[ConfigurationId] [int] NOT NULL,
[SelectionValue] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[SortOrder] [int] NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_SelectionType] on [genie].[SelectionType]'
GO
ALTER TABLE [genie].[SelectionType] ADD CONSTRAINT [PK_SelectionType] PRIMARY KEY CLUSTERED  ([SelectionTypeId])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [genie].[ValueType]'
GO
CREATE TABLE [genie].[ValueType]
(
[ValueTypeId] [int] NOT NULL IDENTITY(1, 1),
[Name] [varbinary] (50) NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_ValueType] on [genie].[ValueType]'
GO
ALTER TABLE [genie].[ValueType] ADD CONSTRAINT [PK_ValueType] PRIMARY KEY CLUSTERED  ([ValueTypeId])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Adding foreign keys to [genie].[Configuration]'
GO
ALTER TABLE [genie].[Configuration] ADD CONSTRAINT [FK_Configuration_Application] FOREIGN KEY ([ApplicationId]) REFERENCES [genie].[Application] ([ApplicationId])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Adding foreign keys to [genie].[Feature]'
GO
ALTER TABLE [genie].[Feature] ADD CONSTRAINT [FK_Feature_Application] FOREIGN KEY ([ApplicationId]) REFERENCES [genie].[Application] ([ApplicationId])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Adding foreign keys to [genie].[SelectionType]'
GO
ALTER TABLE [genie].[SelectionType] ADD CONSTRAINT [FK_SelectionType_Application] FOREIGN KEY ([ApplicationId]) REFERENCES [genie].[Application] ([ApplicationId])
ALTER TABLE [genie].[SelectionType] ADD CONSTRAINT [FK_SelectionType_Configuration] FOREIGN KEY ([ConfigurationId]) REFERENCES [genie].[Configuration] ([ConfigurationId])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating extended properties'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Application configuration settings', 'SCHEMA', N'genie', 'TABLE', N'Configuration', NULL, NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_addextendedproperty N'MS_Description', N'Features that can be turned on or off.', 'SCHEMA', N'genie', 'TABLE', N'Feature', NULL, NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_addextendedproperty N'MS_Description', N'The date and time the feature will be turned off.  If the feature is enabled and the end time is less than now then the feature will effectively be disabled.', 'SCHEMA', N'genie', 'TABLE', N'Feature', 'COLUMN', N'EndTime'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_addextendedproperty N'MS_Description', N'If set to false then the feature will no be enabled.  If set to true the feature will be enabled unless the optional start time and/or end time is set.', 'SCHEMA', N'genie', 'TABLE', N'Feature', 'COLUMN', N'IsEnabled'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_addextendedproperty N'MS_Description', N'The ratio of users that will see this feature.  Express as a percentage.  50 will be interpreted as 50%.', 'SCHEMA', N'genie', 'TABLE', N'Feature', 'COLUMN', N'Ratio'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_addextendedproperty N'MS_Description', N'The date and time the feature will be turned on.  If the feature is enabled and the start time is greater than now then the feature will effectively be disabled.', 'SCHEMA', N'genie', 'TABLE', N'Feature', 'COLUMN', N'StartTime'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_addextendedproperty N'MS_Description', N'Represents an enumeration for a given application configuration setting.', 'SCHEMA', N'genie', 'TABLE', N'SelectionType', NULL, NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_addextendedproperty N'MS_Description', N'Describes the value type for a configuration setting.  Types can be any primitive type like int, double, string, etc or a custom regex value like phone number or email address, or it can be a fixed selection based on a list of values.', 'SCHEMA', N'genie', 'TABLE', N'ValueType', NULL, NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Altering permissions on [genie]'
GO
GRANT SELECT ON SCHEMA:: [genie] TO [FeatureGenieUser]
GRANT INSERT ON SCHEMA:: [genie] TO [FeatureGenieUser]
GRANT DELETE ON SCHEMA:: [genie] TO [FeatureGenieUser]
GRANT UPDATE ON SCHEMA:: [genie] TO [FeatureGenieUser]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
COMMIT TRANSACTION
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
DECLARE @Success AS BIT
SET @Success = 1
SET NOEXEC OFF
IF (@Success = 1) PRINT 'The database update succeeded'
ELSE BEGIN
	IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION
	PRINT 'The database update failed'
END
GO

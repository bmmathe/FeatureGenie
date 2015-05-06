USE [FeatureGenieDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [genie].[FeatureAuditLog](
	[FeatureAuditId] [int] IDENTITY(1,1) NOT NULL,
	[FeatureId] [int] NULL,
	[FieldName] [nvarchar](max) NULL,
	[OldValue] [nvarchar](max) NULL,
	[NewValue] [nvarchar](max) NULL,
	[User] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_FeatureAuditLog] PRIMARY KEY CLUSTERED 
(
	[FeatureAuditId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [genie].[FeatureAuditLog] CHECK CONSTRAINT [FK_FeatureAuditLog_FeatureAuditLog]
GO

ALTER TABLE [genie].[FeatureAuditLog] ADD CONSTRAINT CREATED_DATE DEFAULT GETDATE() FOR CreatedDate
GO
--next table
CREATE TABLE [genie].[ConfigurationAuditLog](
	[ConfigurationAuditId] [int] IDENTITY(1,1) NOT NULL,
	[ConfigurationId] [int] NULL,
	[FieldName] [nvarchar](max) NULL,
	[OldValue] [nvarchar](max) NULL,
	[NewValue] [nvarchar](max) NULL,
	[User] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_ConfigurationAuditLog] PRIMARY KEY CLUSTERED 
(
	[ConfigurationAuditId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [genie].[ConfigurationAuditLog] CHECK CONSTRAINT [FK_ConfigurationAuditLog_ConfigurationAuditLog]
GO

ALTER TABLE [genie].[ConfigurationAuditLog] ADD CONSTRAINT CREATED_DATE DEFAULT GETDATE() FOR CreatedDate
GO
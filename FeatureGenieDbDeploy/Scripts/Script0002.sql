BEGIN TRANSACTION
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

ALTER TABLE genie.FeatureAuditLog ADD CONSTRAINT
	DF_FeatureAuditLog_CreatedDate DEFAULT getdate() FOR CreatedDate

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

ALTER TABLE [genie].[ConfigurationAuditLog] ADD CONSTRAINT DF_ConfigurationAuditLog_CreatedDate DEFAULT GETDATE() FOR CreatedDate
COMMIT
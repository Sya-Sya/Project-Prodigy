CREATE TABLE [dbo].[Logs](
	[id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[errorPage] [varchar](max) NULL,
	[errorMsg] [varchar](max) NULL,
	[errorDetails] [varchar](max) NULL,
	[createdBy] [varchar](50) NULL,
	[createdDate] [datetime] NULL);
create table [Bus](
[Id] uniqueidentifier not null primary key,
[Name] nvarchar(MAX) null,
[IsMechanicWorking] bit null,
[ServiceId] uniqueidentifier not null,
[MechanicId] uniqueidentifier not null,
CONSTRAINT [IX_ServiceID] UNIQUE NONCLUSTERED 
(
	[ServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_MechanicID] UNIQUE NONCLUSTERED 
(
	[MechanicID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
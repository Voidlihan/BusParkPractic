create table [Service](
[Id] uniqueidentifier not null primary key,
[Name] nvarchar(MAX) null,
[IsActual] bit null,
[BusId] uniqueidentifier not null,
CONSTRAINT [IX_BusID] UNIQUE NONCLUSTERED 
(
	[BusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
﻿create table [Mechanic](
[Id] uniqueidentifier not null primary key,
[Name] nvarchar(MAX) null,
[IsWorking] bit null,
[ServiceId] uniqueidentifier not null,
[BusId] uniqueidentifier not null,
CONSTRAINT [IX_Mech_ServiceID] UNIQUE NONCLUSTERED 
(
	[ServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Mech_BusID] UNIQUE NONCLUSTERED 
(
	[BusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
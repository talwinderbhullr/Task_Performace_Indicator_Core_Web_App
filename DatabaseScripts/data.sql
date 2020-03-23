SET IDENTITY_INSERT [dbo].[Operator] ON
INSERT INTO [dbo].[Operator] ([Id], [Name], [IsPermanent]) VALUES (1, N'John Smith', 1)
INSERT INTO [dbo].[Operator] ([Id], [Name], [IsPermanent]) VALUES (2, N'Ken Watson', 0)
INSERT INTO [dbo].[Operator] ([Id], [Name], [IsPermanent]) VALUES (3, N'Harry Davis', 0)
SET IDENTITY_INSERT [dbo].[Operator] OFF
SET IDENTITY_INSERT [dbo].[Task] ON
INSERT INTO [dbo].[Task] ([Id], [Name], [EstimatedTime]) VALUES (1, N'Rotor Assembly', 5)
INSERT INTO [dbo].[Task] ([Id], [Name], [EstimatedTime]) VALUES (2, N'Engine Assembly', 6)
INSERT INTO [dbo].[Task] ([Id], [Name], [EstimatedTime]) VALUES (3, N'Gear Assembly', 4)
SET IDENTITY_INSERT [dbo].[Task] OFF
SET IDENTITY_INSERT [dbo].[TaskPerformance] ON
INSERT INTO [dbo].[TaskPerformance] ([Id], [CompletedTime], [TaskId], [OperatorId]) VALUES (1, 4, 1, 1)
INSERT INTO [dbo].[TaskPerformance] ([Id], [CompletedTime], [TaskId], [OperatorId]) VALUES (3, 7, 2, 1)
INSERT INTO [dbo].[TaskPerformance] ([Id], [CompletedTime], [TaskId], [OperatorId]) VALUES (4, 6, 2, 2)
INSERT INTO [dbo].[TaskPerformance] ([Id], [CompletedTime], [TaskId], [OperatorId]) VALUES (5, 3, 3, 3)
SET IDENTITY_INSERT [dbo].[TaskPerformance] OFF

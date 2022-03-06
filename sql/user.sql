USE [LaptopShopOnline001]
GO
INSERT [dbo].[User] ([Id], [UserGroupId], [UserName], [Password], [ConfirmPassword], [FirstName], [LastName], [Email], [ResetPasswordCode], [Address], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) 
VALUES (N'b9c6d5c0-e616-40a0-9f04-202a371075b3', N'MANAGER_DEFAULT', N'admin', N'202cb962ac59075b964b07152d234b70', N'0192023a7bbd73250516f069df18b500', N'Nguyễn Văn', N'Anh', N'anh@gmail.com', NULL, N'Đà Nẵng', CAST(N'2019-04-21T15:31:55.0000000+07:00' AS DateTimeOffset), NULL, CAST(N'2022-02-18T20:29:15.1310553+07:00' AS DateTimeOffset), N'admin', 0)
GO
INSERT [dbo].[User] ([Id], [UserGroupId], [UserName], [Password], [ConfirmPassword], [FirstName], [LastName], [Email], [ResetPasswordCode], [Address], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) 
VALUES (N'7a336c92-68ce-4cdb-b480-3ec3441b81ba', N'SELLER_DEFAULT', N'leminh', N'202cb962ac59075b964b07152d234b70', N'leminh', N'Lê', N'Minh', N'leminh@gmail.com', NULL, N'Đà Nẵng', CAST(N'2019-04-21T15:31:55.0000000+07:00' AS DateTimeOffset), NULL, CAST(N'2022-02-18T20:29:15.1310553+07:00' AS DateTimeOffset), N'admin', 0)
GO
INSERT [dbo].[User] ([Id], [UserGroupId], [UserName], [Password], [ConfirmPassword], [FirstName], [LastName], [Email], [ResetPasswordCode], [Address], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted])
VALUES (N'a03a1843-7733-4b0c-8039-4bbec27645d8', N'BUYER_DEFAULT', N'bnguyenvy', N'202cb962ac59075b964b07152d234b70', N'f64cf8c7e22b262de23f9bcc8b384bdd', N'Nguyễn', N'Vy', N'bnguyenvy@gmail.com', NULL, N'Hà Nội', CAST(N'2022-03-01T01:06:18.2361099+07:00' AS DateTimeOffset), N'admin', NULL, NULL, 0)
GO
INSERT [dbo].[User] ([Id], [UserGroupId], [UserName], [Password], [ConfirmPassword], [FirstName], [LastName], [Email], [ResetPasswordCode], [Address], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted])
VALUES (N'2b71668a-2ef1-4630-9cd6-951f58917635', N'MANAGER_DEFAULT', N'admin02', N'202cb962ac59075b964b07152d234b70', N'admin02', N'admin02', N'admin02', N'admin02@gmail.com', NULL,N'Đà Nẵng', CAST(N'2019-04-21T15:31:55.0000000+07:00' AS DateTimeOffset), NULL, CAST(N'2022-02-18T20:29:15.1310553+07:00' AS DateTimeOffset), N'admin', 0)
GO
INSERT [dbo].[User] ([Id], [UserGroupId], [UserName], [Password], [ConfirmPassword], [FirstName], [LastName], [Email], [ResetPasswordCode], [Address], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted]) 
VALUES (N'23a66818-1f02-44dd-a8a5-ce2993123456', N'BUYER_DEFAULT', N'tom', N'202cb962ac59075b964b07152d234b70', N'0192023a7bbd73250516f069df18b500', N'An', N'Son', N'anson@gmail.com', NULL,N'Đà Nẵng', CAST(N'2019-04-21T15:31:55.0000000+07:00' AS DateTimeOffset), NULL, CAST(N'2022-02-18T20:29:15.1310553+07:00' AS DateTimeOffset), N'admin', 0)
GO
INSERT [dbo].[User] ([Id], [UserGroupId], [UserName], [Password], [ConfirmPassword], [FirstName], [LastName], [Email], [ResetPasswordCode], [Address], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsDeleted])
VALUES (N'23a66818-1f02-44dd-a8a5-ce29939a9bf2', N'SELLER_DEFAULT', N'slevy', N'202cb962ac59075b964b07152d234b70', N'slevy', N'Lê', N'Vy', N'slevy@gmail.com', NULL, N'Đà Nẵng', CAST(N'2022-03-01T01:05:07.0000000+07:00' AS DateTimeOffset), N'admin', CAST(N'2022-03-02T08:35:48.0697304+07:00' AS DateTimeOffset), N'admin', 0)
GO

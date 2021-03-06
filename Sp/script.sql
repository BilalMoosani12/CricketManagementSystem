USE [ScoreExecDb]
GO
SET IDENTITY_INSERT [dbo].[AspNetRoles] ON 
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (16, NULL, N'Club Admin', N'CLUB ADMIN')
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (19, NULL, N'Administrator', N'ADMINISTRATOR')
SET IDENTITY_INSERT [dbo].[AspNetRoles] OFF

SET IDENTITY_INSERT [dbo].[AspNetUsers] ON 
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (51, 0, N'966a7732-ddbf-4674-9197-7d02de5808d9', N'mehmoodkhan84@gmail.com', 1, 1, NULL, N'MEHMOODKHAN84@GMAIL.COM', N'INQILAB001', N'AQAAAAEAACcQAAAAEMRbMUEPtDBwC2zY6pG1yARe/WL/DNiGNyOcwxW7w0nSK1iPXhtQip4qN1aLsVu0Iw==', NULL, 0, N'83d6edf9-2bf7-4cd9-8c53-1a7f6f7c453b', 0, N'inqilab001')
SET IDENTITY_INSERT [dbo].[AspNetUsers] OFF
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId], [RoleId1], [UserId1]) VALUES (51, 16, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Teams] ON 

INSERT [dbo].[Teams] ([TeamId], [City], [Place], [TeamLogo], [Team_Name], [Zone], [IsRegistered], [Contact]) VALUES (1, N'Karachi', N'Malir City',null, N'Gulzar Cricket Club', N'4', 0, N'03353928246')
INSERT [dbo].[Teams] ([TeamId], [City], [Place], [TeamLogo], [Team_Name], [Zone], [IsRegistered], [Contact]) VALUES (2, N'Karachi', NULL, NULL, N'Pak Shaheen', NULL, 0, NULL)
INSERT [dbo].[Teams] ([TeamId], [City], [Place], [TeamLogo], [Team_Name], [Zone], [IsRegistered], [Contact]) VALUES (3, N'Karachi', N'MALIR',null, N'Inqilab Cricket Club', N'4', 0, N'0313-2276376')
SET IDENTITY_INSERT [dbo].[Teams] OFF
SET IDENTITY_INSERT [dbo].[ClubAdmins] ON 

INSERT [dbo].[ClubAdmins] ([ClubAdminId], [TeamId], [UserId]) VALUES (1, 1, 51)
INSERT [dbo].[ClubAdmins] ([ClubAdminId], [TeamId], [UserId]) VALUES (2, 2, 51)
INSERT [dbo].[ClubAdmins] ([ClubAdminId], [TeamId], [UserId]) VALUES (3, 3, 51)
SET IDENTITY_INSERT [dbo].[ClubAdmins] OFF
SET IDENTITY_INSERT [dbo].[Tournaments] ON 

INSERT [dbo].[Tournaments] ([TournamentId], [Organizor], [StartingDate], [TenantUserId], [TournamentName], [UserId]) VALUES (1, N'Pole of Cricket', CAST(N'2018-01-27T00:00:00.0000000' AS DateTime2), NULL, N'1st Shamroz Memorial T20 Cricket Tournament 2018', 51)
SET IDENTITY_INSERT [dbo].[Tournaments] OFF
SET IDENTITY_INSERT [dbo].[MatchType] ON 

INSERT [dbo].[MatchType] ([MatchTypeId], [MatchTypeName]) VALUES (1, N'Friendly')
INSERT [dbo].[MatchType] ([MatchTypeId], [MatchTypeName]) VALUES (2, N'Tournament')
INSERT [dbo].[MatchType] ([MatchTypeId], [MatchTypeName]) VALUES (3, N'Series')
SET IDENTITY_INSERT [dbo].[MatchType] OFF
SET IDENTITY_INSERT [dbo].[BattingStyle] ON 

INSERT [dbo].[BattingStyle] ([BattingStyleId], [Name]) VALUES (1, N'Left-hand')
INSERT [dbo].[BattingStyle] ([BattingStyleId], [Name]) VALUES (2, N'Right-hand')
SET IDENTITY_INSERT [dbo].[BattingStyle] OFF
SET IDENTITY_INSERT [dbo].[BowlingStyle] ON 

INSERT [dbo].[BowlingStyle] ([BowlingStyleId], [Name]) VALUES (1, N'Right-arm fast')
INSERT [dbo].[BowlingStyle] ([BowlingStyleId], [Name]) VALUES (2, N'Left-arm fast')
INSERT [dbo].[BowlingStyle] ([BowlingStyleId], [Name]) VALUES (3, N'Left-arm medium')
INSERT [dbo].[BowlingStyle] ([BowlingStyleId], [Name]) VALUES (4, N'Right-arm medium')
INSERT [dbo].[BowlingStyle] ([BowlingStyleId], [Name]) VALUES (5, N'Right-arm medium fast')
INSERT [dbo].[BowlingStyle] ([BowlingStyleId], [Name]) VALUES (6, N'Left-arm medium fast')
INSERT [dbo].[BowlingStyle] ([BowlingStyleId], [Name]) VALUES (7, N'Leg break (right-arm)')
INSERT [dbo].[BowlingStyle] ([BowlingStyleId], [Name]) VALUES (8, N'Off-spin (right-arm)')
INSERT [dbo].[BowlingStyle] ([BowlingStyleId], [Name]) VALUES (9, N'Slow left-arm spin')
INSERT [dbo].[BowlingStyle] ([BowlingStyleId], [Name]) VALUES (10, N'Left-arm orthodox')
INSERT [dbo].[BowlingStyle] ([BowlingStyleId], [Name]) VALUES (11, N'Right arm (wrist spiner)')
SET IDENTITY_INSERT [dbo].[BowlingStyle] OFF
SET IDENTITY_INSERT [dbo].[PlayerRole] ON 

INSERT [dbo].[PlayerRole] ([PlayerRoleId], [Name]) VALUES (1, N'Batsman')
INSERT [dbo].[PlayerRole] ([PlayerRoleId], [Name]) VALUES (2, N'Bowler')
INSERT [dbo].[PlayerRole] ([PlayerRoleId], [Name]) VALUES (3, N'All-Rounder')
INSERT [dbo].[PlayerRole] ([PlayerRoleId], [Name]) VALUES (4, N'Wicket-Keeper Batsman')
SET IDENTITY_INSERT [dbo].[PlayerRole] OFF
SET IDENTITY_INSERT [dbo].[Players] ON 
INSERT [dbo].[Players] ([PlayerId], [Address], [CNIC], [Contact], [DOB], [Gender], [IsDeactivated], [IsGuestPlayer], [PlayerLogo], [Player_Name], [TeamId], [BattingStyleId], [BowlingStyleId], [PlayerRoleId]) VALUES (1, NULL, NULL, N'03353928246', NULL, N'Male', 0, 0, NULL, N'Tahir Khan (c)', 1, 2, 8, 1)
INSERT [dbo].[Players] ([PlayerId], [Address], [CNIC], [Contact], [DOB], [Gender], [IsDeactivated], [IsGuestPlayer], [PlayerLogo], [Player_Name], [TeamId], [BattingStyleId], [BowlingStyleId], [PlayerRoleId]) VALUES (2, NULL, NULL, NULL, NULL, N'Male', 0, 0, NULL, N'Jawad Siddiqui', 1, 2, 8, 3)
INSERT [dbo].[Players] ([PlayerId], [Address], [CNIC], [Contact], [DOB], [Gender], [IsDeactivated], [IsGuestPlayer], [PlayerLogo], [Player_Name], [TeamId], [BattingStyleId], [BowlingStyleId], [PlayerRoleId]) VALUES (3, NULL, NULL, N'03422181946', NULL, N'Male', 0, 0, NULL, N'Faraz Ahmed Shaikh', 1, 2, 7, 2)
INSERT [dbo].[Players] ([PlayerId], [Address], [CNIC], [Contact], [DOB], [Gender], [IsDeactivated], [IsGuestPlayer], [PlayerLogo], [Player_Name], [TeamId], [BattingStyleId], [BowlingStyleId], [PlayerRoleId]) VALUES (4, NULL, NULL, NULL, NULL, N'Male', 0, 0,null, N'Taha Siddiqui', 1, 2, 7, 3)
INSERT [dbo].[Players] ([PlayerId], [Address], [CNIC], [Contact], [DOB], [Gender], [IsDeactivated], [IsGuestPlayer], [PlayerLogo], [Player_Name], [TeamId], [BattingStyleId], [BowlingStyleId], [PlayerRoleId]) VALUES (5, N'Quaidabad Landhi Karachi', N'42501-8953272-5', N'0313-2276376', CAST(N'1984-11-20T00:00:00.0000000' AS DateTime2), N'Male', 0, 0, NULL, N'Mehmood khan (c)', 3, 2, 8, 3)
INSERT [dbo].[Players] ([PlayerId], [Address], [CNIC], [Contact], [DOB], [Gender], [IsDeactivated], [IsGuestPlayer], [PlayerLogo], [Player_Name], [TeamId], [BattingStyleId], [BowlingStyleId], [PlayerRoleId]) VALUES (6, N'Green City Quaidabad Karachi', NULL, NULL, NULL, N'Male', 0, 0, NULL, N'Adnan Dilawar ', 3, 2, NULL, 1)
INSERT [dbo].[Players] ([PlayerId], [Address], [CNIC], [Contact], [DOB], [Gender], [IsDeactivated], [IsGuestPlayer], [PlayerLogo], [Player_Name], [TeamId], [BattingStyleId], [BowlingStyleId], [PlayerRoleId]) VALUES (7, N'Green City Quaidabad Karachi', NULL, NULL, NULL, N'Male', 0, 0, NULL, N'Abid Hussain', 3, 2, 7, 3)
INSERT [dbo].[Players] ([PlayerId], [Address], [CNIC], [Contact], [DOB], [Gender], [IsDeactivated], [IsGuestPlayer], [PlayerLogo], [Player_Name], [TeamId], [BattingStyleId], [BowlingStyleId], [PlayerRoleId]) VALUES (8, N'Old Muzaffrabad landhi karachi', NULL, NULL, NULL, N'Male', 0, 0, NULL, N'M Waseem ', 3, 2, 7, 3)
INSERT [dbo].[Players] ([PlayerId], [Address], [CNIC], [Contact], [DOB], [Gender], [IsDeactivated], [IsGuestPlayer], [PlayerLogo], [Player_Name], [TeamId], [BattingStyleId], [BowlingStyleId], [PlayerRoleId]) VALUES (9, N'Old Muzaffrabad landhi karachi', NULL, NULL, NULL, N'Male', 0, 0, NULL, N'Ibraheem Khan', 3, 2, 4, 3)
INSERT [dbo].[Players] ([PlayerId], [Address], [CNIC], [Contact], [DOB], [Gender], [IsDeactivated], [IsGuestPlayer], [PlayerLogo], [Player_Name], [TeamId], [BattingStyleId], [BowlingStyleId], [PlayerRoleId]) VALUES (10, N'Quaidabad Landhi Karachi', NULL, NULL, NULL, N'Male', 0, 0, NULL, N'Shamsher Khan', 3, 1, 7, 3)
INSERT [dbo].[Players] ([PlayerId], [Address], [CNIC], [Contact], [DOB], [Gender], [IsDeactivated], [IsGuestPlayer], [PlayerLogo], [Player_Name], [TeamId], [BattingStyleId], [BowlingStyleId], [PlayerRoleId]) VALUES (11, N'Old Muzaffrabad landhi karachi', NULL, NULL, NULL, N'Male', 0, 0, NULL, N'Asghar khan', 3, 2, 1, 3)
INSERT [dbo].[Players] ([PlayerId], [Address], [CNIC], [Contact], [DOB], [Gender], [IsDeactivated], [IsGuestPlayer], [PlayerLogo], [Player_Name], [TeamId], [BattingStyleId], [BowlingStyleId], [PlayerRoleId]) VALUES (12, N'Quaidabad Landhi Karachi', NULL, NULL, NULL, N'Male', 0, 0, NULL, N'Majid khan', 3, 2, NULL, 4)
INSERT [dbo].[Players] ([PlayerId], [Address], [CNIC], [Contact], [DOB], [Gender], [IsDeactivated], [IsGuestPlayer], [PlayerLogo], [Player_Name], [TeamId], [BattingStyleId], [BowlingStyleId], [PlayerRoleId]) VALUES (13, N'Green City Quaidabad Karachi', NULL, NULL, NULL, N'Male', 0, 0, NULL, N'Faheem ur Rehman', 3, 1, NULL, 1)
INSERT [dbo].[Players] ([PlayerId], [Address], [CNIC], [Contact], [DOB], [Gender], [IsDeactivated], [IsGuestPlayer], [PlayerLogo], [Player_Name], [TeamId], [BattingStyleId], [BowlingStyleId], [PlayerRoleId]) VALUES (14, N'89 Landhi Karachi', NULL, NULL, NULL, N'Male', 0, 0, NULL, N'Meer Ahmed ', 3, 2, NULL, 1)
INSERT [dbo].[Players] ([PlayerId], [Address], [CNIC], [Contact], [DOB], [Gender], [IsDeactivated], [IsGuestPlayer], [PlayerLogo], [Player_Name], [TeamId], [BattingStyleId], [BowlingStyleId], [PlayerRoleId]) VALUES (15, N'Old Muzaffrabad landhi karachi', NULL, NULL, NULL, N'Male', 0, 0, NULL, N'Shakeel Ahmed ', 3, 1, 9, 3)
INSERT [dbo].[Players] ([PlayerId], [Address], [CNIC], [Contact], [DOB], [Gender], [IsDeactivated], [IsGuestPlayer], [PlayerLogo], [Player_Name], [TeamId], [BattingStyleId], [BowlingStyleId], [PlayerRoleId]) VALUES (16, N'Old Muzaffrabad landhi karachi', NULL, NULL, NULL, N'Male', 0, 0, NULL, N'Sher Ali ', 3, 2, NULL, 1)
INSERT [dbo].[Players] ([PlayerId], [Address], [CNIC], [Contact], [DOB], [Gender], [IsDeactivated], [IsGuestPlayer], [PlayerLogo], [Player_Name], [TeamId], [BattingStyleId], [BowlingStyleId], [PlayerRoleId]) VALUES (17, N'Quaidabad Landhi Karachi', NULL, NULL, NULL, N'Male', 0, 0, NULL, N'Naseer AHmed', 3, 2, NULL, 4)
INSERT [dbo].[Players] ([PlayerId], [Address], [CNIC], [Contact], [DOB], [Gender], [IsDeactivated], [IsGuestPlayer], [PlayerLogo], [Player_Name], [TeamId], [BattingStyleId], [BowlingStyleId], [PlayerRoleId]) VALUES (18, N'haspatal chorangi landhi karachi', NULL, NULL, NULL, N'Male', 0, 0, NULL, N'Aftab alam', 3, 2, 4, 2)
INSERT [dbo].[Players] ([PlayerId], [Address], [CNIC], [Contact], [DOB], [Gender], [IsDeactivated], [IsGuestPlayer], [PlayerLogo], [Player_Name], [TeamId], [BattingStyleId], [BowlingStyleId], [PlayerRoleId]) VALUES (19, N'H no B-325 Kohat Colony Khuldabad Quaidabad Karachi', NULL, NULL, NULL, N'Male', 0, 0, NULL, N'Junaid Khan', 3, 2, 8, 2)
INSERT [dbo].[Players] ([PlayerId], [Address], [CNIC], [Contact], [DOB], [Gender], [IsDeactivated], [IsGuestPlayer], [PlayerLogo], [Player_Name], [TeamId], [BattingStyleId], [BowlingStyleId], [PlayerRoleId]) VALUES (20, N'Quaidabad Landhi Karachi', NULL, NULL, NULL, N'Male', 0, 0, NULL, N'Rariq Shah', 3, 2, NULL, 4)
INSERT [dbo].[Players] ([PlayerId], [Address], [CNIC], [Contact], [DOB], [Gender], [IsDeactivated], [IsGuestPlayer], [PlayerLogo], [Player_Name], [TeamId], [BattingStyleId], [BowlingStyleId], [PlayerRoleId]) VALUES (21, N'Old Muzaffrabad landhi karachi', NULL, NULL, NULL, N'Male', 0, 0, NULL, N'Awise khan', 3, 2, NULL, 1)
INSERT [dbo].[Players] ([PlayerId], [Address], [CNIC], [Contact], [DOB], [Gender], [IsDeactivated], [IsGuestPlayer], [PlayerLogo], [Player_Name], [TeamId], [BattingStyleId], [BowlingStyleId], [PlayerRoleId]) VALUES (22, N'Quaidabad Landhi Karachi', NULL, NULL, NULL, N'Male', 0, 0, NULL, N'Dr Hizzbullah', 3, 2, 8, 2)
INSERT [dbo].[Players] ([PlayerId], [Address], [CNIC], [Contact], [DOB], [Gender], [IsDeactivated], [IsGuestPlayer], [PlayerLogo], [Player_Name], [TeamId], [BattingStyleId], [BowlingStyleId], [PlayerRoleId]) VALUES (23, N'89 Landhi Karachi', NULL, NULL, NULL, N'Male', 0, 0, NULL, N'Haris Siddiqui', 3, 2, 4, 2)
SET IDENTITY_INSERT [dbo].[Players] OFF
SET IDENTITY_INSERT [dbo].[HowOut] ON 

INSERT [dbo].[HowOut] ([HowOutId], [Name]) VALUES (1, N'Catch')
INSERT [dbo].[HowOut] ([HowOutId], [Name]) VALUES (2, N'Bowled')
INSERT [dbo].[HowOut] ([HowOutId], [Name]) VALUES (3, N'Stumped')
INSERT [dbo].[HowOut] ([HowOutId], [Name]) VALUES (4, N'Run Out')
INSERT [dbo].[HowOut] ([HowOutId], [Name]) VALUES (5, N'LBW')
INSERT [dbo].[HowOut] ([HowOutId], [Name]) VALUES (6, N'Hit-wicket')
INSERT [dbo].[HowOut] ([HowOutId], [Name]) VALUES (7, N'Not Out')
INSERT [dbo].[HowOut] ([HowOutId], [Name]) VALUES (8, N'Retired-hurt')
SET IDENTITY_INSERT [dbo].[HowOut] OFF

SET IDENTITY_INSERT [dbo].[TournamentStages] ON 

INSERT [dbo].[TournamentStages] ([TournamentStageId], [Name]) VALUES (1, N'Qualifier')
INSERT [dbo].[TournamentStages] ([TournamentStageId], [Name]) VALUES (2, N'Group Stage')
INSERT [dbo].[TournamentStages] ([TournamentStageId], [Name]) VALUES (3, N'Quater Finals')
INSERT [dbo].[TournamentStages] ([TournamentStageId], [Name]) VALUES (4, N'Semi Finals')
INSERT [dbo].[TournamentStages] ([TournamentStageId], [Name]) VALUES (5, N'Final')
SET IDENTITY_INSERT [dbo].[TournamentStages] OFF


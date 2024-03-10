IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(128) NOT NULL,
        [ProviderKey] nvarchar(128) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(128) NOT NULL,
        [Name] nvarchar(128) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'00000000000000_CreateIdentitySchema', N'6.0.26');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231226181624_userrole')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUserTokens]') AND [c].[name] = N'Name');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUserTokens] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [AspNetUserTokens] ALTER COLUMN [Name] nvarchar(450) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231226181624_userrole')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUserTokens]') AND [c].[name] = N'LoginProvider');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUserTokens] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [AspNetUserTokens] ALTER COLUMN [LoginProvider] nvarchar(450) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231226181624_userrole')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUserLogins]') AND [c].[name] = N'ProviderKey');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUserLogins] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [AspNetUserLogins] ALTER COLUMN [ProviderKey] nvarchar(450) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231226181624_userrole')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUserLogins]') AND [c].[name] = N'LoginProvider');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUserLogins] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [AspNetUserLogins] ALTER COLUMN [LoginProvider] nvarchar(450) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231226181624_userrole')
BEGIN
    CREATE TABLE [Trainingvideo] (
        [vdoId] int NOT NULL IDENTITY,
        [VideoName] nvarchar(max) NULL,
        [videoLink] nvarchar(max) NULL,
        [CreateDate] datetime2 NOT NULL,
        [Username] nvarchar(max) NULL,
        CONSTRAINT [PK_Trainingvideo] PRIMARY KEY ([vdoId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231226181624_userrole')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231226181624_userrole', N'6.0.26');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240118105355_UserInformations')
BEGIN
    CREATE TABLE [UserInformation] (
        [UserinfoId] int NOT NULL IDENTITY,
        [UserFullName] nvarchar(max) NULL,
        [Gender] nvarchar(max) NULL,
        [PhoneNumber] int NOT NULL,
        [NID] decimal(20,0) NOT NULL,
        [Address] nvarchar(max) NULL,
        [CreateDate] datetime2 NOT NULL,
        [Status] nvarchar(max) NULL,
        [ExpireDate] datetime2 NOT NULL,
        [LoginId] nvarchar(max) NULL,
        [TranjectionId] nvarchar(max) NULL,
        [Designation] nvarchar(max) NULL,
        [Degree] nvarchar(max) NULL,
        [DVMRegiNo] nvarchar(max) NULL,
        [KhamarType] nvarchar(max) NULL,
        [PhotoUrl] nvarchar(max) NULL,
        CONSTRAINT [PK_UserInformation] PRIMARY KEY ([UserinfoId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240118105355_UserInformations')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240118105355_UserInformations', N'6.0.26');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240119032316_ADdNullable')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserInformation]') AND [c].[name] = N'PhoneNumber');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [UserInformation] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [UserInformation] ALTER COLUMN [PhoneNumber] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240119032316_ADdNullable')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserInformation]') AND [c].[name] = N'NID');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [UserInformation] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [UserInformation] ALTER COLUMN [NID] decimal(20,0) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240119032316_ADdNullable')
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserInformation]') AND [c].[name] = N'ExpireDate');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [UserInformation] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [UserInformation] ALTER COLUMN [ExpireDate] datetime2 NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240119032316_ADdNullable')
BEGIN
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserInformation]') AND [c].[name] = N'CreateDate');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [UserInformation] DROP CONSTRAINT [' + @var7 + '];');
    ALTER TABLE [UserInformation] ALTER COLUMN [CreateDate] datetime2 NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240119032316_ADdNullable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240119032316_ADdNullable', N'6.0.26');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240203171024_Prescriptions')
BEGIN
    CREATE TABLE [Advices] (
        [AdvId] int NOT NULL IDENTITY,
        [AdvName] nvarchar(max) NULL,
        [AdvDate] datetime2 NOT NULL,
        [UrName] nvarchar(max) NULL,
        CONSTRAINT [PK_Advices] PRIMARY KEY ([AdvId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240203171024_Prescriptions')
BEGIN
    CREATE TABLE [ChiefComplaint] (
        [ChiId] int NOT NULL IDENTITY,
        [ChiName] nvarchar(max) NULL,
        [CreateDt] datetime2 NOT NULL,
        [UsrName] nvarchar(max) NULL,
        CONSTRAINT [PK_ChiefComplaint] PRIMARY KEY ([ChiId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240203171024_Prescriptions')
BEGIN
    CREATE TABLE [Diagnosis] (
        [DiagId] int NOT NULL IDENTITY,
        [DiagName] nvarchar(max) NULL,
        [CreateDt] datetime2 NOT NULL,
        [UsrName] nvarchar(max) NULL,
        CONSTRAINT [PK_Diagnosis] PRIMARY KEY ([DiagId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240203171024_Prescriptions')
BEGIN
    CREATE TABLE [Doses] (
        [DosesId] int NOT NULL IDENTITY,
        [Morning] bit NOT NULL,
        [Afternoon] bit NOT NULL,
        [Evening] bit NOT NULL,
        [Days] int NOT NULL,
        [DosesName] nvarchar(max) NULL,
        [DosesDate] datetime2 NOT NULL,
        [UrName] nvarchar(max) NULL,
        CONSTRAINT [PK_Doses] PRIMARY KEY ([DosesId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240203171024_Prescriptions')
BEGIN
    CREATE TABLE [FlowUp] (
        [FloId] int NOT NULL IDENTITY,
        [FloName] nvarchar(max) NULL,
        [FloDate] datetime2 NOT NULL,
        [UrName] nvarchar(max) NULL,
        CONSTRAINT [PK_FlowUp] PRIMARY KEY ([FloId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240203171024_Prescriptions')
BEGIN
    CREATE TABLE [GeneralExamination] (
        [GenId] int NOT NULL IDENTITY,
        [ExamName] nvarchar(max) NULL,
        [CreateDt] datetime2 NOT NULL,
        [UsrName] nvarchar(max) NULL,
        CONSTRAINT [PK_GeneralExamination] PRIMARY KEY ([GenId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240203171024_Prescriptions')
BEGIN
    CREATE TABLE [Invastigations] (
        [InvId] int NOT NULL IDENTITY,
        [InvName] nvarchar(max) NULL,
        [InvDate] datetime2 NOT NULL,
        [UrName] nvarchar(max) NULL,
        CONSTRAINT [PK_Invastigations] PRIMARY KEY ([InvId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240203171024_Prescriptions')
BEGIN
    CREATE TABLE [Medicines] (
        [MedId] int NOT NULL IDENTITY,
        [MedName] nvarchar(max) NULL,
        [MedDate] datetime2 NOT NULL,
        [UrName] nvarchar(max) NULL,
        CONSTRAINT [PK_Medicines] PRIMARY KEY ([MedId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240203171024_Prescriptions')
BEGIN
    CREATE TABLE [Registration] (
        [RegiId] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [PtnId] nvarchar(max) NULL,
        [Phone] nvarchar(max) NULL,
        [Gender] nvarchar(max) NULL,
        [Ages] nvarchar(max) NULL,
        [CreateDAte] datetime2 NOT NULL,
        [UsrName] nvarchar(max) NULL,
        CONSTRAINT [PK_Registration] PRIMARY KEY ([RegiId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240203171024_Prescriptions')
BEGIN
    CREATE TABLE [Prescription] (
        [PresId] int NOT NULL IDENTITY,
        [PresName] nvarchar(max) NULL,
        [PresDate] datetime2 NOT NULL,
        [UrName] nvarchar(max) NULL,
        [RegistrationId] int NOT NULL,
        [ChiefComplaintId] int NOT NULL,
        [GeneralExaminationId] int NOT NULL,
        [DiagnosisId] int NOT NULL,
        [InvastigationId] int NOT NULL,
        [MedicineId] int NOT NULL,
        [DosesId] int NOT NULL,
        [AdviceId] int NOT NULL,
        [FlowUpId] int NOT NULL,
        CONSTRAINT [PK_Prescription] PRIMARY KEY ([PresId]),
        CONSTRAINT [FK_Prescription_Advices_AdviceId] FOREIGN KEY ([AdviceId]) REFERENCES [Advices] ([AdvId]) ON DELETE CASCADE,
        CONSTRAINT [FK_Prescription_ChiefComplaint_ChiefComplaintId] FOREIGN KEY ([ChiefComplaintId]) REFERENCES [ChiefComplaint] ([ChiId]) ON DELETE CASCADE,
        CONSTRAINT [FK_Prescription_Diagnosis_DiagnosisId] FOREIGN KEY ([DiagnosisId]) REFERENCES [Diagnosis] ([DiagId]) ON DELETE CASCADE,
        CONSTRAINT [FK_Prescription_Doses_DosesId] FOREIGN KEY ([DosesId]) REFERENCES [Doses] ([DosesId]) ON DELETE CASCADE,
        CONSTRAINT [FK_Prescription_FlowUp_FlowUpId] FOREIGN KEY ([FlowUpId]) REFERENCES [FlowUp] ([FloId]) ON DELETE CASCADE,
        CONSTRAINT [FK_Prescription_GeneralExamination_GeneralExaminationId] FOREIGN KEY ([GeneralExaminationId]) REFERENCES [GeneralExamination] ([GenId]) ON DELETE CASCADE,
        CONSTRAINT [FK_Prescription_Invastigations_InvastigationId] FOREIGN KEY ([InvastigationId]) REFERENCES [Invastigations] ([InvId]) ON DELETE CASCADE,
        CONSTRAINT [FK_Prescription_Medicines_MedicineId] FOREIGN KEY ([MedicineId]) REFERENCES [Medicines] ([MedId]) ON DELETE CASCADE,
        CONSTRAINT [FK_Prescription_Registration_RegistrationId] FOREIGN KEY ([RegistrationId]) REFERENCES [Registration] ([RegiId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240203171024_Prescriptions')
BEGIN
    CREATE INDEX [IX_Prescription_AdviceId] ON [Prescription] ([AdviceId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240203171024_Prescriptions')
BEGIN
    CREATE INDEX [IX_Prescription_ChiefComplaintId] ON [Prescription] ([ChiefComplaintId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240203171024_Prescriptions')
BEGIN
    CREATE INDEX [IX_Prescription_DiagnosisId] ON [Prescription] ([DiagnosisId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240203171024_Prescriptions')
BEGIN
    CREATE INDEX [IX_Prescription_DosesId] ON [Prescription] ([DosesId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240203171024_Prescriptions')
BEGIN
    CREATE INDEX [IX_Prescription_FlowUpId] ON [Prescription] ([FlowUpId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240203171024_Prescriptions')
BEGIN
    CREATE INDEX [IX_Prescription_GeneralExaminationId] ON [Prescription] ([GeneralExaminationId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240203171024_Prescriptions')
BEGIN
    CREATE INDEX [IX_Prescription_InvastigationId] ON [Prescription] ([InvastigationId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240203171024_Prescriptions')
BEGIN
    CREATE INDEX [IX_Prescription_MedicineId] ON [Prescription] ([MedicineId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240203171024_Prescriptions')
BEGIN
    CREATE INDEX [IX_Prescription_RegistrationId] ON [Prescription] ([RegistrationId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240203171024_Prescriptions')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240203171024_Prescriptions', N'6.0.26');
END;
GO

COMMIT;
GO


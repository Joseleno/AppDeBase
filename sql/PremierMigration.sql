IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210202034457_PremierMigration')
BEGIN
    CREATE TABLE [Fournisseurs] (
        [Id] uniqueidentifier NOT NULL,
        [Nom] varchar(200) NOT NULL,
        [Document] varchar(15) NOT NULL,
        [TypeFournisseur] int NOT NULL,
        [Acitve] bit NOT NULL,
        CONSTRAINT [PK_Fournisseurs] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210202034457_PremierMigration')
BEGIN
    CREATE TABLE [Adresses] (
        [Id] uniqueidentifier NOT NULL,
        [FournisseurId] uniqueidentifier NOT NULL,
        [Numero] varchar(50) NOT NULL,
        [Rue] varchar(200) NOT NULL,
        [Complement] varchar(250) NULL,
        [CodePostal] varchar(8) NOT NULL,
        [Ville] varchar(100) NOT NULL,
        [Province] varchar(50) NOT NULL,
        CONSTRAINT [PK_Adresses] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Adresses_Fournisseurs_FournisseurId] FOREIGN KEY ([FournisseurId]) REFERENCES [Fournisseurs] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210202034457_PremierMigration')
BEGIN
    CREATE TABLE [Produits] (
        [Id] uniqueidentifier NOT NULL,
        [FournisseurId] uniqueidentifier NOT NULL,
        [Nom] varchar(200) NOT NULL,
        [Description] varchar(1000) NOT NULL,
        [Image] varchar(100) NOT NULL,
        [Valeur] decimal(18,2) NOT NULL,
        [DateInscription] datetime2 NOT NULL,
        [Active] bit NOT NULL,
        CONSTRAINT [PK_Produits] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Produits_Fournisseurs_FournisseurId] FOREIGN KEY ([FournisseurId]) REFERENCES [Fournisseurs] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210202034457_PremierMigration')
BEGIN
    CREATE UNIQUE INDEX [IX_Adresses_FournisseurId] ON [Adresses] ([FournisseurId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210202034457_PremierMigration')
BEGIN
    CREATE INDEX [IX_Produits_FournisseurId] ON [Produits] ([FournisseurId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210202034457_PremierMigration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210202034457_PremierMigration', N'2.2.6-servicing-10079');
END;

GO


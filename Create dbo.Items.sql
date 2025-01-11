--USE [LostAndFoundDB]
--GO

--/****** Object: Table [dbo].[Items] Script Date: 12/26/2024 2:36:52 PM ******/
--SET ANSI_NULLS ON
--GO

--SET QUOTED_IDENTIFIER ON
--GO

--CREATE TABLE [dbo].[Items] (
--    [Id]          INT            IDENTITY (1, 1) NOT NULL,
--    [Name]        NVARCHAR (MAX) NOT NULL,
--    [Finder]      NVARCHAR (MAX) NOT NULL,
--    [Category]    NVARCHAR (MAX) NOT NULL,
--    [Status]      NVARCHAR (MAX) NOT NULL,
--    [Description] NVARCHAR (MAX) NOT NULL,
--    [DateFound]   DATE           NOT NULL
--);
USE [LostAndFoundDB]
GO

ALTER TABLE Items
ADD PhoneNumber VARCHAR(15) NOT NULL DEFAULT 'N/A';

-- Read Data from the DB
USE [QFWinData_QQ990099]
GO
/****** Object:  StoredProcedure [dbo].[GetAddress]    Script Date: 11/16/2011 15:35:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Procedure [dbo].[GetAddress]
as
    SELECT TOP 10 [ADDRESS1] + ', ' + [CITY] + ', ' + [STATE] + ' ' + [ZIP] as [ADDRESS],
        Client_ID as PassthroughID
    FROM CLNMAS
    WHERE [STATE]= 'TX'


-- Saves the given data to the DB
USE [QFWinData_QQ990099]
GO
/****** Object:  StoredProcedure [dbo].[SetAddress]    Script Date: 11/16/2011 15:35:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[SetAddress]
    @Address varchar(250),
    @Latitude float,
    @Longitude float,
    @PassthroughID int,
    @Confidence varchar(250),
    @CalculationMethod varchar(250)
as
    UPDATE CLNMAS
    SET Latitu = @Latitude, Longit = @Longitude,
        Confidence = @Confidence, CalculationMethod = @CalculationMethod
    WHERE Client_ID = @PassthroughID

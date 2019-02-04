USE [C56_Eleveight]
GO

/****** Object:  StoredProcedure [dbo].[EventRSVP_PeopleInterested]    Script Date: 2/4/2019 9:59:57 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mark Cuatrona
-- Create date: 07/23/2018
-- Description:	Event RSVP People Interested
-- =============================================
CREATE PROCEDURE [dbo].[EventRSVP_PeopleInterested]
	-- Add the parameters for the stored procedure here
	@EventId int,
			@RSVPTypeId int,
			@PeopleInterested int output
AS
BEGIN
/*
DECLARE	@return_value int,
		@PeopleInterested int

EXEC	@return_value = [dbo].[EventRSVP_PeopleInterested]
		@EventId = 1,
		@RSVPTypeId = 3,
		@PeopleInterested = @PeopleInterested OUTPUT

SELECT	@PeopleInterested as N'@PeopleInterested'

SELECT	'Return Value' = @return_value
*/
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	set @PeopleInterested = (select count(*) from EventRSVP where EventId = @EventId and RSVPTypeId = 3)
END
GO


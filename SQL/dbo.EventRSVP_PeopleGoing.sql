USE [C56_Eleveight]
GO

/****** Object:  StoredProcedure [dbo].[EventRSVP_PeopleGoing]    Script Date: 2/4/2019 9:59:43 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mark Cuatrona	
-- Create date: 07/23/2018
-- Description:	Event RSVP People Going Count
-- =============================================
CREATE PROCEDURE [dbo].[EventRSVP_PeopleGoing]
	-- Add the parameters for the stored procedure here
	
			@EventId int,
			@RSVPTypeId int,
			@PeopleGoing int output
AS
BEGIN
/*
DECLARE	@return_value int,
		@PeopleGoing int,
		@PeopleInterested int

EXEC	@return_value = [dbo].[EventRSVP_Insert]
		@UserBaseId = 21,
		@EventId = 1,
		@RSVPTypeId = 1,
		@PeopleGoing = @PeopleGoing OUTPUT,
		@PeopleInterested = @PeopleInterested OUTPUT

SELECT	@PeopleGoing as N'@PeopleGoing',
		@PeopleInterested as N'@PeopleInterested'

SELECT	'Return Value' = @return_value
*/
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	
	set @PeopleGoing = (select count(*) from EventRSVP where EventId = @EventId and RSVPTypeId = 1)

END
GO


USE [C56_Eleveight]
GO

/****** Object:  StoredProcedure [dbo].[EventRSVP_SelectCount]    Script Date: 2/4/2019 10:00:44 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mark Cuatrona
-- Create date: 07/23/2018
-- Description:	Event RSVP Select Count
-- =============================================
CREATE PROCEDURE  [dbo].[EventRSVP_SelectCount]
	-- Add the parameters for the stored procedure here
	@EventId int
	
	
AS
BEGIN
/*
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[Event_SelectCount]

SELECT	'Return Value' = @return_value

GO

*/
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here


declare @RSVPTypeId int,
	@PeopleGoing int,
	@PeopleInterested int

	set @PeopleGoing = (select count(*) from EventRSVP where  EventId = @EventId and RSVPTypeId = 1)
	set @PeopleInterested = (select count(*) from EventRSVP where EventId = @EventId and RSVPTypeId = 3)

	select @PeopleGoing as PeopleGoing, @PeopleInterested as PeopleInterested

END
GO


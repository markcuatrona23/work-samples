-- =============================================
-- Author:		Mark Cuatrona
-- Create date: 07/19/2018
-- Description:	Event RSVP Insert
-- =============================================
ALTER PROCEDURE [dbo].[EventRSVP_Insert]
	-- Add the parameters for the stored procedure here
	@UserBaseId int,
	@EventId int,
	@RSVPTypeId int,

	@PeopleGoing int output,
	@PeopleInterested int output


AS
BEGIN
/*  Test Script
GO

DECLARE	@return_value int,
		@Attendees int

EXEC	@return_value = [dbo].[EventRSVP_Insert]
		@UserBaseId = 9,
		@EventId = 1,
		@RSVPTypeId = 6,
		@Attendees = @Attendees OUTPUT

SELECT	@Attendees as N'@Attendees'

SELECT	'Return Value' = @return_value

GO
*/
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	if(exists( select * from EventRSVP where UserBaseId = @UserBaseId and EventId = @EventId)) begin

	update EventRSVP
	set RSVPTypeId = @RSVPTypeId
	where eventId = @EventId and userbaseId = @UserBaseId
	end
	
	if(not exists(  select * from EventRSVP where UserBaseId = @UserBaseid and EventId = @EventId and RSVPTypeId = @RSVPTypeId)) begin


	insert into EventRSVP([UserBaseId], [EventId], [RSVPTypeId])
	values(@UserBaseId, @EventId, @RSVPTypeId)
	end

	

	set @PeopleGoing = (select count(*) from EventRSVP where UserBaseId = @UserBaseId and EventId = @EventId and RSVPTypeId = 1)
	set @PeopleInterested = (select count(*) from EventRSVP where UserBaseId = @UserBaseId and EventId = @EventId and RSVPTypeId = 3)


END

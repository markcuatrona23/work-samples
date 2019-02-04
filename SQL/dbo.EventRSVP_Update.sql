USE [C56_Eleveight]
GO

/****** Object:  StoredProcedure [dbo].[EventRSVP_Update]    Script Date: 2/4/2019 10:00:53 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mark Cuatrona
-- Create date: 07/19/2018
-- Description:	Even RSVP Update
-- =============================================
CREATE PROCEDURE [dbo].[EventRSVP_Update]
	-- Add the parameters for the stored procedure here
	@EventId int,
	@UserBaseId int,
	@RSVPTypeId int
AS
BEGIN
/*
DECLARE	@return_value int

EXEC	@return_value = [dbo].[EventRSVP_Update]
		@EventId = 1,
		@UserBaseId = 9,
		@RSVPTypeId = 1

SELECT	'Return Value' = @return_value
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
END

GO


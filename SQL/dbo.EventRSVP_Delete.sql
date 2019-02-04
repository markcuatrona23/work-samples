USE [C56_Eleveight]
GO

/****** Object:  StoredProcedure [dbo].[EventRSVP_Delete]    Script Date: 2/1/2019 9:02:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mark Cuatrona
-- Create date: 07/19/2018
-- Description:	Event RSVP Delete
-- =============================================
CREATE PROCEDURE [dbo].[EventRSVP_Delete]
	-- Add the parameters for the stored procedure here
	@EventId int,
	@UserBaseId int
AS
BEGIN
/*
DECLARE	@return_value int

EXEC	@return_value = [dbo].[EventRSVP_Delete]
		@EventId = 1,
		@UserBaseId = 9,
		@RSVPTypeId = 1

SELECT	'Return Value' = @return_value
*/
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		--if(exists(  select * from EventRSVP where UserBaseId = @UserBaseid and EventId = @EventId and RSVPTypeId = @RSVPTypeId)) begin


	delete from EventRSVP
	where eventId = @eventId and userBaseId = @UserBaseId
	--end



END
GO


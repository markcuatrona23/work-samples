USE [C56_Eleveight]
GO

/****** Object:  StoredProcedure [dbo].[EventRSVP_Save]    Script Date: 2/4/2019 10:00:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mark Cuatrona	
-- Create date: 07/23/2018
-- Description:	Event RSVP Save
-- =============================================
CREATE PROCEDURE [dbo].[EventRSVP_Save]
	-- Add the parameters for the stored procedure here
	@EventId int,
	@UserBaseId int,
	@RSVPTypeId int,

	@PeopleCount int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if(not exists(  select * from EventRSVP where UserBaseId = @UserBaseid and EventId = @EventId and RSVPTypeId = @RSVPTypeId)) begin

	exec dbo.EventRSVP_Insert @EventId, @UserBaseId, @RSVPTypeId, @PeopleCount output
	end

	if(exists(select * from EventRSVP where  UserBaseId = @UserBaseId and EventId = @EventId)) begin
	exec [dbo].[EventRSVP_Delete] @EventId, @UserBaseId
	end

	if(exists(select * from EventRSVP where UserBaseId = @UserBaseId and EventId = @EventId)) begin
	exec dbo.EventRSVP_Update  @RSVPTypeId, @EventId, @UserBaseId
	end



END
GO


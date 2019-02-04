USE [C56_Eleveight]
GO

/****** Object:  StoredProcedure [dbo].[Event_Delete]    Script Date: 2/1/2019 8:58:32 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Create date: 7/2
-- Description:	Delete Event by Id
-- =============================================
CREATE PROCEDURE [dbo].[Event_Delete]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN

/*
Test Script:
DECLARE	@return_value int

EXEC	@return_value = [dbo].[Event_Delete]
		@id = 4

SELECT	'Return Value' = @return_value
*/

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete Event
	where id=@id
END
GO


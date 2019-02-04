USE [C56_Eleveight]
GO

/****** Object:  StoredProcedure [dbo].[EventRSVP_SelectAll]    Script Date: 2/4/2019 10:00:33 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mark Cuatrona
-- Create date: 07/19/2018
-- Description:	Event RSVP Select All
-- =============================================
CREATE PROCEDURE  [dbo].[EventRSVP_SelectAll]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
/*
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[Event_SelectAll]

SELECT	'Return Value' = @return_value

GO

*/
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
select * from EventRSVP

END
GO


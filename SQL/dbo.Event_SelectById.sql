USE [C56_Eleveight]
GO

/****** Object:  StoredProcedure [dbo].[Event_SelectById]    Script Date: 2/1/2019 9:02:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Create date: 7/2
-- Description:	Select Event by Id


-- =============================================
CREATE PROCEDURE [dbo].[Event_SelectById]
	-- Add the parameters for the stored procedure here
	
	@id int

AS
BEGIN

/*
Test Script:
DECLARE	@return_value int

EXEC	@return_value = [dbo].[Event_SelectById]
		@id = 1

SELECT	'Return Value' = @return_value
*/

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select a.StreetAddress, a.StateProvinceId, a.PostalCode, a.City, e.*, o.OrgName, sc.Name, et.TypeName, sp.StateProvinceCode from dbo.Event as e
	join dbo.Address as a on a.Id = e.AddressId
	join dbo.StateProvince as sp on sp.id = a.StateProvinceId
	join dbo.Organization as o on o.Id = e.OrganizationId
	join dbo.Scholarship as sc on sc.id = e.ScholarshipId
	join dbo.EventType as et on et.id = e.EventTypeId
	where e.Id = @id
	
END

GO


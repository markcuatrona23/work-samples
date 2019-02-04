USE [C56_Eleveight]
GO

/****** Object:  StoredProcedure [dbo].[Event_SelectAll]    Script Date: 2/1/2019 9:00:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Create date: 7/2
-- Description:	Select All Events

-- =============================================
CREATE PROCEDURE [dbo].[Event_SelectAll]
	-- Add the parameters for the stored procedure here
@UserBaseId int
AS
BEGIN


/*
Test Script:
DECLARE	@return_value int

EXEC	@return_value = [dbo].[Event_SelectAll]

SELECT	'Return Value' = @return_value
*/

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	 

	select 
		e.Id, e.OrganizationId, 
		EventTypeId, Title, 
		TopicDesc, StartDate, 
		StartTime, EndDate, 
		EndTime, IsAllDay, 
		VenueName, AddressId, 
		ScholarshipId, ImageUrl, 
		ContactInfo, e.CreatedDate, 
		e.ModifiedDate, e.CreatedById, 
		e.ModifiedById,
		a.StreetAddress,
		a.City,
		a.StateProvinceId,
		a.PostalCode,
		s.StateProvinceCode,
		o.*,
		sc.Name,
		et.TypeName

	from Event e
	join Address a on a.Id=e.AddressId
	join StateProvince s on s.Id = a.StateProvinceId
	join Organization as o on o.Id = e.OrganizationId
	join Scholarship as sc on sc.id = e.ScholarshipId
	join EventType as et on et.id = e.EventTypeId

	where e.CreatedById = @UserBaseId
END
GO


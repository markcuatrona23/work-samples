USE [C56_Eleveight]
GO

/****** Object:  StoredProcedure [dbo].[Event_SelectAllEvents]    Script Date: 2/1/2019 9:01:59 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mark Cuatrona
-- Create date: 08/15/2018
-- Description:	Event Select All Events NOT using UserBaseId
-- =============================================
CREATE PROCEDURE [dbo].[Event_SelectAllEvents]

AS
BEGIN
/*
DECLARE	@return_value int

EXEC	@return_value = [dbo].[Event_SelectAllEvents]

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


END
GO


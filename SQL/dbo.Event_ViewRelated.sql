USE [C56_Eleveight]
GO

/****** Object:  StoredProcedure [dbo].[Event_ViewRelated]    Script Date: 2/1/2019 9:02:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mark
-- Create date: 07/16/2018
-- Description:	Event ViewRelated
-- =============================================
CREATE PROCEDURE [dbo].[Event_ViewRelated]
	-- Add the parameters for the stored procedure here
	
	@Id int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

declare @OrganizationId int

select @OrganizationId = OrganizationId from Event e

where e.Id = @Id

select 
		e.*,
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

	where e.OrganizationId = @OrganizationId
	and (
	e.Id NOT LIKE @Id
	)



	Order by e.OrganizationId desc 

END
GO


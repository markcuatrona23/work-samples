USE [C56_Eleveight]
GO

/****** Object:  StoredProcedure [dbo].[Event_Update]    Script Date: 2/1/2019 9:02:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Create date: 7/2
-- Description:	Update Event
-- =============================================
CREATE PROCEDURE [dbo].[Event_Update]
	-- Add the parameters for the stored procedure here
	@organizationId int,
	@eventTypeId int,
	@title nvarchar(100),
	@topicDesc nvarchar(2000),
	@startDate date,
	@startTime time,
	@endDate date,
	@endTime time,
	@isAllDay bit,
	@venueName nvarchar(100),
	@addressId int,
	@scholarshipId int,
	@imageUrl nvarchar(128),
	@contactInfo nvarchar(200),
	@modifiedById int,
	 @streetAddress nvarchar(150),
	@city nvarchar(150),
	@stateProvinceId int,
	@postalCode nvarchar(20),
	@id int 
AS
BEGIN

/*
Test Script:
DECLARE	@return_value int

EXEC	@return_value = [dbo].[Event_Update]
		@organizationId = 1,
		@eventTypeId = 1,
		@title = N'Aaron''s Crappy Event',
		@topicDesc = N'idk',
		@startDate = '10/28/2018',
		@startTime = '9:00',
		@endDate = NULL,
		@endTime = NULL,
		@isAllDay = 1,
		@venueName = N'idk',
		@addressId = 1,
		@scholarshipId = 1,
		@imageUrl = N'idk',
		@contactInfo = N'idk',
		@createdById = 1,
		@modifiedById = 1,
		@id = 1

SELECT	'Return Value' = @return_value
*/

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @AddressIdOut int 
	exec dbo.Address_Insert 4, @streetAddress, @city, @stateProvinceId, @postalCode, null, null, @AddressIdOut output

	update Event
	set OrganizationId= @organizationId,
	EventTypeId= @eventTypeId, 
	Title= @title,
	TopicDesc= @topicDesc,
	StartDate= @startDate,
	StartTime= @startTime, 
	EndDate = @endDate,
	EndTime= @endTime,
	IsAllDay= @isAllDay,
	VenueName= @venueName,
	AddressId= @addressIdOut,
	ScholarshipId= @scholarshipId,
	ImageUrl= @imageUrl,
	ContactInfo= @contactInfo,
	ModifiedDate=GETUTCDATE(),
	ModifiedById= @modifiedById
	where id=@id
END
GO


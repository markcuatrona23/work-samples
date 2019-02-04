USE [C56_Eleveight]
GO

/****** Object:  StoredProcedure [dbo].[Event_Insert]    Script Date: 2/1/2019 8:58:49 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Create date: 7/2
-- Description:	Create Event


-- =============================================
CREATE PROCEDURE [dbo].[Event_Insert]
	-- Add the parameters for the stored procedure here
	@organizationId int,
	@eventTypeId int,
	@title nvarchar(100),
	@topicDesc nvarchar(2000),
	@startDate date,
	@startTime time,
	@endDate date = null,
	@endTime time = null,
	@isAllDay bit,
	@venueName nvarchar(100),
	@addressId int,
	@scholarshipId int,
	@imageUrl nvarchar(128),
	@contactInfo nvarchar(200),
	@createdById int,
	@modifiedById int,
	@id int output
AS
BEGIN

/*
Test Script:
DECLARE	@return_value int,
		@id int

SELECT	@id = 0

EXEC	@return_value = [dbo].[Event_Insert]
		@organizationId = 6,
		@eventTypeId = 1,
		@title = N'Aaron''s Fundraiser',
		@topicDesc = N'idk Description',
		@startDate = '10/28/2018',
		@startTime = '9:00',
		@endDate = NULL,
		@endTime = NULL,
		@isAllDay = 1,
		@venueName = N'idk',
		@addressId = 1,
		@scholarshipId = 8,
		@imageUrl = N'idk',
		@contactInfo = N'idk',
		@createdById = 11,
		@modifiedById = 11,
		@id = @id OUTPUT

SELECT	@id as N'@id'

SELECT	'Return Value' = @return_value
*/
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into Event([OrganizationId], [EventTypeId], [Title], [TopicDesc], [StartDate], [StartTime], [EndDate], [EndTime], [IsAllDay], [VenueName], [AddressId], [ScholarshipId], [ImageUrl], [ContactInfo], [CreatedById], [ModifiedById])
	values(@organizationId, @eventTypeId, @title, @topicDesc, @startDate, @startTime, @endDate,@endTime, @isAllDay,@venueName, @addressId,@scholarshipId, @imageUrl,@contactInfo,@createdById,@modifiedById)
	set @id = SCOPE_IDENTITY()
END
GO


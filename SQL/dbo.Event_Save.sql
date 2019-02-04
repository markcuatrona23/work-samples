USE [C56_Eleveight]
GO

/****** Object:  StoredProcedure [dbo].[Event_Save]    Script Date: 2/1/2019 8:59:46 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mark
-- Create date: 07/09/2018
-- Description:	Event_Save
-- =============================================
CREATE PROCEDURE [dbo].[Event_Save]
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
    @streetAddress nvarchar(150),
	@city nvarchar(150),
	@stateProvinceId int,
	@postalCode nvarchar(20),
	@longitude nvarchar(100) = null,
	@latitude nvarchar (100) = null,
	

	@id int output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
--step 1 execute address insert
declare @AddressIdOut int 
exec dbo.Address_Insert 4, @streetAddress, @city, @stateProvinceId, @postalCode, null, null, @AddressIdOut output 
--step 2 execute event insert
--insert into dbo.Event ([OrganizationId], [EventTypeId], [Title], [TopicDesc], [StartDate], [StartTime], [EndDate], [EndTime], [IsAllDay], [VenueName], [AddressId], [ScholarshipId], [ImageUrl], [ContactInfo], [CreatedById], [ModifiedById])
--values (@OrganizationId, @EventTypeId, @Title, @TopicDesc, @StartDate, @StartTime, @EndDate, @EndTime, @IsAllDay, @Venuename, @AddressId, @scholarshipId, @ImageUrl, @ContactInfo, @CreatedById, @ModifiedById)
--set @id = SCOPE_IDENTITY();

exec dbo.Event_Insert @organizationId, @eventTypeId, @title, @topicDesc, @startDate, @startTime, @endDate, @endTime, @isAllDay, @venueName, @AddressIdOut, @scholarshipId, @imageUrl, @contactInfo, @createdById, @modifiedById, @id output

END
GO


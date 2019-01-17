using Eleveight.Models.Domain.Events;
using Eleveight.Models.Requests.Events;
using Eleveight.Services.Tools;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Eleveight.Services.Events
{
    public class EventService : BaseService, IEventService
    {
        public List<Event> ReadAll(int userBaseId)
        {
            //Get All by UserBaseId
            List<Event> list = new List<Event>();
            DataProvider.ExecuteCmd("dbo.Event_SelectAll",
                inputParamMapper: (SqlParameterCollection inputs) =>
                {
                    inputs.AddWithValue("@UserBaseId", userBaseId);
                },
                singleRecordMapper: (IDataReader reader, short resultSet) =>
                {
                    list.Add(DataMapper<Event>.Instance.MapToObject(reader));
                });
            return list;
        }

        public List<Event> ReadAllEvents()
        {
            List<Event> list = new List<Event>();
            DataProvider.ExecuteCmd("dbo.Event_ActualSelectAll",
                inputParamMapper: null,
                singleRecordMapper: (IDataReader reader, short resultSet) =>
                {
                    list.Add(DataMapper<Event>.Instance.MapToObject(reader));
                });
            return list;
        }

        public Event ReadById(int id)
        {
            Event myTable = new Event();
            //for selects executecmd
            DataProvider.ExecuteCmd("dbo.Event_SelectById",
                inputParamMapper: (SqlParameterCollection inputs) =>
                {
                    inputs.AddWithValue("@id", id);
                },
                singleRecordMapper: (IDataReader reader, short resultSet) =>
                {
                    myTable = DataMapper<Event>.Instance.MapToObject(reader);
                });
            return myTable;
        }

        public List<Event> ViewRelatedEventsById(int id)
        {
            List<Event> orgEvent = new List<Event>();
            DataProvider.ExecuteCmd("dbo.Event_ViewRelated",
                inputParamMapper: (SqlParameterCollection inputs) =>
                {
                    inputs.AddWithValue("@Id", id);
                },
                singleRecordMapper: (IDataReader reader, short resultSet) =>
                {
                    orgEvent.Add(DataMapper<Event>.Instance.MapToObject(reader));
                });
            return orgEvent;
        }

        public int Insert(EventAddRequest myData)
        {
            int id = 0;
            DataProvider.ExecuteNonQuery("dbo.Event_Insert",
                inputParamMapper: (SqlParameterCollection inputs) =>
                {
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@organizationId", myData.OrganizationId, SqlDbType.Int));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@eventTypeId", myData.EventTypeId, SqlDbType.Int));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@title", myData.Title, SqlDbType.NVarChar, 100));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@topicDesc", myData.TopicDesc, SqlDbType.NVarChar, 2000));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@startDate", myData.StartDate, SqlDbType.Date));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@startTime", myData.StartTime, SqlDbType.Time));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@endDate", myData.EndDate, SqlDbType.Date));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@endTime", myData.EndTime, SqlDbType.Time));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@isAllDay", myData.IsAllDay, SqlDbType.Bit));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@venueName", myData.VenueName, SqlDbType.NVarChar, 100));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@addressId", myData.AddressId, SqlDbType.Int));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@scholarshipId", myData.ScholarshipId, SqlDbType.Int));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@imageUrl", myData.ImageUrl, SqlDbType.NVarChar, 128));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@contactInfo", myData.ContactInfo, SqlDbType.NVarChar, 200));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@modifiedById", myData.ModifiedById, SqlDbType.Int));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@createdById", myData.CreatedById, SqlDbType.Int));

                    SqlParameter idOut = new SqlParameter("@Id", 0);
                    idOut.Direction = ParameterDirection.Output;
                    inputs.Add(idOut);
                },
                returnParameters: (SqlParameterCollection inputs) =>
                {
                    int.TryParse(inputs["@Id"].Value.ToString(), out id);
                });
            return id;
        }

        public void Update(EventUpdateRequest myData)
        {
            DataProvider.ExecuteNonQuery("dbo.Event_Update",
                inputParamMapper: (SqlParameterCollection inputs) =>
                {
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@organizationId", myData.OrganizationId, SqlDbType.Int));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@eventTypeId", myData.EventTypeId, SqlDbType.Int));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@title", myData.Title, SqlDbType.NVarChar, 100));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@topicDesc", myData.TopicDesc, SqlDbType.NVarChar, 2000));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@startDate", myData.StartDate, SqlDbType.Date));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@startTime", myData.StartTime, SqlDbType.Time));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@endDate", myData.EndDate, SqlDbType.Date));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@endTime", myData.EndTime, SqlDbType.Time));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@isAllDay", myData.IsAllDay, SqlDbType.Bit));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@venueName", myData.VenueName, SqlDbType.NVarChar, 100));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@addressId", myData.AddressId, SqlDbType.Int));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@scholarshipId", myData.ScholarshipId, SqlDbType.Int));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@imageUrl", myData.ImageUrl, SqlDbType.NVarChar, 128));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@contactInfo", myData.ContactInfo, SqlDbType.NVarChar, 200));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@modifiedById", myData.ModifiedById, SqlDbType.Int));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@streetAddress", myData.StreetAddress, SqlDbType.NVarChar, 150));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@city", myData.City, SqlDbType.NVarChar, 150));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@stateProvinceId", myData.StateProvinceId, SqlDbType.Int));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@postalCode", myData.PostalCode, SqlDbType.NVarChar, 20));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@Id", myData.Id, SqlDbType.Int));
                });
        }

        public void Delete(int id)
        {
            DataProvider.ExecuteNonQuery("dbo.Event_Delete",
                inputParamMapper: (SqlParameterCollection inputs) =>
                {
                    inputs.AddWithValue("@Id", id);
                });
        }

        public int Save(EventAddRequest myData)
        {
            int id = 0;
            DataProvider.ExecuteNonQuery("dbo.Event_Save",
                inputParamMapper: (SqlParameterCollection inputs) =>
                {
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@organizationId", myData.OrganizationId, SqlDbType.Int));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@eventTypeId", myData.EventTypeId, SqlDbType.Int));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@title", myData.Title, SqlDbType.NVarChar, 100));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@topicDesc", myData.TopicDesc, SqlDbType.NVarChar, 2000));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@startDate", myData.StartDate, SqlDbType.Date));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@startTime", myData.StartTime, SqlDbType.Time));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@endDate", myData.EndDate, SqlDbType.Date));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@endTime", myData.EndTime, SqlDbType.Time));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@isAllDay", myData.IsAllDay, SqlDbType.Bit));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@venueName", myData.VenueName, SqlDbType.NVarChar, 100));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@addressId", myData.AddressId, SqlDbType.Int));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@scholarshipId", myData.ScholarshipId, SqlDbType.Int));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@imageUrl", myData.ImageUrl, SqlDbType.NVarChar, 128));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@contactInfo", myData.ContactInfo, SqlDbType.NVarChar, 200));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@modifiedById", myData.ModifiedById, SqlDbType.Int));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@createdById", myData.CreatedById, SqlDbType.Int));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@streetAddress", myData.StreetAddress, SqlDbType.NVarChar, 150));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@city", myData.City, SqlDbType.NVarChar, 150));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@stateProvinceId", myData.StateProvinceId, SqlDbType.Int));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@postalCode", myData.PostalCode, SqlDbType.NVarChar, 20));

                    SqlParameter idOut = new SqlParameter("@Id", 0);
                    idOut.Direction = ParameterDirection.Output;
                    inputs.Add(idOut);
                },
                returnParameters: (SqlParameterCollection inputs) =>
                {
                    int.TryParse(inputs["@Id"].Value.ToString(), out id);
                });
            return id;
        }
    }
}
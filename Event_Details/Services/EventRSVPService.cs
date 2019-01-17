using Eleveight.Models.Domain.Events;
using Eleveight.Models.Requests.Events;
using Eleveight.Services.Tools;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Eleveight.Services.Events
{
    public class EventRSVPService : BaseService, IEventRSVPService
    {
        public List<EventRSVP> ReadAll()
        {
            List<EventRSVP> list = new List<EventRSVP>();
            DataProvider.ExecuteCmd("dbo.EventRSVP_SelectAll",
                inputParamMapper: null,
                singleRecordMapper: (IDataReader reader, short resultSet) =>
                {
                    list.Add(DataMapper<EventRSVP>.Instance.MapToObject(reader));
                });
            return list;
        }

        public EventRSVP ReadById(int eventId)
        {
            EventRSVP eventRSVP = new EventRSVP();
            DataProvider.ExecuteCmd("dbo.EventRSVP_SelectCount",
                inputParamMapper: (SqlParameterCollection inputs) =>
                {
                    inputs.AddWithValue("@eventId", eventId);
                },
                singleRecordMapper: (IDataReader reader, short resultSet) =>
                {
                    eventRSVP = DataMapper<EventRSVP>.Instance.MapToObject(reader);
                });

            return eventRSVP;
        }

        public int Insert(EventRSVPRequest model)
        {
            int returnValue = 0;

            DataProvider.ExecuteNonQuery("dbo.EventRSVP_Insert",
                inputParamMapper: (SqlParameterCollection inputs) =>
                {
                    inputs.AddWithValue("@EventId", model.EventId);
                    inputs.AddWithValue("@UserBaseId", model.UserBaseId);
                    inputs.AddWithValue("@RSVPTypeId", model.RSVPTypeId);

                    SqlParameter idOut1 = new SqlParameter("@PeopleGoing", 0);
                    SqlParameter idOut2 = new SqlParameter("@PeopleInterested", 0);
                    idOut1.Direction = ParameterDirection.Output;
                    idOut2.Direction = ParameterDirection.Output;

                    inputs.Add(idOut1);
                    inputs.Add(idOut2);
                },
                returnParameters: (SqlParameterCollection inputs) =>
                {
                    int.TryParse(inputs["@PeopleGoing"].Value.ToString(), out returnValue);
                    int.TryParse(inputs["@PeopleInterested"].Value.ToString(), out returnValue);
                });
            return returnValue;
        }

        public void Update(EventRSVPRequest model)
        {
            DataProvider.ExecuteNonQuery("dbo.EventRSVP_Update",
                inputParamMapper: (SqlParameterCollection inputs) =>
                {
                    inputs.AddWithValue("@EventId", model.EventId);
                    inputs.AddWithValue("@UserBaseId", model.UserBaseId);
                    inputs.AddWithValue("@RSVPTypeId", model.RSVPTypeId);
                });
        }

        public void Delete(int eventId, int userBaseId)
        {
            DataProvider.ExecuteNonQuery("dbo.EventRSVP_Delete",
                inputParamMapper: (SqlParameterCollection inputs) =>
                {
                    inputs.AddWithValue("@EventId", eventId);
                    inputs.AddWithValue("@UserBaseId", userBaseId);
                });
        }
    }
}
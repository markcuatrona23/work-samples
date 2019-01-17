using Eleveight.Models.Domain.Events;
using Eleveight.Models.Requests.Events;
using Eleveight.Services.Tools;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Eleveight.Services.Events
{
    public class EventTypeService : BaseService, IEventTypeService
    {
        public List<EventType> ReadAll()
        {
            List<EventType> list = new List<EventType>();
            DataProvider.ExecuteCmd("dbo.EventType_SelectAll",
                inputParamMapper: null,
                singleRecordMapper: (IDataReader reader, short resultSet) =>
                {
                    list.Add(DataMapper<EventType>.Instance.MapToObject(reader));
                });

            return list;
        }

        public EventType ReadById(int id)
        {
            EventType eventType = new EventType();
            DataProvider.ExecuteCmd("dbo.EventType_SelectById",
                inputParamMapper: (SqlParameterCollection inputs) =>
                {
                    inputs.AddWithValue("@Id", id);
                },
                singleRecordMapper: (IDataReader reader, short resultSet) =>
                {
                    eventType = DataMapper<EventType>.Instance.MapToObject(reader);
                });

            return eventType;
        }

        public int Insert(EventTypeAddRequest model)
        {
            int returnValue = 0;

            DataProvider.ExecuteNonQuery("dbo.EventType_Insert",
                inputParamMapper: (SqlParameterCollection inputs) =>
                {
                    inputs.AddWithValue("@TypeName", model.TypeName);
                    inputs.AddWithValue("@TypeDescription", model.TypeDescription);

                    SqlParameter idOut = new SqlParameter("@Id", 0);
                    idOut.Direction = ParameterDirection.Output;
                    inputs.Add(idOut);
                },
                returnParameters: (SqlParameterCollection inputs) =>
                {
                    int.TryParse(inputs["@Id"].Value.ToString(), out returnValue);
                });

            return returnValue;
        }

        public void Update(EventTypeUpdateRequest model)
        {
            DataProvider.ExecuteNonQuery("dbo.EventType_Update",

                inputParamMapper: (SqlParameterCollection inputs) =>
                {
                    inputs.AddWithValue("@Id", model.Id);
                    inputs.AddWithValue("@TypeName", model.TypeName);
                    inputs.AddWithValue("@TypeDescription", model.TypeDescription);
                });
        }

        public void Delete(int Id)
        {
            DataProvider.ExecuteNonQuery("dbo.EventType_Delete",

                inputParamMapper: (SqlParameterCollection inputs) =>
                {
                    inputs.AddWithValue("@Id", Id);
                });
        }
    }
}
using Eleveight.Models.Domain.Events;
using Eleveight.Models.Requests.Events;
using Eleveight.Services.Tools;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Eleveight.Services.Events
{
    public class RSVPTypesService : BaseService, IRSVPTypesService
    {
        public List<RSVPTypes> ReadAll()
        {
            List<RSVPTypes> list = new List<RSVPTypes>();
            DataProvider.ExecuteCmd("dbo.RSVPTypes_SelectAll",
                inputParamMapper: null,
                singleRecordMapper: (IDataReader reader, short resultSet) =>
                {
                    list.Add(DataMapper<RSVPTypes>.Instance.MapToObject(reader));
                });
            return list;
        }

        public RSVPTypes ReadById(int id)
        {
            RSVPTypes item = new RSVPTypes();
            DataProvider.ExecuteCmd("dbo.RSVPTypes_SelectById",
                inputParamMapper: (SqlParameterCollection inputs) =>
                {
                    inputs.AddWithValue("@id", id);
                },
                singleRecordMapper: (IDataReader reader, short resultSet) =>
                {
                    item = DataMapper<RSVPTypes>.Instance.MapToObject(reader);
                });
            return item;
        }

        public int Insert(RSVPTypesAddRequest myData)
        {
            int id = 0;
            DataProvider.ExecuteNonQuery("dbo.RSVPTypes_Insert",
                inputParamMapper: (SqlParameterCollection input) =>
                {
                    input.Add(SqlDbParameter.Instance.BuildParameter("@RSVPType", myData.RSVPType, SqlDbType.NVarChar, 50));

                    SqlParameter idOut = new SqlParameter("@Id", 0);
                    idOut.Direction = ParameterDirection.Output;
                    input.Add(idOut);
                },
                returnParameters: (SqlParameterCollection inputs) =>
                {
                    int.TryParse(inputs["@Id"].Value.ToString(), out id);
                });
            return id;
        }

        public void Update(RSVPTypesUpdateRequest myData)
        {
            DataProvider.ExecuteNonQuery("dbo.RSVPTypes_Update",
                inputParamMapper: (SqlParameterCollection inputs) =>
                {
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@RSVPType", myData.RSVPType, SqlDbType.NVarChar, 50));
                    inputs.Add(SqlDbParameter.Instance.BuildParameter("@Id", myData.Id, SqlDbType.Int));
                });
        }

        public void Delete(int id)
        {
            DataProvider.ExecuteNonQuery("dbo.RSVPTypes_Delete",
                inputParamMapper: (SqlParameterCollection input) =>
                {
                    input.AddWithValue("@Id", id);
                });
        }
    }
}
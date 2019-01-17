using Eleveight.Models.Domain.Common;
using Eleveight.Models.Requests.Common;
using Eleveight.Services.Tools;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Eleveight.Services.Common
{
    public class AddressService : BaseService, IAddressService
    {
        public List<Address> ReadAll()
        {
            List<Address> list = new List<Address>();
            DataProvider.ExecuteCmd("dbo.Address_SelectAll",
                inputParamMapper: null,
                singleRecordMapper: (IDataReader reader, short resultSet) =>
                {
                    list.Add(DataMapper<Address>.Instance.MapToObject(reader));
                });
            return list;
        }

        public Address ReadById(int id)
        {
            Address myAddress = new Address();
            DataProvider.ExecuteCmd("dbo.Address_SelectById",
                inputParamMapper: (SqlParameterCollection inputs) =>
                {
                    inputs.AddWithValue("@Id", id);
                },
                singleRecordMapper: (IDataReader reader, short resultSet) =>
                {
                    myAddress = DataMapper<Address>.Instance.MapToObject(reader);
                });
            return myAddress;
        }

        public int Insert(AddressAddRequest model)
        {
            int returnValue = 0;

            DataProvider.ExecuteNonQuery("dbo.Address_Insert",
                inputParamMapper: (SqlParameterCollection inputs) =>
                {
                    inputs.AddWithValue("@AddressTypeId", model.AddressTypeId);
                    inputs.AddWithValue("@StreetAddress", model.StreetAddress);
                    inputs.AddWithValue("@City", model.City);
                    inputs.AddWithValue("@StateProvinceId", model.StateProvinceId);
                    inputs.AddWithValue("@PostalCode", model.PostalCode);
                    inputs.AddWithValue("@Latitude", model.Latitude);
                    inputs.AddWithValue("@Longitude", model.Longitude);

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

        public void Update(AddressUpdateRequest model)
        {
            DataProvider.ExecuteNonQuery("dbo.Address_Update",
                inputParamMapper: (SqlParameterCollection inputs) =>
                {
                    inputs.AddWithValue("@Id", model.Id);
                    inputs.AddWithValue("@AddressTypeId", model.AddressTypeId);
                    inputs.AddWithValue("@StreetAddress", model.StreetAddress);
                    inputs.AddWithValue("@City", model.City);
                    inputs.AddWithValue("@StateProvinceId", model.StateProvinceId);
                    inputs.AddWithValue("@PostalCode", model.PostalCode);
                    inputs.AddWithValue("@Latitude", model.Latitude);
                    inputs.AddWithValue("@Longitude", model.Longitude);
                });
        }

        public void Delete(int id)
        {
            DataProvider.ExecuteNonQuery("dbo.Address_Delete",
                inputParamMapper: (SqlParameterCollection inputs) =>
                {
                    inputs.AddWithValue("@Id", id);
                });
        }
    }
}
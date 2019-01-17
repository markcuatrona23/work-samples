using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eleveight.Data.Providers;
using Eleveight.Models.Domain.Events;
using Eleveight.Services.Tools;

namespace Eleveight.Services.Events
{
    public class OrganizationByUserBaseService : BaseService, IOrganizationByUserBaseService
    {
        public OrganizationByUserBase ReadById(int userBaseId)
        {
            OrganizationByUserBase item = new OrganizationByUserBase();
            DataProvider.ExecuteCmd("dbo.UserBase_SelectOrganizationByUserBaseId",
                inputParamMapper: (SqlParameterCollection inputs) =>
                {
                    inputs.AddWithValue("@UserBaseId", userBaseId);
                },
                singleRecordMapper: (IDataReader reader, short resultSet) =>
                {
                    item = DataMapper<OrganizationByUserBase>.Instance.MapToObject(reader);

                });
            return item;
        }
    }
}

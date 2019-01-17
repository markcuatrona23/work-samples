using Eleveight.Models.Domain.Common;
using Eleveight.Services.Tools;
using System.Collections.Generic;
using System.Data;

namespace Eleveight.Services.Common
{
    public class StatesService : BaseService, IStatesService
    {
        public List<States> ReadAll()
        {
            List<States> list = new List<States>();
            DataProvider.ExecuteCmd("dbo.SelectAllUSStates",
                inputParamMapper: null,
                singleRecordMapper: (IDataReader reader, short resultSet) =>
                {
                    list.Add(DataMapper<States>.Instance.MapToObject(reader));
                });
            return list;
        }
    }
}
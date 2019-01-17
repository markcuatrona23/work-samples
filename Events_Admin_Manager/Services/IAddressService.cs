using Eleveight.Models.Domain.Common;
using Eleveight.Models.Requests.Common;
using System.Collections.Generic;

namespace Eleveight.Services.Common
{
    public interface IAddressService
    {
        List<Address> ReadAll();

        Address ReadById(int id);

        int Insert(AddressAddRequest model);

        void Update(AddressUpdateRequest model);

        void Delete(int id);
    }
}
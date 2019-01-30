using Eleveight.Models.Domain.Events;
using Eleveight.Models.Requests.Events;
using System.Collections.Generic;

namespace Eleveight.Services.Events
{
    public interface IRSVPTypesService
    {
        void Delete(int id);

        int Insert(RSVPTypesAddRequest myData);

        List<RSVPTypes> ReadAll();

        RSVPTypes ReadById(int id);

        void Update(RSVPTypesUpdateRequest myData);
    }
}
using Eleveight.Models.Domain.Events;
using Eleveight.Models.Requests.Events;
using System.Collections.Generic;

namespace Eleveight.Services.Events
{
    public interface IEventTypeService
    {
        void Delete(int Id);

        int Insert(EventTypeAddRequest model);

        List<EventType> ReadAll();

        EventType ReadById(int id);

        void Update(EventTypeUpdateRequest model);
    }
}
using Eleveight.Models.Domain.Events;
using Eleveight.Models.Requests.Events;
using System.Collections.Generic;

namespace Eleveight.Services.Events
{
    public interface IEventService
    {
        void Delete(int id);

        int Insert(EventAddRequest myData);
        List<Event> ReadAll(int userBaseId);
        List<Event> ReadAllEvents();
        List<Event> ViewRelatedEventsById(int id);

        Event ReadById(int id);

        void Update(EventUpdateRequest myData);

        int Save(EventAddRequest myData);
    }
}
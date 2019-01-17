using Eleveight.Models.Domain.Events;
using Eleveight.Models.Requests.Events;
using System.Collections.Generic;

namespace Eleveight.Services.Events
{
    public interface IEventRSVPService
    {
        void Delete(int eventId, int userBaseId);

        int Insert(EventRSVPRequest model);

        List<EventRSVP> ReadAll();

        EventRSVP ReadById(int eventId);

        void Update(EventRSVPRequest model);
    }
}
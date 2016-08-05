using System.Collections.Generic;
using Tickets.DomainModel;

namespace Tickets.Common
{
    public interface IEventsManager
    {
        IList<Event> GetAllEvents();
        void AddEvent(params Event[] events);
        void UpdateEvent(params Event[] events);
        void RemoveEvent(params Event[] events);

    }
}
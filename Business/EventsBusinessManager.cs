using Tickets.DomainModel;
using System.Collections.Generic;
using Tickets.DataAccess;
using Tickets.Common;
using System;

namespace Tickets.Business
{
    public class EventBusinessManager : IEventsManager
    {

        private readonly IEventRepository _eventRepository;


        public EventBusinessManager()
        {
            _eventRepository = new EventRepository();

        }

        public EventBusinessManager(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public void AddEvent(params Event[] events)
        {
            _eventRepository.Add(events);
        }

        public IList<Event> GetAllEvents()
        {
            return _eventRepository.GetAll();
        }

        public void RemoveEvent(params Event[] events)
        {
            _eventRepository.Remove(events);
        }

        public void UpdateEvent(params Event[] events)
        {
            _eventRepository.Update(events);
        }
    }
}
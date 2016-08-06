using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Common;
using Tickets.Model;
using Tickets.Proxy.EventsServiceReference;

namespace Tickets.Proxy
{
    public class EventsManagerProxy : IEventsManager
    {
        public void AddEvent(params Event[] events)
        {
            new EventsServiceClient().AddEvent(events.First());
        }

        public void AddSession(params Session[] sessions)
        {
            new EventsServiceClient().AddSession(sessions.First());
        }

        public void AddTicket(params Ticket[] tickets)
        {
            new EventsServiceClient().AddTicket(tickets.First());
        }

        public IList<Event> GetAllEvents()
        {
            return new EventsServiceClient().GetAllEvents();
        }

        public IList<Session> GetAllEventSessions(int eventId)
        {
            return new EventsServiceClient().GetAllEventSessions(eventId);
        }

        public IList<Ticket> GetAllSessionsTickets(int sessionId)
        {
            return new EventsServiceClient().GetAllSessionsTickets(sessionId);
        }

        public IList<Event> GetSingleEvent(int eventId)
        {
            return new EventsServiceClient().GetSingleEvent(eventId);
        }

        public IList<Session> GetSingleSession(int sessionId)
        {
            return new EventsServiceClient().GetSingleSession(sessionId);
        }

        public IList<Ticket> GetSingleTicket(int ticketId)
        {
            return new EventsServiceClient().GetSingleTicket(ticketId);
        }

        public void RemoveEvent(params Event[] events)
        {
            new EventsServiceClient().RemoveEvent(events.First());
        }

        public void RemoveSession(params Session[] sessions)
        {
            new EventsServiceClient().RemoveSession(sessions.First());
        }

        public void RemoveTicket(params Ticket[] tickets)
        {
            new EventsServiceClient().RemoveTicket(tickets.First());
        }

        public void UpdateEvent(params Event[] events)
        {
            new EventsServiceClient().UpdateEvent(events.First());
        }

        public void UpdateSession(params Session[] sessions)
        {
            new EventsServiceClient().UpdateSession(sessions.First());
        }

        public void UpdateTicket(params Ticket[] tickets)
        {
            new EventsServiceClient().UpdateTicket(tickets.First());
        }
    }
}

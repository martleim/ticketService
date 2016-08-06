using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Tickets.Business;
using Tickets.Model;

namespace Tickets.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EventsService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EventsService.svc or EventsService.svc.cs at the Solution Explorer and start debugging.
    public class EventsService : IEventsService
    {
        public void AddEvent(Event e)
        {
            new EventBusinessManager().AddEvent(e);
        }

        public void AddSession(Session session)
        {
            new EventBusinessManager().AddSession(session);
        }

        public void AddTicket(Ticket ticket)
        {
            new EventBusinessManager().AddTicket(ticket);
        }

        public IList<Event> GetSingleEvent(int eventId)
        {
            return new EventBusinessManager().GetSingleEvent(eventId);
        }

        public IList<Event> GetAllEvents()
        {
            return new EventBusinessManager().GetAllEvents();
        }

        public IList<Session> GetAllEventSessions(int eventId)
        {
            return new EventBusinessManager().GetAllEventSessions(eventId);
        }

        public IList<Ticket> GetAllSessionsTickets(int sessionId)
        {
            return new EventBusinessManager().GetAllSessionsTickets(sessionId);
        }

        public IList<Session> GetSingleSession(int sessionId)
        {
            return new EventBusinessManager().GetSingleSession(sessionId);
        }

        public IList<Ticket> GetSingleTicket(int ticketId)
        {
            return new EventBusinessManager().GetSingleTicket(ticketId);
        }

        public void RemoveEvent(Event e)
        {
            new EventBusinessManager().RemoveEvent(e);
        }

        public void RemoveSession(Session session)
        {
            new EventBusinessManager().RemoveSession(session);
        }

        public void RemoveTicket(Ticket ticket)
        {
            new EventBusinessManager().RemoveTicket(ticket);
        }

        public void UpdateEvent(Event e)
        {
            new EventBusinessManager().UpdateEvent(e);
        }

        public void UpdateSession(Session session)
        {
            new EventBusinessManager().UpdateSession(session);
        }

        public void UpdateTicket(Ticket ticket)
        {
            new EventBusinessManager().UpdateTicket(ticket);
        }
    }
}

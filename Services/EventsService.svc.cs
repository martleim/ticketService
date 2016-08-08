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

        public Event GetSingleEvent(int eventId)
        {
            return new EventBusinessManager().GetSingleEvent(eventId);
        }

        public List<Event> GetAllEvents()
        {
            var ret = new EventBusinessManager().GetAllEvents().Cast<Event>().ToList();
            return ret;
        }

        public List<Session> GetAllEventSessions(int eventId)
        {
            var ret = new EventBusinessManager().GetAllEventSessions(eventId).ToList();
            return ret;
        }

        public List<Ticket> GetAllSessionsTickets(int sessionId)
        {
            return new EventBusinessManager().GetAllSessionsTickets(sessionId).ToList();
        }

        public List<Ticket> GetAllEventTickets(int eventId)
        {
            return new EventBusinessManager().GetAllEventTickets(eventId).ToList();
        }

        public Session GetSingleSession(int sessionId)
        {
            return new EventBusinessManager().GetSingleSession(sessionId);
        }

        public Ticket GetSingleTicket(int ticketId)
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

using System.Collections.Generic;
using Tickets.Model;

namespace Tickets.Common
{
    public interface IEventsManager
    {
        Event GetSingleEvent(int eventId);
        IList<Event> GetAllEvents();
        void AddEvent(params Event[] events);
        void UpdateEvent(params Event[] events);
        void RemoveEvent(params Event[] events);

        IList<Session> GetAllEventSessions(int eventId);
        Session GetSingleSession(int sessionId);
        void AddSession(params Session[] sessions);
        void UpdateSession(params Session[] sessions);
        void RemoveSession(params Session[] sessions);

        IList<Ticket> GetAllEventTickets(int eventId);
        IList<Ticket> GetAllSessionsTickets(int sessionId);
        Ticket GetSingleTicket(int ticketId);
        void AddTicket(params Ticket[] tickets);
        void UpdateTicket(params Ticket[] tickets);
        void RemoveTicket(params Ticket[] tickets);

    }
}
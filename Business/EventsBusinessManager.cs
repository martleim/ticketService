using Tickets.Model;
using System.Collections.Generic;
using Tickets.DataAccess;
using Tickets.Common;
using System;
using Tickets.DataAccess.PartialRepositories;
using Tickets.DataAccess.Contracts;

namespace Tickets.Business
{
    public class EventBusinessManager : BaseManager, IEventsManager
    {

        private readonly EventRepository _eventRepository;
        private readonly SessionRepository _sessionRepository;
        private readonly TicketRepository _ticketRepository;


        public EventBusinessManager()
        {
            _eventRepository = new EventRepository();
            _sessionRepository = new SessionRepository();
            _ticketRepository = new TicketRepository();
        }


        public void AddEvent(params Event[] events)
        {
            foreach(Event e in events)
            {
                var tickets = e.Ticket;
                e.Ticket = new HashSet<Ticket>();
                _eventRepository.Add(events);
                List<Ticket> toAdd = new List<Ticket>(tickets);
                foreach (Ticket t in toAdd)
                {
                    t.EventId = e.Id;
                }

                _ticketRepository.Add(toAdd.ToArray());
            }
        }

        public void AddSession(params Session[] sessions)
        {
            foreach (Session s in sessions)
            {
                var tickets = s.TicketSale;
                /*s.Ticket = new HashSet<Ticket>();
                _sessionRepository.Add(sessions);
                List<Ticket> toAdd = new List<Ticket>(tickets);
                foreach (Ticket t in toAdd)
                {
                    t.SessionId = s.Id;
                }
                _ticketRepository.Update(toAdd.ToArray());*/
            }
        }

        public void AddTicket(params Ticket[] tickets)
        {
            _ticketRepository.Add(tickets);
        }

        public IList<Event> GetAllEvents()
        {
            return _eventRepository.GetList(e=>true);
        }
        public Event GetSingleEvent(int eventId)
        {
            return _eventRepository.GetSingle(e => e.Id == eventId, e=>e.Session);
        }

        public IList<Session> GetAllEventSessions(int eventId)
        {
            return _sessionRepository.GetList(s => s.EventId==eventId, s=>s.TicketSale );
        }

        public IList<Ticket> GetAllSessionsTickets(int sessionId)
        {
            return _ticketRepository.GetList(t => t.SessionId == sessionId);
        }

        public IList<Ticket> GetAllEventTickets(int eventId)
        {
            return _ticketRepository.GetList(t => t.EventId == eventId);
        }

        public Session GetSingleSession(int sessionId)
        {
            return _sessionRepository.GetSingle(s => s.Id == sessionId, s => s.TicketSale);
        }

        public Ticket GetSingleTicket(int ticketId)
        {
            return _ticketRepository.GetSingle(t => t.Id == ticketId, t=>t.Description);
        }

        public void RemoveEvent(params Event[] events)
        {
            _eventRepository.Remove(events);
        }

        public void RemoveSession(params Session[] sessions)
        {
            _sessionRepository.Remove(sessions);
        }

        public void RemoveTicket(params Ticket[] tickets)
        {
            _ticketRepository.Remove(tickets);
        }

        public void UpdateEvent(params Event[] events)
        {
            _eventRepository.Remove(events);
        }

        public void UpdateSession(params Session[] sessions)
        {
            _sessionRepository.Update(sessions);
        }

        public void UpdateTicket(params Ticket[] tickets)
        {
            _ticketRepository.Update(tickets);
        }
    }
}
using Tickets.Model;
using System.Collections.Generic;
using Tickets.DataAccess;
using Tickets.Common;
using System;

namespace Tickets.Business
{
    public class EventBusinessManager : IEventsManager
    {

        private readonly IEventRepository _eventRepository;
        private readonly ISessionRepository _sessionRepository;
        private readonly ITicketRepository _ticketRepository;


        public EventBusinessManager()
        {
            _eventRepository = new EventRepository();
            _sessionRepository = new SessionRepository();
            _ticketRepository = new TicketRepository();
        }

        public EventBusinessManager(IEventRepository eventRepository,
            ISessionRepository sessionRepository,
            ITicketRepository ticketRepository)
        {
            _eventRepository = eventRepository;
            _sessionRepository = sessionRepository;
            _ticketRepository = ticketRepository;

        }

        public void AddEvent(params Event[] events)
        {
            _eventRepository.Add(events);
        }

        public void AddSession(params Session[] sessions)
        {
            _sessionRepository.Add(sessions);
        }

        public void AddTicket(params Ticket[] tickets)
        {
            _ticketRepository.Add(tickets);
        }

        public IList<Event> GetAllEvents()
        {
            return _eventRepository.GetAll();
        }
        public IList<Event> GetSingleEvent(int eventId)
        {
            return _eventRepository.GetAll(e => e.Id == eventId);
        }

        public IList<Session> GetAllEventSessions(int eventId)
        {
            return _sessionRepository.GetAll(s => s.EventId==eventId );
        }

        public IList<Ticket> GetAllSessionsTickets(int sessionId)
        {
            return _ticketRepository.GetAll(t => t.SessionId == sessionId);
        }

        public IList<Session> GetSingleSession(int sessionId)
        {
            return _sessionRepository.GetAll(s => s.Id == sessionId);
        }

        public IList<Ticket> GetSingleTicket(int ticketId)
        {
            return _ticketRepository.GetAll(t => t.Id == ticketId);
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
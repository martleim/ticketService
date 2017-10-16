using Tickets.Model;
using System.Collections.Generic;
using Tickets.DataAccess;
using Tickets.Common;
using System;
using Tickets.DataAccess.PartialRepositories;

namespace Tickets.Business
{
    public class TicketBusinessManager : BaseManager, ITicketsManager
    {
        private readonly EventRepository _eventRepository;
        private readonly SessionRepository _sessionRepository;
        private readonly TicketRepository _ticketRepository;
        private readonly TransactionRepository _transactionRepository;
        
        public TicketBusinessManager()
        {
            _sessionRepository = new SessionRepository();
            _transactionRepository = new TransactionRepository();
            _ticketRepository = new TicketRepository();
            _eventRepository = new EventRepository();

        }

        public TicketBusinessManager(SessionRepository sessionRepository,
            TransactionRepository transactionRepository, 
            TicketRepository ticketRepository, 
            EventRepository eventRepository)
        {
            _sessionRepository = sessionRepository;
            _transactionRepository = transactionRepository;
            _ticketRepository = ticketRepository;
            _eventRepository = eventRepository;
        }

        public IList<Event> GetAllEvents()
        {
            return _eventRepository.GetAll();
        }

        public IList<Session> GetAllEventSessions(int eventId)
        {
            return _sessionRepository.GetAll(
                d => d.EventId.Equals(eventId));
        }

        public IList<Ticket> GetAllSessionTickets(int sessionId)
        {
            return _ticketRepository.GetAll(
                d => d.SessionId.Equals(sessionId));
        }

        public IList<Transaction> GetAllUserTransactions(int userId)
        {
            return _transactionRepository.GetAll(
                d => d.UserId.Equals(userId));
        }
        public void AddTransaction(params Transaction[] transactions)
        {
            _transactionRepository.Add(transactions);
        }
        public void RemoveTransaction(params Transaction[] transactions)
        {
            _transactionRepository.Remove(transactions);
        }
        public void UpdateTransaction(params Transaction[] transactions)
        {
            _transactionRepository.Update(transactions);
        }
    }
}
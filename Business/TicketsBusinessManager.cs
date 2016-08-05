using Tickets.DomainModel;
using System.Collections.Generic;
using Tickets.DataAccess;
using Tickets.Common;
using System;

namespace Tickets.Business
{
    public class TicketBusinessManager : ITicketsManager
    {
        private readonly IEventRepository _eventRepository;
        private readonly ISessionRepository _sessionRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly ITransactionRepository _transactionRepository;
        
        public TicketBusinessManager()
        {
            _sessionRepository = new SessionRepository();
            _transactionRepository = new TransactionRepository();
            _ticketRepository = new TicketRepository();
            _eventRepository = new EventRepository();

        }

        public TicketBusinessManager(ISessionRepository sessionRepository,
            ITransactionRepository transactionRepository, 
            ITicketRepository ticketRepository, 
            IEventRepository eventRepository)
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

        public IList<Ticket> GetAllSessionTicketCategories(int sessionId)
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
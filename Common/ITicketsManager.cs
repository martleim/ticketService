using System.Collections.Generic;
using Tickets.DomainModel;

namespace Tickets.Common
{
    public interface ITicketsManager
    {
        
        IList<Event> GetAllEvents();
        IList<Session> GetAllEventSessions(int eventId);
        IList<Ticket> GetAllSessionTicketCategories(int sessionId);
        IList<Transaction> GetAllUserTransactions(int userId);
        void AddTransaction(params Transaction[] transactions);
        void UpdateTransaction(params Transaction[] transactions);
        void RemoveTransaction(params Transaction[] transactions);

    }
}
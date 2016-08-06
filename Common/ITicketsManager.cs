using System.Collections.Generic;
using Tickets.Model;

namespace Tickets.Common
{
    public interface ITicketsManager
    {
        
        IList<Event> GetAllEvents();
        IList<Session> GetAllEventSessions(int eventId);
        IList<Ticket> GetAllSessionTickets(int sessionId);
        IList<Transaction> GetAllUserTransactions(int userId);
        void AddTransaction(params Transaction[] transactions);
        void UpdateTransaction(params Transaction[] transactions);
        void RemoveTransaction(params Transaction[] transactions);

    }
}
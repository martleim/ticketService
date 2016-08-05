using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Common;
using Tickets.DomainModel;

namespace Tickets.Proxy
{
    public class TicketsManagerProxy : ITicketsManager
    {
        public void AddTransaction(params Transaction[] transactions)
        {
            new TicketsServiceReference.TicketsServiceClient().AddTransaction(transactions.First());
        }

        public IList<Event> GetAllEvents()
        {
            return new TicketsServiceReference.TicketsServiceClient().GetAllEvents();
        }

        public IList<Session> GetAllEventSessions(int eventId)
        {
            return new TicketsServiceReference.TicketsServiceClient().GetAllEventSessions(eventId);
        }

        public IList<Ticket> GetAllSessionTicketCategories(int sessionId)
        {
            return new TicketsServiceReference.TicketsServiceClient().GetAllSessionTicketCategories(sessionId);
        }

        public IList<Transaction> GetAllUserTransactions(int userId)
        {
            return new TicketsServiceReference.TicketsServiceClient().GetAllUserTransactions(userId);
        }

        public void RemoveTransaction(params Transaction[] transactions)
        {
            new TicketsServiceReference.TicketsServiceClient().RemoveTransaction(transactions.First());
        }

        public void UpdateTransaction(params Transaction[] transactions)
        {
            new TicketsServiceReference.TicketsServiceClient().UpdateTransaction(transactions.First());
        }
    }
}

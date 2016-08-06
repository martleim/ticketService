using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Common;
using Tickets.Model;
using Tickets.Proxy.TicketsServiceReference;

namespace Tickets.Proxy
{
    public class TicketsManagerProxy : ITicketsManager
    {
        public void AddTransaction(params Transaction[] transactions)
        {
            new TicketsServiceClient().AddTransaction(transactions.First());
        }

        public IList<Event> GetAllEvents()
        {
            return new TicketsServiceClient().GetAllEvents();
        }

        public IList<Session> GetAllEventSessions(int eventId)
        {
            return new TicketsServiceClient().GetAllEventSessions(eventId);
        }

        public IList<Ticket> GetAllSessionTickets(int sessionId)
        {
            return new TicketsServiceClient().GetAllSessionTickets(sessionId);
        }

        public IList<Transaction> GetAllUserTransactions(int userId)
        {
            return new TicketsServiceClient().GetAllUserTransactions(userId);
        }

        public void RemoveTransaction(params Transaction[] transactions)
        {
            new TicketsServiceClient().RemoveTransaction(transactions.First());
        }

        public void UpdateTransaction(params Transaction[] transactions)
        {
            new TicketsServiceClient().UpdateTransaction(transactions.First());
        }
    }
}

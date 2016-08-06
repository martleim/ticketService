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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TicketsService" in both code and config file together.
    public class TicketsService : ITicketsService
    {
        public void AddTransaction(Transaction transaction)
        {
            new TicketBusinessManager().AddTransaction(new Transaction[] { transaction });
        }

        public IList<Event> GetAllEvents()
        {
            return new TicketBusinessManager().GetAllEvents();
        }

        public IList<Session> GetAllEventSessions(int eventId)
        {
            return new TicketBusinessManager().GetAllEventSessions(eventId);
        }

        public IList<Ticket> GetAllSessionTickets(int sessionId)
        {
            return new TicketBusinessManager().GetAllSessionTickets(sessionId);
        }

        public IList<Transaction> GetAllUserTransactions(int userId)
        {
            return new TicketBusinessManager().GetAllUserTransactions(userId);
        }

        public void RemoveTransaction(Transaction transaction)
        {
            new TicketBusinessManager().RemoveTransaction(new Transaction[] { transaction });
        }

        public void UpdateTransaction(Transaction transaction)
        {
            new TicketBusinessManager().UpdateTransaction(new Transaction[] { transaction });
        }
    }
}

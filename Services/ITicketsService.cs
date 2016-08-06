using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Tickets.Model;

namespace Tickets.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITicketsService" in both code and config file together.
    [ServiceContract]
    public interface ITicketsService
    {
        [OperationContract]
        IList<Event> GetAllEvents();

        [OperationContract]
        IList<Session> GetAllEventSessions(int eventId);

        [OperationContract]
        IList<Ticket> GetAllSessionTickets(int sessionId);

        [OperationContract]
        IList<Transaction> GetAllUserTransactions(int userId);

        [OperationContract]
        void AddTransaction(Transaction transaction);

        [OperationContract]
        void UpdateTransaction(Transaction transaction);

        [OperationContract]
        void RemoveTransaction(Transaction transaction);
    }
}

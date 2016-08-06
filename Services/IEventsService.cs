using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Tickets.Model;

namespace Tickets.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEventsService" in both code and config file together.
    [ServiceContract]
    public interface IEventsService
    {
        [OperationContract]
        IList<Event> GetSingleEvent(int eventId);

        [OperationContract]
        IList<Event> GetAllEvents();

        [OperationContract]
        void AddEvent(Event e);

        [OperationContract]
        void UpdateEvent(Event e);

        [OperationContract]
        void RemoveEvent(Event e);
        
        [OperationContract]
        IList<Session> GetAllEventSessions(int eventId);

        [OperationContract]
        IList<Session> GetSingleSession(int sessionId);

        [OperationContract]
        void AddSession(Session session);

        [OperationContract]
        void UpdateSession(Session session);

        [OperationContract]
        void RemoveSession(Session session);

        [OperationContract]
        IList<Ticket> GetAllSessionsTickets(int sessionId);

        [OperationContract]
        IList<Ticket> GetSingleTicket(int ticketId);

        [OperationContract]
        void AddTicket(Ticket ticket);

        [OperationContract]
        void UpdateTicket(Ticket ticket);

        [OperationContract]
        void RemoveTicket(Ticket ticket);

    }
}

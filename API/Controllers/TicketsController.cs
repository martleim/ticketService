using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tickets.Model;
using Tickets.Proxy;

namespace Tickets.API.Controllers
{
    public class TicketsController : BaseController
    {

        [HttpGet]
        [Route("TicketSell/Events")]
        public IHttpActionResult GetEvents()
        {
            return Json(new TicketsManagerProxy().GetAllEvents());
        }

        [HttpGet]
        [Route("TicketSell/Sessions/Event/{eventId}")]
        public IHttpActionResult GetEventSessions(int eventId)
        {
            return Json(new TicketsManagerProxy().GetAllEventSessions(eventId));
        }

        [HttpGet]
        [Route("TicketSell/Tickets/Session/{sessionId}")]
        public IHttpActionResult GetSessionTickets(int sessionId)
        {
            return Ok(new TicketsManagerProxy().GetAllSessionTickets(sessionId));
        }

        [HttpGet]
        [Route("TicketSell/Transactions")]
        public IHttpActionResult GetUserTransactions()
        {
            return Ok(new TicketsManagerProxy().GetAllUserTransactions(GetLoggedUserId()));
        }

        [HttpPost]
        [Route("TicketSell/Transactions")]
        public IHttpActionResult Transactions(Transaction transaction)
        {
            transaction.UserId = GetLoggedUserId();
            new TicketsManagerProxy().AddTransaction(transaction);
            return Ok();
        }

        [HttpPut]
        [Route("TicketSell/Ticketss/Transactions/{transactionId}")]
        public IHttpActionResult Transactions(int transactionId, Transaction transaction)
        {
            transaction.Id = transactionId;
            new TicketsManagerProxy().UpdateTransaction(transaction);
            return Ok();
        }

        [HttpDelete]
        [Route("TicketSell/Ticketss/Transactions/{transactionId}")]
        public IHttpActionResult Transactions(int transactionId)
        {
            Transaction transaction = new Transaction() { Id = transactionId };
            new TicketsManagerProxy().RemoveTransaction(transaction);
            return Ok();
        }

    }
}

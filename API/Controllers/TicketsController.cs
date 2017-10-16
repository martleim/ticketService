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
            return Json(ProxyManager.TicketsManager.GetAllEvents());
        }

        [HttpGet]
        [Route("TicketSell/Sessions/Event/{eventId}")]
        public IHttpActionResult GetEventSessions(int eventId)
        {
            return Json(ProxyManager.TicketsManager.GetAllEventSessions(eventId));
        }

        [HttpGet]
        [Route("TicketSell/Tickets/Session/{sessionId}")]
        public IHttpActionResult GetSessionTickets(int sessionId)
        {
            return Ok(ProxyManager.TicketsManager.GetAllSessionTickets(sessionId));
        }

        [HttpGet]
        [Route("TicketSell/Transactions")]
        public IHttpActionResult GetUserTransactions()
        {
            return Ok(ProxyManager.TicketsManager.GetAllUserTransactions(GetLoggedUserId()));
        }

        [HttpPost]
        [Route("TicketSell/Transactions")]
        public IHttpActionResult Transactions(Transaction transaction)
        {
            transaction.UserId = GetLoggedUserId();
            ProxyManager.TicketsManager.AddTransaction(transaction);
            return Ok();
        }

        [HttpPut]
        [Route("TicketSell/Ticketss/Transactions/{transactionId}")]
        public IHttpActionResult Transactions(int transactionId, Transaction transaction)
        {
            transaction.Id = transactionId;
            ProxyManager.TicketsManager.UpdateTransaction(transaction);
            return Ok();
        }

        [HttpDelete]
        [Route("TicketSell/Ticketss/Transactions/{transactionId}")]
        public IHttpActionResult Transactions(int transactionId)
        {
            Transaction transaction = new Transaction() { Id = transactionId };
            ProxyManager.TicketsManager.RemoveTransaction(transaction);
            return Ok();
        }

    }
}

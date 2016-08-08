using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tickets.Model;
using Tickets.Proxy;

namespace Tickets.API.Controllers
{
    public class EventsAdminController : BaseController
    {

        [Route("Admin/Events")]
        [HttpGet]
        public IHttpActionResult GetEvents(int? limit=null, int start=0)
        {
            var events = new EventsManagerProxy().GetAllEvents();
            int totalRecords = events.Count;
            if (limit != null)
            {
                events=events.Skip(start * limit.Value).Take(limit.Value).ToList();
            }
            return Json(GetPagedResult(events,totalRecords));
        }

        [Route("Admin/Events/{eventId}")]
        [HttpGet]
        public IHttpActionResult GetEvents(int eventId)
        {
            var e = new EventsManagerProxy().GetSingleEvent(eventId);
            return Json(e);
        }
        [Route("Admin/Events")]
        [HttpPost]
        public IHttpActionResult PostEvents(Event e)
        {
            new EventsManagerProxy().AddEvent(e);
            return Ok();
        }
        [Route("Admin/Events/{eventId}")]
        [HttpPut]
        public IHttpActionResult PutEvents(int eventId, Event e)
        {
            e.Id = eventId;
            new EventsManagerProxy().UpdateEvent(e);
            return Ok();
        }
        [Route("Admin/Events/{eventId}")]
        [HttpDelete]
        public IHttpActionResult DeleteEvents(int eventId)
        {
            Event e = new Event();
            e.Id = eventId;
            new EventsManagerProxy().AddEvent(e);
            return Ok();
        }

        [Route("Admin/Sessions/Event/{eventId}")]
        [HttpGet]
        public IHttpActionResult GetEventSessions(int eventId)
        {
            return Json(GetResult(new EventsManagerProxy().GetAllEventSessions(eventId)));
        }
        [Route("Admin/Sessions/{sessionId}")]
        [HttpGet]
        public IHttpActionResult GetSession(int sessionId)
        {
            return Json(new EventsManagerProxy().GetSingleSession(sessionId));
        }
        [Route("Admin/Sessions")]
        [HttpPost]
        public IHttpActionResult PostSessions(Session session)
        {
            new EventsManagerProxy().AddSession(session);
            return Ok();
        }
        [Route("Admin/Sessions/{sessionId}")]
        [HttpPut]
        public IHttpActionResult PutSessions(int sessionId, Session session)
        {
            session.Id=sessionId;
            new EventsManagerProxy().UpdateSession(session);
            return Ok();
        }
        [Route("Admin/Sessions/{sessionId}")]
        [HttpDelete]
        public IHttpActionResult DeleteSessions(int sessionId)
        {
            Session e = new Session();
            e.Id = sessionId;
            new EventsManagerProxy().AddSession(e);
            return Ok();
        }
        [Route("Admin/Tickets/Event/{eventId}")]
        [HttpGet]
        public IHttpActionResult GetEventTickets(int eventId)
        {
            return Json(GetResult(new EventsManagerProxy().GetAllEventTickets(eventId)));
        }

        [Route("Admin/Tickets/Session/{sessionId}")]
        [HttpGet]
        public IHttpActionResult GetSessionTickets(int sessionId)
        {
            return Json(GetResult(new EventsManagerProxy().GetAllSessionsTickets(sessionId)));
        }

        [Route("Admin/Tickets")]
        [HttpPost]
        public IHttpActionResult PostTickets(Ticket ticket)
        {
            new EventsManagerProxy().AddTicket(ticket);
            return Ok();
        }
        [Route("Admin/Tickets/{ticketId}")]
        [HttpPut]
        public IHttpActionResult PutTickets(int ticketId, Ticket ticket)
        {
            ticket.Id = ticketId;
            new EventsManagerProxy().UpdateTicket(ticket);
            return Ok();
        }
        [Route("Admin/Tickets/{ticketId}")]
        [HttpDelete]
        public IHttpActionResult DeleteTickets(int ticketId)
        {
            Ticket e = new Ticket();
            e.Id = ticketId;
            new EventsManagerProxy().AddTicket(e);
            return Ok();
        }
        

    }
}

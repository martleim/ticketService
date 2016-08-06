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
            dynamic myobject = new ExpandoObject();
            IDictionary<string, object> result = myobject;
            result.Add("result", events);
            result.Add("totalRecords", totalRecords); 
            return Json(result);
        }

        [Route("Admin/Events/{id}")]
        [HttpGet]
        public IHttpActionResult GetEvents(int id)
        {
            var events = new EventsManagerProxy().GetSingleEvent(id);
            return Ok(events.FirstOrDefault());
        }
        [Route("Admin/Events")]
        [HttpPost]
        public IHttpActionResult PostEvents(Event e)
        {
            new EventsManagerProxy().AddEvent(e);
            return Ok();
        }
        [Route("Admin/Events/{id}")]
        [HttpPut]
        public IHttpActionResult PutEvents(int eventId, Event e)
        {
            e.Id = eventId;
            new EventsManagerProxy().UpdateEvent(e);
            return Ok();
        }
        [Route("Admin/Events/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteEvents(int eventId)
        {
            Event e = new Event();
            e.Id = eventId;
            new EventsManagerProxy().AddEvent(e);
            return Ok();
        }

        [Route("Admin/Sessions")]
        [HttpGet]
        public IHttpActionResult GetSessions(int eventId)
        {
            return Ok(new EventsManagerProxy().GetAllEventSessions(eventId));
        }
        [Route("Admin/Sessions/{id}")]
        [HttpGet]
        public IHttpActionResult Sessions(int sessionId)
        {
            return Ok(new EventsManagerProxy().GetSingleSession(sessionId));
        }
        [Route("Admin/Sessions")]
        [HttpPost]
        public IHttpActionResult PostSessions(Session session)
        {
            new EventsManagerProxy().AddSession(session);
            return Ok();
        }
        [Route("Admin/Sessions/{id}")]
        [HttpPut]
        public IHttpActionResult PutSessions(int sessionId, Session session)
        {
            session.Id=sessionId;
            new EventsManagerProxy().UpdateSession(session);
            return Ok();
        }
        [Route("Admin/Sessions/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteSessions(int sessionId)
        {
            Session e = new Session();
            e.Id = sessionId;
            new EventsManagerProxy().AddSession(e);
            return Ok();
        }
        [Route("Admin/Tickets/{id}")]
        public IHttpActionResult GetTickets(int sessionId)
        {
            return Ok(new EventsManagerProxy().GetAllSessionsTickets(sessionId));
        }
        [Route("Admin/Tickets")]
        [HttpPost]
        public IHttpActionResult PostTickets(Ticket ticket)
        {
            new EventsManagerProxy().AddTicket(ticket);
            return Ok();
        }
        [Route("Admin/Tickets/{id}")]
        [HttpPut]
        public IHttpActionResult PutTickets(int ticketId, Ticket ticket)
        {
            ticket.Id = ticketId;
            new EventsManagerProxy().UpdateTicket(ticket);
            return Ok();
        }
        [Route("Admin/Tickets/{id}")]
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

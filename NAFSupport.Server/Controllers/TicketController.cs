using Microsoft.AspNetCore.Mvc;
using NAFSupport.Server.DataAccessLayer;
using NAFSupport.Server.Services;
using NAFSupport.Shared.Models;

namespace NAFSupport.Server.Controllers
{
    [ApiController]
    public class TicketController : Controller
    {
        public readonly TicketServices Tickets;
        public TicketController(NAFSupportDBContext _DbContext)
        {
            Tickets = new TicketServices(_DbContext);
        }

        [HttpGet]
        [Route("/ticket")]
        public async Task<ActionResult<IEnumerable<Ticket>>> getTicket() {

            var res = await Tickets.getTicket();

            return res;
        }

        [HttpPost]
        [Route("/ticket")]
        public async Task<ActionResult<String>> addTicket(Ticket ticket)
        {
            var res = await Tickets.postTicket(ticket);

            if (res == null) return BadRequest("Can't add " + ticket.ticketId + " to the database");

            return Ok(res?.Value?.ticketId + " added successfull");
        }

        [HttpPut]
        [Route("/ticket")]
        public async Task<ActionResult<String>> updateTicket(Ticket ticket)
        {
            var res = await Tickets.putTicket(ticket);

            if (res == null) return BadRequest("Can't update "+ ticket.ticketId);

            return Ok(res.Value.ticketId + " updated successfully");
        } 

        [HttpDelete]
        [Route("/ticket")]
        public async Task<ActionResult<String>> deleteTicketWithTicketId(string ticketId)
        {
            var res = await Tickets.deleteTicket(ticketId);

            if (res == null) return BadRequest(ticketId + " not found");

            return Ok(res?.Value?.ticketId + " deleted successful");
        }

        [HttpDelete]
        [Route("/ticket/{ticketId}")]
        public async Task<ActionResult<String>> deleteTicketWithTicketIdFromRoute([FromRoute] string ticketId)
        {
            var res = await Tickets.deleteTicket(ticketId);

            if (res == null) return BadRequest(ticketId + " not found");

            return Ok(res?.Value?.ticketId + " deleted successful");
        }

        [HttpDelete]
        [Route("/ticket/{Id:int}")]
        public async Task<ActionResult<String>> deleteTicketWithIdFromRoute([FromRoute] int Id)
        {
            var res = await Tickets.deleteTicket(Id);

            if (res == null) return BadRequest(Id + " not found");

            return Ok(res?.Value?.ticketId + " deleted successful");
        } 
    }
}

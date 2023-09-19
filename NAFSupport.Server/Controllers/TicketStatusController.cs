using Microsoft.AspNetCore.Mvc;
using NAFSupport.Server.DataAccessLayer;
using NAFSupport.Server.Services;
using NAFSupport.Shared.Models;

namespace NAFSupport.Server.Controllers
{
        [ApiController]
    public class TicketStatusController : Controller
    {
            public readonly TicketStatusServices TicketStatus;
            public TicketStatusController(NAFSupportDBContext _DbContext)
            {
            TicketStatus = new TicketStatusServices(_DbContext);
            }

        [HttpGet]
        [Route("/ticketstatus")]
        public async Task<ActionResult<IEnumerable<TicketStatus>>> getTicketStatus()
        {

            var res = await TicketStatus.getAllTicketStatus();

            if (res == null) return BadRequest(res);
            return Ok(res);
        }

        [HttpGet]
        [Route("/ticketstatus/{Id:int}")]
        public async Task<ActionResult<IEnumerable<TicketStatus>>> getTicketStatusById([FromRoute] int Id)
        {

            var res = await TicketStatus.getTicketStatusWithId(Id);

            if (res == null) return BadRequest(res);
            return Ok(res);
        }

        [HttpPost]
        [Route("/ticketstatus")]
        public async Task<ActionResult<TicketStatus>> postTicketStatus(TicketStatus newTicketStatus)
        {

            var res = await TicketStatus.postTicketStatus(newTicketStatus);

            if (res == null) return BadRequest(res);
            return Ok(res);
        }

        [HttpPut]
        [Route("/ticketstatus")]
        public async Task<ActionResult<TicketStatus>> updateTicketStatus(TicketStatus newTicketStatus)
        {

            var res = await TicketStatus.putTicketStatus(newTicketStatus);

            if (res == null) return BadRequest(res);
            return Ok(res);
        }

        [HttpDelete]
        [Route("/ticketstatus")]
        public async Task<ActionResult<TicketStatus>> deleteTicketStatus(TicketStatus TicketStatusToBeDeleted)
        {

            var res = await TicketStatus.deleteTicketStatus(TicketStatusToBeDeleted);

            if (res == null) return BadRequest(res);
            return Ok(res);
        }
    }
}

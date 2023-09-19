using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NAFSupport.Server.DataAccessLayer;
using NAFSupport.Server.Services;
using NAFSupport.Shared.Models;

namespace NAFSupport.Server.Controllers
{
    [ApiController]
    public class RoleController:Controller
    {
        private readonly IUserService _employeeService;
        public RoleController(IUserService employeeService)
        {
            this._employeeService = employeeService;
        }

        [HttpGet]
        [Route("get/role")]
        public async Task<ActionResult> GetRoleDetails()
        {
            try
            {
                return Ok(await _employeeService.GetEmployeeRoles());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retreiving data from the database");
            }
        }

        [HttpPost]
        [Route("post/role")]
        public async Task<IActionResult> AddRoleDetails(Role rl)
        {
            try
            {
                if (rl == null)
                {
                    return BadRequest("Enter valid details");
                }
                return Ok(await _employeeService.AddEmployeeRoles(rl));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retreiving data from the database");
            }
        }
    }
}

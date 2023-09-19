using Microsoft.AspNetCore.Mvc;
using NAFSupport.Server.Services;
using NAFSupport.Shared.Models;

namespace NAFSupport.Server.Controllers
{
    [ApiController]
    public class DepartmentController:Controller
    {
        private readonly IUserService _employeeService;
        public DepartmentController(IUserService employeeService)
        {
            this._employeeService = employeeService;
        }
        [HttpGet]
        [Route("get/department")]
        public async Task<ActionResult> GetDepartmentDetails()
        {
            try
            {
                return Ok(await _employeeService.GetEmployeeDepartment());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retreiving data from the database");
            }
        }

        [HttpPost]
        [Route("post/department")]
        public async Task<IActionResult> AddDepartmentDetails(Department d)
        {
            try
            {
                if (d == null)
                {
                    return BadRequest("Enter valid details");
                }
                return Ok(await _employeeService.AddEmployeeDepartment(d));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retreiving data from the database");
            }
        }
    }
}

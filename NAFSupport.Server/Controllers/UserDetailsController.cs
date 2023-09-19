using Microsoft.AspNetCore.Mvc;
using NAFSupport.Server.Services;
using NAFSupport.Shared.Models;

namespace NAFSupport.Server.Controllers
{
    [ApiController]
    public class UserDetailsController:Controller
    {
        private readonly IUserService _employeeService;
        public UserDetailsController(IUserService employeeService)
        {
            this._employeeService = employeeService;
        }

        [HttpPost]
        [Route("post/users")]
        public async Task<IActionResult> AddUserDetails(InsertUserDetailsRequest ud)
        {
            try
            {
               if (ud == null)
               {
                    return BadRequest("Enter valid details");
               }
                return Ok(await _employeeService.AddUserDetails(ud));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retreiving data from the database");
            }
        }

        [HttpGet]
        [Route("get/users")]
        public async Task<ActionResult> GetUserDetails()
        {
            try
            {
                return Ok(await _employeeService.GetUserDetails());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retreiving data from the database");
            }
        }

        [HttpGet]
        [Route("get/users/{id:int}")]
        public async Task<ActionResult<UserDetails>> GetUsersById(int id)
        {
            try
            {
                var result = await _employeeService.GetUserDetailsById(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retreiving data from the database");
            }
        }

        [HttpDelete]
        [Route("deleteUsers/{id:int}")]
        public async Task<ActionResult<UserDetails>> DeleteUserDetails(int id)
        {
            try
            {
                var employeeToDelete = await _employeeService.GetUserDetailsById(id);
                if (employeeToDelete == null)
                {
                    return NotFound($"Employee with Id = {id} not found");
                }
                return await _employeeService.DeleteUser(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }

        [HttpPut]
        [Route("updateUsers/{id:int}")]
        public async Task<ActionResult<UserDetails>> UpdateUser(int id,UserDetails user)
        {
            try
            {
                if (id != user.id)
                {
                    return BadRequest("Employee ID mismatch");
                }
                var employeeToUpdate = await _employeeService.GetUserDetailsById(id);
                if (employeeToUpdate == null)
                {
                    return NotFound($"Employee with Id = {id} not found");
                }
                var updatedEmployee = await _employeeService.UpdateUser(user);
                if (updatedEmployee != null)
                {
                    return Ok(updatedEmployee);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }

        [HttpGet]
        [Route("api/getuser")]
        public async Task<IActionResult> GetUserByEmailAndPassword(string email, string password)
        {
            var user = await _employeeService.UserLogin(email, password);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

    }
}

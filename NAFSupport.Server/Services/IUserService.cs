using NAFSupport.Shared.Models;

namespace NAFSupport.Server.Services
{
    public interface IUserService
    {
            Task<Role> AddEmployeeRoles(Role rl);
            Task<IEnumerable<Role>> GetEmployeeRoles();
            Task<Department> AddEmployeeDepartment(Department d);
            Task<IEnumerable<Department>> GetEmployeeDepartment();
            Task<UserDetails> AddUserDetails(InsertUserDetailsRequest iur);
            Task<IEnumerable<UserDetails>> GetUserDetails();
            Task<UserDetails> GetUserDetailsById(int Id);
            Task<UserDetails> DeleteUser(int Id);
            Task<UserDetails> UpdateUser(UserDetails user);
           // Task<UserDetails> UserLogin(string email, UserDetails user);
            Task<UserDetails> UserLogin(string Email, string Password);
    }
}

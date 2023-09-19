using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NAFSupport.Server.DataAccessLayer;
using NAFSupport.Shared.Models;

namespace NAFSupport.Server.Services
{
    public class UserService:IUserService
    {
        public readonly NAFSupportDBContext dbContext;
        public UserService(NAFSupportDBContext dBContext)
        {
            this.dbContext = dBContext;
        }
        public async Task<Role> AddEmployeeRoles(Role rl)
        {
            var res = await dbContext.role.AddAsync(rl);
            await dbContext.SaveChangesAsync();
            return res.Entity;
        }
        public async Task<IEnumerable<Role>> GetEmployeeRoles()
        {
            return await dbContext.role.ToListAsync();
        }
        public async Task<Department> AddEmployeeDepartment(Department d)
        {
            var res = await dbContext.department.AddAsync(d);
            await dbContext.SaveChangesAsync();
            return res.Entity;
        }
        public async Task<IEnumerable<Department>> GetEmployeeDepartment()
        {
            return await dbContext.department.ToListAsync();
        }

        public async Task<UserDetails> AddUserDetails(InsertUserDetailsRequest iur)
        {
            int count = dbContext.userDetails.Count();
            var suffixnum = 1;
            if (count != 0)
            {
                var res = (from user in dbContext.userDetails orderby user.id descending select user).FirstOrDefault(); // sort by descending order based on id and selects the first row
                suffixnum = (int)(res.id + 1);
            }
            UserDetails ud = new UserDetails();

            var prefix = "NAF";
            int length = CountDigits(suffixnum);
            string suffix = ud.id.ToString().PadLeft(4 - length, '0');
            ud.userName = prefix + suffix + suffixnum;
            ud.name = iur.name;
            ud.email = iur.email;
            ud.password = iur.password; //encodePassword(iur.password);
            ud.department = iur.department;
            ud.role = iur.role;
            ud.roleId = dbContext.role.FirstOrDefault(x => x.roleName.Equals(iur.role)).roleId;
            ud.departmentRefId = dbContext.department.FirstOrDefault(x => x.departmentName.Equals(iur.department)).departmentRefId;
            //ud.departmentId = dbContext.department.FirstOrDefault(x => x.departmentName.Equals(iur.department)).departmentRefId;
            var result = await dbContext.userDetails.AddAsync(ud);
            await dbContext.SaveChangesAsync();

            return result.Entity;
        }
        public static int CountDigits(int number)
        {
            int count = 0;
            while (number > 0)
            {
                number = number / 10;
                count++;
            }
            return count;
        }
        public async Task<IEnumerable<UserDetails>> GetUserDetails()
        {
            return await dbContext.userDetails.ToListAsync();
        }
        public async Task<UserDetails> GetUserDetailsById(int Id)
        {
            return await dbContext.userDetails.FirstOrDefaultAsync(e => e.id == Id);
        }

        public async Task<UserDetails> DeleteUser(int Id)
        {
            var res = await dbContext.userDetails.FirstOrDefaultAsync(x => x.id == Id);
            if (res != null)
            {
                dbContext.userDetails.Remove(res);
                await dbContext.SaveChangesAsync();
                return res;
            }
            return null;
        }

        public async Task<UserDetails> UpdateUser(UserDetails user)
        {
            var result = await dbContext.userDetails.FirstOrDefaultAsync(e => e.id == user.id);
            if(result != null)
            {
                result.name = user.name;
                result.email = user.email;
                result.department = user.department;
                result.role = user.role;

                await dbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<UserDetails> UserLogin(string Email, string Password)
        {
            var user = await dbContext.userDetails.FirstOrDefaultAsync(e => e.email == Email);
            if (user == null)
            {
                return null;
            }
            if (user.password == Password)
            {
                return user;
            }
            return null;
        }
    }
}

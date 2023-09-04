using Microsoft.EntityFrameworkCore;
using NAFSupport.Shared.Models;

namespace NAFSupport.Server.DataAccessLayer
{
    public class NAFSupportDBContext : DbContext
    {
        public NAFSupportDBContext(DbContextOptions<NAFSupportDBContext> options) : base(options) { }
        public DbSet<Role> role { get; set; }

    }
}

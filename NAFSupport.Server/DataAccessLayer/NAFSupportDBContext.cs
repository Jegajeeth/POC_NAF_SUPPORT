using Microsoft.EntityFrameworkCore;
using NAFSupport.Shared.Models;

namespace NAFSupport.Server.DataAccessLayer
{
    public class NAFSupportDBContext : DbContext
    {
        public NAFSupportDBContext(DbContextOptions<NAFSupportDBContext> options) : base(options) { }
        public DbSet<Role> role { get; set; }

        public DbSet<Department> department { get; set; }
        public DbSet<UserDetails> userDetails { get; set; }
        public DbSet<Ticket> tickets { get; set; }
        public DbSet<TicketStatus> ticketStatus { get; set; }

    }
}

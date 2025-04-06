using Microsoft.EntityFrameworkCore;
using Stationery_Management_System.Models;

namespace Stationery_Management_System.db_context
{
    public class sqldb : DbContext
    {
        public sqldb(DbContextOptions<sqldb>options) : base(options)
        {


        }

        public DbSet<users> users { get; set; }

        public DbSet<Stationery> Stationeries { get; set; }
        public DbSet<Stationery_Management_System.Models.UserRoles> UserRoles { get; set; } = default!;
        public DbSet<Request> Requests { get; set; }

        public DbSet<Notification> Notifications { get; set; }



    }
}

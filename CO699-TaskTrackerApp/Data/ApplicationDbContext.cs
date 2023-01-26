using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CO699_TaskTrackerApp.Models;

namespace CO699_TaskTrackerApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CO699_TaskTrackerApp.Models.User> User { get; set; } = default!;
        public DbSet<CO699_TaskTrackerApp.Models.UserTask> UserTask { get; set; } = default!;
    }
}
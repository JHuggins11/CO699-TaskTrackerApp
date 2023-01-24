using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CO699_TaskTrackerApp.Models;

namespace CO699_TaskTrackerApp.Data
{
    public class TaskTrackerAppContext : DbContext
    {
        public TaskTrackerAppContext (DbContextOptions<TaskTrackerAppContext> options)
            : base(options)
        {
        }

        public DbSet<CO699_TaskTrackerApp.Models.User> User { get; set; } = default!;
    }
}

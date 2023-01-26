using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CO699_TaskTrackerApp.Data;
using CO699_TaskTrackerApp.Models;

namespace CO699_TaskTrackerApp.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly CO699_TaskTrackerApp.Data.ApplicationDbContext _context;

        public IndexModel(CO699_TaskTrackerApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.User != null)
            {
                User = await _context.User.ToListAsync();
            }
        }
    }
}

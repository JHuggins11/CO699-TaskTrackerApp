using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CO699_TaskTrackerApp.Data;
using CO699_TaskTrackerApp.Models;
using Microsoft.AspNetCore.Identity;

namespace CO699_TaskTrackerApp.Pages.UserTasks
{
    public class IndexModel : PageModel
    {
        private readonly CO699_TaskTrackerApp.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public IndexModel(CO699_TaskTrackerApp.Data.ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<UserTask> UserTask { get;set; } = default!;

        public async Task OnGetAsync()
        {
            // Only display tasks linked to the current user's ID
            var userTasks = from u in _context.UserTask
                            select u;
            var currentUserId = _userManager.GetUserId(User);

            if (_context.UserTask != null)
            {
                userTasks = userTasks.Where(u => u.UserID == currentUserId);
            }

            UserTask = await userTasks.ToListAsync();
        }
    }
}

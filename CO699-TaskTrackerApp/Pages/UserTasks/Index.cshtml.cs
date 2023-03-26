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

        public string DateSort { get; set; }
        public string PrioritySort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<UserTask> UserTasks { get;set; } = default!;

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            // Reference: https://learn.microsoft.com/en-gb/aspnet/core/data/ef-rp/sort-filter-page?view=aspnetcore-7.0
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            PrioritySort = sortOrder == "Priority" ? "priority_desc" : "Priority";

            CurrentFilter = searchString;
            IQueryable<UserTask> tasksIQ = from t in _context.UserTask
                                           select t;

            if (!String.IsNullOrEmpty(searchString))
            {
                tasksIQ = tasksIQ.Where(t => t.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "date_desc":
                    tasksIQ = tasksIQ.OrderByDescending(t => t.DueDate);
                    break;
                case "Priority":
                    tasksIQ = tasksIQ.OrderBy(t => t.Priority);
                    break;
                case "priority_desc":
                    tasksIQ = tasksIQ.OrderByDescending(t => t.Priority);
                    break;
                default:
                    tasksIQ = tasksIQ.OrderBy(t => t.DueDate);
                    break;
            }

            //// Only display tasks linked to the current user's ID
            //var userTasks = from u in _context.UserTask
            //                select u;
            //var currentUserId = _userManager.GetUserId(User);

            //if (_context.UserTask != null)
            //{
            //    userTasks = userTasks.Where(u => u.UserID == currentUserId);
            //}

            UserTasks = await tasksIQ.AsNoTracking().ToListAsync();
        }
    }
}

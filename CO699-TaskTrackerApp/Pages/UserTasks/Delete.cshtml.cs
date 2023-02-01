using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CO699_TaskTrackerApp.Data;
using CO699_TaskTrackerApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace CO699_TaskTrackerApp.Pages.UserTasks
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly CO699_TaskTrackerApp.Data.ApplicationDbContext _context;

        public DeleteModel(CO699_TaskTrackerApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public UserTask UserTask { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.UserTask == null)
            {
                return NotFound();
            }

            var usertask = await _context.UserTask.FirstOrDefaultAsync(m => m.Id == id);

            if (usertask == null)
            {
                return NotFound();
            }
            else 
            {
                UserTask = usertask;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.UserTask == null)
            {
                return NotFound();
            }
            var usertask = await _context.UserTask.FindAsync(id);

            if (usertask != null)
            {
                UserTask = usertask;
                _context.UserTask.Remove(UserTask);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

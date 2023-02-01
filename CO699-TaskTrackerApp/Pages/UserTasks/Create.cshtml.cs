using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CO699_TaskTrackerApp.Data;
using CO699_TaskTrackerApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace CO699_TaskTrackerApp.Pages.UserTasks
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly CO699_TaskTrackerApp.Data.ApplicationDbContext _context;

        public CreateModel(CO699_TaskTrackerApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["UserId"] = new SelectList(_context.User, "Id", "Email");
            return Page();
        }

        [BindProperty]
        public UserTask UserTask { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.UserTask == null || UserTask == null)
            {
                return Page();
            }

            _context.UserTask.Add(UserTask);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

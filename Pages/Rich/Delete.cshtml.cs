using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RichestHumansAlive.Models;

namespace Asp_Assignments.Pages.Rich
{
    public class DeleteModel : PageModel
    {
        private readonly RichestHumansAliveContext _context;

        public DeleteModel(RichestHumansAliveContext context)
        {
            _context = context;
        }

        [BindProperty]
      public RichHuman RichHuman { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.RichHuman == null)
            {
                return NotFound();
            }

            var richhuman = await _context.RichHuman.FirstOrDefaultAsync(m => m.ID == id);

            if (richhuman == null)
            {
                return NotFound();
            }
            else 
            {
                RichHuman = richhuman;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.RichHuman == null)
            {
                return NotFound();
            }
            var richhuman = await _context.RichHuman.FindAsync(id);

            if (richhuman != null)
            {
                RichHuman = richhuman;
                _context.RichHuman.Remove(RichHuman);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

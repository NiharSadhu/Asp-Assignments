using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RichestHumansAlive.Models;

namespace Asp_Assignments.Pages.Rich
{
    public class EditModel : PageModel
    {
        private readonly RichestHumansAliveContext _context;

        public EditModel(RichestHumansAliveContext context)
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

            var richhuman =  await _context.RichHuman.FirstOrDefaultAsync(m => m.ID == id);
            if (richhuman == null)
            {
                return NotFound();
            }
            RichHuman = richhuman;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(RichHuman).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RichHumanExists(RichHuman.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RichHumanExists(int id)
        {
          return (_context.RichHuman?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}

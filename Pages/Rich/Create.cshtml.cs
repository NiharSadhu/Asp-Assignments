using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RichestHumansAlive.Models;

namespace Asp_Assignments.Pages.Rich
{
    public class CreateModel : PageModel
    {
        private readonly RichestHumansAliveContext _context;

        public CreateModel(RichestHumansAliveContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public RichHuman RichHuman { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.RichHuman == null || RichHuman == null)
            {
                return Page();
            }

            _context.RichHuman.Add(RichHuman);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

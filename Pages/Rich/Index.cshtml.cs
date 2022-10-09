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
    public class IndexModel : PageModel
    {
        private readonly RichestHumansAliveContext _context;

        public IndexModel(RichestHumansAliveContext context)
        {
            _context = context;
        }

        public IList<RichHuman> RichHuman { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.RichHuman != null)
            {
                RichHuman = await _context.RichHuman.ToListAsync();
            }
        }
    }
}

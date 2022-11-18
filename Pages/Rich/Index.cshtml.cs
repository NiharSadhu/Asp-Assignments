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
    public class IndexModel : PageModel
    {
        private readonly RichestHumansAliveContext _context;

        public IndexModel(RichestHumansAliveContext context)
        {
            _context = context;
        }

        public IList<RichHuman> RichHuman { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string ? SearchString { get; set; }
        public SelectList ? Name { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ? RichHumanName { get; set; }

        
        
        public SelectList ? TheirExpertise { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ? RichHumanTheirExpertise { get; set; }

         public SelectList ? Gender { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ? RichHumanGender { get; set; }

        public async Task OnGetAsync()
        {
             var richHumans = from m in _context.RichHuman  select m;




            if (!string.IsNullOrEmpty(SearchString))
            {
                 richHumans = richHumans.Where(s => s.Name.Contains(SearchString)); 
                 
            }

            if (!string.IsNullOrEmpty(RichHumanTheirExpertise))
             {
            richHumans = richHumans.Where(x => x.TheirExpertise.Contains(RichHumanTheirExpertise));
             }

             if (!string.IsNullOrEmpty(RichHumanGender))
             {
            richHumans = richHumans.Where(y => y.Gender.Contains(RichHumanGender));
             }

                RichHuman = await richHumans.ToListAsync();
                TheirExpertise = new(await richHumans.ToListAsync());
                Gender = new(await richHumans.ToListAsync());
        }
    }
}

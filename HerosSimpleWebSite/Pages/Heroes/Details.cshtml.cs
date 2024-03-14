using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Heros.Database;

namespace Heros.Pages.Heroes
{
    public class DetailsModel : PageModel
    {
        private readonly Heros.Database.HeroDbContext _context;

        public DetailsModel(Heros.Database.HeroDbContext context)
        {
            _context = context;
        }

        public Hero Hero { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hero = await _context.Heroes.FirstOrDefaultAsync(m => m.Id == id);
            if (hero == null)
            {
                return NotFound();
            }
            else
            {
                Hero = hero;
            }
            return Page();
        }
    }
}

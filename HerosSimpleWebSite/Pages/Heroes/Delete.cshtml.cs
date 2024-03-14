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
    public class DeleteModel : PageModel
    {
        private readonly Heros.Database.HeroDbContext _context;

        public DeleteModel(Heros.Database.HeroDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hero = await _context.Heroes.FindAsync(id);
            if (hero != null)
            {
                Hero = hero;
                _context.Heroes.Remove(Hero);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

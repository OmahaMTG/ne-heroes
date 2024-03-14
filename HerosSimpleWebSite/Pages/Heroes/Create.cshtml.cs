using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Heros.Database;

namespace Heros.Pages.Heroes
{
    public class CreateModel : PageModel
    {
        private readonly Heros.Database.HeroDbContext _context;

        public CreateModel(Heros.Database.HeroDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Hero Hero { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Heroes.Add(Hero);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

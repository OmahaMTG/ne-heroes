using System.Collections;
using Heros.Database;
using Heros.Pages.Stats;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mono.TextTemplating;

namespace Heros.Pages.Counties
{
    public class IndexModel(HeroDbContext context) : PageModel
    {
        public IEnumerable<(string? State, string? County)>? StatesAndCounties { get; set; }

        public void OnGet()
        {
            StatesAndCounties = context.Heroes
                .Where(h => !h.Deleted)
                .GroupBy(h => new { h.OriginState, h.OriginCounty })
                .Select(sc => new { State = sc.Key.OriginState, County = sc.Key.OriginCounty })
                .OrderBy(h => h.State)
                .ThenBy(h => h.County)
                .ToList()
                .Select(h => (State: h.State, County: h.County ));
        }
    }
}

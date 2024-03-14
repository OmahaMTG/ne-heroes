using Heros.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Heros.Pages.Stats
{
    public class IndexModel : PageModel
    {
        private readonly HeroDbContext _dbContext;

        public IndexModel(HeroDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet()
        {
            Counties = _dbContext
                .Heroes
                .Where(h => !h.Deleted)
                .GroupBy(h => new {County = h.OriginCounty, State = h.OriginState})
                .Select(g => new County
                {
                    Name = string.IsNullOrWhiteSpace(g.Key.County) ? "Unknown" : g.Key.County,
                    State = g.Key.State,
                    HeroCount = g.Count()
                })
                .OrderByDescending(c => c.HeroCount)
                .ToList();
        }

        public IEnumerable<County> Counties { get; set; }


    }

    public class CountyStats
    {
        public List<County> Counties { get; set; } = new List<County>();
    }

    public class County
    {
        public string? Name { get; set; }
        public string? State { get; set; }
        public int HeroCount { get; set; }
    }
}

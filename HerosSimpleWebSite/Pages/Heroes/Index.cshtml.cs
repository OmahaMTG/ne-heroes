using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Heros.Database;
using System.Globalization;
using CsvHelper;

namespace Heros.Pages.Heroes
{
    public class IndexModel(HeroDbContext context) : PageModel
    {
        public IList<Hero> Hero { get; set; } = default!;
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string? CurrentCounty { get; set; }
        public string? CurrentState { get; set; }

        public async Task OnGetAsync()
        {
            CurrentCounty = Request.Query["county"].ToString();
            CurrentState = Request.Query["state"].ToString();
            int.TryParse(Request.Query["p"].ToString(), out int pageNumber);
            CurrentPage = pageNumber == 0 ? 1 : pageNumber;


            IQueryable<Hero> heroes = context.Heroes.Where(h => !h.Deleted).OrderBy(h => h.LastName);
            if (!string.IsNullOrWhiteSpace(CurrentCounty))
            {
                if(!string.IsNullOrWhiteSpace(CurrentState))
                    heroes = heroes.Where(h => h.OriginCountyName == CurrentCounty && h.OriginState == CurrentState);
                else
                    heroes = heroes.Where(h => h.OriginCountyName == CurrentCounty);
            }

            TotalPages = (heroes.Count() / 100) + 1;
            heroes = heroes.Skip((CurrentPage - 1) * 100).Take(100);
            if (heroes.Any())
            {
                Hero = await heroes.ToListAsync();
            }
            else
            {
                CurrentPage--;
                if (CurrentPage < 1)
                    CurrentPage = 1;

                Hero = await heroes.Skip((CurrentPage - 1) * 100).Take(100).ToListAsync();
            }
        }

        public FileResult OnGetExport(string state, string county)
        {
            var query = context
                .Heroes
                .Where(h => (!h.Deleted));
            if(!string.IsNullOrWhiteSpace(county))
            {
                query = query.Where(h => h.OriginCountyName == county);
            }
            if (!string.IsNullOrWhiteSpace(state))
            {
                query = query.Where(h => h.OriginState == state);
            }
            var heroes = query.ToList()
                .Select(h => new
                {
                    Id = h.Id,
                    OriginCounty = h.OriginCounty,
                    TreeSite = h.TreeSite,
                    Rank = h.Rank,
                    FirstName = h.FirstName,
                    MiddleName = h.MiddleName,
                    LastName = h.LastName,
                    War = h.War,
                    MilitaryBranch = h.MilitaryBranch,
                    FirstResponderType = h.FirstResponderType,
                    BirthDate = h.BirthDate?.ToString("d"),
                    DateOfDeath = h.DateOfDeath?.ToString("d"),
                    CauseOfDeath = h.CauseOfDeath,
                    LocationOfDeath = h.LocationOfDeath,
                    OriginCity = h.OriginCity,
                    OriginState = h.OriginState,
                    FlagStatus = h.FlagStatus,
                    FlagReceiveStatus = h.FlagReceiveStatus,
                    FlagReceivedDate = h.FlagReceivedDate,
                    FlagSponsor = h.FlagSponsor,
                    OriginLocation = h.OriginLocation,
                    TreeLatitude = h.TreeLatitude,
                    TreeLongitude = h.TreeLongitude,
                    Notes = h.Notes
                }).ToList();
            //Convert heroes to CSV
            //var properties = heroes.GetType().GetGenericArguments().First().GetProperties();
            //var csvString = new StringBuilder();
            //csvString.AppendLine(properties.Select(p => p.Name).Aggregate((p1, p2) => $"{p1},{p2}"));

            using var writer = new StringWriter();
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords((IEnumerable)heroes);
            return File(Encoding.UTF8.GetBytes(writer.ToString()), "text/csv", $"{county}.csv");
        }
    }
}

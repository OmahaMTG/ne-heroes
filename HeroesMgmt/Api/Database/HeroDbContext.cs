using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Heros.Database
{
    public class HeroDbContext : DbContext
    {
        public HeroDbContext(DbContextOptions<HeroDbContext> options) : base(options)
        {

        }

        public DbSet<Hero> Heroes { get; set; }
    }

    public class Hero
    {
        public int Id { get; set; }
        public string? War { get; set; }
        public string? Specialization { get; set; }
        public string? Group { get; set; }
        public string? Name { get; set; }
        public string? Nickname { get; set; }
        public string? Prefix { get; set; }
        public string? Suffix { get; set; }
        public string? HeroType { get; set; }
        public string? FlagStatus { get; set; }
        public string? FlagReceiveStatus { get; set; }
        public string? FlagReceivedDate { get; set; }
        public string? FlagSponsor { get; set; }
        public string? MilitaryBranch { get; set; }
        public string? FirstResponderType { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? BirthDate { get; set; }
        public string? BirthMonth { get; set; }
        public string? BirthDay { get; set; }
        public string? BirthYear { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Rank { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? DateOfDeath { get; set; }
        public string? DateOfDeathString { get; set; }
        public string? TreeSite { get; set; }
        public string? TreeStatus { get; set; }
        public string? TreeLatitude { get; set; }
        public string? TreeLongitude { get; set; }
        public string? CauseOfDeath { get; set; }
        public string? LocationOfDeath { get; set; }
        public string? OriginCity { get; set; }
        public string? OriginCounty { get; set; }
        public string? OriginState { get; set; }
        public string? OriginLocation { get; set; }
        public string? OriginRegionCode { get; set; }
        public string? OriginRegionName { get; set; }
        public string? OriginDivisionCode { get; set; }
        public string? OriginDivisionName { get; set; }
        public string? OriginStateFipsCode { get; set; }
        public string? OriginStateName { get; set; }
        public string? CountyCodeFips { get; set; }
        public string? OriginCountyName { get; set; }
        public string? Notes { get; set; }
        public bool Deleted { get; set; }



    }
}

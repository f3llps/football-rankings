using System;

namespace Way2.FootballRankings.Business.Models
{
    public class Competition
    {
        public int Id { get; set; }
        public Area area { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string EmblemUrl { get; set; }
        public string Plan { get; set; }
        public CurrentSeason CurrentSeason { get; set; }
        public int NumberOfAvailableSeasons { get; set; }
        public DateTime LastUpdated { get; set; }
   }
}

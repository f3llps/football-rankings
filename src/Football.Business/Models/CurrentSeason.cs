using System;

namespace FootballRankings.Business.Models
{
    public class CurrentSeason
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? CurrentMatchDay { get; set; }
        public Winner Winner { get; set; }
    }
}

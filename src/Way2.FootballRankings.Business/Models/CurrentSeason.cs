using System;

namespace Way2.FootballRankings.Business.Models
{
    class CurrentSeason
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CurrentMatchDay { get; set; }
        public string Winner { get; set; }
    }
}

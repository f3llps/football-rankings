using System.Collections.Generic;
using Way2.FootballRankings.Business.Models;

namespace Way2.FootballRankings.Api.ViewModels
{
    public class CompetitionStandingsViewModel
    {
        public string Stage { get; set; }
        public string Total { get; set; }
        public string Group { get; set; }
        public List<TeamStandings> Table { get; set; } = new List<TeamStandings>();
    }
}

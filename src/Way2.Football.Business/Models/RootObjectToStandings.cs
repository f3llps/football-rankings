using System.Collections.Generic;

namespace Way2.FootballRankings.Business.Models
{
    public class RootObjectToStandings
    {
        public Competition Competition { get; set; }
        public CurrentSeason Season { get; set; }
        public List<CompetitionStandings> Standings { get; set; } = new List<CompetitionStandings>();
    }
}

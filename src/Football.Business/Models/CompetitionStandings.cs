using System.Collections.Generic;

namespace FootballRankings.Business.Models
{
    public class CompetitionStandings
    {
        public string Stage { get; set; }
        public string Type { get; set; }
        public string Group { get; set; }
        public List<TeamStandings> Table { get; set; } = new List<TeamStandings>();
    }
}

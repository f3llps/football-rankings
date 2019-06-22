using System.Collections.Generic;

namespace FootballRankings.Api.ViewModels
{
    public class StandingsViewModel
    {
        public List<CompetitionStandingsViewModel> Standings { get; set; } = new List<CompetitionStandingsViewModel>();
    }
}

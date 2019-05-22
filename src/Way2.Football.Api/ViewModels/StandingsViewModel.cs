using System.Collections.Generic;

namespace Way2.FootballRankings.Api.ViewModels
{
    public class StandingsViewModel
    {
        public List<CompetitionStandingsViewModel> Standings { get; set; } = new List<CompetitionStandingsViewModel>();
    }
}

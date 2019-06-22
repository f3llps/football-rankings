using System.Collections.Generic;
using Football.Api.ViewModels;

namespace FootballRankings.Api.ViewModels
{
    public class CompetitionStandingsViewModel
    {
        public List<TeamStandingsViewModel> Table { get; set; } = new List<TeamStandingsViewModel>();
    }
}

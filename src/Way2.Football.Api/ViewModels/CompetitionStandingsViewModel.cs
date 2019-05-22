using System.Collections.Generic;
using Way2.Football.Api.ViewModels;

namespace Way2.FootballRankings.Api.ViewModels
{
    public class CompetitionStandingsViewModel
    {
        public List<TeamStandingsViewModel> Table { get; set; } = new List<TeamStandingsViewModel>();
    }
}

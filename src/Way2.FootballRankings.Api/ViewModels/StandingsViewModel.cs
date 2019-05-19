﻿using System.Collections.Generic;
using Way2.FootballRankings.Business.Models;

namespace Way2.FootballRankings.Api.ViewModels
{
    public class StandingsViewModel
    {
        public Competition Competition { get; set; }
        public CurrentSeason Season { get; set; }
        public List<CompetitionStandings> Standings { get; set; } = new List<CompetitionStandings>();
    }
}

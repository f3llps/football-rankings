using AutoMapper;
using Way2.FootballRankings.Api.ViewModels;
using Way2.FootballRankings.Business.Models;

namespace Way2.FootballRankings.Api.Configurations
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Competition, CompetitionViewModel>().ReverseMap();
            CreateMap<TeamStandings, TeamStandingsViewModel>().ReverseMap();
            CreateMap<Area, AreaViewModel>().ReverseMap();
            CreateMap<Standings, StandingsViewModel>().ReverseMap();
            CreateMap<TeamStandings, TeamStandingsViewModel>().ReverseMap();
        }
    }
}

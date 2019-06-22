using AutoMapper;
using FootballRankings.Api.ViewModels;
using FootballRankings.Business.Models;

namespace FootballRankings.Api.Configurations
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Competition, CompetitionViewModel>().ReverseMap();
            CreateMap<Area, AreaViewModel>().ReverseMap();
            CreateMap<RootObjectToStandings, StandingsViewModel>().ReverseMap();
        }
    }
}

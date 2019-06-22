namespace FootballRankings.Infra.Interfaces
{
    interface IFootballDataService
    {
        Task<IEnumerable<CompetitionDto>> GetCompetitions();
    }
}

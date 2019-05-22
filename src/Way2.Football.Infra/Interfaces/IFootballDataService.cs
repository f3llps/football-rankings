namespace Way2.FootballRankings.Infra.Interfaces
{
    interface IFootballDataService
    {
        Task<IEnumerable<CompetitionDto>> GetCompetitions();

    }
}

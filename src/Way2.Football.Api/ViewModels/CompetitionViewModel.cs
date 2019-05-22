using System.ComponentModel.DataAnnotations;

namespace Way2.FootballRankings.Api.ViewModels
{
    public class CompetitionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AreaViewModel Area { get; set; }
    }
}

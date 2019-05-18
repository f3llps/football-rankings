using System.ComponentModel.DataAnnotations;

namespace Way2.FootballRankings.Api.ViewModels
{
    public class CompetitionViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastUpdated { get; set; }
    }
}

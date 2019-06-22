using System.Collections.Generic;

namespace FootballRankings.Business.Models
{
    public class RootObjectToCompetitions
    {
        public List<Competition> competitions { get; set; } = new List<Competition>();
    }
}

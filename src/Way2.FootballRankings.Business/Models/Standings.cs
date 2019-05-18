using System.Collections.Generic;

namespace Way2.FootballRankings.Business.Models
{




    class Standings
    {
        public string Stage { get; set; }
        public string Total { get; set; }
        public string Group { get; set; }
        public List<TeamClassification> Table { get; set; }
    }
}

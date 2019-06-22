
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FootballRankings.Business.Interfaces;
using FootballRankings.Business.Models;

namespace FootballRankings.Business.Services
{
    public class FootballDataService : IFootballDataService
    {
        private const string URL = "https://api.football-data.org/v2";
        private const string COMPETITION_PARAM = "/competitions";
        private const string STANDINGS_PARAM = "/standings";

        private IConfiguration Configuration { get; set; }
        private static readonly HttpClient client = new HttpClient();

        public FootballDataService(){}

        public FootballDataService(IConfiguration configuration)
        {
            if (!client.DefaultRequestHeaders.Any())
                client.DefaultRequestHeaders.Add("X-Auth-Token", configuration["Tokens:FootballDataServiceToken"]);
        }

        public async Task<IEnumerable<Competition>> ObterTodasCompeticoes()
        {
            const string FILTER = "?plan=TIER_ONE";

            var response = await client.GetAsync($"{URL}{COMPETITION_PARAM}{FILTER}");
            var listOfCompetitons = new RootObjectToCompetitions();
            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                listOfCompetitons = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObjectToCompetitions>(jsonString);
            }

            return listOfCompetitons.competitions;
        }

        public async Task<RootObjectToStandings> ObterClassificacaoPorCompeticao(int competicaoId)
        {
            const string FILTER = "?standingType=TOTAL";

            var response = await client.GetAsync($"{URL}{COMPETITION_PARAM}/{competicaoId.ToString()}{STANDINGS_PARAM}{FILTER}");
            var standings = new RootObjectToStandings();
            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                standings = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObjectToStandings>(jsonString);
            }

            return standings;
        }
    }
}

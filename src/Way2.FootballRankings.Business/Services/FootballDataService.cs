
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Way2.FootballRankings.Business.Interfaces;
using Way2.FootballRankings.Business.Models;

namespace Way2.FootballRankings.Business.Services
{
    public class FootballDataService : IFootballDataService
    {
        private const string URL = "https://api.football-data.org/v2";
        private const string COMPETITION_PARAM = "/competitions";
        private const string STANDINGS_PARAM = "/standings";

        private IConfiguration Configuration { get; set; }
        private HttpClient client = new HttpClient();

        public FootballDataService(IConfiguration configuration)
        {
            client.DefaultRequestHeaders.Add("X-Auth-Token", configuration["Tokens:FootballDataServiceToken"]);
        }

        public async Task<Standings> ObterClassificacaoPorCompeticao(int competicaoId)
        {
            const string FILTER = "?standingType=TOTAL";

            var response = await client.GetAsync($"{URL}{COMPETITION_PARAM}/{competicaoId.ToString()}{STANDINGS_PARAM}{FILTER}");
            var standings = new Standings();
            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                standings = Newtonsoft.Json.JsonConvert.DeserializeObject<Standings>(jsonString);
            }

            return standings;
        }

        public async Task<Competition> ObterCompeticaoPorId(int competicaoId)
        {
            const string FILTER = "?id=";

            var response = await client.GetAsync($"{URL}{COMPETITION_PARAM}{FILTER}{competicaoId.ToString()}");
            var competition = new Competition();
            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                competition = Newtonsoft.Json.JsonConvert.DeserializeObject<Competition>(jsonString);
            }

            return competition;
        }

        public async Task<IEnumerable<Competition>> ObterTodasCompeticoes()
        {
            var response = await client.GetAsync($"{URL}{COMPETITION_PARAM}");
            var listOfCompetitons = new ListOfCompetitions();
            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                listOfCompetitons = Newtonsoft.Json.JsonConvert.DeserializeObject<ListOfCompetitions>(jsonString);
            }

            return listOfCompetitons.competitions;
        }
    }
}

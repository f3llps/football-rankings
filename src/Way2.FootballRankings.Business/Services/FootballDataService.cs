
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

        public async Task<Standings> ObterClassificacaoPorCompeticao(int competicaoId)
        {
            const string PARAM = "/competitions/";
            const string PARAM2 = "/standings";
            const string FILTER = "?standingType=TOTAL";

            var client = new HttpClient();
            var response = await client.GetAsync($"{URL}{PARAM}{competicaoId.ToString()}{PARAM2}{FILTER}");
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
            const string PARAM = "/competitions";
            const string FILTER = "?id=";

            var client = new HttpClient();
            var response = await client.GetAsync($"{URL}{PARAM}{FILTER}{competicaoId.ToString()}");
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
            const string PARAM = "/competitions";

            var client = new HttpClient();
            var response = await client.GetAsync($"{URL}{PARAM}");
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

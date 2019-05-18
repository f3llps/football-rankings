
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
        private const string URL = "https://api.football-data.org/v2/competitions";

        async Task<IEnumerable<Competition>> IFootballDataService.ObterTodasCompeticoes()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(URL);
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

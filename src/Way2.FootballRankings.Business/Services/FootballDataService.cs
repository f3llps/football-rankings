using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Way2.FootballRankings.Business.Interfaces;

namespace Way2.FootballRankings.Business.Services
{
    public class FootballDataService : IFootballDataService
    {
        public async Task<HttpResponseMessage> ObterTodasCompeticoesAsync()
        {
            var response =  new HttpClient();

            return await response.GetAsync("https://api.football-data.org/v2/competitions"); 
        }
    }
}

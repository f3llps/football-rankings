using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Way2.FootballRankings.Business.Models;

namespace Way2.FootballRankings.Business.Interfaces
{
    public interface IFootballDataService
    {
         Task<HttpResponseMessage>  ObterTodasCompeticoesAsync();
    }
}

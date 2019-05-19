using System.Collections.Generic;
using System.Threading.Tasks;
using Way2.FootballRankings.Business.Models;

namespace Way2.FootballRankings.Business.Interfaces
{
    public interface IFootballDataService
    {
        Task<IEnumerable<Competition>> ObterTodasCompeticoes();
        Task<Competition> ObterCompeticaoPorId(int competicaoId);
        Task<RootObjectToStandings> ObterClassificacaoPorCompeticao(int competicaoId);
    }
}

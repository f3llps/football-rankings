using System.Collections.Generic;
using System.Threading.Tasks;
using FootballRankings.Business.Models;

namespace FootballRankings.Business.Interfaces
{
    public interface IFootballDataService
    {
        Task<IEnumerable<Competition>> ObterTodasCompeticoes();
        //Task<Competition> ObterCompeticaoPorId(int competicaoId);
        Task<RootObjectToStandings> ObterClassificacaoPorCompeticao(int competicaoId);
    }
}

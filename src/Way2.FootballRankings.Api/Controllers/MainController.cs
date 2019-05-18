using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Way2.FootballRankings.Api.ViewModels;
using Way2.FootballRankings.Business.Interfaces;

namespace Way2.FootballRankings.Api.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {

    }

    [Route("api/competitions")]
    public class CompetitionController : MainController
    {
        private readonly IFootballDataService _footballDataService;

        CompetitionController(IFootballDataService footballDataService)
        {
            _footballDataService = footballDataService;
        }

        public async Task<ActionResult<IEnumerable<CompetitionViewModel>>> ObterTodasCompeticoes()
        {
            var competicoes = await _footballDataService.ObterTodasCompeticoesAsync();

            return Ok(competicoes);
        }
    }
}

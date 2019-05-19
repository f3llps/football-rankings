using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Way2.FootballRankings.Api.ViewModels;
using Way2.FootballRankings.Business.Interfaces;

namespace Way2.FootballRankings.Api.Controllers
{
    [Route("api/competitions")]
    public class CompetitionController : MainController
    {
        private readonly IFootballDataService _footballDataService;
        private readonly IMapper _mapper;

        public CompetitionController(IFootballDataService footballDataService, IMapper mapper)
        {
            _footballDataService = footballDataService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompetitionViewModel>>> ObterTodasCompeticoes()
        {
            var competicoes = _mapper.Map<IEnumerable<CompetitionViewModel>>(await _footballDataService.ObterTodasCompeticoes());

            if (competicoes == null)
                return BadRequest();

            return Ok(competicoes);
        }

        [HttpGet("{competicaoId:int}")]
        public async Task<ActionResult<CompetitionViewModel>> ObterCompeticaoPorId(int competicaoId)
        {
            var competicao = _mapper.Map<CompetitionViewModel>(await _footballDataService.ObterCompeticaoPorId(competicaoId));

            if (competicao == null)
                return NotFound();

            return Ok(competicao);
        }

        [HttpGet("{competicaoId:int}")]
        public async Task<ActionResult<CompetitionViewModel>> ObterClassificacaoPorCompeticao(int competicaoId)
        {
            var classificacao = _mapper.Map<CompetitionViewModel>(await _footballDataService.ObterClassificacaoPorCompeticao(competicaoId));

            if (classificacao == null)
                return NotFound();

            return Ok(classificacao);
        }

    }
}
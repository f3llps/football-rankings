﻿using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using FootballRankings.Api.ViewModels;
using FootballRankings.Business.Interfaces;

namespace FootballRankings.Api.Controllers
{
    public class StandingsController : MainController
    {
        private readonly IFootballDataService _footballDataService;
        private readonly IMapper _mapper;

        public StandingsController(IFootballDataService footballDataService, IMapper mapper)
        {
            _footballDataService = footballDataService;
            _mapper = mapper;
        }

        [HttpGet("obter-classificacao-por-competicao/{competicaoId:int}")]
        public async Task<ActionResult<StandingsViewModel>> ObterClassificacaoPorCompeticao(int competicaoId)
        {
            var classificacao = _mapper.Map<StandingsViewModel>(await _footballDataService.ObterClassificacaoPorCompeticao(competicaoId));

            if (classificacao == null)
                return NotFound();

            return Ok(classificacao.Standings[0].Table);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using FootballRankings.Api.ViewModels;
using FootballRankings.Business.Interfaces;

namespace FootballRankings.Api.Controllers
{
    public class CompetitionController : MainController
    {
        private readonly IFootballDataService _footballDataService;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public CompetitionController(IFootballDataService footballDataService, IMapper mapper, IMemoryCache memoryCache)
        {
            _footballDataService = footballDataService;
            _mapper = mapper;
            _cache = memoryCache;
        }

        [HttpGet]
        [EnableCors("Development")]
        public async Task<ActionResult<IEnumerable<CompetitionViewModel>>> ObterTodasCompeticoes()
        {
            // 5 Minutos de cache
            var tempoLimiteCache = TimeSpan.FromSeconds(60*5);
            if (!_cache.TryGetValue("ObterTodasCompeticoes", out IEnumerable<CompetitionViewModel> competicoes))
            {
                competicoes = _mapper.Map<IEnumerable<CompetitionViewModel>>(await _footballDataService.ObterTodasCompeticoes());

                if (competicoes == null)
                    return BadRequest();

                _cache.Set("ObterTodasCompeticoes", competicoes, tempoLimiteCache);
            }

            return Ok(competicoes);
        }
    }
}
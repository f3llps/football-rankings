using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
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

        public async Task<ActionResult<IEnumerable<CompetitionViewModel>>> ObterTodasCompeticoes()
        {
            var competicoes = _mapper.Map<IEnumerable<CompetitionViewModel>>(await _footballDataService.ObterTodasCompeticoes());

            return Ok(competicoes);
        }
    }
}
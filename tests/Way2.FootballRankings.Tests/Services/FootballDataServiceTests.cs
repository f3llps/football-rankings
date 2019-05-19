using FluentAssertions;
using System.Threading.Tasks;
using Way2.FootballRankings.Business.Services;
using Xunit;

namespace Way2.FootballRankings.Tests.Services
{
    public class FootballDataServiceTests
    {
        private readonly FootballDataService _footballDataService;

        public FootballDataServiceTests()
        {
            _footballDataService = new FootballDataService();
        }

        [Fact]
        public async Task ObterTodasCompeticoes_DeveriaRetornarAoMenosUmaCompeticao()
        {
            var result = await _footballDataService.ObterTodasCompeticoes();
            result.Should().NotBeNull("Todo ano existem competições previstas.")
                .And.HaveCountGreaterThan(1, "Em condições mínimas extremas deve existir pelo menos 1 competição ao ano.");
        }

        [Theory]
        [InlineData(2013)] //Serie A
        [InlineData(2021)] //Premier League
        public async Task ObterClassificacaoPorCompeticao_DeveriaRetornarExatamenteUmaClassificacao(int competicaoId)
        {
            var result = await _footballDataService.ObterClassificacaoPorCompeticao(competicaoId);
            result.Should().NotBeNull("O id obrigatoriamente deve existir");
        }

        [Theory]
        [InlineData(2013)] //Serie A
        [InlineData(2021)] //Premier League
        public async Task ObterCompeticaoPorId_DeveriaRetornarExatamenteUmaCompeticao(int competicaoId)
        {
            var result = await _footballDataService.ObterCompeticaoPorId(competicaoId);
            result.Should().NotBeNull("O id obrigatoriamente deve existir");
        }
    }
}

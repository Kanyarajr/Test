using Microsoft.EntityFrameworkCore;
using SportScore.API.Controllers.Sports.Database;
using SportScore.API.Controllers.Sports.Database.Repositories;
using SportScore.API.Controllers.Sports.Service;
using SportsScorePredictor.Game;
using Xunit;

namespace SportsScore.Tests
{
    public class MatchResultServiceTests
    {
        private readonly IMatchResultService _service;
        private readonly MatchResultContext _context;

        public MatchResultServiceTests()
        {
            var options = new DbContextOptionsBuilder<MatchResultContext>()
                .UseInMemoryDatabase(databaseName: "MatchTestDb")
                .Options;
            _context = new MatchResultContext(options);
            var repository = new MatchResultRepository(_context);
            _service = new MatchResultService(repository);
        }

        [Fact]
        public async Task CheckAndSaveResultAsync_ShouldSaveResult()
        {
            var result = await _service.CheckAndSaveResultAsync("Ravens", "Badgers", "Volleyball", "1001010101111011101111,0110101010000100010000,1001010101111011101111", "Some input");
            Assert.NotNull(result);
            Assert.Equal("Ravens", result.Team1);
        }

        [Fact]
        public async Task GetMatchResultByIdAsync_ShouldReturnResult()
        {
            var savedResult = await _service.CheckAndSaveResultAsync("Ravens", "Badgers", "Squash", "00000000011111111100,00000000001111111111,00000000011111111111", "Some input");
            var retrievedResult = await _service.GetMatchResultByIdAsync(savedResult.Id);
            Assert.NotNull(retrievedResult);
            Assert.Equal(savedResult.Id, retrievedResult.Id);
        }

        [Fact]
        public async Task DeleteMatchResultByIdAsync_ShouldDeleteResult()
        {
            var savedResult = await _service.CheckAndSaveResultAsync("Ravens", "Badgers", "Volleyball", "1001010101111011101111,0110101010000100010000,1001010101111011101111", "Some input");
            var deleteResult = await _service.DeleteMatchResultByIdAsync(savedResult.Id);
            Assert.True(deleteResult);

            var retrievedResult = await _service.GetMatchResultByIdAsync(savedResult.Id);
            Assert.Null(retrievedResult);
        }
    }
}
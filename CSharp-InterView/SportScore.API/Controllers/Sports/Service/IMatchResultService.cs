using SportScore.API.Controllers.Sports.DataModel;

namespace SportScore.API.Controllers.Sports.Service;

public interface IMatchResultService
{
    Task<MatchResult> CheckAndSaveResultAsync(string team1, string team2, string sport, string score, string inputString);

    IEnumerable<MatchResult> ListAllMatchesAsync();

    Task<MatchResult> GetMatchResultByIdAsync(Guid id);

    Task<bool> DeleteMatchResultByIdAsync(Guid id);
}

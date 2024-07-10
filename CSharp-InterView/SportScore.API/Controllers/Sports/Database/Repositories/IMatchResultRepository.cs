using SportScore.API.Controllers.Sports.DataModel;

namespace SportScore.API.Controllers.Sports.Database.Repositories;

public interface IMatchResultRepository
{
    Task<MatchResult> AddAsync(MatchResult matchResult);
    IEnumerable<MatchResult> GetAllAsync();
    Task<MatchResult> GetByIdAsync(Guid id);
    Task<bool> DeleteAsync(Guid id);
}

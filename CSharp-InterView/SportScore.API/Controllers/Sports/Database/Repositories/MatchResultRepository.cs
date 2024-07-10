using SportScore.API.Controllers.Sports.DataModel;

namespace SportScore.API.Controllers.Sports.Database.Repositories;

public class MatchResultRepository : IMatchResultRepository
{
    private readonly MatchResultContext _context;

    public MatchResultRepository(MatchResultContext context)
    {
        _context = context;
    }

    public async Task<MatchResult> AddAsync(MatchResult matchResult)
    {
        _context.MatchResults.Add(matchResult);
        await _context.SaveChangesAsync();
        return matchResult;
    }

    public async Task<MatchResult> GetByIdAsync(Guid id)
    {
        return await _context.MatchResults.FindAsync(id);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var matchResult = await _context.MatchResults.FindAsync(id);
        if (matchResult == null)
        {
            return false;
        }

        _context.MatchResults.Remove(matchResult);
        await _context.SaveChangesAsync();
        return true;
    }

    public IEnumerable<MatchResult> GetAllAsync()
    {
        return _context.MatchResults.ToList();
    }
}
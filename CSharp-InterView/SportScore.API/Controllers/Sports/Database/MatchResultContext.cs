using Microsoft.EntityFrameworkCore;
using SportScore.API.Controllers.Sports.DataModel;

namespace SportScore.API.Controllers.Sports.Database;

public class MatchResultContext : DbContext
{
    public DbSet<MatchResult> MatchResults { get; set; }

    public MatchResultContext(DbContextOptions<MatchResultContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MatchResult>().ToTable("MatchResult");
    }
}

namespace SportScore.API.Controllers.Sports.DataModel;

public class MatchResult
{
    public Guid Id { get; set; }
    public string Team1 { get; set; } = string.Empty;
    public string Team2 { get; set; } = string.Empty;
    public string Score { get; set; } = string.Empty;
    public string InputString { get; set; } = string.Empty;
    public string Result { get; set; } = string.Empty;
}

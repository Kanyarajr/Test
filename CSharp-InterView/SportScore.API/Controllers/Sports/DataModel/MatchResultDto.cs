namespace SportScore.API.Controllers.Sports.DataModel;

public class MatchResultDto
{
    public string Team1 { get; set; } = string.Empty;
    public string Team2 { get; set; } = string.Empty;
    public string Sport { get; set; } = string.Empty;
    public string Score { get; set; } = string.Empty;
    public string InputString { get; set; } = string.Empty;
}

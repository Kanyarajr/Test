namespace SportsScorePredictor.SharedLogics;

public abstract class Sports : ISports
{
    public string team1 = string.Empty;
    public string team2 = string.Empty;
    public string winner = string.Empty;
    public string loser = string.Empty;
    public List<string> scores = new();
    public int setsTeam1 = 0;
    public int setsTeam2 = 0;

    private int WinningPoints = 0;
    private int DeucePoints = 0;

    protected Sports(int winningPoints, int deucePoints)
    {
        WinningPoints = winningPoints;
        DeucePoints = deucePoints;
    }

    public virtual string GameMatchPredictor(string team1, string team2, List<string> matchSets)
    {
        this.team1 = team1;
        this.team2 = team2;

        foreach (string set in matchSets)
        {
            var points = GameSetPredictor(set);
            scores.Add($"{points.team1SetPoint}-{points.team2SetPoint}");
            if (points.team1SetPoint > points.team2SetPoint)
                setsTeam1++;
            else if (points.team1SetPoint < points.team2SetPoint)
                setsTeam2++;
        }

        winner = setsTeam1 > setsTeam2 ? team1 : team2;
        loser = setsTeam1 > setsTeam2 ? team2 : team1;

        return "Success";
    }

    private MatchSetOutput GameSetPredictor(string setInput)
    {
        int team1Points = 0;
        int team2Points = 0;

        foreach (char c in setInput)
        {
            if (c == '1')
                team1Points++;
            else
                team2Points++;

            if (team1Points >= WinningPoints || team2Points >= WinningPoints)
            {
                if (team1Points >= DeucePoints && team2Points >= DeucePoints)
                {
                    if (Math.Abs(team1Points - team2Points) >= 2)
                    {
                        break;
                    }
                }
            }
        }

        return new MatchSetOutput
        {
            team1SetPoint = team1Points,
            team2SetPoint = team2Points,
        };

    }

    public abstract string GameMatchResult();

}

using SportsScorePredictor.SharedLogics;

namespace SportsScorePredictor.Game
{
    public class Squash : Sports
    {
        private const int WinningScore = 15;
        private const int DeuceScore = 14;

        public Squash() : base(WinningScore, DeuceScore)
        {
        }

        public override string GameMatchPredictor(string team1, string team2, List<string> matchSets)
        {
            if (matchSets.Count < 3)
            {
                return "Sets count should be 3.";
            }
            else if (string.IsNullOrEmpty(team1.Trim()) || string.IsNullOrEmpty(team2.Trim()))
            {
                return "Team names should not be empty.";
            }
            else
            {
                return base.GameMatchPredictor(team1, team2, matchSets);
            }
        }

        public override string GameMatchResult()
        {


            string matchResult = setsTeam1 > setsTeam2 ? $"{team1} beat {team2}" :
                setsTeam1 < setsTeam2 ? $"{team2} beat {team1}" : $"{team1} ties {team2}";
            string winingRatio = setsTeam1 > setsTeam2 ? $"{setsTeam1}-{setsTeam2}" : $"{setsTeam2}-{setsTeam1}";
            return $"{matchResult} ({winingRatio}) Scores: {string.Join(", ", scores)}.";
        }
    }
}
using Microsoft.Extensions.Logging;
using SportScore.API.Controllers.Sports.Database.Repositories;
using SportScore.API.Controllers.Sports.DataModel;
using System.Reflection;

namespace SportScore.API.Controllers.Sports.Service
{
    public class MatchResultService : IMatchResultService
    {
        private readonly IMatchResultRepository _repository;

        public MatchResultService(IMatchResultRepository repository)
        {
            _repository = repository;
        }

        public async Task<MatchResult> CheckAndSaveResultAsync(string team1, string team2, string sport, string score, string inputString)
        {
            var result = GameMatchPredictor(team1, team1, sport, score.Split(',').ToList());
            var matchResult = new MatchResult
            {
                Id = Guid.NewGuid(),
                Team1 = team1,
                Team2 = team2,
                Score = score,
                InputString = inputString,
                Result = result
            };

            return await _repository.AddAsync(matchResult);
        }

        public async Task<MatchResult> GetMatchResultByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<bool> DeleteMatchResultByIdAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public string GameMatchPredictor(string team1, string team2, string sport, List<string> matchSets)
        {
            List<string> scores = new();
            int setsTeam1 = 0;
            int setsTeam2 = 0;
            int WinningPoints = sport == "Volleyball" ? 15 : 11;
            int DeucePoints = sport == "Squash" ? 14 : 10;

            foreach (string set in matchSets)
            {
                var points = GameSetPredictor(set, WinningPoints, DeucePoints);
                scores.Add($"{points.team1SetPoint}-{points.team2SetPoint}");
                if (points.team1SetPoint > points.team2SetPoint)
                    setsTeam1++;
                else if (points.team1SetPoint < points.team2SetPoint)
                    setsTeam2++;
            }

            string matchResult = setsTeam1 > setsTeam2 ? $"{team1} beat {team2}" : setsTeam1 < setsTeam2 ? $"{team2} beat {team1}" : $"{team1} ties {team2}";
            string winingRatio = setsTeam1 > setsTeam2 ? $"{setsTeam1}-{setsTeam2}" : $"{setsTeam2}-{setsTeam1}";
            return $"{matchResult} ({winingRatio})";
        }

        private MatchSetOutput GameSetPredictor(string setInput, int WinningPoints, int DeucePoints)
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

        public IEnumerable<MatchResult> ListAllMatchesAsync()
        {
            return _repository.GetAllAsync().ToList();
        }
    }
}

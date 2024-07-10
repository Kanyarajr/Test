using SportsScorePredictor.Game;
using SportsScorePredictor.SharedLogics;

namespace SportsScorePredictor;

public static class GameFactory
{
    public static Sports GetGame(string gameType)
    {
        switch (gameType)
        {
            case "Volleyball":
                return new Volleyball();
            case "Squash":
                return new Squash();
            default:
                throw new NotSupportedException("Game type not supported.");
        }
    }
}

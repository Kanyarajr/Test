using SportsScorePredictor;
using SportsScorePredictor.SharedLogics;
using Xunit;

namespace SportsScore.Tests;

public class PredictionTests
{
    [Fact]
    public void Select_Sports_Success()
    {
        Sports volleyball = GameFactory.GetGame("Volleyball");
        Assert.Equal("Volleyball", volleyball.GetType().Name);

        Sports squash = GameFactory.GetGame("Squash");
        Assert.Equal("Squash", squash.GetType().Name);

    }

    [Fact]
    public void Select_Sports_Failure()
    {
        NotSupportedException exception = Assert.Throws<NotSupportedException>(() => GameFactory.GetGame("Cricket"));
        Assert.Equal("Game type not supported.", exception.Message);
    }

    [Fact]
    public void TestVolleyballMatch_With_SingleSet()
    {
        Sports volleyball = GameFactory.GetGame("Volleyball");
        List<string> setScore = new List<string>()
        {
            "0110101010000010101011"
        };

        volleyball.GameMatchPredictor("Ravens", "Badgers", setScore);
        string result = volleyball.GameMatchResult();
        Assert.Equal("Badgers beat Ravens (1-0) Scores: 10-12.", result);
    }

    
    
    [Fact]
    public void TestVolleyballMatch_With_MultipleSet()
    {
        Sports volleyball = GameFactory.GetGame("Volleyball");
        List<string> setScore = new List<string>()
        {
            "1001010101111011101111",
            "0110101010000100010000",
            "1001010101111011101111"
        };

        volleyball.GameMatchPredictor("Ravens", "Badgers", setScore);
        string result = volleyball.GameMatchResult();
        Assert.Equal("Ravens beat Badgers (2-1) Scores: 15-7, 7-15, 15-7.", result);
    }

    [Fact]
    public void TestVolleyballMatch_Invalid_Input()
    {
        Sports volleyball = GameFactory.GetGame("Volleyball");
        List<string> setScore = new List<string>();

        string setScoreResponse = volleyball.GameMatchPredictor("", "Badgers", setScore);
        Assert.Equal("Atlease one match set needed.", setScoreResponse);

        setScore.Add("00000000011111111100");

        string team1Response = volleyball.GameMatchPredictor("", "Badgers", setScore);
        Assert.Equal("Team names should not be empty.", team1Response);

        string team2Response = volleyball.GameMatchPredictor("Ravens", "", setScore);
        Assert.Equal("Team names should not be empty.", team1Response);

    }

    [Fact]
    public void TestSquashMatch_With_Valid_Input()
    {
        Sports squash = GameFactory.GetGame("Squash");

        List<string> setScore = new List<string>()
        {
            "00000000011111111100",
            "00000000001111111111",
            "00000000011111111111",
        };

        squash.GameMatchPredictor("Ravens", "Badgers", setScore);

        string result = squash.GameMatchResult();
        Assert.Equal("Ravens ties Badgers (1-1) Scores: 9-11, 10-10, 11-9.", result);
    }

    [Fact]
    public void TestSquashMatch_With_InValid_Sets_Count()
    {
        Sports squash = GameFactory.GetGame("Squash");
        List<string> setScore = new List<string>()
        {
            "00000000011111111100",
            "00000000001111111111"
        };

        string response = squash.GameMatchPredictor("Ravens", "Badgers", setScore);
        Assert.Equal("Sets count should be 3.", response);
    }

    [Fact]
    public void TestSquashMatch_With_InValid_Name()
    {
        Sports squash = GameFactory.GetGame("Squash");
        List<string> setScore = new List<string>()
        {
            "00000000011111111100",
            "00000000001111111111",
            "00000000011111111111",
        };

        string team1Response = squash.GameMatchPredictor("", "Badgers", setScore);
        Assert.Equal("Team names should not be empty.", team1Response);

        string team2Response = squash.GameMatchPredictor("Ravens", "", setScore);
        Assert.Equal("Team names should not be empty.", team1Response);

    }

}
using Moq;
using Xunit;

namespace BracketConsole.Tests;

public class BracketBuilderTests
{
    [Fact]
    public void Build_With48Players_ShouldCreate64SizeBracket()
    {
        // Arrange
        var players = CreatePlayers(48);

        // Act
        var bracket = BracketBuilder.Build(players, "48 Player Test");

        // Assert
        Assert.NotNull(bracket);
        Assert.Equal(48, bracket.RequestedPlayerCount);
        Assert.Equal(64, bracket.BracketSize);
    }

    [Fact]
    public void Build_With48Players_ShouldCreateCorrectNumberOfRounds()
    {
        // Arrange
        var players = CreatePlayers(48);

        // Act
        var bracket = BracketBuilder.Build(players, "48 Player Test");

        // Assert
        // 64 bracket => 6 rounds
        Assert.Equal(6, bracket.Rounds.Count);
    }

    [Fact]
    public void Build_With48Players_ShouldCreateCorrectMatchCountsPerRound()
    {
        // Arrange
        var players = CreatePlayers(48);

        // Act
        var bracket = BracketBuilder.Build(players, "48 Player Test");

        // Assert
        Assert.Collection(bracket.Rounds,
            round1 => Assert.Equal(32, round1.Matches.Count),
            round2 => Assert.Equal(16, round2.Matches.Count),
            round3 => Assert.Equal(8, round3.Matches.Count),
            round4 => Assert.Equal(4, round4.Matches.Count),
            round5 => Assert.Equal(2, round5.Matches.Count),
            round6 => Assert.Single(round6.Matches));
    }

    [Fact]
    public void Build_With48Players_ShouldFillRound1With64SlotsIncluding16Byes()
    {
        // Arrange
        var players = CreatePlayers(48);

        // Act
        var bracket = BracketBuilder.Build(players, "48 Player Test");

        // Assert
        var firstRound = bracket.Rounds.First();

        var round1Players = firstRound.Matches
            .SelectMany(m => new[] { m.Player1, m.Player2 })
            .Where(p => p is not null)
            .Cast<Player>()
            .ToList();

        Assert.Equal(64, round1Players.Count);
        Assert.Equal(16, round1Players.Count(p => p.IsBye));
        Assert.Equal(48, round1Players.Count(p => !p.IsBye));
    }

    [Fact]
    public void Build_With48Players_ShouldAutoAdvancePlayersFromByeMatches()
    {
        // Arrange
        var players = CreatePlayers(48);

        // Act
        var bracket = BracketBuilder.Build(players, "48 Player Test");

        // Assert
        var firstRound = bracket.Rounds[0];

        var byeMatches = firstRound.Matches
            .Where(m =>
                (m.Player1?.IsBye == true && m.Player2?.IsBye == false) ||
                (m.Player2?.IsBye == true && m.Player1?.IsBye == false))
            .ToList();

        Assert.NotEmpty(byeMatches);
        Assert.All(byeMatches, match => Assert.NotNull(match.Winner));
    }

    [Fact]
    public void Build_With48Players_ShouldGenerateValidNextMatchNumbers()
    {
        // Arrange
        var players = CreatePlayers(48);

        // Act
        var bracket = BracketBuilder.Build(players, "48 Player Test");

        // Assert
        var allMatchNumbers = bracket.Rounds
            .SelectMany(r => r.Matches)
            .Select(m => m.MatchNumber)
            .ToHashSet();

        var nonFinalMatches = bracket.Rounds
            .Take(bracket.Rounds.Count - 1)
            .SelectMany(r => r.Matches)
            .ToList();

        Assert.All(nonFinalMatches, match =>
        {
            Assert.True(match.NextMatchNumber.HasValue,
                $"Match {match.MatchNumber} should have NextMatchNumber");

            Assert.Contains(match.NextMatchNumber!.Value, allMatchNumbers);
        });

        var finalMatch = bracket.Rounds.Last().Matches.Single();
        Assert.Null(finalMatch.NextMatchNumber);
    }

    [Fact]
    public void SetResult_ShouldAdvanceWinnerToNextRound()
    {
        // Arrange
        var players = CreatePlayers(48);
        var bracket = BracketBuilder.Build(players, "48 Player Test");

        var firstRound = bracket.Rounds[0];
        var firstPlayableMatch = firstRound.Matches.First(m =>
            m.Player1 is not null &&
            m.Player2 is not null &&
            !m.Player1.IsBye &&
            !m.Player2.IsBye);

        // Act
        BracketBuilder.SetResult(
            bracket,
            roundNumber: firstPlayableMatch.RoundNumber,
            positionIndex: firstPlayableMatch.PositionIndex,
            score1: 4,
            score2: 2);

        // Assert
        Assert.NotNull(firstPlayableMatch.Winner);
        Assert.Equal(firstPlayableMatch.Player1, firstPlayableMatch.Winner);

        var nextMatch = bracket.Rounds
            .SelectMany(r => r.Matches)
            .Single(m => m.MatchNumber == firstPlayableMatch.NextMatchNumber);

        if (firstPlayableMatch.PositionIndex % 2 == 1)
            Assert.Equal(firstPlayableMatch.Winner, nextMatch.Player1);
        else
            Assert.Equal(firstPlayableMatch.Winner, nextMatch.Player2);
    }

    [Fact]
    public void Build_With48Players_ShouldNotThrow()
    {
        // Arrange
        var players = CreatePlayers(48);

        // Act
        var ex = Record.Exception(() => BracketBuilder.Build(players, "48 Player Test"));

        // Assert
        Assert.Null(ex);
    }

    [Fact]
    public void ExportService_ShouldCallPdfGenerator_UsingMoq()
    {
        // Arrange
        var players = CreatePlayers(48);
        var bracket = BracketBuilder.Build(players, "48 Player Test");

        var pdfGeneratorMock = new Mock<IBracketPdfGenerator>();
        var service = new BracketExportService(pdfGeneratorMock.Object);

        // Act
        service.ExportPdf(bracket, "test-output.pdf");

        // Assert
        pdfGeneratorMock.Verify(
            x => x.Generate(bracket, "test-output.pdf"),
            Times.Once);
    }

    private static List<Player> CreatePlayers(int count)
    {
        var players = new List<Player>();

        for (int i = 1; i <= count; i++)
        {
            players.Add(new Player(
                Id: i,
                Name: $"Player {i}",
                Seed: i));
        }

        return players;
    }
}
namespace KOBracketPrinter.Models;

public static class BracketBuilder
{
    public static Bracket Build(IReadOnlyList<Player> originalPlayers, string title)
    {
        if (originalPlayers.Count == 0)
            throw new InvalidOperationException("At least one player is required.");

        var bracketSize = GetNextPowerOfTwo(originalPlayers.Count);
        var roundsCount = (int)Math.Log2(bracketSize);

        var players = originalPlayers
            .OrderBy(p => p.Seed)
            .ToList();

        while (players.Count < bracketSize)
        {
            players.Add(new Player(
                Id: -players.Count - 1,
                Name: "BYE",
                Seed: players.Count + 1,
                IsBye: true));
        }

        var seededOrder = GenerateSeedOrder(bracketSize)
            .Select(seed => players.First(p => p.Seed == seed))
            .ToList();

        var rounds = new List<Round>();

        for (var roundNo = 1; roundNo <= roundsCount; roundNo++)
        {
            var matchesInRound = bracketSize / (int)Math.Pow(2, roundNo);

            var round = new Round
            {
                RoundNumber = roundNo,
                Title = GetRoundTitle(bracketSize, roundNo),
                Matches = []
            };

            for (var i = 0; i < matchesInRound; i++)
            {
                round.Matches.Add(new Match
                {
                    MatchNumber = i + 1,
                    RoundNumber = roundNo,
                    PositionIndex = i + 1
                });
            }

            rounds.Add(round);
        }

        var firstRound = rounds[0];
        for (var i = 0; i < firstRound.Matches.Count; i++)
        {
            firstRound.Matches[i].Player1 = seededOrder[i * 2];
            firstRound.Matches[i].Player2 = seededOrder[i * 2 + 1];
        }

        return new Bracket
        {
            Title = title,
            RequestedPlayerCount = originalPlayers.Count,
            BracketSize = bracketSize,
            Rounds = rounds
        };
    }

    private static int GetNextPowerOfTwo(int value)
    {
        var power = 1;
        while (power < value)
            power *= 2;
        return power;
    }

    private static List<int> GenerateSeedOrder(int size)
    {
        if (size < 2 || (size & (size - 1)) != 0)
            throw new ArgumentException("Size must be a power of two.");

        var positions = new List<int> { 1, 2 };

        while (positions.Count < size)
        {
            var nextSize = positions.Count * 2 + 1;
            var next = new List<int>();

            foreach (var seed in positions)
            {
                next.Add(seed);
                next.Add(nextSize - seed);
            }

            positions = next;
        }

        return positions;
    }

    private static string GetRoundTitle(int bracketSize, int roundNumber)
    {
        var playersInRound = bracketSize / (int)Math.Pow(2, roundNumber - 1);

        return playersInRound switch
        {
            2 => "Final",
            4 => "Semi Final",
            8 => "Quarter Final",
            16 => "Last 16",
            32 => "Last 32",
            64 => "Last 64",
            128 => "Last 128",
            _ => $"Round {roundNumber}"
        };
    }
}
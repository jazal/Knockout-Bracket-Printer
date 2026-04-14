namespace KOBracketPrinter.Models;

public static class PrintRequestMapper
{
    public static Bracket Map(PrintRequestDto dto)
    {
        var rounds = dto.Matches
            .GroupBy(x => x.RoundNumber)
            .OrderBy(x => x.Key)
            .Select(g => new Round
            {
                Title = GetRoundTitle(g.Key, dto.PlayerCount),
                Matches = g.Select((m, index) => new Match
                {
                    MatchNumber = m.MatchNo,
                    PositionIndex = index,

                    Player1 = string.IsNullOrWhiteSpace(m.Opponent1)
                        ? null
                        : new Player(0, m.Opponent1, m.Seed1 ?? 0, m.Flag1),

                    Player2 = string.IsNullOrWhiteSpace(m.Opponent2)
                        ? null
                        : new Player(0, m.Opponent2, m.Seed2 ?? 0, m.Flag2),
                    Score1 = m.Score1,
                    Score2 = m.Score2,
                }).ToList()
            })
            .ToList();

        return new Bracket
        {
            Title = dto.EventCategoryTitle ?? "Tournament",
            RequestedPlayerCount = int.Parse(dto.PlayerCount),
            Rounds = rounds
        };
    }

    private static string GetRoundTitle(int roundNumber, string playerCount)
    {
        int total = int.Parse(playerCount);

        int remaining = total / (int)Math.Pow(2, roundNumber - 1);

        return remaining switch
        {
            256 => "Last 256",
            128 => "Last 128",
            64 => "Last 64",
            32 => "Last 32",
            16 => "Last 16",
            8 => "Quarter Final",
            4 => "Semi Final",
            2 => "Final",
            _ => $"Round {roundNumber}"
        };
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOBracketPrinter.Models;

public sealed record Player(int Id, string Name, int Seed, bool IsBye = false);

public sealed class Match
{
    public int MatchNumber { get; init; }
    public int RoundNumber { get; init; }
    public int PositionIndex { get; init; }

    public Player? Player1 { get; set; }
    public Player? Player2 { get; set; }

    public int? Score1 { get; set; }
    public int? Score2 { get; set; }

    public Player? Winner { get; set; }
}

public sealed class Round
{
    public int RoundNumber { get; init; }
    public string Title { get; init; } = string.Empty;
    public List<Match> Matches { get; init; } = [];
}

public sealed class Bracket
{
    public string Title { get; init; } = string.Empty;
    public int RequestedPlayerCount { get; init; }
    public int BracketSize { get; init; }
    public List<Round> Rounds { get; init; } = [];
}

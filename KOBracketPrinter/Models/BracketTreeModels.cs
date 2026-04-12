namespace KOBracketPrinter.Models;

public sealed class BracketTreeNode
{
    public int MatchNumber { get; set; }
    public int RoundNumber { get; set; }
    public int PositionIndex { get; set; }

    public Player? Player1 { get; set; }
    public Player? Player2 { get; set; }

    public int? Score1 { get; set; }
    public int? Score2 { get; set; }

    public Player? Winner { get; set; }

    public BracketTreeNode? Left { get; set; }
    public BracketTreeNode? Right { get; set; }
    public BracketTreeNode? Parent { get; set; }
}

public sealed class BracketTree
{
    public string Title { get; set; } = string.Empty;
    public int RequestedPlayerCount { get; set; }
    public int BracketSize { get; set; }
    public BracketTreeNode? Root { get; set; }
    public List<List<BracketTreeNode>> Levels { get; set; } = [];
}
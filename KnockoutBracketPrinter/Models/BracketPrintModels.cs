namespace KnockoutBracketPrinter.Models;

public sealed class BracketPrintPage
{
    public int PageNumber { get; set; }
    public List<BracketPrintColumn> Columns { get; set; } = [];
}

public sealed class BracketPrintColumn
{
    public int RoundNumber { get; set; }
    public string Title { get; set; } = string.Empty;
    public List<Match> Matches { get; set; } = [];
}
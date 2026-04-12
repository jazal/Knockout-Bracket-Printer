namespace ConsoleApp1;

public sealed class BracketPdfPage
{
    public int PageNumber { get; set; }
    public List<BracketPdfPageRound> Rounds { get; set; } = [];
}

public sealed class BracketPdfPageRound
{
    public int RoundNumber { get; set; }
    public string Title { get; set; } = string.Empty;
    public List<Match> Matches { get; set; } = [];
}

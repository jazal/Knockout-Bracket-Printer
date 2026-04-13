namespace KOBracketPrinter.Models;

public class PrintRequestDto
{
    public string? EventCategoryTitle { get; set; }

    public string PlayerCount { get; set; }

    public List<PrintRequestMatchDto> Matches { get; set; } = [];
}

public class PrintRequestMatchDto
{
    public PrintRequestMatchDto()
    {

    }

    public PrintRequestMatchDto(int matchNo, int roundNumber, string? opponent1, string? opponent2, int? score1, int? score2, short? seed1, short? seed2)
    {
        MatchNo = matchNo;
        RoundNumber = roundNumber;
        Opponent1 = opponent1;
        Opponent2 = opponent2;
        Score1 = score1;
        Score2 = score2;
        Seed1 = seed1;
        Seed2 = seed2;
    }

    public int MatchNo { get; set; }

    public int RoundNumber { get; init; }

    public string? Opponent1 { get; set; }

    public string? Opponent2 { get; set; }

    public int? Score1 { get; set; }

    public int? Score2 { get; set; }

    public short? Seed1 { get; set; }

    public short? Seed2 { get; set; }
}
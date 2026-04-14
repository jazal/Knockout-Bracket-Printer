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

    public PrintRequestMatchDto(int matchNo, int roundNumber, string? opponent1 = null, string? opponent2 = null, int? score1 = null, int? score2 = null, short? seed1 = null, short? seed2 = null, string? flag1 = null, string? flag2 = null)
    {
        MatchNo = matchNo;
        RoundNumber = roundNumber;
        Opponent1 = opponent1;
        Opponent2 = opponent2;
        Score1 = score1;
        Score2 = score2;
        Seed1 = seed1;
        Seed2 = seed2;
        Flag1 = flag1;
        Flag2 = flag2;
    }

    public int MatchNo { get; set; }

    public int RoundNumber { get; init; }

    public string? Opponent1 { get; set; }

    public string? Opponent2 { get; set; }

    public int? Score1 { get; set; }

    public int? Score2 { get; set; }

    public short? Seed1 { get; set; }

    public short? Seed2 { get; set; }

    public string? Flag1 { get; set; }

    public string? Flag2 { get; set; }
}
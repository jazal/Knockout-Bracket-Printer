namespace GroupsStagePrinter;

public class GroupStagePrintRequest
{
    public string Title { get; set; } = "";
    public string? Subtitle { get; set; }
    public string? LogoUrl { get; set; }
    public int? GroupsPerRow { get; set; } = 3;   // 3 or 2
    public List<GroupStandingModel> Groups { get; set; } = new();
}

public class GroupStandingModel
{
    public string GroupName { get; set; } = "";
    public List<GroupPlayerStandingModel> Players { get; set; } = new();
}

public class GroupPlayerStandingModel
{
    public string PlayerName { get; set; } = "";
    public string Country { get; set; } = "";
    public int MatchesPlayed { get; set; }
    public int MatchesWon { get; set; }
    public int FramesWon { get; set; }
    public int FramesLost { get; set; }
    public int FrameDifference { get; set; }
}

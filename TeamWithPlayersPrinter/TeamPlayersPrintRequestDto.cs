namespace TeamWithPlayersPrinter;

public class TeamPlayersPrintRequestDto
{
    public string Title { get; set; } = "";
    public string Subtitle { get; set; } = "";
    public string? LogoUrl { get; set; }
    public List<TeamPlayersPrintViewModel> Teams { get; set; } = new();
}

public class TeamPlayersPrintViewModel
{
    public string TeamName { get; set; } = "";
    public List<string> Players { get; set; } = new();
}

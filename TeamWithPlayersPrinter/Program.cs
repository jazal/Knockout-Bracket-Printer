using TeamWithPlayersPrinter;

var model = new TeamPlayersPrintRequestDto
{
    Title = "Team Sheet",
    Subtitle = "Interclub Championship 2026",
    LogoUrl = "https://flagsapi.com/CN/flat/32.png",
    Teams = new List<TeamPlayersPrintViewModel>
    {
        new()
        {
            TeamName = "Team A",
            Players = new List<string> { "Ali", "Ahmed", "Usman" }
        },
        new()
        {
            TeamName = "Team B",
            Players = new List<string> { "John", "Mark", "David" }
        }
    }
};

var logoBytes = await ImageHelper.DownloadImageAsync(model.LogoUrl);
var pdfBytes = TeamSheetPdfGenerator.Generate(model, logoBytes);
File.WriteAllBytes("teams.pdf", pdfBytes);
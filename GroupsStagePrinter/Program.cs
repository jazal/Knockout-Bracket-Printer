using GroupsStagePrinter;

var request = new GroupStagePrintRequest
{
    Title = "Group Stage Standings",
    Subtitle = "Snooker Championship 2026",
    LogoUrl = "https://example.com/logo.png",
    GroupsPerRow = 2,
    ShowPoints = true,
    Groups = new List<GroupStandingModel>
    {
        new GroupStandingModel
        {
            GroupName = "A",
            Players = new List<GroupPlayerStandingModel>
            {
                new() { Points = new[] { 3, -1, 1 }, PlayerName = "Ali", Country = "Qatar", MatchesPlayed = 3, MatchesWon = 2, FramesWon = 8, FramesLost = 4, FrameDifference = 4 },
                new() { Points = new[] { 3, -1, 1 }, PlayerName = "Ahmed", Country = "Pakistan", MatchesPlayed = 3, MatchesWon = 2, FramesWon = 7, FramesLost = 5, FrameDifference = 2 },
                new() { Points = new[] { 3, -1, 1 }, PlayerName = "John", Country = "England", MatchesPlayed = 3, MatchesWon = 1, FramesWon = 5, FramesLost = 7, FrameDifference = -2 },
                new() { Points = new[] { 3, -1, 1 }, PlayerName = "Mark", Country = "India", MatchesPlayed = 3, MatchesWon = 1, FramesWon = 4, FramesLost = 8, FrameDifference = -4 }
            }
        },
        new GroupStandingModel
        {
            GroupName = "B",
            Players = new List<GroupPlayerStandingModel>
            {
                new() { PlayerName = "Usman", Country = "Pakistan", MatchesPlayed = 3, MatchesWon = 3, FramesWon = 9, FramesLost = 2, FrameDifference = 7 },
                new() { PlayerName = "David", Country = "Wales", MatchesPlayed = 3, MatchesWon = 2, FramesWon = 7, FramesLost = 4, FrameDifference = 3 },
                new() { PlayerName = "Ravi", Country = "India", MatchesPlayed = 3, MatchesWon = 1, FramesWon = 4, FramesLost = 8, FrameDifference = -4 },
                new() { PlayerName = "Omar", Country = "Qatar", MatchesPlayed = 3, MatchesWon = 0, FramesWon = 2, FramesLost = 8, FrameDifference = -6 }
            }
        },
        new GroupStandingModel
        {
            GroupName = "C",
            Players = new List<GroupPlayerStandingModel>
            {
                new() { PlayerName = "Ali", Country = "Qatar", MatchesPlayed = 3, MatchesWon = 2, FramesWon = 8, FramesLost = 4, FrameDifference = 4 },
                new() { PlayerName = "Ahmed", Country = "Pakistan", MatchesPlayed = 3, MatchesWon = 2, FramesWon = 7, FramesLost = 5, FrameDifference = 2 },
                new() { PlayerName = "John", Country = "England", MatchesPlayed = 3, MatchesWon = 1, FramesWon = 5, FramesLost = 7, FrameDifference = -2 },
                new() { PlayerName = "Mark", Country = "India", MatchesPlayed = 3, MatchesWon = 1, FramesWon = 4, FramesLost = 8, FrameDifference = -4 }
            }
        },
        new GroupStandingModel
        {
            GroupName = "D",
            Players = new List<GroupPlayerStandingModel>
            {
                new() { PlayerName = "Usman", Country = "Pakistan", MatchesPlayed = 3, MatchesWon = 3, FramesWon = 9, FramesLost = 2, FrameDifference = 7 },
                new() { PlayerName = "David", Country = "Wales", MatchesPlayed = 3, MatchesWon = 2, FramesWon = 7, FramesLost = 4, FrameDifference = 3 },
                new() { PlayerName = "Ravi", Country = "India", MatchesPlayed = 3, MatchesWon = 1, FramesWon = 4, FramesLost = 8, FrameDifference = -4 },
                new() { PlayerName = "Omar", Country = "Qatar", MatchesPlayed = 3, MatchesWon = 0, FramesWon = 2, FramesLost = 8, FrameDifference = -6 }
            }
        },
        new GroupStandingModel
        {
            GroupName = "E",
            Players = new List<GroupPlayerStandingModel>
            {
                new() { PlayerName = "Ali", Country = "Qatar", MatchesPlayed = 3, MatchesWon = 2, FramesWon = 8, FramesLost = 4, FrameDifference = 4 },
                new() { PlayerName = "Ahmed", Country = "Pakistan", MatchesPlayed = 3, MatchesWon = 2, FramesWon = 7, FramesLost = 5, FrameDifference = 2 },
                new() { PlayerName = "John", Country = "England", MatchesPlayed = 3, MatchesWon = 1, FramesWon = 5, FramesLost = 7, FrameDifference = -2 },
                new() { PlayerName = "Mark", Country = "India", MatchesPlayed = 3, MatchesWon = 1, FramesWon = 4, FramesLost = 8, FrameDifference = -4 }
            }
        },
        new GroupStandingModel
        {
            GroupName = "F",
            Players = new List<GroupPlayerStandingModel>
            {
                new() { PlayerName = "Usman", Country = "Pakistan", MatchesPlayed = 3, MatchesWon = 3, FramesWon = 9, FramesLost = 2, FrameDifference = 7 },
                new() { PlayerName = "David", Country = "Wales", MatchesPlayed = 3, MatchesWon = 2, FramesWon = 7, FramesLost = 4, FrameDifference = 3 },
                new() { PlayerName = "Ravi", Country = "India", MatchesPlayed = 3, MatchesWon = 1, FramesWon = 4, FramesLost = 8, FrameDifference = -4 },
                new() { PlayerName = "Omar", Country = "Qatar", MatchesPlayed = 3, MatchesWon = 0, FramesWon = 2, FramesLost = 8, FrameDifference = -6 }
            }
        },
        new GroupStandingModel
        {
            GroupName = "H",
            Players = new List<GroupPlayerStandingModel>
            {
                new() { PlayerName = "Ali", Country = "Qatar", MatchesPlayed = 3, MatchesWon = 2, FramesWon = 8, FramesLost = 4, FrameDifference = 4 },
                new() { PlayerName = "Ahmed", Country = "Pakistan", MatchesPlayed = 3, MatchesWon = 2, FramesWon = 7, FramesLost = 5, FrameDifference = 2 },
                new() { PlayerName = "John", Country = "England", MatchesPlayed = 3, MatchesWon = 1, FramesWon = 5, FramesLost = 7, FrameDifference = -2 },
                new() { PlayerName = "Mark", Country = "India", MatchesPlayed = 3, MatchesWon = 1, FramesWon = 4, FramesLost = 8, FrameDifference = -4 }
            }
        },
        new GroupStandingModel
        {
            GroupName = "I",
            Players = new List<GroupPlayerStandingModel>
            {
                new() { PlayerName = "Usman", Country = "Pakistan", MatchesPlayed = 3, MatchesWon = 3, FramesWon = 9, FramesLost = 2, FrameDifference = 7 },
                new() { PlayerName = "David", Country = "Wales", MatchesPlayed = 3, MatchesWon = 2, FramesWon = 7, FramesLost = 4, FrameDifference = 3 },
                new() { PlayerName = "Ravi", Country = "India", MatchesPlayed = 3, MatchesWon = 1, FramesWon = 4, FramesLost = 8, FrameDifference = -4 },
                new() { PlayerName = "Omar", Country = "Qatar", MatchesPlayed = 3, MatchesWon = 0, FramesWon = 2, FramesLost = 8, FrameDifference = -6 }
            }
        },
        new GroupStandingModel
        {
            GroupName = "J",
            Players = new List<GroupPlayerStandingModel>
            {
                new() { PlayerName = "Usman", Country = "Pakistan", MatchesPlayed = 3, MatchesWon = 3, FramesWon = 9, FramesLost = 2, FrameDifference = 7 },
                new() { PlayerName = "David", Country = "Wales", MatchesPlayed = 3, MatchesWon = 2, FramesWon = 7, FramesLost = 4, FrameDifference = 3 },
                new() { PlayerName = "Ravi", Country = "India", MatchesPlayed = 3, MatchesWon = 1, FramesWon = 4, FramesLost = 8, FrameDifference = -4 },
                new() { PlayerName = "Omar", Country = "Qatar", MatchesPlayed = 3, MatchesWon = 0, FramesWon = 2, FramesLost = 8, FrameDifference = -6 }
            }
        },
        new GroupStandingModel
        {
            GroupName = "K",
            Players = new List<GroupPlayerStandingModel>
            {
                new() { PlayerName = "Usman", Country = "Pakistan", MatchesPlayed = 3, MatchesWon = 3, FramesWon = 9, FramesLost = 2, FrameDifference = 7 },
                new() { PlayerName = "David", Country = "Wales", MatchesPlayed = 3, MatchesWon = 2, FramesWon = 7, FramesLost = 4, FrameDifference = 3 },
                new() { PlayerName = "Ravi", Country = "India", MatchesPlayed = 3, MatchesWon = 1, FramesWon = 4, FramesLost = 8, FrameDifference = -4 },
                new() { PlayerName = "Omar", Country = "Qatar", MatchesPlayed = 3, MatchesWon = 0, FramesWon = 2, FramesLost = 8, FrameDifference = -6 }
            }
        }
    }
};

var logoBytes = await ImageHelper.DownloadImageAsync(request.LogoUrl);
var generator = new GroupStagePdfGenerator(request, logoBytes);
var pdfBytes = generator.Generate();

File.WriteAllBytes("group-stage.pdf", pdfBytes);
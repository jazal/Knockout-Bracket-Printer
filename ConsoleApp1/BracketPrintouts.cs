using System.Text;

const string tournamentTitle = "Demo Tournament - Last 16";
const string outputHtmlFile = "bracket-last16.html";

// Dummy data for Last 16.
// You can change this count to any number.
// The code will automatically expand to the next power of 2 and add BYEs if needed.
var players = new List<Player>
{
    //new(1, "Player 1", 1),
    //new(2, "Player 2", 16),
    //new(3, "Player 3", 8),
    //new(4, "Player 4", 9),
    //new(5, "Player 5", 5),
    //new(6, "Player 6", 12),
    //new(7, "Player 7", 4),
    //new(8, "Player 8", 13),
    //new(9, "Player 9", 3),
    //new(10, "Player 10", 14),
    //new(11, "Player 11", 6),
    //new(12, "Player 12", 11),
    //new(13, "Player 13", 7),
    //new(14, "Player 14", 10),
    //new(15, "Player 15", 2),
    //new(16, "Player 16", 15),
    //new(17, "Player 17", 17),
    //new(18, "Player 18", 18),
    //new(19, "Player 19", 19),
    //new(20, "Player 20", 20),
    //new(21, "Player 21", 21),
    //new(22, "Player 22", 22),
    //new(23, "Player 23", 23),
    //new(24, "Player 24", 24),
    //new(25, "Player 25", 25),
    //new(26, "Player 26", 26),
    //new(27, "Player 27", 27),
    //new(28, "Player 28", 28),
    //new(29, "Player 29", 29),
    //new(30, "Player 30", 30),
    //new(31, "Player 31", 31),
    //new(32, "Player 32", 32),

    new(1, "Player 1", 1),
    new(2, "Player 2", 2),
    new(3, "Player 3", 3),
    new(4, "Player 4", 4),
    new(5, "Player 5", 5),
    new(6, "Player 6", 6),
    new(7, "Player 7", 7),
    new(8, "Player 8", 8),
    new(9, "Player 9", 9),
    new(10, "Player 10", 10),
    new(11, "Player 11", 11),
    new(12, "Player 12", 12),
    new(13, "Player 13", 13),
    new(14, "Player 14", 14),
    new(15, "Player 15", 15),
    new(16, "Player 16", 16),
    new(17, "Player 17", 17),
    //new(18, "Player 18", 18),
    //new(19, "Player 19", 19),
    //new(20, "Player 20", 20),
    //new(21, "Player 21", 21),
    //new(22, "Player 22", 22),
    //new(23, "Player 23", 23),
    //new(24, "Player 24", 24),
    //new(25, "Player 25", 25),
    //new(26, "Player 26", 26),
    //new(27, "Player 27", 27),
    //new(28, "Player 28", 28),
    //new(29, "Player 29", 29),
    //new(30, "Player 30", 30),
    //new(31, "Player 31", 31),
    //new(32, "Player 32", 32),
};

// Build bracket for any number of players.
var bracket = BracketBuilder.Build(players, tournamentTitle);

// Populate some dummy scores/results for demo.
BracketDemoData.PopulateSampleResults(bracket);

// Print text summary to console.
BracketConsolePrinter.Print(bracket);

// Generate printable HTML.
var html = BracketHtmlRenderer.Render(bracket);
var outputPath = Path.Combine(AppContext.BaseDirectory, outputHtmlFile);
File.WriteAllText(outputPath, html, Encoding.UTF8);

Console.WriteLine();
Console.WriteLine($"HTML generated: {outputPath}");
Console.WriteLine("Open it in a browser and print with Ctrl+P.");

var _bracket = BracketBuilder.Build(players, tournamentTitle);
BracketDemoData.PopulateSampleResults(_bracket);

BracketConsolePrinter.Print(_bracket);

//var _html = BracketHtmlRenderer.Render(_bracket);
//var outputHtmlPath = Path.Combine(AppContext.BaseDirectory, "bracket-last16.html");
//File.WriteAllText(outputHtmlPath, _html, Encoding.UTF8);

//var outputPdfPath = Path.Combine(AppContext.BaseDirectory, "bracket-last16.pdf");
//BracketPdfGenerator.Generate(_bracket, outputPdfPath);

//Console.WriteLine();
//Console.WriteLine($"HTML generated: {outputHtmlPath}");
//Console.WriteLine($"PDF generated: {outputPdfPath}");

var __bracket = BracketBuilder.Build(players, "Demo Tournament - V3");
BracketDemoData.PopulateSampleResults(bracket);

var __outputPdfPath = Path.Combine(AppContext.BaseDirectory, "bracket-v3.pdf");
BracketPdfGenerator.Generate(__bracket, __outputPdfPath);



public sealed record Player(int Id, string Name, int Seed, bool IsBye = false);

public class BracketPdfPage
{
    public int PageNumber { get; set; }
    public List<Round> Rounds { get; set; } = new();
}

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

    public int? NextMatchNumber { get; init; }

    public string DisplayTitle => $"Match {MatchNumber}";
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

public static class BracketBuilder
{
    public static Bracket Build(IReadOnlyList<Player> originalPlayers, string title)
    {
        if (originalPlayers.Count == 0)
            throw new InvalidOperationException("At least one player is required.");

        var bracketSize = GetNextPowerOfTwo(originalPlayers.Count);
        var roundsCount = (int)Math.Log2(bracketSize);

        var players = originalPlayers
            .OrderBy(p => p.Seed)
            .ToList();

        while (players.Count < bracketSize)
        {
            players.Add(new Player(
                Id: -players.Count - 1,
                Name: "BYE",
                Seed: players.Count + 1,
                IsBye: true));
        }

        // Standard top-vs-bottom style pairing based on seed order.
        var seededOrder = GenerateSeedOrder(bracketSize)
            .Select(seed => players.First(p => p.Seed == seed))
            .ToList();

        var rounds = new List<Round>();
        var matchNumber = 1;

        for (var roundNo = 1; roundNo <= roundsCount; roundNo++)
        {
            var matchesInRound = bracketSize / (int)Math.Pow(2, roundNo);
            var roundStartMatchNumber = matchNumber;

            var round = new Round
            {
                RoundNumber = roundNo,
                Title = GetRoundTitle(bracketSize, roundNo),
                Matches = []
            };

            for (var i = 0; i < matchesInRound; i++)
            {
                int? nextMatchNumber = roundNo < roundsCount
                    ? roundStartMatchNumber + matchesInRound + (i / 2)
                    : null;

                round.Matches.Add(new Match
                {
                    MatchNumber = matchNumber,
                    RoundNumber = roundNo,
                    PositionIndex = i + 1,
                    NextMatchNumber = nextMatchNumber
                });

                matchNumber++;
            }

            rounds.Add(round);
        }

        // Fill round 1 from seeded slots.
        var firstRound = rounds[0];
        for (var i = 0; i < firstRound.Matches.Count; i++)
        {
            firstRound.Matches[i].Player1 = seededOrder[i * 2];
            firstRound.Matches[i].Player2 = seededOrder[i * 2 + 1];
        }

        // Auto-advance players from BYE matches.
        AdvanceByes(rounds);

        return new Bracket
        {
            Title = title,
            RequestedPlayerCount = originalPlayers.Count,
            BracketSize = bracketSize,
            Rounds = rounds
        };
    }

    private static void AdvanceByes(List<Round> rounds)
    {
        foreach (var round in rounds)
        {
            foreach (var match in round.Matches)
            {
                if (match.Player1 is null && match.Player2 is null)
                    continue;

                if (match.Player1?.IsBye == true && match.Player2?.IsBye == true)
                    continue;

                if (match.Player1?.IsBye == true && match.Player2 is not null)
                {
                    match.Winner = match.Player2;
                    AdvanceWinner(rounds, match);
                }
                else if (match.Player2?.IsBye == true && match.Player1 is not null)
                {
                    match.Winner = match.Player1;
                    AdvanceWinner(rounds, match);
                }
            }
        }
    }

    public static void SetResult(Bracket bracket, int roundNumber, int positionIndex, int score1, int score2)
    {
        var round = bracket.Rounds.Single(r => r.RoundNumber == roundNumber);
        var match = round.Matches.Single(m => m.PositionIndex == positionIndex);

        if (match.Player1 is null || match.Player2 is null)
            throw new InvalidOperationException("Cannot score a match without both players assigned.");

        if (score1 == score2)
            throw new InvalidOperationException("Ties are not supported in this single-elimination demo.");

        match.Score1 = score1;
        match.Score2 = score2;
        match.Winner = score1 > score2 ? match.Player1 : match.Player2;

        AdvanceWinner(bracket.Rounds, match);
    }

    private static void AdvanceWinner(List<Round> rounds, Match match)
    {
        if (match.Winner is null || match.NextMatchNumber is null)
            return;

        var nextMatch = rounds
            .SelectMany(r => r.Matches)
            .Single(m => m.MatchNumber == match.NextMatchNumber.Value);

        var sourceIsTop = match.PositionIndex % 2 == 1;

        if (sourceIsTop)
            nextMatch.Player1 = match.Winner;
        else
            nextMatch.Player2 = match.Winner;
    }

    private static int GetNextPowerOfTwo(int value)
    {
        var power = 1;
        while (power < value)
            power *= 2;
        return power;
    }

    // Example for 16 seeds: 1,16,8,9,5,12,4,13,3,14,6,11,7,10,2,15
    private static List<int> GenerateSeedOrder(int size)
    {
        if (size < 2 || (size & (size - 1)) != 0)
            throw new ArgumentException("Size must be a power of two.");

        var positions = new List<int> { 1, 2 };

        while (positions.Count < size)
        {
            var nextSize = positions.Count * 2 + 1;
            var next = new List<int>();

            foreach (var seed in positions)
            {
                next.Add(seed);
                next.Add(nextSize - seed);
            }

            positions = next;
        }

        return positions;
    }

    private static string GetRoundTitle(int bracketSize, int roundNumber)
    {
        var playersInRound = bracketSize / (int)Math.Pow(2, roundNumber - 1);

        return playersInRound switch
        {
            2 => "Final",
            4 => "Semi Final",
            8 => "Quarter Final",
            16 => "Last 16",
            32 => "Last 32",
            64 => "Last 64",
            128 => "Last 128",
            _ => $"Round {roundNumber}"
        };
    }
}

public static class BracketDemoData
{
    public static void PopulateSampleResults(Bracket bracket)
    {
        var firstRound = bracket.Rounds.FirstOrDefault(r => r.RoundNumber == 1);
        if (firstRound is not null)
        {
            foreach (var match in firstRound.Matches)
            {
                if (match.Player1 is null || match.Player2 is null)
                    continue;

                if (match.Player1.IsBye || match.Player2.IsBye)
                    continue;

                var player1Wins = match.PositionIndex % 2 == 1;
                BracketBuilder.SetResult(
                    bracket,
                    roundNumber: 1,
                    positionIndex: match.PositionIndex,
                    score1: player1Wins ? 4 : 2,
                    score2: player1Wins ? 1 : 4);
            }
        }

        var secondRound = bracket.Rounds.FirstOrDefault(r => r.RoundNumber == 2);
        if (secondRound is not null)
        {
            foreach (var match in secondRound.Matches)
            {
                if (match.Player1 is null || match.Player2 is null)
                    continue;

                var player1Wins = match.PositionIndex % 2 == 0;
                BracketBuilder.SetResult(
                    bracket,
                    roundNumber: 2,
                    positionIndex: match.PositionIndex,
                    score1: player1Wins ? 4 : 3,
                    score2: player1Wins ? 2 : 4);
            }
        }

        var semiFinal = bracket.Rounds.FirstOrDefault(r => r.Title == "Semi Final");
        if (semiFinal is not null)
        {
            foreach (var match in semiFinal.Matches)
            {
                if (match.Player1 is null || match.Player2 is null)
                    continue;

                BracketBuilder.SetResult(
                    bracket,
                    roundNumber: semiFinal.RoundNumber,
                    positionIndex: match.PositionIndex,
                    score1: 4,
                    score2: 3);
            }
        }

        var final = bracket.Rounds.FirstOrDefault(r => r.Title == "Final");
        if (final is not null)
        {
            var match = final.Matches.Single();
            if (match.Player1 is not null && match.Player2 is not null)
            {
                BracketBuilder.SetResult(
                    bracket,
                    roundNumber: final.RoundNumber,
                    positionIndex: 1,
                    score1: 5,
                    score2: 2);
            }
        }
    }
}

public static class BracketConsolePrinter
{
    public static void Print(Bracket bracket)
    {
        Console.WriteLine($"Tournament: {bracket.Title}");
        Console.WriteLine($"Players: {bracket.RequestedPlayerCount}");
        Console.WriteLine($"Bracket size: {bracket.BracketSize}");
        Console.WriteLine(new string('-', 70));

        foreach (var round in bracket.Rounds)
        {
            Console.WriteLine(round.Title);

            foreach (var match in round.Matches)
            {
                var p1 = match.Player1?.Name ?? "-";
                var p2 = match.Player2?.Name ?? "-";
                var s1 = match.Score1?.ToString() ?? "";
                var s2 = match.Score2?.ToString() ?? "";
                var winner = match.Winner?.Name ?? "-";

                Console.WriteLine(
                    $"  {match.DisplayTitle,-10} " +
                    $"{p1,-18} [{s1,2}]  vs  {p2,-18} [{s2,2}]  Winner: {winner}");
            }

            Console.WriteLine();
        }
    }
}

public static class BracketHtmlRenderer
{
    public static string Render(Bracket bracket)
    {
        const int rowHeight = 76;
        const int matchHeight = 56;
        const int columnWidth = 260;
        const int roundGap = 28;
        const int margin = 24;

        var roundsCount = bracket.Rounds.Count;
        var totalRows = bracket.BracketSize / 2;
        var contentHeight = totalRows * rowHeight + 120;
        var contentWidth = roundsCount * columnWidth + (roundsCount - 1) * roundGap + margin * 2;

        var sb = new StringBuilder();

        sb.AppendLine("""
<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="utf-8" />
<meta name="viewport" content="width=device-width, initial-scale=1" />
<title>Bracket Print</title>
<style>
    * { box-sizing: border-box; }
    body {
        margin: 0;
        font-family: Arial, Helvetica, sans-serif;
        background: #f2f2f2;
        color: #111;
    }
    .toolbar {
        padding: 12px 16px;
        background: #fff;
        border-bottom: 1px solid #ddd;
        position: sticky;
        top: 0;
        z-index: 10;
    }
    .toolbar button {
        padding: 10px 14px;
        font-size: 14px;
        cursor: pointer;
    }
    .page {
        width: max-content;
        min-width: 100%;
        padding: 20px;
    }
    .sheet {
        position: relative;
        background: #e9e9e9;
        border: 1px solid #cfcfcf;
        padding: 0;
    }
    .title {
        text-align: center;
        font-size: 26px;
        font-weight: bold;
        padding: 18px 16px 8px;
    }
    .subtitle {
        text-align: center;
        font-size: 14px;
        padding-bottom: 16px;
    }
    .round-header {
        position: absolute;
        top: 76px;
        height: 30px;
        line-height: 30px;
        background: #0a8a0a;
        color: #fff;
        text-align: center;
        font-weight: bold;
        border: 1px solid #066d06;
    }
    .match {
        position: absolute;
        background: #fff;
        border: 1px solid #666;
        width: 220px;
        height: 56px;
    }
    .player-row {
        display: flex;
        align-items: stretch;
        height: 27.5px;
        border-bottom: 1px solid #666;
    }
    .player-row:last-child {
        border-bottom: 0;
    }
    .seed {
        width: 28px;
        border-right: 1px solid #666;
        display: flex;
        align-items: center;
        justify-content: center;
        font-size: 12px;
        background: #fafafa;
    }
    .name {
        flex: 1;
        padding: 6px 8px;
        overflow: hidden;
        white-space: nowrap;
        text-overflow: ellipsis;
        font-size: 13px;
    }
    .score {
        width: 34px;
        border-left: 1px solid #666;
        display: flex;
        align-items: center;
        justify-content: center;
        font-weight: bold;
        background: #fafafa;
    }
    .winner .name {
        font-weight: bold;
    }
    .footer {
        position: absolute;
        left: 24px;
        bottom: 12px;
        font-style: italic;
        font-size: 13px;
        font-weight: bold;
    }
    @media print {
        .toolbar { display: none; }
        body { background: #fff; }
        .page { padding: 0; }
        .sheet { border: 0; }
    }
</style>
</head>
<body>
<div class="toolbar">
    <button onclick="window.print()">Print bracket</button>
</div>
<div class="page">
""");

        sb.AppendLine($"""<div class="sheet" style="width:{contentWidth}px;height:{contentHeight}px;">""");
        sb.AppendLine($"""<div class="title">{Escape(bracket.Title)}</div>""");
        sb.AppendLine($"""<div class="subtitle">Requested Players: {bracket.RequestedPlayerCount} | Bracket Size: {bracket.BracketSize}</div>""");

        for (var roundIndex = 0; roundIndex < bracket.Rounds.Count; roundIndex++)
        {
            var round = bracket.Rounds[roundIndex];
            var x = margin + roundIndex * (columnWidth + roundGap);
            var headerWidth = 220;

            sb.AppendLine($"""<div class="round-header" style="left:{x}px;width:{headerWidth}px;">{Escape(round.Title)}</div>""");

            var step = rowHeight * (int)Math.Pow(2, roundIndex + 1);
            var startY = 110 + (step - matchHeight) / 2 - (rowHeight / 2);

            foreach (var match in round.Matches)
            {
                var y = startY + (match.PositionIndex - 1) * step;
                sb.AppendLine(RenderMatch(match, x, y));
            }
        }

        sb.AppendLine("""<div class="footer">Knockout stages</div>""");
        sb.AppendLine("</div></div></body></html>");

        return sb.ToString();
    }

    private static string RenderMatch(Match match, int x, int y)
    {
        var p1 = match.Player1;
        var p2 = match.Player2;

        var p1Winner = match.Winner?.Id == p1?.Id;
        var p2Winner = match.Winner?.Id == p2?.Id;

        return $"""
<div class="match" style="left:{x}px;top:{y}px;">
    <div class="player-row {(p1Winner ? "winner" : "")}">
        <div class="seed">{(p1?.IsBye == true ? "" : p1?.Seed.ToString() ?? "")}</div>
        <div class="name">{Escape(p1?.Name ?? "-")}</div>
        <div class="score">{(match.Score1?.ToString() ?? "")}</div>
    </div>
    <div class="player-row {(p2Winner ? "winner" : "")}">
        <div class="seed">{(p2?.IsBye == true ? "" : p2?.Seed.ToString() ?? "")}</div>
        <div class="name">{Escape(p2?.Name ?? "-")}</div>
        <div class="score">{(match.Score2?.ToString() ?? "")}</div>
    </div>
</div>
""";
    }

    private static string Escape(string value) =>
        System.Net.WebUtility.HtmlEncode(value);
}
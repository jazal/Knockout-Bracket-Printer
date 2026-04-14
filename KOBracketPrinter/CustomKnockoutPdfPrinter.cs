using KOBracketPrinter.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace KOBracketPrinter;

public static class CustomKnockoutPdfPrinter
{
    private const float RoundColumnHeight = 500f;
    private const float MatchBoxHeight = 38f;
    private const float ColumnGap = 18f;
    private const float StartX = 10f;
    private const float StartY = 20f;
    private const float BaseRowStep = 52f;

    public static void Generate(Bracket bracket, string outputPath)
    {
        QuestPDF.Settings.License = LicenseType.Community;

        var pages = CustomKnockoutPageLayoutService.BuildPages(bracket);
        var totalPages = pages.Count;

        var document = Document.Create(container =>
        {
            foreach (var item in pages)
            {
                var pageData = item;

                container.Page(page =>
                {
                    page.Size(PageSizes.A4.Landscape());
                    page.Margin(20);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(10));

                    page.Header().Element(c => ComposeHeader(c, bracket, pageData, totalPages));
                    page.Content().Element(c => ComposePage(c, pageData));
                    page.Footer().Element(c => ComposeFooter(c));
                });
            }
        });

        document.GeneratePdf(outputPath);
    }

    private static void ComposeHeader(
    IContainer container,
    Bracket bracket,
    BracketPrintPage pageData,
    int totalPages)
    {
        container.Column(column =>
        {
            column.Item().AlignCenter().Text(bracket.Title).FontSize(16).Bold();
            column.Item().AlignCenter().Text($"Knockout stages {pageData.PageNumber}/{totalPages}");
            column.Item().PaddingTop(4);

            column.Item().Row(row =>
            {
                foreach (var columnData in pageData.Columns)
                {
                    row.RelativeItem()
                        .Background(Colors.Green.Darken2)
                        .Border(1)
                        .BorderColor(Colors.Green.Darken3)
                        .PaddingVertical(5)
                        .AlignCenter()
                        .Text(columnData.Title)
                        .FontColor(Colors.White)
                        .Bold();
                }
            });

            column.Item().PaddingBottom(4);
        });
    }

    private static void ComposePage(IContainer container, BracketPrintPage pageData)
    {
        const float contentTopOffset = 10f;

        container.PaddingTop(contentTopOffset).Row(row =>
        {
            for (int roundIndex = 0; roundIndex < pageData.Columns.Count; roundIndex++)
            {
                var columnData = pageData.Columns[roundIndex];

                row.RelativeItem().PaddingHorizontal(6).Column(column =>
                {
                    var positions = GetVerticalOffsets(roundIndex, columnData.Matches.Count);

                    for (int i = 0; i < columnData.Matches.Count; i++)
                    {
                        if (i == 0 && positions[i] > 0)
                            column.Item().PaddingTop(positions[i]);

                        if (i > 0)
                        {
                            var gap = positions[i] - positions[i - 1] - MatchBoxHeight;
                            if (gap > 0)
                                column.Item().Height(gap);
                        }

                        var match = columnData.Matches[i];
                        column.Item()
                            .Height(MatchBoxHeight)
                            .Element(c => ComposeMatchBox(c, match));
                    }
                });
            }
        });
    }

    private static List<float> GetVerticalOffsets(int roundIndex, int matchCount)
    {
        var offsets = new List<float>();

        float startOffset = roundIndex switch
        {
            0 => 0f,
            1 => BaseRowStep / 2f,
            2 => BaseRowStep * 1.5f,
            3 => BaseRowStep * 3.5f,
            _ => 0f
        };

        float step = BaseRowStep * (float)Math.Pow(2, roundIndex);

        for (int i = 0; i < matchCount; i++)
        {
            offsets.Add(startOffset + i * step);
        }

        return offsets;
    }

    private static void ComposeMatchBox(IContainer container, Match match)
    {
        container
            .Height(MatchBoxHeight)
            .Border(1)
            .BorderColor(Colors.Grey.Darken2)
            .Background(Colors.White)
            .Layers(layers =>
            {
                layers.PrimaryLayer().Column(column =>
                {
                    column.Item().Element(c => ComposePlayerRow(
                        c,
                        match.Player1,
                        match.Score1,
                        match.Winner?.Id == match.Player1?.Id));

                    column.Item().LineHorizontal(1).LineColor(Colors.Grey.Lighten1);

                    column.Item().Element(c => ComposePlayerRow(
                        c,
                        match.Player2,
                        match.Score2,
                        match.Winner?.Id == match.Player2?.Id));
                });

                // Absolute-style overlay: match number before seed
                layers.Layer()
                    .AlignLeft()
                    .AlignMiddle()
                    .PaddingLeft(2)
                    .Text(text =>
                    {
                        text.Span(match.MatchNumber.ToString())
                            .FontSize(6)
                            .FontColor(Colors.Grey.Darken1);
                    });
            });
    }

    private static void ComposePlayerRow(
    IContainer container,
    Player? player,
    int? score,
    bool isWinner)
    {
        container.Height(18).Row(row =>
        {
            row.ConstantItem(24)
                .PaddingLeft(10)
                .AlignCenter()
                .AlignMiddle()
                .Text(text =>
                {
                    if (player?.IsBye == true || player?.Seed is null || player.Seed == 0)
                        return;

                    text.Span(player.Seed.ToString())
                        .FontSize(8)
                        .FontColor(Colors.Grey.Darken3);
                });

            var nameCell = row.RelativeItem()
                .PaddingHorizontal(3)
                .AlignMiddle();

            var rawName = player?.Name ?? "-";
            var formatted = FormatPlayerNameForFixedRow(rawName);

            nameCell.Column(col =>
            {
                if (!string.IsNullOrWhiteSpace(formatted.Line1))
                {
                    col.Item().Height(formatted.Line2 is null ? 18 : 9)
                        .AlignMiddle()
                        .Text(text =>
                        {
                            var span = text.Span(formatted.Line1);
                            span.FontSize(formatted.FontSize);

                            if (isWinner)
                                span.Bold();
                        });
                }

                if (!string.IsNullOrWhiteSpace(formatted.Line2))
                {
                    col.Item().Height(9)
                        .AlignMiddle()
                        .Text(text =>
                        {
                            var span = text.Span(formatted.Line2!);
                            span.FontSize(formatted.FontSize);

                            if (isWinner)
                                span.Bold();
                        });
                }
            });

            row.ConstantItem(24)
                .AlignCenter()
                .AlignMiddle()
                .Text(score?.ToString() ?? "");
        });
    }

    private static void ComposeFooter(IContainer container)
    {
        container.Row(row =>
        {
            row.RelativeItem().AlignLeft().Text("Knockout stages").Italic();
            row.RelativeItem().AlignCenter().Text(text =>
            {
                text.CurrentPageNumber();
                text.Span("/");
                text.TotalPages();
            });
            row.RelativeItem().AlignRight().Text($"Printed: {DateTime.Now:dd.MM.yyyy HH:mm}");
        });
    }

    private sealed class FixedNameLayout
    {
        public string Line1 { get; init; } = "-";
        public string? Line2 { get; init; }
        public float FontSize { get; init; }
    }

    private static FixedNameLayout FormatPlayerNameForFixedRow(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return new FixedNameLayout
            {
                Line1 = "-",
                Line2 = null,
                FontSize = 8
            };
        }

        value = value.Trim();

        // Use full width first before shrinking
        if (value.Length <= 22)
        {
            return new FixedNameLayout
            {
                Line1 = value,
                Line2 = null,
                FontSize = 8
            };
        }

        // Slightly smaller font, still keep one line if possible
        if (value.Length <= 30)
        {
            return new FixedNameLayout
            {
                Line1 = value,
                Line2 = null,
                FontSize = 7
            };
        }

        // For longer names, use 2 lines but allow more characters per line
        var parts = SplitIntoTwoLinesSmart(value, 35, 35);

        return new FixedNameLayout
        {
            Line1 = parts.line1,
            Line2 = parts.line2,
            FontSize = 6.5f
        };
    }

    private static (string line1, string? line2) SplitIntoTwoLinesSmart(string value, int max1, int max2)
    {
        value = NormalizeSpaces(value);

        if (value.Length <= max1)
            return (value, null);

        int break1 = FindBestBreak(value, max1);
        string line1 = value[..break1].Trim();
        string remaining = value[break1..].Trim();

        if (remaining.Length <= max2)
            return (line1, remaining);

        int break2 = FindBestBreak(remaining, max2);
        string line2 = remaining[..break2].Trim();

        if (break2 < remaining.Length)
        {
            if (line2.Length >= max2)
                line2 = line2[..Math.Max(0, max2 - 1)] + "…";
            else
                line2 += "…";
        }

        return (line1, line2);
    }

    private static int FindBestBreak(string value, int preferred)
    {
        if (value.Length <= preferred)
            return value.Length;

        // Prefer breaking at separators near the preferred width
        char[] separators = [' ', '-', '_'];

        for (int i = preferred; i >= Math.Max(1, preferred - 6); i--)
        {
            if (separators.Contains(value[i - 1]))
                return i;
        }

        for (int i = preferred; i <= Math.Min(value.Length - 1, preferred + 6); i++)
        {
            if (separators.Contains(value[i]))
                return i + 1;
        }

        return preferred;
    }

    private static string NormalizeSpaces(string value)
    {
        return string.Join(" ", value
            .Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries));
    }

    private static (string line1, string? line2) SplitIntoTwoLines(string value, int max1, int max2)
    {
        value = value.Trim();

        if (value.Length <= max1)
            return (value, null);

        var firstBreak = FindBreakPosition(value, max1);
        var line1 = value[..firstBreak].Trim();

        var remaining = value[firstBreak..].Trim();

        if (remaining.Length <= max2)
            return (line1, remaining);

        var secondBreak = FindBreakPosition(remaining, max2);
        var line2 = remaining[..secondBreak].Trim();

        // hard clamp second line so it never grows layout
        if (line2.Length > max2)
            line2 = line2[..max2];

        if (secondBreak < remaining.Length)
        {
            if (line2.Length >= max2)
                line2 = line2[..Math.Max(0, max2 - 1)] + "…";
            else
                line2 += "…";
        }

        return (line1, line2);
    }

    private static int FindBreakPosition(string value, int maxLength)
    {
        if (value.Length <= maxLength)
            return value.Length;

        var lastSpace = value.LastIndexOf(' ', maxLength);
        if (lastSpace > 0)
            return lastSpace;

        return maxLength;
    }
}
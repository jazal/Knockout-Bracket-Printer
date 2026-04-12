using KOBracketPrinter.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace KOBracketPrinter;

public static class CustomKnockoutPdfPrinter
{
    public static void Generate(Bracket bracket, string outputPath)
    {
        QuestPDF.Settings.License = LicenseType.Community;

        var pages = CustomKnockoutPageLayoutService.BuildPages(bracket);

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

                    page.Header().Element(c => ComposeHeader(c, bracket, pageData));
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
        BracketPrintPage pageData)
    {
        container.Column(column =>
        {
            column.Item().AlignCenter().Text(bracket.Title).FontSize(16).Bold();
            column.Item().AlignCenter().Text($"Knockout stages {pageData.PageNumber}/{pageData.PageNumber}");
            column.Item().PaddingTop(8);

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
        });
    }

    private static void ComposePage(IContainer container, BracketPrintPage pageData)
    {
        container.PaddingTop(10).Row(row =>
        {
            foreach (var columnData in pageData.Columns)
            {
                row.RelativeItem().PaddingHorizontal(6).Element(c =>
                {
                    ComposeRoundColumn(c, columnData);
                });
            }
        });
    }

    private static void ComposeRoundColumn(IContainer container, BracketPrintColumn columnData)
    {
        container.Column(column =>
        {
            foreach (var match in columnData.Matches)
            {
                column.Item().PaddingBottom(10).Element(c => ComposeMatchBox(c, match));
            }
        });
    }

    private static void ComposeMatchBox(IContainer container, Match match)
    {
        container.Border(1)
            .BorderColor(Colors.Grey.Darken2)
            .Background(Colors.White)
            .Column(column =>
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
    }

    private static void ComposePlayerRow(
    IContainer container,
    Player? player,
    int? score,
    bool isWinner)
    {
        container.Height(20).Row(row =>
        {
            row.ConstantItem(20)
                .AlignCenter()
                .AlignMiddle()
                .Text(player?.IsBye == true ? "" : player?.Seed.ToString() ?? "");

            var nameCell = row.RelativeItem()
                .BorderLeft(1)
                .BorderRight(1)
                .BorderColor(Colors.Grey.Darken2)
                .PaddingHorizontal(3)
                .AlignMiddle();

            var name = player?.Name ?? "-";

            if (isWinner)
                nameCell.Text(name).Bold();
            else
                nameCell.Text(name);

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
}
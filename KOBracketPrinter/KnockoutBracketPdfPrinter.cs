using KOBracketPrinter.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace KOBracketPrinter;

public static class KnockoutBracketPdfPrinter
{
    public static void Generate(Bracket bracket, string outputPath)
    {
        QuestPDF.Settings.License = LicenseType.Community;

        var pages = KnockoutBracketPaginationService.Paginate(bracket);

        var document = Document.Create(document =>
        {
            foreach (var item in pages)
            {
                var pageData = item;

                document.Page(page =>
                {
                    page.Size(PageSizes.A4.Landscape());
                    page.Margin(20);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(10));

                    page.Header().Element(c => ComposeHeader(c, bracket, pageData));
                    page.Content().Element(c => ComposePage(c, pageData));
                    page.Footer().AlignCenter().Text(text =>
                    {
                        text.Span("Page ");
                        text.CurrentPageNumber();
                        text.Span(" of ");
                        text.TotalPages();
                    });
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

            column.Item().AlignCenter().Text(
                $"Players: {bracket.RequestedPlayerCount} | Bracket Size: {bracket.BracketSize}");

            column.Item().AlignCenter().Text(text =>
            {
                text.Span("Page ");
                text.CurrentPageNumber();
                text.Span(" of ");
                text.TotalPages();
            });

            column.Item().PaddingTop(8);

            column.Item().Row(row =>
            {
                foreach (var columnData in pageData.Columns)
                {
                    row.RelativeItem()
                        .Background(QuestPDF.Helpers.Colors.Green.Darken2)
                        .Border(1)
                        .BorderColor(QuestPDF.Helpers.Colors.Green.Darken3)
                        .PaddingVertical(5)
                        .AlignCenter()
                        .Text(columnData.Title)
                        .FontColor(QuestPDF.Helpers.Colors.White)
                        .Bold();
                }
            });
        });
    }

    private static void ComposePage(IContainer container, BracketPrintPage pageData)
    {
        var round = pageData.Columns.Single();

        container.Column(column =>
        {
            column.Item()
                .Background(Colors.Green.Darken2)
                .PaddingVertical(6)
                .AlignCenter()
                .Text(round.Title)
                .FontColor(Colors.White)
                .Bold();

            column.Item().PaddingTop(10);

            foreach (var match in round.Matches)
            {
                column.Item().PaddingBottom(8).Element(c => ComposeMatchBox(c, match));
            }

            int emptyRows = KnockoutBracketPaginationService.MaxRowsPerColumn - round.Matches.Count;

            for (int i = 0; i < emptyRows; i++)
            {
                column.Item().PaddingBottom(8).Element(c => ComposeEmptyMatchBox(c));
            }
        });
    }

    private static void ComposeMatchBox(IContainer container, Match match)
    {
        container
            .Border(1)
            .BorderColor(Colors.Grey.Darken1)
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

    private static void ComposeEmptyMatchBox(IContainer container)
    {
        container
            .Border(1)
            .BorderColor(Colors.Grey.Lighten1)
            .Height(44);
    }

    private static void ComposePlayerRow(IContainer container, Player? player, int? score, bool isWinner)
    {
        container.MinHeight(22).Row(row =>
        {
            row.ConstantItem(30)
                .Background(Colors.Grey.Lighten4)
                .BorderRight(1)
                .BorderColor(Colors.Grey.Lighten1)
                .AlignCenter()
                .AlignMiddle()
                .Text(player?.IsBye == true ? "" : player?.Seed.ToString() ?? "");

            var nameCell = row.RelativeItem()
                .PaddingHorizontal(6)
                .AlignMiddle();

            var displayName = player?.Name ?? "-";

            if (isWinner)
                nameCell.Text(displayName).Bold();
            else
                nameCell.Text(displayName);

            row.ConstantItem(30)
                .Background(Colors.Grey.Lighten4)
                .BorderLeft(1)
                .BorderColor(Colors.Grey.Lighten1)
                .AlignCenter()
                .AlignMiddle()
                .Text(score?.ToString() ?? "");
        });
    }
}
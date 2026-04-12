using ConsoleApp1;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

//public static class BracketPdfGenerator
//{
//    // Previous code
//    //public static void Generate(Bracket bracket, string outputPath)
//    //{
//    //    QuestPDF.Settings.License = LicenseType.Community;

//    //    var document = Document.Create(container =>
//    //    {
//    //        container.Page(page =>
//    //        {
//    //            page.Size(PageSizes.A4.Landscape());
//    //            page.Margin(20);
//    //            page.PageColor(Colors.White);
//    //            page.DefaultTextStyle(x => x.FontSize(10));

//    //            page.Header().Element(c => ComposeHeader(c, bracket));
//    //            page.Content().Element(c => ComposeBracket(c, bracket));
//    //            page.Footer().AlignCenter().Text(text =>
//    //            {
//    //                text.Span("Page ");
//    //                text.CurrentPageNumber();
//    //                text.Span(" of ");
//    //                text.TotalPages();
//    //            });
//    //        });
//    //    });

//    //    document.GeneratePdf(outputPath);
//    //}

//    public static void Generate(Bracket bracket, string outputPath)
//    {
//        QuestPDF.Settings.License = LicenseType.Community;

//        var pages = BracketPaginationService.Paginate(bracket);

//        var document = Document.Create(container =>
//        {
//            foreach (var pageData in pages)
//            {
//                container.Page(page =>
//                {
//                    page.Size(PageSizes.A4.Landscape());
//                    page.Margin(20);

//                    page.Header().Text($"{bracket.Title} - Page {pageData.PageNumber}")
//                        .AlignCenter().Bold();

//                    page.Content().Element(c => ComposePage(c, pageData));

//                    page.Footer().AlignCenter().Text(text =>
//                    {
//                        text.Span("Page ");
//                        text.CurrentPageNumber();
//                    });
//                });
//            }
//        });

//        document.GeneratePdf(outputPath);
//    }

//    private static void ComposePage(IContainer container, BracketPdfPage page)
//    {
//        container.Row(row =>
//        {
//            foreach (var round in page.Rounds)
//            {
//                row.RelativeItem().Padding(5).Column(column =>
//                {
//                    column.Item()
//                        .Background(Colors.Green.Darken2)
//                        .Padding(5)
//                        .AlignCenter()
//                        .Text(round.Title)
//                        .FontColor(Colors.White)
//                        .Bold();

//                    column.Item().PaddingTop(5);

//                    foreach (var match in round.Matches)
//                    {
//                        column.Item().PaddingBottom(5).Element(c =>
//                        {
//                            ComposeMatchBox(c, match);
//                        });
//                    }
//                });
//            }
//        });
//    }

//    private static void ComposeHeader(IContainer container, Bracket bracket)
//    {
//        container.Column(column =>
//        {
//            column.Item().AlignCenter().Text(bracket.Title).FontSize(18).Bold();
//            column.Item().AlignCenter().Text(
//                $"Requested Players: {bracket.RequestedPlayerCount} | Bracket Size: {bracket.BracketSize}"
//            ).FontSize(10);
//            column.Item().PaddingTop(8);
//        });
//    }

//    private static void ComposeBracket(IContainer container, Bracket bracket)
//    {
//        container.Row(row =>
//        {
//            foreach (var round in bracket.Rounds.OrderBy(r => r.RoundNumber))
//            {
//                row.RelativeItem().PaddingHorizontal(6).Column(column =>
//                {
//                    column.Item()
//                        .Background(Colors.Green.Darken2)
//                        .PaddingVertical(6)
//                        .AlignCenter()
//                        .Text(round.Title)
//                        .FontColor(Colors.White)
//                        .Bold();

//                    column.Item().PaddingTop(8);

//                    foreach (var match in round.Matches.OrderBy(m => m.PositionIndex))
//                    {
//                        column.Item().PaddingBottom(GetMatchSpacing(round.RoundNumber)).Element(c =>
//                        {
//                            ComposeMatchBox(c, match);
//                        });
//                    }
//                });
//            }
//        });
//    }

//    private static void ComposeMatchBox(IContainer container, Match match)
//    {
//        container
//            .Border(1)
//            .BorderColor(Colors.Grey.Darken1)
//            .Background(Colors.White)
//            .Column(column =>
//            {
//                column.Item().Element(c => ComposePlayerRow(
//                    c,
//                    match.Player1,
//                    match.Score1,
//                    isWinner: match.Winner?.Id == match.Player1?.Id));

//                column.Item().LineHorizontal(1).LineColor(Colors.Grey.Lighten1);

//                column.Item().Element(c => ComposePlayerRow(
//                    c,
//                    match.Player2,
//                    match.Score2,
//                    isWinner: match.Winner?.Id == match.Player2?.Id));
//            });
//    }

//    private static void ComposePlayerRow(IContainer container, Player? player, int? score, bool isWinner)
//    {
//        container.MinHeight(22).Row(row =>
//        {
//            row.ConstantItem(24)
//                .Background(Colors.Grey.Lighten4)
//                .BorderRight(1)
//                .BorderColor(Colors.Grey.Lighten1)
//                .AlignCenter()
//                .AlignMiddle()
//                .Text(player?.IsBye == true ? "" : player?.Seed.ToString() ?? "");

//            row.RelativeItem()
//                .PaddingHorizontal(6)
//                .AlignMiddle()
//                .Text(player?.Name ?? "-")
//                .SemiBold();

//            row.ConstantItem(24)
//                .Background(Colors.Grey.Lighten4)
//                .BorderLeft(1)
//                .BorderColor(Colors.Grey.Lighten1)
//                .AlignCenter()
//                .AlignMiddle()
//                .Text(score?.ToString() ?? "");
//        });
//    }

//    private static float GetMatchSpacing(int roundNumber)
//    {
//        // Increase spacing each round so it visually resembles a bracket.
//        // Adjust these values if you want tighter or looser layout.
//        return roundNumber switch
//        {
//            1 => 8,
//            2 => 22,
//            3 => 50,
//            4 => 110,
//            5 => 220,
//            _ => 12
//        };
//    }
//}

public static class BracketPdfGenerator
{
    public static void Generate(Bracket bracket, string outputPath)
    {
        QuestPDF.Settings.License = LicenseType.Community;

        var pages = CustomBracketPaginationService.Paginate(bracket);

        var document = Document.Create(document =>
        {
            foreach (var item in pages)
            {
                var pdfPage = item;

                document.Page(page =>
                {
                    page.Size(PageSizes.A4.Landscape());
                    page.Margin(20);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(10));

                    page.Header().Element(c => ComposeHeader(c, bracket));
                    page.Content().Element(c => ComposePage(c, pdfPage));
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

    private static void ComposeHeader(IContainer container, Bracket bracket)
    {
        container.Column(column =>
        {
            column.Item().AlignCenter().Text(bracket.Title).FontSize(18).Bold();

            column.Item().AlignCenter().Text(text =>
            {
                text.Span($"Players: {bracket.RequestedPlayerCount} | Bracket Size: {bracket.BracketSize} | Page ");
                text.CurrentPageNumber();
                text.Span(" of ");
                text.TotalPages();
            });

            column.Item().PaddingTop(8);
        });
    }

    private static void ComposePage(IContainer container, ConsoleApp1.BracketPdfPage pdfPage)
    {
        container.Row(row =>
        {
            foreach (var round in pdfPage.Rounds)
            {
                row.RelativeItem().PaddingHorizontal(4).Column(column =>
                {
                    column.Item()
                        .Background(Colors.Green.Darken2)
                        .PaddingVertical(6)
                        .AlignCenter()
                        .Text(round.Title)
                        .FontColor(Colors.White)
                        .Bold();

                    column.Item().PaddingTop(8);

                    if (round.Matches.Count == 0)
                    {
                        column.Item().Height(24);
                    }
                    else
                    {
                        foreach (var match in round.Matches)
                        {
                            column.Item().PaddingBottom(6).Element(c =>
                            {
                                ComposeMatchBox(c, match);
                            });
                        }
                    }
                });
            }
        });
    }

    private static void ComposeMatchBox(IContainer container, Match match)
    {
        container
            .Height(42)
            .Border(1)
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

    private static void ComposePlayerRow(IContainer container, Player? player, int? score, bool isWinner)
    {
        container.MinHeight(22).Row(row =>
        {
            row.ConstantItem(24)
                .Background(Colors.Grey.Lighten4)
                .BorderRight(1)
                .BorderColor(Colors.Grey.Lighten1)
                .AlignCenter()
                .AlignMiddle()
                .Text(player?.IsBye == true ? "" : player?.Seed.ToString() ?? "");

            var nameText = player?.Name ?? "-";

            var nameCell = row.RelativeItem()
                .PaddingHorizontal(6)
                .AlignMiddle();

            if (isWinner)
                nameCell.Text(nameText).Bold();
            else
                nameCell.Text(nameText);

            row.ConstantItem(24)
                .Background(Colors.Grey.Lighten4)
                .BorderLeft(1)
                .BorderColor(Colors.Grey.Lighten1)
                .AlignCenter()
                .AlignMiddle()
                .Text(score?.ToString() ?? "");
        });
    }
}
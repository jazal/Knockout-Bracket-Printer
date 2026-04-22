using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace TeamWithPlayersPrinter;

public static class TeamSheetPdfGenerator
{
    public static byte[] Generate(TeamPlayersPrintRequestDto model, byte[]? logoBytes = null)
    {
        QuestPDF.Settings.License = LicenseType.Community;

        var document = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(24);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(10));

                page.Header().Element(c => ComposeHeader(c, model, logoBytes));
                page.Content().Element(c => ComposeContent(c, model));
                page.Footer().AlignCenter().Text(text =>
                {
                    text.CurrentPageNumber();
                    text.Span(" / ");
                    text.TotalPages();
                });
            });
        });

        using var stream = new MemoryStream();
        document.GeneratePdf(stream);
        return stream.ToArray();
    }

    private static void ComposeHeader(IContainer container, TeamPlayersPrintRequestDto model, byte[]? logoBytes)
    {
        container.Row(row =>
        {
            row.ConstantItem(70).Height(50).AlignLeft().AlignTop().Element(c =>
            {
                if (logoBytes is not null)
                {
                    c.Width(60)
                     .Height(45)
                     .Image(logoBytes)
                     .FitArea();
                }
            });

            row.RelativeItem().Column(column =>
            {
                column.Item().AlignCenter().Text(model.Title).FontSize(18).Bold();
                column.Item().AlignCenter().Text(model.Subtitle).FontSize(11).FontColor(Colors.Grey.Darken2);
            });
        });
    }

    private static void ComposeContent(IContainer container, TeamPlayersPrintRequestDto model)
    {
        container.PaddingTop(16).Column(column =>
        {
            column.Spacing(12);

            foreach (var team in model.Teams)
            {
                column.Item().Border(1).BorderColor(Colors.Grey.Lighten1).Padding(10).Column(teamCol =>
                {
                    teamCol.Item()
                        .Background(Colors.Green.Lighten4)
                        .Padding(6)
                        .Text(team.TeamName)
                        .Bold()
                        .FontSize(12);

                    teamCol.Item().PaddingTop(8).Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.ConstantColumn(25);
                            columns.RelativeColumn();
                        });

                        int index = 1;
                        foreach (var player in team.Players)
                        {
                            table.Cell().PaddingVertical(3).Text(index.ToString());
                            table.Cell().PaddingVertical(3).Text(player);
                            index++;
                        }
                    });
                });
            }
        });
    }
}

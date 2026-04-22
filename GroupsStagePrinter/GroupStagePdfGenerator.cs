using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace GroupsStagePrinter;

public class GroupStagePdfGenerator
{
    private readonly GroupStagePrintRequest _request;
    private readonly byte[]? _logoBytes;

    public GroupStagePdfGenerator(GroupStagePrintRequest request, byte[]? logoBytes = null)
    {
        _request = request;
        _logoBytes = logoBytes;
    }

    public byte[] Generate()
    {
        QuestPDF.Settings.License = LicenseType.Community;

        var document = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4.Landscape());
                page.Margin(20);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(10));

                page.Header().Element(ComposeHeader);
                page.Content().Element(ComposeContent);
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

    private void ComposeHeader(IContainer container)
    {
        container.Height(70).AlignMiddle().Row(row =>
        {
            row.ConstantItem(70)
                .AlignLeft()
                .AlignMiddle()
                .Element(c =>
                {
                    if (_logoBytes != null)
                    {
                        c.Width(60)
                         .Height(50)
                         .AlignCenter()
                         .AlignMiddle()
                         .Image(_logoBytes)
                         .FitArea();
                    }
                });

            row.RelativeItem()
                .AlignCenter()
                .AlignMiddle()
                .Column(column =>
                {
                    column.Item()
                        .AlignCenter()
                        .Text(_request.Title ?? string.Empty)
                        .FontSize(16)
                        .Bold();

                    if (!string.IsNullOrWhiteSpace(_request.Subtitle))
                    {
                        column.Item()
                            .PaddingTop(4)
                            .AlignCenter()
                            .Text(_request.Subtitle!)
                            .FontSize(11)
                            .FontColor(Colors.Grey.Darken2);
                    }
                });

            row.ConstantItem(70);
        });
    }

    private void ComposeContent(IContainer container)
    {
        var groupsPerRow = _request.GroupsPerRow == 3 ? 3 : 2;

        container.PaddingTop(10).Grid(grid =>
        {
            grid.Columns(groupsPerRow);
            grid.HorizontalSpacing(10);
            grid.VerticalSpacing(12);

            foreach (var group in _request.Groups)
            {
                grid.Item()
                    .ShowEntire()
                    .Element(c => ComposeGroupTable(c, group));
            }
        });
    }

    private void ComposeGroupTable(IContainer container, GroupStandingModel group)
    {
        var showPoints = _request.ShowPoints;

        container
            .ShowEntire()
            .Border(1)
            .BorderColor(Colors.Grey.Lighten1)
            .Padding(6)
            .Column(column =>
            {
                column.Item()
                    .Background(Colors.Green.Darken2)
                    .Padding(5)
                    .Text($"Group {group.GroupName}")
                    .FontColor(Colors.White)
                    .Bold()
                    .FontSize(11);

                column.Item().PaddingTop(6).Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.ConstantColumn(20);   // #
                        columns.RelativeColumn(2.3f); // Player
                        columns.RelativeColumn(1.2f); // Country

                        if (showPoints)
                            columns.RelativeColumn(1.8f); // Points

                        columns.ConstantColumn(22);   // MP
                        columns.ConstantColumn(22);   // MW
                        columns.ConstantColumn(22);   // FW
                        columns.ConstantColumn(22);   // FL
                        columns.ConstantColumn(26);   // Diff
                    });

                    static IContainer HeaderStyle(IContainer x) =>
                        x.BorderBottom(1)
                         .BorderColor(Colors.Grey.Lighten1)
                         .Background(Colors.Grey.Lighten3)
                         .PaddingVertical(3)
                         .PaddingHorizontal(2);

                    static IContainer CellStyle(IContainer x) =>
                        x.BorderBottom(1)
                         .BorderColor(Colors.Grey.Lighten3)
                         .PaddingVertical(3)
                         .PaddingHorizontal(2);

                    table.Header(header =>
                    {
                        header.Cell().Element(HeaderStyle).AlignCenter().Text("#").FontSize(8).Bold();
                        header.Cell().Element(HeaderStyle).Text("Player").FontSize(8).Bold();
                        header.Cell().Element(HeaderStyle).Text("Country").FontSize(8).Bold();

                        if (showPoints)
                            header.Cell().Element(HeaderStyle).AlignCenter().Text("Points").FontSize(8).Bold();

                        header.Cell().Element(HeaderStyle).AlignCenter().Text("MP").FontSize(8).Bold();
                        header.Cell().Element(HeaderStyle).AlignCenter().Text("MW").FontSize(8).Bold();
                        header.Cell().Element(HeaderStyle).AlignCenter().Text("FW").FontSize(8).Bold();
                        header.Cell().Element(HeaderStyle).AlignCenter().Text("FL").FontSize(8).Bold();
                        header.Cell().Element(HeaderStyle).AlignCenter().Text("Diff").FontSize(8).Bold();
                    });

                    for (int i = 0; i < group.Players.Count; i++)
                    {
                        var player = group.Players[i];

                        table.Cell().Element(CellStyle).AlignCenter().Text((i + 1).ToString()).FontSize(8);
                        table.Cell().Element(CellStyle).Text(player.PlayerName).FontSize(8);
                        table.Cell().Element(CellStyle).Text(player.Country).FontSize(8);

                        if (showPoints)
                        {
                            table.Cell().Element(CellStyle).Element(c => ComposePointsCell(c, player.Points));
                        }

                        table.Cell().Element(CellStyle).AlignCenter().Text(player.MatchesPlayed.ToString()).FontSize(8);
                        table.Cell().Element(CellStyle).AlignCenter().Text(player.MatchesWon.ToString()).FontSize(8);
                        table.Cell().Element(CellStyle).AlignCenter().Text(player.FramesWon.ToString()).FontSize(8);
                        table.Cell().Element(CellStyle).AlignCenter().Text(player.FramesLost.ToString()).FontSize(8);
                        table.Cell().Element(CellStyle).AlignCenter().Text(player.FrameDifference.ToString()).FontSize(8);
                    }
                });
            });
    }

    private void ComposePointsCell(IContainer container, int[]? points)
    {
        var values = points ?? [];

        container.Row(row =>
        {
            row.Spacing(2);

            foreach (var point in values)
            {
                row.ConstantItem(14).Height(14).Element(box =>
                {
                    var background = point == -1 ? Colors.Black : Colors.Yellow.Lighten2;
                    var textColor = point == -1 ? Colors.White : Colors.Black;
                    var displayText = point == -1 ? "" : point.ToString();

                    box.Background(background)
                       .Border(0)
                       .BorderColor(Colors.Grey.Lighten1)
                       .AlignCenter()
                       .AlignMiddle()
                       .Text(displayText)
                       .FontSize(7)
                       .FontColor(textColor)
                       .Bold();
                });
            }
        });
    }
}
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace RefereeSchedulePrinter;


public class RefereeSchedulePdfGenerator
{
    private readonly RefereeScheduleTableDto _request;
    private readonly byte[]? _logoBytes;

    public RefereeSchedulePdfGenerator(RefereeScheduleTableDto request, byte[]? logoBytes = null)
    {
        _request = request;
        _logoBytes = logoBytes;
    }

    public byte[] Generate()
    {
        QuestPDF.Settings.License = LicenseType.Community;

        var groupedColumns = _request.Columns
            .OrderBy(c => c.Date)
            .ThenBy(c => c.TimeFrom)
            .GroupBy(c => c.Date)
            .ToList();

        var document = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4.Landscape());
                page.Margin(12);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(7));

                page.Header().Element(ComposeHeader);

                page.Content().PaddingTop(5).Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.ConstantColumn(22);  // #
                        columns.ConstantColumn(105); // Referee

                        foreach (var _ in groupedColumns.SelectMany(g => g))
                            columns.RelativeColumn();
                    });

                    table.Header(header =>
                    {
                        header.Cell().RowSpan(2).Element(HeaderCell).AlignCenter().AlignMiddle().Text("#").Bold();

                        header.Cell().RowSpan(2).Element(HeaderCell).AlignCenter().AlignMiddle().Text("Referee").Bold();

                        foreach (var group in groupedColumns)
                        {
                            header.Cell()
                                .ColumnSpan((uint)group.Count())
                                .Element(HeaderCell)
                                .AlignCenter()
                                .Text(group.Key.ToString("dd MMM yyyy"))
                                .Bold();
                        }

                        foreach (var group in groupedColumns)
                        {
                            foreach (var col in group)
                            {
                                header.Cell()
                                    .Element(HeaderCell)
                                    .AlignCenter()
                                    .Text(col.TimeFrom.ToString("hh:mm tt"));
                            }
                        }
                    });

                    for (int i = 0; i < _request.Rows.Count; i++)
                    {
                        var rowData = _request.Rows[i];
                        var background = i % 2 == 0 ? Colors.White : Colors.Grey.Lighten4;

                        table.Cell().Element(c => BodyCell(c, background)).AlignCenter().Text((i + 1).ToString());
                        table.Cell().Element(c => BodyCell(c, background)).Text(rowData.RefereeName).Bold();

                        foreach (var group in groupedColumns)
                        {
                            foreach (var column in group)
                            {
                                var cell = rowData.Cells.FirstOrDefault(x =>
                                    x.Date == column.Date &&
                                    x.TimeFrom == column.TimeFrom);

                                table.Cell()
                                    .Element(c => BodyCell(c, background))
                                    .AlignCenter()
                                    .AlignMiddle()
                                    .Text(RemoveTableWord(cell?.Table));
                            }
                        }
                    }
                });

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
        container.Height(65).AlignMiddle().Row(row =>
        {
            row.ConstantItem(60)
                .AlignLeft()
                .AlignMiddle()
                .Element(c =>
                {
                    if (_logoBytes != null)
                    {
                        c.Width(55)
                         .Height(45)
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
                        .Text(_request.Title ?? "Referee Schedule")
                        .FontSize(15)
                        .Bold();

                    if (!string.IsNullOrWhiteSpace(_request.Subtitle))
                    {
                        column.Item()
                            .PaddingTop(3)
                            .AlignCenter()
                            .Text(_request.Subtitle!)
                            .FontSize(10)
                            .FontColor(Colors.Grey.Darken2);
                    }
                });

            row.ConstantItem(60);
        });
    }

    private static IContainer HeaderCell(IContainer container) =>
    container.Border(1)
        .BorderColor(Colors.Grey.Darken1)
        .Background(Colors.Grey.Lighten3)
        .PaddingVertical(3)
        .PaddingHorizontal(2)
        .AlignMiddle();

    private static IContainer BodyCell(IContainer container, string background) =>
        container.Border(1)
            .BorderColor(Colors.Grey.Lighten2)
            .Background(background)
            .PaddingVertical(2)
            .PaddingHorizontal(2)
            .MinHeight(20)
            .AlignMiddle();

    private static string RemoveTableWord(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return "";

        return value
            .Replace("Table", "", StringComparison.OrdinalIgnoreCase)
            .Trim();
    }
}

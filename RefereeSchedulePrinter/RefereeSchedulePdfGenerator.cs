using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace RefereeSchedulePrinter;


public class RefereeSchedulePdfGenerator
{
    private readonly RefereeScheduleTableDto _request;

    public RefereeSchedulePdfGenerator(RefereeScheduleTableDto request)
    {
        _request = request;
    }

    public byte[] Generate()
    {
        QuestPDF.Settings.License = LicenseType.Community;

        var document = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4.Landscape());
                page.Margin(15);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(8));

                page.Header().AlignCenter().Text("Referee Schedule").FontSize(16).Bold();
                page.Content().PaddingTop(10).Element(ComposeTable);

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

    private void ComposeTable(IContainer container)
    {
        container.Table(table =>
        {
            table.ColumnsDefinition(columns =>
            {
                columns.ConstantColumn(120); // Referee column

                foreach (var _ in _request.Columns)
                    columns.RelativeColumn();
            });

            table.Header(header =>
            {
                header.Cell().Element(HeaderCell).Text("Referee").Bold();

                foreach (var column in _request.Columns)
                {
                    header.Cell().Element(HeaderCell).AlignCenter().Column(c =>
                    {
                        c.Item().Text(column.Date.ToString("dd MMM")).Bold();
                        c.Item().Text(column.TimeFrom.ToString("HH:mm")).FontSize(7);
                    });
                }
            });

            foreach (var row in _request.Rows)
            {
                table.Cell().Element(BodyCell).Text(row.RefereeName).Bold();

                foreach (var column in _request.Columns)
                {
                    var cell = row.Cells.FirstOrDefault(x =>
                        x.Date == column.Date &&
                        x.TimeFrom == column.TimeFrom);

                    table.Cell()
                        .Element(BodyCell)
                        .AlignCenter()
                        .AlignMiddle()
                        .Text(cell?.Table ?? "");
                }
            }
        });
    }

    private static IContainer HeaderCell(IContainer container)
    {
        return container
            .Border(1)
            .BorderColor(Colors.Grey.Darken1)
            .Background(Colors.Grey.Lighten3)
            .Padding(4)
            .AlignMiddle();
    }

    private static IContainer BodyCell(IContainer container)
    {
        return container
            .Border(1)
            .BorderColor(Colors.Grey.Lighten1)
            .Padding(4)
            .MinHeight(28)
            .AlignMiddle();
    }
}

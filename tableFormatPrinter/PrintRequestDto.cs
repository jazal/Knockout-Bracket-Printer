using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace TableFormatPrinter;

public class PrintRequestDto
{
    public string? Title { get; set; }
    public string? Subtitle { get; set; }
    public string? LogoUrl { get; set; }
    public List<OpponentDto> Opponents { get; set; } = new();
}

public class OpponentDto
{
    public string? Name { get; set; }
    public string? Country { get; set; }
}

public interface ITableFormatPdfService
{
    Task<byte[]> GenerateAsync(PrintRequestDto request, CancellationToken cancellationToken = default);
}

public class TableFormatPdfService : ITableFormatPdfService
{
    private readonly HttpClient _httpClient;

    public TableFormatPdfService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<byte[]> GenerateAsync(PrintRequestDto request, CancellationToken cancellationToken = default)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        byte[]? logoBytes = null;

        if (!string.IsNullOrWhiteSpace(request.LogoUrl))
        {
            try
            {
                logoBytes = await _httpClient.GetByteArrayAsync(request.LogoUrl, cancellationToken);
            }
            catch
            {
                // optional: log this, but continue generating PDF without logo
                logoBytes = null;
            }
        }

        QuestPDF.Settings.License = LicenseType.Community;

        var document = new OpponentsTableDocument(request, logoBytes);
        return document.GeneratePdf();
    }
}

public class OpponentsTableDocument : IDocument
{
    private readonly PrintRequestDto _request;
    private readonly byte[]? _logoBytes;

    public OpponentsTableDocument(PrintRequestDto request, byte[]? logoBytes)
    {
        _request = request;
        _logoBytes = logoBytes;
    }

    public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

    public void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.Size(PageSizes.A4);
            page.Margin(20);
            page.PageColor(Colors.White);
            page.DefaultTextStyle(x => x.FontSize(11));

            page.Header().Element(ComposeHeader);

            page.Content().PaddingTop(10).Element(ComposeContent);

            page.Footer()
                .AlignCenter()
                .Text(text =>
                {
                    text.Span("Page ");
                    text.CurrentPageNumber();
                    text.Span(" of ");
                    text.TotalPages();
                });
        });
    }

    private void ComposeHeader(IContainer container)
    {
        container.Row(row =>
        {
            row.ConstantItem(70).Height(60).AlignLeft().AlignMiddle().Element(c =>
            {
                if (_logoBytes != null)
                    c.Image(_logoBytes).FitArea();
                else
                    c.Border(1).BorderColor(Colors.Grey.Lighten2);
            });

            row.RelativeItem().AlignCenter().AlignMiddle().Column(column =>
            {
                column.Item().Text(_request.Title ?? string.Empty)
                    .FontSize(18)
                    .Bold()
                    .AlignCenter();

                if (!string.IsNullOrWhiteSpace(_request.Subtitle))
                {
                    column.Item().PaddingTop(4).Text(_request.Subtitle!)
                        .FontSize(11)
                        .FontColor(Colors.Grey.Darken2)
                        .AlignCenter();
                }
            });

            row.ConstantItem(70); // spacer to keep title visually centered
        });
    }

    private void ComposeContent(IContainer container)
    {
        container.Table(table =>
        {
            table.ColumnsDefinition(columns =>
            {
                columns.ConstantColumn(40);   // Sr #
                columns.RelativeColumn(3);    // Name
                columns.RelativeColumn(2);    // Country
            });

            table.Header(header =>
            {
                header.Cell().Element(HeaderCell).Text("#").Bold();
                header.Cell().Element(HeaderCell).Text("Name").Bold();
                header.Cell().Element(HeaderCell).Text("Country").Bold();
            });

            for (int i = 0; i < _request.Opponents.Count; i++)
            {
                var opponent = _request.Opponents[i];

                table.Cell().Element(BodyCell).Text((i + 1).ToString());
                table.Cell().Element(BodyCell).Text(opponent.Name ?? string.Empty);
                table.Cell().Element(BodyCell).Text(opponent.Country ?? string.Empty);
            }
        });
    }

    private static IContainer HeaderCell(IContainer container)
    {
        return container
            .Background(Colors.Grey.Lighten3)
            .Border(1)
            .BorderColor(Colors.Grey.Medium)
            .PaddingVertical(8)
            .PaddingHorizontal(6)
            .AlignMiddle();
    }

    private static IContainer BodyCell(IContainer container)
    {
        return container
            .Border(1)
            .BorderColor(Colors.Grey.Lighten1)
            .PaddingVertical(6)
            .PaddingHorizontal(6)
            .AlignMiddle();
    }
}
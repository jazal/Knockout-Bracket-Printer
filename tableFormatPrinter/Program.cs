using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Net;

QuestPDF.Settings.License = LicenseType.Community;

// 🔹 INPUT DATA
var request = new PrintRequestDto
{
    Title = "QBSF Championship",
    Subtitle = "Players List",
    LogoUrl = "https://www.questpdf.com/logo.webp",
    Opponents = new List<OpponentDto>
    {
        new() { Name = "Ali Khan", Country = "Pakistan" },
        new() { Name = "John Smith", Country = "England" },
        new() { Name = "Omar Hassan", Country = "Qatar" }
    }
};

// 🔹 DOWNLOAD LOGO
byte[]? logoBytes = null;

if (!string.IsNullOrWhiteSpace(request.LogoUrl))
{
    using var client = new WebClient();
    try
    {
        logoBytes = client.DownloadData(request.LogoUrl);
    }
    catch
    {
        logoBytes = null;
    }
}

// 🔹 GENERATE PDF
var filePath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

Document.Create(container =>
{
    container.Page(page =>
    {
        page.Size(PageSizes.A4);
        page.Margin(20);
        page.PageColor(Colors.White);

        // 🔹 HEADER
        page.Header().Row(row =>
        {
            row.ConstantItem(70).Height(60).AlignLeft().AlignMiddle().Element(c =>
            {
                if (logoBytes != null)
                    c.Image(logoBytes).FitArea();
            });

            row.RelativeItem().AlignCenter().AlignMiddle().Column(col =>
            {
                col.Item().Text(request.Title ?? "").FontSize(18).Bold().AlignCenter();
                col.Item().Text(request.Subtitle ?? "").FontSize(11).AlignCenter();
            });

            row.ConstantItem(70); // spacing
        });

        // 🔹 TABLE
        page.Content().PaddingTop(20).Table(table =>
        {
            table.ColumnsDefinition(columns =>
            {
                columns.ConstantColumn(40);
                columns.RelativeColumn(3);
                columns.RelativeColumn(2);
            });

            // Header
            table.Header(header =>
            {
                header.Cell().Element(CellHeader).Text("#").Bold();
                header.Cell().Element(CellHeader).Text("Name").Bold();
                header.Cell().Element(CellHeader).Text("Country").Bold();
            });

            // Rows
            for (int i = 0; i < request.Opponents.Count; i++)
            {
                var o = request.Opponents[i];

                table.Cell().Element(CellBody).Text((i + 1).ToString());
                table.Cell().Element(CellBody).Text(o.Name ?? "");
                table.Cell().Element(CellBody).Text(o.Country ?? "");
            }
        });

        // 🔹 FOOTER
        page.Footer().AlignCenter().Text(x =>
        {
            x.Span("Page ");
            x.CurrentPageNumber();
            x.Span(" / ");
            x.TotalPages();
        });
    });
})
.GeneratePdf(filePath);

Console.WriteLine($"PDF generated: {filePath}");


// 🔹 STYLES
static IContainer CellHeader(IContainer container) =>
    container
        .Background(Colors.Grey.Lighten3)
        .Border(1)
        .Padding(6);

static IContainer CellBody(IContainer container) =>
    container
        .Border(1)
        .Padding(6);


// 🔹 DTOs
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
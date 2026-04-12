public class BracketExportService
{
    private readonly IBracketPdfGenerator _pdfGenerator;

    public BracketExportService(IBracketPdfGenerator pdfGenerator)
    {
        _pdfGenerator = pdfGenerator;
    }

    public void ExportPdf(Bracket bracket, string outputPath)
    {
        _pdfGenerator.Generate(bracket, outputPath);
    }
}
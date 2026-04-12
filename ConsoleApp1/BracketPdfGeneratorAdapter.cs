public class BracketPdfGeneratorAdapter : IBracketPdfGenerator
{
    public void Generate(Bracket bracket, string outputPath)
    {
        BracketPdfGenerator.Generate(bracket, outputPath);
    }
}
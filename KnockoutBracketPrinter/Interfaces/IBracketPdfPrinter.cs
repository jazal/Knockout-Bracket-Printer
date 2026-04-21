using KnockoutBracketPrinter.Models;

namespace KnockoutBracketPrinter.Interfaces;

public interface IBracketPdfPrinter
{
    Task GenerateAsync(Bracket bracket, string outputPath);
}

using KnockoutBracketPrinter.Models;

namespace KnockoutBracketPrinter.Interfaces;

public interface IBracketPageLayoutService
{
    List<BracketPrintPage> BuildPages(Bracket bracket);
}
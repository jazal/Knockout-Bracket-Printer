namespace KnockoutBracketPrinter.Interfaces;

public interface IFlagImageCache
{
    Task<byte[]?> GetAsync(string? url);
}

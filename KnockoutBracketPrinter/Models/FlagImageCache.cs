namespace KnockoutBracketPrinter.Models;

public static class FlagImageCache
{
    private static readonly HttpClient _httpClient = new();
    private static readonly Dictionary<string, byte[]> _cache = new(StringComparer.OrdinalIgnoreCase);

    public static byte[]? Get(string? url)
    {
        if (string.IsNullOrWhiteSpace(url))
            return null;

        if (_cache.TryGetValue(url, out var cached))
            return cached;

        try
        {
            var bytes = _httpClient.GetByteArrayAsync(url).GetAwaiter().GetResult();
            _cache[url] = bytes;
            return bytes;
        }
        catch
        {
            return null;
        }
    }
}

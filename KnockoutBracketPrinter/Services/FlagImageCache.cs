using KnockoutBracketPrinter.Interfaces;

namespace KnockoutBracketPrinter.Services;

public class FlagImageCache : IFlagImageCache
{
    private readonly HttpClient _httpClient;
    private readonly Dictionary<string, byte[]> _cache = new(StringComparer.OrdinalIgnoreCase);

    public FlagImageCache(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<byte[]?> GetAsync(string? url)
    {
        if (string.IsNullOrWhiteSpace(url))
            return null;

        if (_cache.TryGetValue(url, out var cached))
            return cached;

        try
        {
            var bytes = await _httpClient.GetByteArrayAsync(url);
            _cache[url] = bytes;
            return bytes;
        }
        catch
        {
            return null;
        }
    }
}

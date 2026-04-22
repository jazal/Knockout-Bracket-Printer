namespace GroupsStagePrinter;

public static class ImageHelper
{
    public static async Task<byte[]?> DownloadImageAsync(string? url)
    {
        if (string.IsNullOrWhiteSpace(url))
            return null;

        using var httpClient = new HttpClient();

        try
        {
            return await httpClient.GetByteArrayAsync(url);
        }
        catch
        {
            return null;
        }
    }
}

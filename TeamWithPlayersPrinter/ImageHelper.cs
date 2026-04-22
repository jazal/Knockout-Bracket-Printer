namespace TeamWithPlayersPrinter;

public static class ImageHelper
{
    public static async Task<byte[]?> DownloadImageAsync(string? url)
    {
        if (string.IsNullOrWhiteSpace(url))
            return null;

        using var http = new HttpClient();
        try
        {
            return await http.GetByteArrayAsync(url);
        }
        catch
        {
            return null;
        }
    }
}

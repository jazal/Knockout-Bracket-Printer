namespace ConsoleApp1;

public static class CustomBracketPaginationService
{
    public static List<BracketPdfPage> Paginate(Bracket bracket)
    {
        return bracket.RequestedPlayerCount switch
        {
            4 => Build4(bracket),
            8 => Build8(bracket),
            16 => Build16(bracket),
            20 => Build20(bracket),
            32 => Build32(bracket),
            48 => Build48(bracket),
            _ => BuildDefault(bracket)
        };
    }

    private static List<BracketPdfPage> Build4(Bracket bracket)
    {
        return
        [
            CreatePage(bracket, 1,
                RoundSlice("Semi Final", 0, 2),
                RoundSlice("Final", 0, 1))
        ];
    }

    private static List<BracketPdfPage> Build8(Bracket bracket)
    {
        return
        [
            CreatePage(bracket, 1,
                RoundSlice("Quarter Final", 0, 4),
                RoundSlice("Semi Final", 0, 2),
                RoundSlice("Final", 0, 1))
        ];
    }

    private static List<BracketPdfPage> Build16(Bracket bracket)
    {
        return
        [
            CreatePage(bracket, 1,
                RoundSlice("Last 16", 0, 8),
                RoundSlice("Quarter Final", 0, 4),
                RoundSlice("Semi Final", 0, 2),
                RoundSlice("Final", 0, 1))
        ];
    }

    private static List<BracketPdfPage> Build20(Bracket bracket)
    {
        return
        [
            CreatePage(bracket, 1,
                RoundSlice("Last 24", 0, 8),
                RoundSlice("Last 16", 0, 8),
                RoundSlice("Quarter Final", 0, 4),
                RoundSlice("Semi Final", 0, 2),
                RoundSlice("Final", 0, 1))
        ];
    }

    private static List<BracketPdfPage> Build32(Bracket bracket)
    {
        return
        [
            CreatePage(bracket, 1,
                RoundSlice("Last 32", 0, 8),
                RoundSlice("Last 16", 0, 4),
                RoundSlice("Quarter Final", 0, 2)),

            CreatePage(bracket, 2,
                RoundSlice("Last 32", 8, 8),
                RoundSlice("Last 16", 4, 4),
                RoundSlice("Quarter Final", 2, 2)),

            CreatePage(bracket, 3,
                RoundSlice("Last 16", 0, 8),
                RoundSlice("Quarter Final", 0, 4),
                RoundSlice("Semi Final", 0, 2),
                RoundSlice("Final", 0, 1))
        ];
    }

    private static List<BracketPdfPage> Build48(Bracket bracket)
    {
        return
        [
            CreatePage(bracket, 1,
                RoundSlice("Last 48", 0, 8),
                RoundSlice("Last 32", 0, 4),
                RoundSlice("Last 16", 0, 2)),

            CreatePage(bracket, 2,
                RoundSlice("Last 48", 8, 8),
                RoundSlice("Last 32", 4, 4),
                RoundSlice("Last 16", 2, 2)),

            CreatePage(bracket, 3,
                RoundSlice("Last 16", 0, 8),
                RoundSlice("Quarter Final", 0, 4),
                RoundSlice("Semi Final", 0, 2),
                RoundSlice("Final", 0, 1))
        ];
    }

    private static List<BracketPdfPage> BuildDefault(Bracket bracket)
    {
        var pages = new List<BracketPdfPage>();
        var page = new BracketPdfPage { PageNumber = 1 };

        foreach (var round in bracket.Rounds.OrderBy(x => x.RoundNumber))
        {
            page.Rounds.Add(new BracketPdfPageRound
            {
                RoundNumber = round.RoundNumber,
                Title = round.Title,
                Matches = round.Matches.OrderBy(x => x.PositionIndex).Take(8).ToList()
            });
        }

        pages.Add(page);
        return pages;
    }

    private static BracketPdfPage CreatePage(
        Bracket bracket,
        int pageNumber,
        params RoundRequest[] requests)
    {
        var page = new BracketPdfPage
        {
            PageNumber = pageNumber
        };

        foreach (var request in requests)
        {
            var round = bracket.Rounds
                .FirstOrDefault(r => Normalize(r.Title) == Normalize(request.RoundTitle));

            if (round is null)
            {
                page.Rounds.Add(new BracketPdfPageRound
                {
                    Title = request.RoundTitle,
                    Matches = []
                });
                continue;
            }

            var matches = round.Matches
                .OrderBy(m => m.PositionIndex)
                .Skip(request.Skip)
                .Take(request.Take)
                .ToList();

            page.Rounds.Add(new BracketPdfPageRound
            {
                RoundNumber = round.RoundNumber,
                Title = round.Title,
                Matches = matches
            });
        }

        return page;
    }

    private static RoundRequest RoundSlice(string roundTitle, int skip, int take)
        => new(roundTitle, skip, take);

    private static string Normalize(string value)
        => value.Replace(" ", string.Empty).Trim().ToLowerInvariant();

    private sealed record RoundRequest(string RoundTitle, int Skip, int Take);
}
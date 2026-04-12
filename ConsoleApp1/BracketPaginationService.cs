public static class BracketPaginationService
{
    private const int MaxRoundsPerPage = 4;
    private const int MaxMatchesPerPage = 8;

    public static List<BracketPdfPage> Paginate(Bracket bracket)
    {
        var pages = new List<BracketPdfPage>();

        // Split rounds into chunks of 4
        var roundChunks = bracket.Rounds
            .Select((round, index) => new { round, index })
            .GroupBy(x => x.index / MaxRoundsPerPage)
            .Select(g => g.Select(x => x.round).ToList())
            .ToList();

        int pageNumber = 1;

        foreach (var roundChunk in roundChunks)
        {
            // Find max matches in this chunk (for vertical slicing)
            var maxMatches = roundChunk.Max(r => r.Matches.Count);

            for (int start = 0; start < maxMatches; start += MaxMatchesPerPage)
            {
                var page = new BracketPdfPage
                {
                    PageNumber = pageNumber++,
                    Rounds = new List<Round>()
                };

                foreach (var round in roundChunk)
                {
                    var slicedMatches = round.Matches
                        .Skip(start)
                        .Take(MaxMatchesPerPage)
                        .ToList();

                    page.Rounds.Add(new Round
                    {
                        RoundNumber = round.RoundNumber,
                        Title = round.Title,
                        Matches = slicedMatches
                    });
                }

                pages.Add(page);
            }
        }

        return pages;
    }
}
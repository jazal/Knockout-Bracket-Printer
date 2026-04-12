using KOBracketPrinter.Models;

namespace KOBracketPrinter;

public static class KnockoutBracketPaginationService
{
    public const int MaxRowsPerColumn = 8;
    public const int MinColumnsPerPage = 4;
    public const int PreferredColumnsPerPage = 5;

    public static List<BracketPrintPage> Paginate(Bracket bracket)
    {
        var allSlices = BuildRoundSlices(bracket);
        var pages = new List<BracketPrintPage>();

        if (allSlices.Count == 0)
            return pages;

        int pageNumber = 1;
        int index = 0;

        while (index < allSlices.Count)
        {
            int remaining = allSlices.Count - index;
            int take;

            if (remaining >= PreferredColumnsPerPage)
            {
                take = PreferredColumnsPerPage;
            }
            else if (remaining >= MinColumnsPerPage)
            {
                take = remaining;
            }
            else if (pages.Count > 0)
            {
                // Rebalance so last page does not end up with too few columns
                var previousPage = pages[^1];

                while (previousPage.Columns.Count > MinColumnsPerPage &&
                       remaining < MinColumnsPerPage)
                {
                    var moved = previousPage.Columns[^1];
                    previousPage.Columns.RemoveAt(previousPage.Columns.Count - 1);
                    allSlices.Insert(index, moved);
                    remaining++;
                }

                take = Math.Min(remaining, PreferredColumnsPerPage);
            }
            else
            {
                take = remaining;
            }

            var pageRounds = allSlices
                .Skip(index)
                .Take(take)
                .ToList();

            pages.Add(new BracketPrintPage
            {
                PageNumber = pageNumber++,
                Columns = pageRounds
            });

            index += take;
        }

        return pages;
    }

    private static List<BracketPrintColumn> BuildRoundSlices(Bracket bracket)
    {
        var result = new List<BracketPrintColumn>();

        foreach (var round in bracket.Rounds.OrderBy(r => r.RoundNumber))
        {
            var orderedMatches = round.Matches
                .OrderBy(m => m.PositionIndex)
                .ToList();

            int sliceIndex = 1;

            for (int i = 0; i < orderedMatches.Count; i += MaxRowsPerColumn)
            {
                var sliceMatches = orderedMatches
                    .Skip(i)
                    .Take(MaxRowsPerColumn)
                    .ToList();

                result.Add(new BracketPrintColumn
                {
                    Title = round.Title,
                    Matches = sliceMatches
                });
            }
        }

        return result;
    }
}
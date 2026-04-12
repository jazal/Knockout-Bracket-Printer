using KOBracketPrinter.Models;

namespace KOBracketPrinter;

public static class CustomKnockoutPageLayoutService
{
    public static List<BracketPrintPage> BuildPages(Bracket bracket)
    {
        return bracket.RequestedPlayerCount switch
        {
            4 => Build4(bracket),
            8 => Build8(bracket),
            16 => Build16(bracket),
            32 => Build32(bracket),
            _ => throw new NotSupportedException(
                $"Custom print structure is not defined for {bracket.RequestedPlayerCount} players.")
        };
    }

    private static List<BracketPrintPage> Build4(Bracket bracket)
    {
        return
        [
            new BracketPrintPage
            {
                PageNumber = 1,
                Columns =
                [
                    CreateColumn(bracket, "Semi Final", 0, 2),
                    CreateColumn(bracket, "Final", 0, 1)
                ]
            }
        ];
    }

    private static List<BracketPrintPage> Build8(Bracket bracket)
    {
        return
        [
            new BracketPrintPage
            {
                PageNumber = 1,
                Columns =
                [
                    CreateColumn(bracket, "Quarter Final", 0, 4),
                    CreateColumn(bracket, "Semi Final", 0, 2),
                    CreateColumn(bracket, "Final", 0, 1)
                ]
            }
        ];
    }

    private static List<BracketPrintPage> Build16(Bracket bracket)
    {
        return
        [
            new BracketPrintPage
            {
                PageNumber = 1,
                Columns =
                [
                    CreateColumn(bracket, "Last 16", 0, 8),
                    CreateColumn(bracket, "Quarter Final", 0, 4),
                    CreateColumn(bracket, "Semi Final", 0, 2),
                    CreateColumn(bracket, "Final", 0, 1)
                ]
            }
        ];
    }

    private static List<BracketPrintPage> Build32(Bracket bracket)
    {
        return
        [
            new BracketPrintPage
            {
                PageNumber = 1,
                Columns =
                [
                    CreateColumn(bracket, "Last 32", 0, 8),
                    CreateColumn(bracket, "Last 16", 0, 4),
                    CreateColumn(bracket, "Quarter Final", 0, 2)
                ]
            },

            new BracketPrintPage
            {
                PageNumber = 2,
                Columns =
                [
                    CreateColumn(bracket, "Last 32", 8, 8),
                    CreateColumn(bracket, "Last 16", 4, 4),
                    CreateColumn(bracket, "Quarter Final", 2, 2)
                ]
            },

            new BracketPrintPage
            {
                PageNumber = 3,
                Columns =
                [
                    CreateColumn(bracket, "Last 16", 0, 8),
                    CreateColumn(bracket, "Quarter Final", 0, 4),
                    CreateColumn(bracket, "Semi Final", 0, 2),
                    CreateColumn(bracket, "Final", 0, 1)
                ]
            }
        ];
    }

    private static BracketPrintColumn CreateColumn(
        Bracket bracket,
        string title,
        int skip,
        int take)
    {
        var round = bracket.Rounds.FirstOrDefault(r => Normalize(r.Title) == Normalize(title));

        if (round is null)
        {
            return new BracketPrintColumn
            {
                Title = title,
                Matches = []
            };
        }

        return new BracketPrintColumn
        {
            Title = round.Title,
            Matches = round.Matches
                .OrderBy(m => m.PositionIndex)
                .Skip(skip)
                .Take(take)
                .ToList()
        };
    }

    private static string Normalize(string value)
        => value.Replace(" ", string.Empty).Trim().ToLowerInvariant();
}
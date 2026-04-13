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
            64 => Build64(bracket),
            128 => Build128(bracket),
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

    private static List<BracketPrintPage> Build64(Bracket bracket)
    {
        return
        [
            new BracketPrintPage
        {
            PageNumber = 1,
            Columns =
            [
                CreateColumn(bracket, "Last 64", 0, 8),
                CreateColumn(bracket, "Last 32", 0, 4),
                CreateColumn(bracket, "Last 16", 0, 2)
            ]
        },

        new BracketPrintPage
        {
            PageNumber = 2,
            Columns =
            [
                CreateColumn(bracket, "Last 64", 8, 8),
                CreateColumn(bracket, "Last 32", 4, 4),
                CreateColumn(bracket, "Last 16", 2, 2)
            ]
        },

        new BracketPrintPage
        {
            PageNumber = 3,
            Columns =
            [
                CreateColumn(bracket, "Last 64", 16, 8),
                CreateColumn(bracket, "Last 32", 8, 4),
                CreateColumn(bracket, "Last 16", 4, 2)
            ]
        },

        new BracketPrintPage
        {
            PageNumber = 4,
            Columns =
            [
                CreateColumn(bracket, "Last 64", 24, 8),
                CreateColumn(bracket, "Last 32", 12, 4),
                CreateColumn(bracket, "Last 16", 6, 2)
            ]
        },

        new BracketPrintPage
        {
            PageNumber = 5,
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

    private static List<BracketPrintPage> Build128(Bracket bracket)
    {
        return
        [
            new BracketPrintPage
        {
            PageNumber = 1,
            Columns =
            [
                CreateColumn(bracket, "Last 128", 0, 8),
                CreateColumn(bracket, "Last 64", 0, 4),
                CreateColumn(bracket, "Last 32", 0, 2),
                CreateColumn(bracket, "Last 16", 0, 1)
            ]
        },

        new BracketPrintPage
        {
            PageNumber = 2,
            Columns =
            [
                CreateColumn(bracket, "Last 128", 8, 8),
                CreateColumn(bracket, "Last 64", 4, 4),
                CreateColumn(bracket, "Last 32", 2, 2),
                CreateColumn(bracket, "Last 16", 1, 1)
            ]
        },

        new BracketPrintPage
        {
            PageNumber = 3,
            Columns =
            [
                CreateColumn(bracket, "Last 128", 16, 8),
                CreateColumn(bracket, "Last 64", 8, 4),
                CreateColumn(bracket, "Last 32", 4, 2),
                CreateColumn(bracket, "Last 16", 2, 1)
            ]
        },

        new BracketPrintPage
        {
            PageNumber = 4,
            Columns =
            [
                CreateColumn(bracket, "Last 128", 24, 8),
                CreateColumn(bracket, "Last 64", 12, 4),
                CreateColumn(bracket, "Last 32", 6, 2),
                CreateColumn(bracket, "Last 16", 3, 1)
            ]
        },

        new BracketPrintPage
        {
            PageNumber = 5,
            Columns =
            [
                CreateColumn(bracket, "Last 128", 32, 8),
                CreateColumn(bracket, "Last 64", 16, 4),
                CreateColumn(bracket, "Last 32", 8, 2),
                CreateColumn(bracket, "Last 16", 4, 1)
            ]
        },

        new BracketPrintPage
        {
            PageNumber = 6,
            Columns =
            [
                CreateColumn(bracket, "Last 128", 40, 8),
                CreateColumn(bracket, "Last 64", 20, 4),
                CreateColumn(bracket, "Last 32", 10, 2),
                CreateColumn(bracket, "Last 16", 5, 1)
            ]
        },

        new BracketPrintPage
        {
            PageNumber = 7,
            Columns =
            [
                CreateColumn(bracket, "Last 128", 48, 8),
                CreateColumn(bracket, "Last 64", 24, 4),
                CreateColumn(bracket, "Last 32", 12, 2),
                CreateColumn(bracket, "Last 16", 6, 1)
            ]
        },

        new BracketPrintPage
        {
            PageNumber = 8,
            Columns =
            [
                CreateColumn(bracket, "Last 128", 56, 8),
                CreateColumn(bracket, "Last 64", 28, 4),
                CreateColumn(bracket, "Last 32", 14, 2),
                CreateColumn(bracket, "Last 16", 7, 1)
            ]
        },

        new BracketPrintPage
        {
            PageNumber = 9,
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
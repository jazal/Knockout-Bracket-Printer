using KnockoutBracketPrinter.Interfaces;
using KnockoutBracketPrinter.Models;

namespace KnockoutBracketPrinter.Services;

public class CustomKnockoutPageLayoutService : IBracketPageLayoutService
{
    public List<BracketPrintPage> BuildPages(Bracket bracket)
    {
        return bracket.RequestedPlayerCount switch
        {
            4 => Build4(bracket),
            8 => Build8(bracket),
            16 => Build16(bracket),
            32 => Build32(bracket),
            64 => Build64(bracket),
            128 => Build128(bracket),
            256 => Build256(bracket),
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
                    CreateColumn(bracket, 1, "Semi Final", 0, 2),
                    CreateColumn(bracket, 2,"Final", 0, 1)
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
                    CreateColumn(bracket, 1, "Quarter Final", 0, 4),
                    CreateColumn(bracket, 2, "Semi Final", 0, 2),
                    CreateColumn(bracket, 3, "Final", 0, 1)
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
                    CreateColumn(bracket, 1,  "Last 16", 0, 8),
                    CreateColumn(bracket, 2, "Quarter Final", 0, 4),
                    CreateColumn(bracket, 3, "Semi Final", 0, 2),
                    CreateColumn(bracket, 4, "Final", 0, 1)
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
                    CreateColumn(bracket, 1, "Last 32", 0, 8),
                    CreateColumn(bracket, 2, "Last 16", 0, 4),
                    CreateColumn(bracket, 3, "Quarter Final", 0, 2)
                ]
            },

            new BracketPrintPage
            {
                PageNumber = 2,
                Columns =
                [
                    CreateColumn(bracket, 1, "Last 32", 8, 8),
                    CreateColumn(bracket, 2, "Last 16", 4, 4),
                    CreateColumn(bracket, 3, "Quarter Final", 2, 2)
                ]
            },

            new BracketPrintPage
            {
                PageNumber = 3,
                Columns =
                [
                    CreateColumn(bracket, 2, "Last 16", 0, 8),
                    CreateColumn(bracket, 3, "Quarter Final", 0, 4),
                    CreateColumn(bracket, 4, "Semi Final", 0, 2),
                    CreateColumn(bracket, 5, "Final", 0, 1)
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
                CreateColumn(bracket, 1, "Last 64", 0, 8),
                CreateColumn(bracket, 2, "Last 32", 0, 4),
                CreateColumn(bracket, 3, "Last 16", 0, 2)
            ]
        },

        new BracketPrintPage
        {
            PageNumber = 2,
            Columns =
            [
                CreateColumn(bracket, 1, "Last 64", 8, 8),
                CreateColumn(bracket, 2, "Last 32", 4, 4),
                CreateColumn(bracket, 3, "Last 16", 2, 2)
            ]
        },

        new BracketPrintPage
        {
            PageNumber = 3,
            Columns =
            [
                CreateColumn(bracket, 1, "Last 64", 16, 8),
                CreateColumn(bracket, 2, "Last 32", 8, 4),
                CreateColumn(bracket, 3, "Last 16", 4, 2)
            ]
        },

        new BracketPrintPage
        {
            PageNumber = 4,
            Columns =
            [
                CreateColumn(bracket, 1, "Last 64", 24, 8),
                CreateColumn(bracket, 2, "Last 32", 12, 4),
                CreateColumn(bracket, 3, "Last 16", 6, 2)
            ]
        },

        new BracketPrintPage
        {
            PageNumber = 5,
            Columns =
            [
                CreateColumn(bracket, 3, "Last 16", 0, 8),
                CreateColumn(bracket, 4, "Quarter Final", 0, 4),
                CreateColumn(bracket, 5, "Semi Final", 0, 2),
                CreateColumn(bracket, 6, "Final", 0, 1)
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
                CreateColumn(bracket, 1, "Last 128", 0, 8),
                CreateColumn(bracket, 2, "Last 64", 0, 4),
                CreateColumn(bracket, 3, "Last 32", 0, 2),
                CreateColumn(bracket, 4, "Last 16", 0, 1)
            ]
        },

        new BracketPrintPage
        {
            PageNumber = 2,
            Columns =
            [
                CreateColumn(bracket, 1, "Last 128", 8, 8),
                CreateColumn(bracket, 2, "Last 64", 4, 4),
                CreateColumn(bracket, 3, "Last 32", 2, 2),
                CreateColumn(bracket, 4, "Last 16", 1, 1)
            ]
        },

        new BracketPrintPage
        {
            PageNumber = 3,
            Columns =
            [
                CreateColumn(bracket, 1,"Last 128", 16, 8),
                CreateColumn(bracket, 2,"Last 64", 8, 4),
                CreateColumn(bracket, 3,"Last 32", 4, 2),
                CreateColumn(bracket, 4,"Last 16", 2, 1)
            ]
        },

        new BracketPrintPage
        {
            PageNumber = 4,
            Columns =
            [
                CreateColumn(bracket, 1,"Last 128", 24, 8),
                CreateColumn(bracket, 2,"Last 64", 12, 4),
                CreateColumn(bracket, 3,"Last 32", 6, 2),
                CreateColumn(bracket, 4,"Last 16", 3, 1)
            ]
        },

        new BracketPrintPage
        {
            PageNumber = 5,
            Columns =
            [
                CreateColumn(bracket, 1,"Last 128", 32, 8),
                CreateColumn(bracket, 2,"Last 64", 16, 4),
                CreateColumn(bracket, 3,"Last 32", 8, 2),
                CreateColumn(bracket, 4,"Last 16", 4, 1)
            ]
        },

        new BracketPrintPage
        {
            PageNumber = 6,
            Columns =
            [
                CreateColumn(bracket, 1, "Last 128", 40, 8),
                CreateColumn(bracket, 2, "Last 64", 20, 4),
                CreateColumn(bracket, 3, "Last 32", 10, 2),
                CreateColumn(bracket, 4, "Last 16", 5, 1)
            ]
        },

        new BracketPrintPage
        {
            PageNumber = 7,
            Columns =
            [
                CreateColumn(bracket, 1,"Last 128", 48, 8),
                CreateColumn(bracket, 2,"Last 64", 24, 4),
                CreateColumn(bracket, 3,"Last 32", 12, 2),
                CreateColumn(bracket, 4,"Last 16", 6, 1)
            ]
        },

        new BracketPrintPage
        {
            PageNumber = 8,
            Columns =
            [
                CreateColumn(bracket, 1,"Last 128", 56, 8),
                CreateColumn(bracket, 2,"Last 64", 28, 4),
                CreateColumn(bracket, 3,"Last 32", 14, 2),
                CreateColumn(bracket, 4,"Last 16", 7, 1)
            ]
        },

        new BracketPrintPage
        {
            PageNumber = 9,
            Columns =
            [
                CreateColumn(bracket, 4,"Last 16", 0, 8),
                CreateColumn(bracket, 5,"Quarter Final", 0, 4),
                CreateColumn(bracket, 6,"Semi Final", 0, 2),
                CreateColumn(bracket, 7,"Final", 0, 1)
            ]
        }
        ];
    }

    private static List<BracketPrintPage> Build256(Bracket bracket)
    {
        return
        [
            new BracketPrintPage
        {
            PageNumber = 1,
            Columns =
            [
                CreateColumn(bracket, 1, "Last 256", 0, 8),
                CreateColumn(bracket, 2, "Last 128", 0, 4),
                CreateColumn(bracket, 3, "Last 64", 0, 2),
                CreateColumn(bracket, 4, "Last 32", 0, 1)
            ]
        },

        new BracketPrintPage
        {
            PageNumber = 2,
            Columns =
            [
                CreateColumn(bracket, 1, "Last 256", 8, 8),
                CreateColumn(bracket, 2, "Last 128", 4, 4),
                CreateColumn(bracket, 3, "Last 64", 2, 2),
                CreateColumn(bracket, 4, "Last 32", 1, 1)
            ]
        },

        new BracketPrintPage
        {
            PageNumber = 3,
            Columns =
            [
                CreateColumn(bracket, 1, "Last 256", 16, 8),
                CreateColumn(bracket, 2, "Last 128", 8, 4),
                CreateColumn(bracket, 3, "Last 64", 4, 2),
                CreateColumn(bracket, 4, "Last 32", 2, 1)
            ]
        },

        new BracketPrintPage
        {
            PageNumber = 4,
            Columns =
            [
                CreateColumn(bracket, 1, "Last 256", 24, 8),
                CreateColumn(bracket, 2, "Last 128", 12, 4),
                CreateColumn(bracket, 3, "Last 64", 6, 2),
                CreateColumn(bracket, 4, "Last 32", 3, 1)
            ]
        },

        new BracketPrintPage
        {
            PageNumber = 5,
            Columns =
            [
                CreateColumn(bracket, 1, "Last 256", 32, 8),
                CreateColumn(bracket, 2, "Last 128", 16, 4),
                CreateColumn(bracket, 3, "Last 64", 8, 2),
                CreateColumn(bracket, 4, "Last 32", 4, 1)
            ]
        },

        new BracketPrintPage
        {
            PageNumber = 6,
            Columns =
            [
                CreateColumn(bracket, 1, "Last 256", 40, 8),
                CreateColumn(bracket, 2, "Last 128", 20, 4),
                CreateColumn(bracket, 3, "Last 64", 10, 2),
                CreateColumn(bracket, 4, "Last 32", 5, 1)
            ]
        },

        new BracketPrintPage
        {
            PageNumber = 7,
            Columns =
            [
                CreateColumn(bracket, 1, "Last 256", 48, 8),
                CreateColumn(bracket, 2, "Last 128", 24, 4),
                CreateColumn(bracket, 3, "Last 64", 12, 2),
                CreateColumn(bracket, 4, "Last 32", 6, 1)
            ]
        },

        new BracketPrintPage
        {
            PageNumber = 8,
            Columns =
            [
                CreateColumn(bracket, 1, "Last 256", 56, 8),
                CreateColumn(bracket, 2, "Last 128", 28, 4),
                CreateColumn(bracket, 3, "Last 64", 14, 2),
                CreateColumn(bracket, 4, "Last 32", 7, 1)
            ]
        },

        new BracketPrintPage
        {
            PageNumber = 9,
            Columns =
            [
                CreateColumn(bracket, 1, "Last 256", 64, 8),
                CreateColumn(bracket, 2, "Last 128", 32, 4),
                CreateColumn(bracket, 3, "Last 64", 16, 2),
                CreateColumn(bracket, 4, "Last 32", 8, 1)
            ]
        },

        new BracketPrintPage
        {
            PageNumber = 10,
            Columns =
            [
                CreateColumn(bracket, 1, "Last 256", 72, 8),
                CreateColumn(bracket, 2, "Last 128", 36, 4),
                CreateColumn(bracket, 3, "Last 64", 18, 2),
                CreateColumn(bracket, 4, "Last 32", 9, 1)
            ]
        },

        new BracketPrintPage
        {
            PageNumber = 11,
            Columns =
            [
                CreateColumn(bracket, 1, "Last 256", 80, 8),
                CreateColumn(bracket, 2, "Last 128", 40, 4),
                CreateColumn(bracket, 3, "Last 64", 20, 2),
                CreateColumn(bracket, 4, "Last 32", 10, 1)
            ]
        },

        new BracketPrintPage
        {
            PageNumber = 12,
            Columns =
            [
                CreateColumn(bracket, 1, "Last 256", 88, 8),
                CreateColumn(bracket, 2, "Last 128", 44, 4),
                CreateColumn(bracket, 3, "Last 64", 22, 2),
                CreateColumn(bracket, 4, "Last 32", 11, 1)
            ]
        },

        new BracketPrintPage
        {
            PageNumber = 13,
            Columns =
            [
                CreateColumn(bracket, 1, "Last 256", 96, 8),
                CreateColumn(bracket, 2, "Last 128", 48, 4),
                CreateColumn(bracket, 3, "Last 64", 24, 2),
                CreateColumn(bracket, 4, "Last 32", 12, 1)
            ]
        },

        new BracketPrintPage
        {
            PageNumber = 14,
            Columns =
            [
                CreateColumn(bracket, 1, "Last 256", 104, 8),
                CreateColumn(bracket, 2, "Last 128", 52, 4),
                CreateColumn(bracket, 3, "Last 64", 26, 2),
                CreateColumn(bracket, 4, "Last 32", 13, 1)
            ]
        },

        new BracketPrintPage
        {
            PageNumber = 15,
            Columns =
            [
                CreateColumn(bracket, 1, "Last 256", 112, 8),
                CreateColumn(bracket, 2, "Last 128", 56, 4),
                CreateColumn(bracket, 3, "Last 64", 28, 2),
                CreateColumn(bracket, 4, "Last 32", 14, 1)
            ]
        },

        new BracketPrintPage
        {
            PageNumber = 16,
            Columns =
            [
                CreateColumn(bracket, 1, "Last 256", 120, 8),
                CreateColumn(bracket, 2, "Last 128", 60, 4),
                CreateColumn(bracket, 3, "Last 64", 30, 2),
                CreateColumn(bracket, 4, "Last 32", 15, 1)
            ]
        },

        new BracketPrintPage
        {
            PageNumber = 17,
            Columns =
            [
                CreateColumn(bracket, 5, "Last 16", 0, 8),
                CreateColumn(bracket, 6, "Quarter Final", 0, 4),
                CreateColumn(bracket, 7, "Semi Final", 0, 2),
                CreateColumn(bracket, 8, "Final", 0, 1)
            ]
        }
        ];
    }

    private static BracketPrintColumn CreateColumn(
    Bracket bracket,
    int roundNumber,
    string fallbackTitle,
    int skip,
    int take)
    {
        var round = bracket.Rounds
            .FirstOrDefault(r => r.RoundNumber == roundNumber);

        if (round is null)
        {
            round = bracket.Rounds
                .FirstOrDefault(r => Normalize(r.Title) == Normalize(fallbackTitle));
        }

        if (round is null)
        {
            return new BracketPrintColumn
            {
                RoundNumber = roundNumber,
                Title = fallbackTitle,
                Matches = []
            };
        }

        return new BracketPrintColumn
        {
            RoundNumber = round.RoundNumber,
            Title = string.IsNullOrWhiteSpace(round.Title) ? fallbackTitle : round.Title,
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

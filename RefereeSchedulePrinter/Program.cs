using RefereeSchedulePrinter;

var request = new RefereeScheduleTableDto
{
    Title = "Referee Schedule",
    Subtitle = "April 10-11, 2026",
    LogoUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTWBuB632p-BzikvlVaPUTEubUuieUuoFM2TQ&s",

    Columns = new List<RefereeScheduleColumnDto>
    {
        new() { Date = new DateOnly(2026, 4, 10), TimeFrom = new TimeOnly(10, 0) },
        new() { Date = new DateOnly(2026, 4, 10), TimeFrom = new TimeOnly(12, 0) },
        new() { Date = new DateOnly(2026, 4, 10), TimeFrom = new TimeOnly(14, 0) },
        new() { Date = new DateOnly(2026, 4, 11), TimeFrom = new TimeOnly(10, 0) },
        new() { Date = new DateOnly(2026, 4, 11), TimeFrom = new TimeOnly(12, 0) }
    },

    Rows = new List<RefereeScheduleRowDto>
    {
        new()
        {
            RefereeId = 1,
            RefereeName = "Ali Khan",
            Country = "Qatar",
            Cells = new List<RefereeScheduleCellDto>
            {
                new() { Date = new DateOnly(2026, 4, 10), TimeFrom = new TimeOnly(10, 0), Table = "Table 1" },
                new() { Date = new DateOnly(2026, 4, 10), TimeFrom = new TimeOnly(12, 0), Table = "Table 2" },
                new() { Date = new DateOnly(2026, 4, 11), TimeFrom = new TimeOnly(10, 0), Table = "Table 3" }
            }
        },

        new()
        {
            RefereeId = 2,
            RefereeName = "Ahmed Ali",
            Country = "Pakistan",
            Cells = new List<RefereeScheduleCellDto>
            {
                new() { Date = new DateOnly(2026, 4, 10), TimeFrom = new TimeOnly(14, 0), Table = "Table 1" },
                new() { Date = new DateOnly(2026, 4, 11), TimeFrom = new TimeOnly(12, 0), Table = "Table 2" }
            }
        },

        new()
        {
            RefereeId = 3,
            RefereeName = "John Smith",
            Country = "England",
            Cells = new List<RefereeScheduleCellDto>
            {
                new() { Date = new DateOnly(2026, 4, 10), TimeFrom = new TimeOnly(10, 0), Table = "Table 4" },
                new() { Date = new DateOnly(2026, 4, 10), TimeFrom = new TimeOnly(12, 0), Table = "Table 1" },
                new() { Date = new DateOnly(2026, 4, 11), TimeFrom = new TimeOnly(12, 0), Table = "Table 3" }
            }
        },

        new()
        {
            RefereeId = 4,
            RefereeName = "Omar Hassan",
            Country = "Qatar",
            Cells = new List<RefereeScheduleCellDto>
            {
                new() { Date = new DateOnly(2026, 4, 10), TimeFrom = new TimeOnly(14, 0), Table = "Table 3" },
                new() { Date = new DateOnly(2026, 4, 11), TimeFrom = new TimeOnly(10, 0), Table = "Table 2" }
            }
        },
        new()
        {
            RefereeId = 1,
            RefereeName = "Ali Khan",
            Country = "Qatar",
            Cells = new List<RefereeScheduleCellDto>
            {
                new() { Date = new DateOnly(2026, 4, 10), TimeFrom = new TimeOnly(10, 0), Table = "Table 1" },
                new() { Date = new DateOnly(2026, 4, 10), TimeFrom = new TimeOnly(12, 0), Table = "Table 2" },
                new() { Date = new DateOnly(2026, 4, 11), TimeFrom = new TimeOnly(10, 0), Table = "Table 3" }
            }
        },

        new()
        {
            RefereeId = 2,
            RefereeName = "Ahmed Ali",
            Country = "Pakistan",
            Cells = new List<RefereeScheduleCellDto>
            {
                new() { Date = new DateOnly(2026, 4, 10), TimeFrom = new TimeOnly(14, 0), Table = "Table 1" },
                new() { Date = new DateOnly(2026, 4, 11), TimeFrom = new TimeOnly(12, 0), Table = "Table 2" }
            }
        },

        new()
        {
            RefereeId = 3,
            RefereeName = "John Smith",
            Country = "England",
            Cells = new List<RefereeScheduleCellDto>
            {
                new() { Date = new DateOnly(2026, 4, 10), TimeFrom = new TimeOnly(10, 0), Table = "Table 4" },
                new() { Date = new DateOnly(2026, 4, 10), TimeFrom = new TimeOnly(12, 0), Table = "Table 1" },
                new() { Date = new DateOnly(2026, 4, 11), TimeFrom = new TimeOnly(12, 0), Table = "Table 3" }
            }
        },

        new()
        {
            RefereeId = 4,
            RefereeName = "Omar Hassan",
            Country = "Qatar",
            Cells = new List<RefereeScheduleCellDto>
            {
                new() { Date = new DateOnly(2026, 4, 10), TimeFrom = new TimeOnly(14, 0), Table = "Table 3" },
                new() { Date = new DateOnly(2026, 4, 11), TimeFrom = new TimeOnly(10, 0), Table = "Table 2" }
            }
        },
        new()
        {
            RefereeId = 1,
            RefereeName = "Ali Khan",
            Country = "Qatar",
            Cells = new List<RefereeScheduleCellDto>
            {
                new() { Date = new DateOnly(2026, 4, 10), TimeFrom = new TimeOnly(10, 0), Table = "Table 1" },
                new() { Date = new DateOnly(2026, 4, 10), TimeFrom = new TimeOnly(12, 0), Table = "Table 2" },
                new() { Date = new DateOnly(2026, 4, 11), TimeFrom = new TimeOnly(10, 0), Table = "Table 3" }
            }
        },

        new()
        {
            RefereeId = 2,
            RefereeName = "Ahmed Ali",
            Country = "Pakistan",
            Cells = new List<RefereeScheduleCellDto>
            {
                new() { Date = new DateOnly(2026, 4, 10), TimeFrom = new TimeOnly(14, 0), Table = "Table 1" },
                new() { Date = new DateOnly(2026, 4, 11), TimeFrom = new TimeOnly(12, 0), Table = "Table 2" }
            }
        },

        new()
        {
            RefereeId = 3,
            RefereeName = "John Smith",
            Country = "England",
            Cells = new List<RefereeScheduleCellDto>
            {
                new() { Date = new DateOnly(2026, 4, 10), TimeFrom = new TimeOnly(10, 0), Table = "Table 4" },
                new() { Date = new DateOnly(2026, 4, 10), TimeFrom = new TimeOnly(12, 0), Table = "Table 1" },
                new() { Date = new DateOnly(2026, 4, 11), TimeFrom = new TimeOnly(12, 0), Table = "Table 3" }
            }
        },

        new()
        {
            RefereeId = 4,
            RefereeName = "Omar Hassan",
            Country = "Qatar",
            Cells = new List<RefereeScheduleCellDto>
            {
                new() { Date = new DateOnly(2026, 4, 10), TimeFrom = new TimeOnly(14, 0), Table = "Table 3" },
                new() { Date = new DateOnly(2026, 4, 11), TimeFrom = new TimeOnly(10, 0), Table = "Table 2" }
            }
        },
        new()
        {
            RefereeId = 1,
            RefereeName = "Ali Khan",
            Country = "Qatar",
            Cells = new List<RefereeScheduleCellDto>
            {
                new() { Date = new DateOnly(2026, 4, 10), TimeFrom = new TimeOnly(10, 0), Table = "Table 1" },
                new() { Date = new DateOnly(2026, 4, 10), TimeFrom = new TimeOnly(12, 0), Table = "Table 2" },
                new() { Date = new DateOnly(2026, 4, 11), TimeFrom = new TimeOnly(10, 0), Table = "Table 3" }
            }
        },

        new()
        {
            RefereeId = 2,
            RefereeName = "Ahmed Ali",
            Country = "Pakistan",
            Cells = new List<RefereeScheduleCellDto>
            {
                new() { Date = new DateOnly(2026, 4, 10), TimeFrom = new TimeOnly(14, 0), Table = "Table 1" },
                new() { Date = new DateOnly(2026, 4, 11), TimeFrom = new TimeOnly(12, 0), Table = "Table 2" }
            }
        },

        new()
        {
            RefereeId = 3,
            RefereeName = "John Smith",
            Country = "England",
            Cells = new List<RefereeScheduleCellDto>
            {
                new() { Date = new DateOnly(2026, 4, 10), TimeFrom = new TimeOnly(10, 0), Table = "Table 4" },
                new() { Date = new DateOnly(2026, 4, 10), TimeFrom = new TimeOnly(12, 0), Table = "Table 1" },
                new() { Date = new DateOnly(2026, 4, 11), TimeFrom = new TimeOnly(12, 0), Table = "Table 3" }
            }
        },

        new()
        {
            RefereeId = 4,
            RefereeName = "Omar Hassan",
            Country = "Qatar",
            Cells = new List<RefereeScheduleCellDto>
            {
                new() { Date = new DateOnly(2026, 4, 10), TimeFrom = new TimeOnly(14, 0), Table = "Table 3" },
                new() { Date = new DateOnly(2026, 4, 11), TimeFrom = new TimeOnly(10, 0), Table = "Table 2" }
            }
        }
    }
};

var generator = new RefereeSchedulePdfGenerator(request);
var pdfBytes = generator.Generate();

File.WriteAllBytes("referee-schedule.pdf", pdfBytes);
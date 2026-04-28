namespace RefereeSchedulePrinter;

public class RefereeScheduleTableDto { public List<RefereeScheduleColumnDto> Columns { get; set; } = new(); public List<RefereeScheduleRowDto> Rows { get; set; } = new(); }
public class RefereeScheduleColumnDto { public DateOnly Date { get; set; } public TimeOnly TimeFrom { get; set; } }
public class RefereeScheduleRowDto { public int RefereeId { get; set; } public string RefereeName { get; set; } = ""; public string? RefereeImageName { get; set; } = ""; public string? Country { get; set; } = ""; public List<RefereeScheduleCellDto> Cells { get; set; } = new(); }
public class RefereeScheduleCellDto { public DateOnly Date { get; set; } public TimeOnly TimeFrom { get; set; } public string? Table { get; set; } }

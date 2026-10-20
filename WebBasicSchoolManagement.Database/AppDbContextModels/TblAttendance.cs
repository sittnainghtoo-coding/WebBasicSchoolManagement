using System;
using System.Collections.Generic;

namespace WebBasicSchoolManagement.Database.AppDbContextModels;

public partial class TblAttendance
{
    public int Id { get; set; }

    public DateOnly? Date { get; set; }

    public string? StdId { get; set; }

    public bool IsAttendance { get; set; }

    public string Type { get; set; } = null!;

    public string? Reason { get; set; }
}

using System;
using System.Collections.Generic;

namespace WebBasicSchoolManagement.Database.AppDbContextModels;

public partial class TblTeacher
{
    public int Id { get; set; }

    public string TecId { get; set; } = null!;

    public string? TecName { get; set; }

    public int? SubId { get; set; }
}

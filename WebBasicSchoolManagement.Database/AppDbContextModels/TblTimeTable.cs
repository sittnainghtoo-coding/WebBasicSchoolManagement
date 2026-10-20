using System;
using System.Collections.Generic;

namespace WebBasicSchoolManagement.Database.AppDbContextModels;

public partial class TblTimeTable
{
    public int Id { get; set; }

    public DateOnly? Date { get; set; }

    public string? Day { get; set; }

    public string? Period1 { get; set; }

    public string? Period2 { get; set; }

    public string? Period3 { get; set; }

    public string? Period4 { get; set; }

    public string? Period5 { get; set; }

    public string? Period6 { get; set; }
}

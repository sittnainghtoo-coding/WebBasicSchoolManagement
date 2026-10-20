using System;
using System.Collections.Generic;

namespace WebBasicSchoolManagement.Database.AppDbContextModels;

public partial class TblStudent
{
    public int Id { get; set; }

    public string StdId { get; set; } = null!;

    public string StdName { get; set; } = null!;

    public string? FatherName { get; set; }

    public int StdAge { get; set; }

    public DateOnly Dob { get; set; }

    public string Gender { get; set; } = null!;

    public DateOnly ResgisterDate { get; set; }
}

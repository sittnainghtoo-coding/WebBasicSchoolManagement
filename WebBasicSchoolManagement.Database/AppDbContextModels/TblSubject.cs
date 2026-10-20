using System;
using System.Collections.Generic;

namespace WebBasicSchoolManagement.Database.AppDbContextModels;

public partial class TblSubject
{
    public int Id { get; set; }

    public string SubName { get; set; } = null!;
}

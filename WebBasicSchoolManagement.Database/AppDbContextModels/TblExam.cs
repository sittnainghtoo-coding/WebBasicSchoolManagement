using System;
using System.Collections.Generic;

namespace WebBasicSchoolManagement.Database.AppDbContextModels;

public partial class TblExam
{
    public int Id { get; set; }

    public string ExamType { get; set; } = null!;

    public string Subject { get; set; } = null!;
}

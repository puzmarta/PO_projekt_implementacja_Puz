using System;
using System.Collections.Generic;

namespace PO_projekt_implementacja_Puz.Models;

public partial class RecruitmentCriterion
{
    public int Id { get; set; }

    public string? Content { get; set; }

    public int FieldOfStudyFk { get; set; }

    public virtual FieldOfStudy FieldOfStudyFkNavigation { get; set; } = null!;
}

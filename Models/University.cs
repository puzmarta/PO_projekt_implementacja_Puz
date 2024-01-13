using System;
using System.Collections.Generic;

namespace PO_projekt_implementacja_Puz.Models;

public partial class University
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public string? Rector { get; set; }

    public string? Description { get; set; }

    public string? RecruitmentPolicies { get; set; }

    public virtual ICollection<Faculty> Faculties { get; set; } = new List<Faculty>();

    public virtual ICollection<QuestionPool> QuestionPools { get; set; } = new List<QuestionPool>();
}

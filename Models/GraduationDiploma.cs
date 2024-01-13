using System;
using System.Collections.Generic;

namespace PO_projekt_implementacja_Puz.Models;

public partial class GraduationDiploma
{
    public int Id { get; set; }

    public string? GraduationField { get; set; }

    public int? Grade { get; set; }

    public double Gpa { get; set; }

    public int DocumentFk { get; set; }

    public virtual Document DocumentFkNavigation { get; set; } = null!;
}

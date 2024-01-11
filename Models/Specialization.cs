using System;
using System.Collections.Generic;

namespace PO_projekt_implementacja_Puz.Models;

public partial class Specialization
{
    public int Id { get; set; }

    public int AdmissionLimit { get; set; }

    public string? SpecializationName { get; set; }

    public int FieldOfStudyFk { get; set; }

    public virtual FieldOfStudy FieldOfStudyFkNavigation { get; set; } = null!;
}

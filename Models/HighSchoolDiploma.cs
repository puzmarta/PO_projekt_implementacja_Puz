using System;
using System.Collections.Generic;

namespace PO_projekt_implementacja_Puz.Models;

public partial class HighSchoolDiploma
{
    public int Id { get; set; }

    public DateOnly AcquisitionDate { get; set; }

    public string DiplomaNumber { get; set; } = null!;

    public double BiologyResult { get; set; }

    public double ForeignBasicResult { get; set; }

    public double ForeignAdvancedResult { get; set; }

    public double PolishBasicResult { get; set; }

    public double PolishAdvancedResult { get; set; }

    public double MathBasicResult { get; set; }

    public double MathAdvancedResult { get; set; }

    public double AdditionalSubjectResult { get; set; }

    public int DocumentFk { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    public virtual Document Document { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace PO_projekt_implementacja_Puz.Models;

public partial class DegreeLevel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<FieldOfStudy> FieldOfStudies { get; set; } = new List<FieldOfStudy>();
}

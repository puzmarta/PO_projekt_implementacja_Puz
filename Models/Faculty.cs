using System;
using System.Collections.Generic;

namespace PO_projekt_implementacja_Puz.Models;

public partial class Faculty
{
    public int Id { get; set; }

    public int UniversityFk { get; set; }

    public string FacultyName { get; set; } = null!;

    public string FacultyNumber { get; set; } = null!;

    public virtual ICollection<FieldOfStudy> FieldOfStudies { get; set; } = new List<FieldOfStudy>();

    public virtual University University { get; set; } = null!;
}

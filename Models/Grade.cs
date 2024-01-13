using System;
using System.Collections.Generic;

namespace PO_projekt_implementacja_Puz.Models;

public partial class Grade
{
    public int Id { get; set; }

    public double Value { get; set; }

    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();
}

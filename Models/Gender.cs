using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PO_projekt_implementacja_Puz.Models;

public partial class Gender
{
    public int Id { get; set; }

    [Display(Name = "Płeć")]
    public string Name { get; set; } = null!;

    public virtual ICollection<Candidate> Candidates { get; set; } = new List<Candidate>();
}

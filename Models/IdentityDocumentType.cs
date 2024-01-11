using System;
using System.Collections.Generic;

namespace PO_projekt_implementacja_Puz.Models;

public partial class IdentityDocumentType
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Candidate> Candidates { get; set; } = new List<Candidate>();
}

using System;
using System.Collections.Generic;

namespace PO_projekt_implementacja_Puz.Models;

public partial class RankingList
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Candidate> CandidateFks { get; set; } = new List<Candidate>();
}

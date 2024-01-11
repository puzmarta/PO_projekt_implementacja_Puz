using System;
using System.Collections.Generic;

namespace PO_projekt_implementacja_Puz.Models;

public partial class RankingList
{
    public int Id { get; set; }

    public int? Title { get; set; }

    public virtual ICollection<Candidate> CandidateFks { get; set; } = new List<Candidate>();
}

using System;
using System.Collections.Generic;

namespace PO_projekt_implementacja_Puz.Models;

public partial class OlympiadSubject
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<OlympiadWinnerDiploma> OlympiadWinnerDiplomas { get; set; } = new List<OlympiadWinnerDiploma>();
}

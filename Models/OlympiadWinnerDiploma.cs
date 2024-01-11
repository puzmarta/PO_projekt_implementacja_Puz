using System;
using System.Collections.Generic;

namespace PO_projekt_implementacja_Puz.Models;

public partial class OlympiadWinnerDiploma
{
    public int Id { get; set; }

    public DateOnly? ExpiryDate { get; set; }

    public DateOnly? AcquisitionDate { get; set; }

    public int DocumentFk { get; set; }

    public int OlympiadSubjectFk { get; set; }

    public virtual Document DocumentFkNavigation { get; set; } = null!;

    public virtual OlympiadSubject OlympiadSubjectFkNavigation { get; set; } = null!;
}

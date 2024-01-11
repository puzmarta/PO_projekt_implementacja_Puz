using System;
using System.Collections.Generic;

namespace PO_projekt_implementacja_Puz.Models;

public partial class TalentStudyCompletionCertificate
{
    public int Id { get; set; }

    public DateOnly? AcquisitionDate { get; set; }

    public int DocumentFk { get; set; }

    public int StudySubjectFk { get; set; }

    public virtual Document DocumentFkNavigation { get; set; } = null!;

    public virtual StudySubject StudySubjectFkNavigation { get; set; } = null!;
}

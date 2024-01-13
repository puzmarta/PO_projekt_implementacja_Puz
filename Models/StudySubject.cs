using System;
using System.Collections.Generic;

namespace PO_projekt_implementacja_Puz.Models;

public partial class StudySubject
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<TalentStudyCompletionCertificate> TalentStudyCompletionCertificates { get; set; } = new List<TalentStudyCompletionCertificate>();
}

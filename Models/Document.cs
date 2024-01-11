using System;
using System.Collections.Generic;

namespace PO_projekt_implementacja_Puz.Models;

public partial class Document
{
    public int Id { get; set; }

    public DateOnly? CreationDate { get; set; }

    public int ApplicationFk { get; set; }

    public string Name { get; set; } = null!;

    public virtual Application ApplicationFkNavigation { get; set; } = null!;

    public virtual ICollection<GraduationDiploma> GraduationDiplomas { get; set; } = new List<GraduationDiploma>();

    public virtual ICollection<HighSchoolDiploma> HighSchoolDiplomas { get; set; } = new List<HighSchoolDiploma>();

    public virtual ICollection<OlympiadWinnerDiploma> OlympiadWinnerDiplomas { get; set; } = new List<OlympiadWinnerDiploma>();

    public virtual ICollection<TalentStudyCompletionCertificate> TalentStudyCompletionCertificates { get; set; } = new List<TalentStudyCompletionCertificate>();
}

using System;
using System.Collections.Generic;

namespace PO_projekt_implementacja_Puz.Models;

public partial class Application
{
    public int Id { get; set; }

    public string? ApplicationIdentifier { get; set; }

    public double RecruitmentIndex { get; set; }

    public int CandidateFk { get; set; }

    public int RecruitmentFk { get; set; }

    public int ApplicationStatusFk { get; set; }

    public int? HighSchoolTranscriptFk { get; set; }

    public virtual ApplicationStatus ApplicationStatusFkNavigation { get; set; } = null!;

    public virtual Candidate CandidateFkNavigation { get; set; } = null!;

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual HighSchoolDiploma? HighSchoolTranscriptFkNavigation { get; set; }

    public virtual Recruitment RecruitmentFkNavigation { get; set; } = null!;
}

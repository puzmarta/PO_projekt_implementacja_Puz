using System;
using System.Collections.Generic;

namespace PO_projekt_implementacja_Puz.Models;

public partial class Application
{
    public int Id { get; set; }

    public string ApplicationIdentifier { get; set; } = null!;

    public double RecruitmentIndex { get; set; }

    public int CandidateFk { get; set; }

    public int RecruitmentFk { get; set; }

    public int ApplicationStatusFk { get; set; }

    public int? HighSchoolDiplomaFk { get; set; }

    public int DocumentFk { get; set; }

    public virtual ApplicationStatus ApplicationStatus { get; set; } = null!;

    public virtual Candidate Candidate { get; set; } = null!;

    public virtual Document Document { get; set; } = null!;

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual HighSchoolDiploma? HighSchoolDiploma { get; set; }

    public virtual Recruitment Recruitment{ get; set; } = null!;
}

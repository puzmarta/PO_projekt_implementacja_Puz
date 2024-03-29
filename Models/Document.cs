﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PO_projekt_implementacja_Puz.Models;

public partial class Document
{
    public int Id { get; set; }

    [Display(Name = "Data złożenia")]
    public DateOnly? CreationDate { get; set; }

    public int? ApplicationFk { get; set; }

    public string Name { get; set; } = null!;

    public virtual Application? ApplicationFkNavigation { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

    public virtual ICollection<GraduationDiploma> GraduationDiplomas { get; set; } = new List<GraduationDiploma>();

    public virtual ICollection<HighSchoolDiploma> HighSchoolDiplomas { get; set; } = new List<HighSchoolDiploma>();

    public virtual ICollection<OlympiadWinnerDiploma> OlympiadWinnerDiplomas { get; set; } = new List<OlympiadWinnerDiploma>();

    public virtual ICollection<TalentStudyCompletionCertificate> TalentStudyCompletionCertificates { get; set; } = new List<TalentStudyCompletionCertificate>();
}

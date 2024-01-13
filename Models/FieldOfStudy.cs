using System;
using System.Collections.Generic;

namespace PO_projekt_implementacja_Puz.Models;

public partial class FieldOfStudy
{
    public int Id { get; set; }

    public string FieldName { get; set; } = null!;

    public string FieldAbbreviation { get; set; } = null!;

    public string? FieldDescription { get; set; }

    public int AdmissionLimit { get; set; }

    public string? StudyProgram { get; set; }

    public string? StudyPlan { get; set; }

    public string? CourseCards { get; set; }

    public int FacultyFk { get; set; }

    public int StudyFormFk { get; set; }

    public int DegreeLevelFk { get; set; }

    public int AcademicTitleFk { get; set; }

    public virtual AcademicTitle AcademicTitleFkNavigation { get; set; } = null!;

    public virtual ICollection<AnswerMapping> AnswerMappings { get; set; } = new List<AnswerMapping>();

    public virtual DegreeLevel DegreeLevelFkNavigation { get; set; } = null!;

    public virtual Faculty FacultyFkNavigation { get; set; } = null!;

    public virtual ICollection<RecruitmentCriterion> RecruitmentCriteria { get; set; } = new List<RecruitmentCriterion>();

    public virtual ICollection<Recruitment> Recruitments { get; set; } = new List<Recruitment>();

    public virtual ICollection<Specialization> Specializations { get; set; } = new List<Specialization>();

    public virtual StudyForm StudyFormFkNavigation { get; set; } = null!;
}

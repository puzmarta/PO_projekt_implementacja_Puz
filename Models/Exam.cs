using System;
using System.Collections.Generic;

namespace PO_projekt_implementacja_Puz.Models;

public partial class Exam
{
    public int Id { get; set; }

    public DateOnly? Date { get; set; }

    public int GradeFk { get; set; }

    public virtual ICollection<DrawingAdmissionExam> DrawingAdmissionExams { get; set; } = new List<DrawingAdmissionExam>();

    public virtual Grade GradeFkNavigation { get; set; } = null!;

    public virtual ICollection<SecondDegreeAdmissionExam> SecondDegreeAdmissionExams { get; set; } = new List<SecondDegreeAdmissionExam>();
}

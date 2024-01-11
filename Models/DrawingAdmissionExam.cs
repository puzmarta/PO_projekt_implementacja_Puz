using System;
using System.Collections.Generic;

namespace PO_projekt_implementacja_Puz.Models;

public partial class DrawingAdmissionExam
{
    public int Id { get; set; }

    public int ExamFk { get; set; }

    public virtual Exam ExamFkNavigation { get; set; } = null!;
}

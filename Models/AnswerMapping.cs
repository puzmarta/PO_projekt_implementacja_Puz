using System;
using System.Collections.Generic;

namespace PO_projekt_implementacja_Puz.Models;

public partial class AnswerMapping
{
    public int QuestionFk { get; set; }

    public string Answer { get; set; } = null!;

    public int FieldOfStudyFk { get; set; }

    public int Points { get; set; }

    public virtual FieldOfStudy FieldOfStudyFkNavigation { get; set; } = null!;

    public virtual Question QuestionFkNavigation { get; set; } = null!;
}

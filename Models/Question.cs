using System;
using System.Collections.Generic;

namespace PO_projekt_implementacja_Puz.Models;

public partial class Question
{
    public int Id { get; set; }

    public string? AnswerD { get; set; }

    public string? AnswerA { get; set; }

    public string? AnswerB { get; set; }

    public string? AnswerC { get; set; }

    public string? QuestionContent { get; set; }

    public int QuestionPoolFk { get; set; }

    public virtual QuestionPool QuestionPoolFkNavigation { get; set; } = null!;
}

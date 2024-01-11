using System;
using System.Collections.Generic;

namespace PO_projekt_implementacja_Puz.Models;

public partial class QuestionPool
{
    public int Id { get; set; }

    public int UniversityFk { get; set; }

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    public virtual University UniversityFkNavigation { get; set; } = null!;
}

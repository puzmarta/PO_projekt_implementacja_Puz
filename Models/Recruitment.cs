using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PO_projekt_implementacja_Puz.Models;

public partial class Recruitment
{
    public int Id { get; set; }

    public int FieldOfStudyFk { get; set; }

    [Display(Name = "Tura")]
    public int RoundNumber { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? ApplicationSubmissionDeadline { get; set; }

    public DateOnly? FeePaymentDeadline { get; set; }

    public DateOnly? DocumentSubmissionDeadline { get; set; }

    public DateOnly? EndDate { get; set; }

    public int PointThreshold { get; set; }

    public int? PreviousRoundFk { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    public virtual FieldOfStudy FieldOfStudy { get; set; } = null!;

    public virtual ICollection<Recruitment> InversePreviousRoundFkNavigation { get; set; } = new List<Recruitment>();

    public virtual Recruitment? PreviousRound { get; set; }
}
